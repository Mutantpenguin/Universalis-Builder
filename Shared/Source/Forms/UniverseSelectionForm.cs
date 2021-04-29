using LibGit2Sharp;
using Newtonsoft.Json;
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
        public delegate Form FormToOpen( Image universeImage, string universePath, Universe universe );

        private static readonly string UniversesSubFolder = "Universes";

        private static readonly string UniversesPath = Path.Combine( UniversalisSettings.UserAppFolder, UniversesSubFolder );

        private static readonly string universeImageFilename = "logo.jpg";

        private static readonly ColorMatrix s_colorMatrixRepoBehind = ColorHelper.ColorToColorMatrix( Color.SeaGreen );
        private static readonly ColorMatrix s_colorMatrixRepoAhead = ColorHelper.ColorToColorMatrix( Color.Orange );
        private static readonly ColorMatrix s_colorMatrixRepoError = ColorHelper.ColorToColorMatrix( Color.Red );

        private static readonly Image repoBehindImage = ImageHelper.Colorize( Shared.Properties.Resources.baseline_new_releases_black_48dp, s_colorMatrixRepoBehind );
        private static readonly Image repoAheadImage = ImageHelper.Colorize( Shared.Properties.Resources.baseline_warning_black_48dp, s_colorMatrixRepoAhead );
        private static readonly Image repoErrorImage = ImageHelper.Colorize( Shared.Properties.Resources.baseline_error_black_48dp, s_colorMatrixRepoError );

        public UniverseSelectionForm( FormToOpen formToOpen )
        {
            this.formToOpen = formToOpen;

            if( !Directory.Exists( UniversesPath ) )
            {
                Directory.CreateDirectory( UniversesPath );
            }

            File.SetAttributes( UniversesPath, FileAttributes.Hidden );

            InitializeComponent();

            listViewUniverses.Font = new Font( UniversalisFont.Family, 10 );
            labelNoUniverses.Font = new Font( UniversalisFont.Family, 20 );

            tableLayoutPanelCentered.Left = ( panelNoUniverses.Width - tableLayoutPanelCentered.Width ) / 2;
            tableLayoutPanelCentered.Top = ( panelNoUniverses.Height - tableLayoutPanelCentered.Height ) / 2;

            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            this.Icon = Shared.Properties.Resources.icon;

            RefreshUniverses();
        }

        private readonly FormToOpen formToOpen;

        private class UniverseListViewItem : ListViewItem
        {
            public string RepositoryURL
            {
                get;
                set;
            }

            public enum EState
            {
                READY,
                BEHIND,
                AHEAD,
                ERROR
            }

            public EState State
            {
                get;
                set;
            } = EState.READY;

            public Universe Universe
            {
                get;
                set;
            }
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
                int validUniverseCounter = 0;

                foreach( string universePath in universeSubfolders )
                {
                    var lvi = new UniverseListViewItem()
                    {
                        ImageKey = universePath
                    };

                    Image universeImg = Shared.Properties.Resources.empty;

                    var (universe, error) = Universe.Load( universePath );

                    if( universe == null )
                    {
                        lvi.Text = "Defektes Universum";
                        lvi.State = UniverseListViewItem.EState.ERROR;
                        lvi.ToolTipText = error;
                    }
                    else
                    {
                        lvi.Universe = universe;
                        lvi.Text = universe.NameWithVersion();
                        lvi.ToolTipText = universe.Description;

                        if( Repository.IsValid( universePath ) )
                        {
                            try
                            {
                                using( var repo = new Repository( universePath ) )
                                {
                                    lvi.RepositoryURL = repo.Network.Remotes.FirstOrDefault( r => r.Name == "origin" ).Url;

                                    string logMessage = String.Empty;

                                    // fetch all
                                    foreach( Remote remote in repo.Network.Remotes )
                                    {
                                        var refSpecs = remote.FetchRefSpecs.Select( x => x.Specification );
                                        Commands.Fetch( repo, remote.Name, refSpecs, null, logMessage );
                                    }

                                    if( repo.Head.TrackingDetails.AheadBy > 0 )
                                    {
                                        lvi.State = UniverseListViewItem.EState.AHEAD;
                                    }
                                    else if( repo.Head.TrackingDetails.BehindBy > 0 )
                                    {
                                        lvi.State = UniverseListViewItem.EState.BEHIND;
                                    }
                                }
                            }
                            catch( RepositoryNotFoundException ex )
                            {
                                lvi.ToolTipText = ex.Message;

                                lvi.State = UniverseListViewItem.EState.ERROR;
                            }
                            catch( Exception ex )
                            {
                                lvi.ToolTipText = ex.Message;

                                lvi.State = UniverseListViewItem.EState.ERROR;
                            }
                        }

                        var universeImagePath = Path.Combine( universePath, universeImageFilename );

                        if( File.Exists( universeImagePath ) )
                        {
                            // this is needed, because loading via the Bitmaps constructor (or Image.FromFile) leaves a file handle open so we can't delete the folder while the program is running
                            using( var bmpTemp = new Bitmap( universeImagePath ) )
                            {
                                universeImg = new Bitmap( bmpTemp );
                            }
                        }
                    }

                    Image overlayImage = null;

                    switch( lvi.State )
                    {
                        case UniverseListViewItem.EState.BEHIND:
                            overlayImage = repoBehindImage;
                            break;

                        case UniverseListViewItem.EState.AHEAD:
                            overlayImage = repoAheadImage;
                            break;

                        case UniverseListViewItem.EState.ERROR:
                            overlayImage = repoErrorImage;
                            break;
                    }

                    if( overlayImage != null )
                    {
                        using( var g = Graphics.FromImage( universeImg ) )
                        {
                            g.DrawImage( overlayImage, 0, 0 );
                        }
                    }

                    this.Invoke( new MethodInvoker( () =>
                    {
                        imageListUniverses.Images.Add( universePath, universeImg );

                        listViewUniverses.Items.Add( lvi );
                    } ) );

                    validUniverseCounter++;
                }

                this.Invoke( new MethodInvoker( () =>
                {
                    if( validUniverseCounter == 0 )
                    {
                        panelNoUniverses.Visible = true;
                    }
                    else
                    {
                        panelMain.Visible = true;
                    }
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

                formToOpen( imageListUniverses.Images[ universeItem.ImageKey ], universeItem.ImageKey, universeItem.Universe ).ShowDialog( this );

                this.Close();
            }

            switch( universeItem.State )
            {
                case UniverseListViewItem.EState.READY:
                    OpenUniverse();

                    break;

                case UniverseListViewItem.EState.BEHIND:
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
                    else
                    {
                        OpenUniverse();
                    }

                    break;

                case UniverseListViewItem.EState.AHEAD:
                    if( MessageBox.Show( "Lokale Änderungen sind vorhanden! Trotzdem öffnen?",
                                         "Lokale Änderungen vorhanden",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning,
                                         MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                    {
                        OpenUniverse();
                    }

                    break;

                case UniverseListViewItem.EState.ERROR:
                    MessageBox.Show( "Dieses Universum ist defekt und kann nicht geöffnet werden!",
                                     "Universum defekt",
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

                        if( !String.IsNullOrEmpty( universeItem.RepositoryURL ) )
                        {
                            var itemUri = new Uri( universeItem.RepositoryURL );

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
    }
}
