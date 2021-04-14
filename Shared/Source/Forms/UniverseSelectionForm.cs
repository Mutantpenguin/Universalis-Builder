using LibGit2Sharp;
using Newtonsoft.Json;
using System;
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
        public delegate Form FormToOpen( Image universeImage, string universePath, string universeName );

        private static readonly string UniversesSubFolder = "Universes";

        private static readonly string UniversesPath = Path.Combine( UniversalisSettings.UserAppFolder, UniversesSubFolder );

        private static readonly string universeSettingsFilename = "universe.json";
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
        }

        private void RefreshUniverses()
        {
            imageListUniverses.Images.Clear();
            listViewUniverses.Clear();

            string[] universeSubfolders = Directory.GetDirectories( UniversesPath );

            if( universeSubfolders.Count() > 0 )
            {
                int validUniverseCounter = 0;

                foreach( string universeSubfolder in universeSubfolders )
                {
                    var universeSettingsPath = Path.Combine( universeSubfolder, universeSettingsFilename );

                    if( !File.Exists( universeSettingsPath ) )
                    {
#if DEBUG
                        // TODO show message
#endif
                    }
                    else
                    {
                        string repositoryURL = String.Empty;
                        UniverseListViewItem.EState state = UniverseListViewItem.EState.READY;

                        //* TODO git integration via "LibGit2Sharp"
                        if( Repository.IsValid( universeSubfolder ) )
                        {
                            try
                            {
                                using( var repo = new Repository( universeSubfolder ) )
                                {
                                    string logMessage = "";

                                    // fetch all
                                    foreach( Remote remote in repo.Network.Remotes )
                                    {
                                        var refSpecs = remote.FetchRefSpecs.Select( x => x.Specification );
                                        Commands.Fetch( repo, remote.Name, refSpecs, null, logMessage );
                                    }

                                    if( repo.Head.TrackingDetails.AheadBy > 0 )
                                    {
                                        state = UniverseListViewItem.EState.AHEAD;
                                    }
                                    else if( repo.Head.TrackingDetails.BehindBy > 0 )
                                    {
                                        state = UniverseListViewItem.EState.BEHIND;
                                    }
                                }
                            }
                            catch( RepositoryNotFoundException )
                            {
                                // TODO store and show message?

                                state = UniverseListViewItem.EState.ERROR;
                            }
                            catch( Exception )
                            {
                                // TODO store and show message?

                                state = UniverseListViewItem.EState.ERROR;
                            }
                        }

                        var universe = JsonConvert.DeserializeObject<Universe>( File.ReadAllText( universeSettingsPath ) );

                        var universeImagePath = Path.Combine( universeSubfolder, universeImageFilename );

                        Image universeImg;

                        if( File.Exists( universeImagePath ) )
                        {
                            // this is needed, because loading via the Bitmaps constructor (or Image.FromFile) leaves a file handle open so we can't delete the folder while the program is running
                            using( var bmpTemp = new Bitmap( universeImagePath ) )
                            {
                                universeImg = new Bitmap( bmpTemp );
                            }
                        }
                        else
                        {
                            universeImg = Shared.Properties.Resources.empty;
                        }

                        Image overlayImage = null;

                        switch( state )
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

                        imageListUniverses.Images.Add( universeSubfolder, universeImg );

                        var lvi = new UniverseListViewItem()
                        {
                            Text = universe.Name,
                            ImageKey = universeSubfolder,
                            ToolTipText = universe.Description,
                            RepositoryURL = repositoryURL,
                            State = state
                        };

                        listViewUniverses.Items.Add( lvi );

                        validUniverseCounter++;
                    }
                }

                if( validUniverseCounter == 0 )
                {
                    listViewUniverses.Visible = false;
                    panelHeader.Visible = false;
                    panelNoUniverses.Visible = true;
                }
                else
                {
                    listViewUniverses.Visible = true;
                    panelHeader.Visible = true;
                    panelNoUniverses.Visible = false;
                }
            }
            else
            {
                listViewUniverses.Visible = false;
                panelHeader.Visible = false;
                panelNoUniverses.Visible = true;
            }
        }

        private void listViewUniverses_ItemActivate( object sender, EventArgs e )
        {
            var universeItem = listViewUniverses.SelectedItems[ 0 ] as UniverseListViewItem;

            void OpenUniverse()
            {
                this.Hide();

                formToOpen( imageListUniverses.Images[ universeItem.ImageKey ], universeItem.ImageKey, universeItem.Text ).ShowDialog( this );

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
                        // TODO
                        using( var repo = new Repository( universeItem.ImageKey ) )
                        {
                            try
                            {
                                Commands.Pull( repo, null, null );
                            }
                            catch( Exception )
                            {
                                // TODO MessageBox
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

                        if( dialog.RepositoryURL.ToString() == universeItem.RepositoryURL )
                        {
                            MessageBox.Show( "Dieses Universum existiert hier bereits!" );
                            return;
                        }
                    }

                    using( var progressForm = new CloneForm( UniversesPath, dialog.RepositoryURL ) )
                    {
                        if( progressForm.ShowDialog() == DialogResult.OK )
                        {
                            // TODO check if this is a valid universe, or just any git repo
                            // TODO ask to delete if it's invalid

                            RefreshUniverses();
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
    }
}
