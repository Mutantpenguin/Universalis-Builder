using LibGit2Sharp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class UniverseSelectionForm : Form
    {
        private static readonly string UniversesSubFolder = "Universes";

        private static readonly string UniversesPath = Path.Combine( UniversalisSettings.UserAppFolder, UniversesSubFolder );

        private static readonly string universeImageFilename = "logo.jpg";

        private static readonly ColorMatrix s_colorMatrixRepoBehind = ColorHelper.ColorToColorMatrix( Color.SeaGreen );
        private static readonly ColorMatrix s_colorMatrixRepoAhead = ColorHelper.ColorToColorMatrix( Color.Orange );
        private static readonly ColorMatrix s_colorMatrixRepoError = ColorHelper.ColorToColorMatrix( Color.Red );

        private static readonly Image repoBehindOverlayImage = ImageHelper.Colorize( Properties.Resources.baseline_new_releases_black_48dp, s_colorMatrixRepoBehind );
        private static readonly Image repoModifiedOverlayImage = ImageHelper.Colorize( Properties.Resources.baseline_warning_black_48dp, s_colorMatrixRepoAhead );
        private static readonly Image repoErrorOverlayImage = ImageHelper.Colorize( Properties.Resources.baseline_error_black_48dp, s_colorMatrixRepoError );

        private static readonly Image invalidUniverseOverlayImage = ImageHelper.Colorize( Properties.Resources.baseline_do_not_disturb_on_black_48dp, s_colorMatrixRepoError );

        public UniverseSelectionForm()
        {
            if( !Directory.Exists( UniversesPath ) )
            {
                Directory.CreateDirectory( UniversesPath );
            }

            File.SetAttributes( UniversesPath, FileAttributes.Hidden );

            InitializeComponent();

            this.CenterToParent();

            if( Options.DeityMode )
            {
                panelDeityMode.Visible = true;

                string deityModeString = " - GOTTHEIT MODUS";

                this.Text += deityModeString;
                labelHeader.Text += deityModeString;
            }

            this.Text += " - v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString( 2 );

            listViewUniverses.Font = new Font( UniversalisFont.Family, 10 );
            labelNoUniverses.Font = new Font( UniversalisFont.Family, 20 );

            tableLayoutPanelCentered.Left = ( panelNoUniverses.Width - tableLayoutPanelCentered.Width ) / 2;
            tableLayoutPanelCentered.Top = ( panelNoUniverses.Height - tableLayoutPanelCentered.Height ) / 2;

            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            this.Icon = Properties.Resources.icon;
        }

        private class UniverseListViewItem : ListViewItem
        {
            public string RepoURL
            {
                get;
                set;
            }

            public enum ERepoState
            {
                READY,
                BEHIND,
                MODIFIED,
                ERROR,
                NONE
            }

            public ERepoState RepoState
            {
                get;
                set;
            } = ERepoState.NONE;

            public string RepoError
            {
                get;
                set;
            }

            public Universe Universe
            {
                get;
                set;
            }

            public bool ValidUniverse
            {
                get;
                set;
            } = true;
        }

        private void RefreshUniverses()
        {
            panelMain.Visible = false;
            panelControl.Enabled = false;
            panelWorking.Visible = true;
            panelNoUniverses.Visible = false;

            imageListUniverses.Images.Clear();
            listViewUniverses.Clear();

            var backgroundWorkerRefresh = new BackgroundWorker();

            backgroundWorkerRefresh.DoWork += BackgroundWorkerRefresh_DoWork;

            backgroundWorkerRefresh.RunWorkerAsync();
        }

        private void BackgroundWorkerRefresh_DoWork( object sender, DoWorkEventArgs e )
        {
            string[] universeSubfolders = Directory.GetDirectories( UniversesPath );

            if( universeSubfolders.Count() > 0 )
            {
                foreach( string universePath in universeSubfolders )
                {
                    var lvi = new UniverseListViewItem()
                    {
                        ImageKey = universePath
                    };

                    {
                        var (universe, error) = Universe.Load( universePath );

                        if( universe != null )
                        {
                            lvi.Text = Options.DeityMode ? universe.NameWithVersionAndHash() : universe.NameWithVersion();
                            lvi.ToolTipText = universe.Description;

                            lvi.Universe = universe;
                        }
                        else
                        {
                            lvi.Text = "Defektes Universum";
                            lvi.ValidUniverse = false;
                            lvi.ToolTipText = error;
                        }
                    }

                    Image universeLogo = null;
                    bool universeModified = false;
                    string universeCommitHash = String.Empty;

                    var universeImagePath = Path.Combine( universePath, universeImageFilename );

                    if( File.Exists( universeImagePath ) )
                    {
                        // this is needed, because loading via the Bitmaps constructor (or Image.FromFile) leaves a file handle open so we can't delete the folder while the program is running
                        using( var bmpTemp = new Bitmap( universeImagePath ) )
                        {
                            universeLogo = new Bitmap( bmpTemp );
                        }
                    }
                    else
                    {
                        universeLogo = Properties.Resources.empty;
                    }

                    if( !lvi.ValidUniverse )
                    {
                        var temp = new Bitmap( universeLogo );

                        using( var g = Graphics.FromImage( temp ) )
                        {
                            int x = ( temp.Width - invalidUniverseOverlayImage.Width ) / 2;
                            int y = ( temp.Height - invalidUniverseOverlayImage.Height ) / 2;

                            g.DrawImage( invalidUniverseOverlayImage, x, y );
                        }

                        universeLogo = temp;
                    }

                    if( Repository.IsValid( universePath ) )
                    {
                        lvi.RepoState = UniverseListViewItem.ERepoState.READY;

                        try
                        {
                            using( var repo = new Repository( universePath ) )
                            {
                                lvi.RepoURL = repo.Network.Remotes[ "origin" ].Url;

                                string logMessage = String.Empty;

                                // fetch all
                                foreach( Remote remote in repo.Network.Remotes )
                                {
                                    var refSpecs = remote.FetchRefSpecs.Select( x => x.Specification );
                                    Commands.Fetch( repo, remote.Name, refSpecs, null, logMessage );
                                }

                                if( repo.Head.TrackingDetails.AheadBy > 0
                                    ||
                                    repo.Diff.Compare<TreeChanges>().Count > 0
                                    ||
                                    repo.RetrieveStatus().IsDirty )
                                {
                                    lvi.RepoState = UniverseListViewItem.ERepoState.MODIFIED;
                                    universeModified = true;
                                }
                                else if( repo.Head.TrackingDetails.BehindBy > 0 )
                                {
                                    lvi.RepoState = UniverseListViewItem.ERepoState.BEHIND;
                                }

                                universeCommitHash = repo.Head.Tip.Sha;
                            }
                        }
                        catch( RepositoryNotFoundException ex )
                        {
                            lvi.RepoError = ex.Message;

                            lvi.RepoState = UniverseListViewItem.ERepoState.ERROR;
                        }
                        catch( Exception ex )
                        {
                            lvi.RepoError = ex.Message;

                            lvi.RepoState = UniverseListViewItem.ERepoState.ERROR;
                        }

                        Image repoOverlayImage = null;

                        switch( lvi.RepoState )
                        {
                            case UniverseListViewItem.ERepoState.BEHIND:
                                repoOverlayImage = repoBehindOverlayImage;
                                break;

                            case UniverseListViewItem.ERepoState.MODIFIED:
                                repoOverlayImage = repoModifiedOverlayImage;
                                break;

                            case UniverseListViewItem.ERepoState.ERROR:
                                repoOverlayImage = repoErrorOverlayImage;
                                break;
                        }

                        if( repoOverlayImage != null )
                        {
                            var temp = new Bitmap( universeLogo );

                            using( var g = Graphics.FromImage( temp ) )
                            {
                                g.DrawImage( repoOverlayImage, 0, 0 );
                            }

                            universeLogo = temp;
                        }
                    }

                    if( lvi.Universe != null )
                    {
                        lvi.Universe.Logo = universeLogo;
                        lvi.Universe.Modified = universeModified;
                        lvi.Universe.CommitHash = universeCommitHash;
                    }

                    this.Invoke( new MethodInvoker( () =>
                    {
                        imageListUniverses.Images.Add( universePath, universeLogo );
                        listViewUniverses.Items.Add( lvi );
                    } ) );
                }

                this.Invoke( new MethodInvoker( () =>
                {
                    panelMain.Visible = true;
                } ) );
            }
            else
            {
                this.Invoke( new MethodInvoker( () =>
                {
                    panelNoUniverses.Visible = true;
                } ) );
            }

            this.Invoke( new MethodInvoker( () =>
            {
                panelControl.Enabled = true;
                panelWorking.Visible = false;
            } ) );
        }

        private void listViewUniverses_ItemActivate( object sender, EventArgs e )
        {
            var universeItem = listViewUniverses.SelectedItems[ 0 ] as UniverseListViewItem;

            void OpenUniverse()
            {
                this.Hide();

                var universe = universeItem.Universe;
                var universePath = universeItem.ImageKey;
                
                using( ProgressForm progressForm = new ProgressForm( universe.Logo ) )
                {
                    Storage.BackgroundWorkerProvider backgroundWorkerProvider = () => progressForm.CreateBackgroundWorker();

                    MasterDataStorage.Setup( universePath, backgroundWorkerProvider );

                    UserDataStorage.Setup( universe.ID, backgroundWorkerProvider );

                    progressForm.ShowDialog();
                }

                if( Options.DeityMode )
                {
                    var deityModeForm = new DeityModeForm( universe, universePath );

                    deityModeForm.FormClosed += delegate
                    {
                        deityModeForm.Dispose();

                        this.Close();
                    };

                    deityModeForm.Show( this );
                }
                else
                {
                    var universeForm = new UniverseForm( universe, deityMode: false );

                    universeForm.FormClosed += delegate
                    {
                        universeForm.Dispose();

                        this.Close();
                    };

                    universeForm.Show( this );
                }
            }

            switch( universeItem.RepoState )
            {
                case UniverseListViewItem.ERepoState.NONE:
                case UniverseListViewItem.ERepoState.READY:
                    if( universeItem.ValidUniverse )
                    {
                        OpenUniverse();
                    }
                    else
                    {
                        MessageBox.Show( "Dieses Universum ist defekt und kann nicht geöffnet werden!",
                                         "Universum defekt",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error );
                    }

                    break;

                case UniverseListViewItem.ERepoState.BEHIND:
                    if( MessageBox.Show( "Ein Update ist vorhanden! Soll das Update installiert werden?",
                                         "Update vorhanden",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Information,
                                         MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                    {
                        using( var repo = new Repository( universeItem.ImageKey ) )
                        {
                            try
                            {
                                repo.RemoveUntrackedFiles();

                                repo.Reset( ResetMode.Hard );

                                Commands.Pull( repo, new Signature( "dummy", "dummy", DateTimeOffset.Now ), new PullOptions() );
                            }
                            catch( Exception ex )
                            {
                                MessageBox.Show( ex.Message,
                                                 "Probleme beim Update",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error );
                            }
                        }

                        RefreshUniverses();
                    }

                    break;

                case UniverseListViewItem.ERepoState.MODIFIED:
                    if( universeItem.ValidUniverse )
                    {
                        if (Options.DeityMode)
                        {
                            OpenUniverse();
                        }
                        else
                        {
                            if (MessageBox.Show("Das Universum wurde lokal verändert. Dennoch öffnen?",
                                                 "Lokale Änderungen vorhanden",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning,
                                                 MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                OpenUniverse();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show( "Dieses Universum ist defekt und kann nicht geöffnet werden!",
                                         "Universum defekt",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error );
                    }

                    break;

                case UniverseListViewItem.ERepoState.ERROR:
                    MessageBox.Show( "Probleme bei der Kommunikation mit dem Repository:" + Environment.NewLine + universeItem.RepoError,
                                     "Git Repository",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );

                    break;
            }
        }

        private void UniverseSelectionForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Application.Exit();
            }
        }

        private void buttonRefresh_Click( object sender, EventArgs e )
        {
            RefreshUniverses();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using( var dialog = new RepoUrlForm() )
            {
                if( dialog.ShowDialog() == DialogResult.OK )
                {
                    // iterate all repositories and decline to checkout if it was already checked out
                    foreach( var item in listViewUniverses.Items )
                    {
                        var universeItem = item as UniverseListViewItem;

                        if( !String.IsNullOrEmpty( universeItem.RepoURL ) )
                        {
                            var itemUri = new Uri( universeItem.RepoURL );

                            if( Uri.Compare( dialog.RepositoryURL, itemUri,
                                             UriComponents.Host | UriComponents.PathAndQuery,
                                             UriFormat.SafeUnescaped,
                                             StringComparison.OrdinalIgnoreCase ) == 0 )
                            {
                                MessageBox.Show( "Dieses Universum existiert hier bereits!",
                                                 String.Empty,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error );
                                return;
                            }
                        }
                    }

                    using( var cloneForm = new CloneForm( UniversesPath, dialog.RepositoryURL ) )
                    {
                        if( cloneForm.ShowDialog() == DialogResult.OK )
                        {
                            RefreshUniverses();
                        }
                        else
                        {
                            RepositoryHelper.Delete( cloneForm.UniversePath );
                        }
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if( listViewUniverses.SelectedItems.Count > 0 )
            {
                var path = listViewUniverses.SelectedItems[ 0 ].ImageKey;

                if( MessageBox.Show( $"Wirklich das Universum '{listViewUniverses.SelectedItems[ 0 ].Text}' löschen?",
                                     "Wirklich löschen?",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                {
                    RepositoryHelper.Delete( path );

                    RefreshUniverses();
                }
            }
        }

        private void buttonOpenFolder_Click( object sender, EventArgs e )
        {
            if( listViewUniverses.SelectedItems.Count > 0 )
            {
                var selectedItem = listViewUniverses.SelectedItems[ 0 ];

                var path = selectedItem.ImageKey;

                if( !Directory.Exists( path ) )
                {
                    MessageBox.Show( $"Der Ordner für das Universum '{selectedItem.Text}' existiert nicht!" );
                }
                else
                {
                    Process.Start( path );
                }
            }
        }

        private void buttonOpenVscode_Click( object sender, EventArgs e )
        {
            if( listViewUniverses.SelectedItems.Count > 0 )
            {
                var selectedItem = listViewUniverses.SelectedItems[ 0 ];

                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo()
                    {
                        FileName = "code",
                        Arguments = $"\"{selectedItem.ImageKey}\"",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start( startInfo );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.ToString() );
                }
            }
        }

        private void panelHeader_Paint( object sender, PaintEventArgs e )
        {
            base.OnPaint( e );

            using( Graphics g = e.Graphics )
            {
                var p = new Pen( Color.Black, 1 );
                g.DrawLine( p, 0, panelHeader.Height - 1, panelHeader.Width, panelHeader.Height - 1 );
            }
        }

        private void panelControl_Paint( object sender, PaintEventArgs e )
        {
            base.OnPaint( e );

            using( Graphics g = e.Graphics )
            {
                var p = new Pen( Color.Black, 1 );
                g.DrawLine( p, 0, 0, panelControl.Width, 0 );
            }
        }

        private void buttonCreateUniverse_Click( object sender, EventArgs e )
        {
            if( MessageBox.Show( $"Wirklich ein neues Universum erzeugen?",
                                 "Wirklich erzeugen?",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
            {
                var path = Universe.Create( UniversesPath );

                Process.Start( "notepad.exe", path );

                RefreshUniverses();
            }
        }

        private void buttonInfo_Click( object sender, EventArgs e )
        {
            if( listViewUniverses.SelectedItems.Count > 0 )
            {
                var universeItem = listViewUniverses.SelectedItems[ 0 ] as UniverseListViewItem;

                using( var infoForm = new UniverseInfoForm( universeItem.Universe ) )
                {
                    infoForm.ShowDialog();
                }
            }
        }

        private void listViewUniverses_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
        {
            if( listViewUniverses.SelectedItems.Count > 0 )
            {
                buttonInfo.Enabled = true;
                buttonOpenFolder.Enabled = true;
                buttonOpenVscode.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonInfo.Enabled = false;
                buttonOpenFolder.Enabled = false;
                buttonOpenVscode.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void UniverseSelectionForm_Shown( object sender, EventArgs e )
        {
            RefreshUniverses();
        }

        private void buttonOpenRules_Click( object sender, EventArgs e )
        {
            System.Diagnostics.Process.Start("https://mutantpenguin.github.io/Universalis/");
        }
    }
}
