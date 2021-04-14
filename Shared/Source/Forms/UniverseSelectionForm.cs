using LibGit2Sharp;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class UniverseSelectionForm : Form
    {
        public delegate Form FormToOpen( Image universeImage, string universePath, string universeName );

        private static readonly string UniversesPath = Path.Combine( Directory.GetCurrentDirectory(), "Universes" );

        private static readonly string universeSettingsFilename = "universe.json";
        private static readonly string universeImageFilename = "logo.jpg";

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

                        //* TODO git integration via "LibGit2Sharp"
                        if( Repository.IsValid( universeSubfolder ) )
                        {
                            try
                            {
                                using( var repo = new Repository( universeSubfolder ) )
                                {
                                    string logMessage = "";
                                    var remote = repo.Network.Remotes[ "origin" ];

                                    repositoryURL = remote.Url;

                                    var refSpecs = remote.FetchRefSpecs.Select( x => x.Specification );
                                    Commands.Fetch( repo, remote.Name, refSpecs, null, logMessage );
                                }
                            }
                            catch( RepositoryNotFoundException )
                            {
                                // TODO
                            }
                        }

                        var universe = JsonConvert.DeserializeObject<Universe>( File.ReadAllText( universeSettingsPath ) );

                        var universeImagePath = Path.Combine( universeSubfolder, universeImageFilename );
                        if( File.Exists( universeImagePath ) )
                        {
                            // this is needed, because loading via the Bitmaps constructor (or Image.FromFile) leaves a file handle open so we can't delete the folder while the program is running
                            Image universeImg;
                            using( var bmpTemp = new Bitmap( universeImagePath ) )
                            {
                                universeImg = new Bitmap( bmpTemp );
                            }

                            imageListUniverses.Images.Add( universeSubfolder, universeImg );
                        }
                        else
                        {
                            imageListUniverses.Images.Add( universeSubfolder, Shared.Properties.Resources.empty );
                        }

                        var lvi = new UniverseListViewItem()
                        {
                            Text = universe.Name,
                            ImageKey = universeSubfolder,
                            ToolTipText = universe.Description,
                            RepositoryURL = repositoryURL
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
            this.Hide();

            formToOpen( imageListUniverses.Images[ listViewUniverses.SelectedItems[ 0 ].ImageKey ], listViewUniverses.SelectedItems[ 0 ].ImageKey, listViewUniverses.SelectedItems[ 0 ].Text ).ShowDialog( this );

            this.Close();
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
                    // can't delete a git repo just like that since some files are protected so we need to reset their file attributes first
                    var directory = new DirectoryInfo( path ) { Attributes = FileAttributes.Normal };

                    foreach( var info in directory.GetFileSystemInfos( "*", SearchOption.AllDirectories ) )
                    {
                        info.Attributes = FileAttributes.Normal;
                    }

                    directory.Delete( true );

                    RefreshUniverses();
                }
            }
        }
    }
}
