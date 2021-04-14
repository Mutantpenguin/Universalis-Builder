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
                        /* TODO git integration via "LibGit2Sharp"
                        try
                        {
                            // TODO if( Repository.IsValid( universeSubfolder ) )
                            using( var repo = new Repository( universeSubfolder ) )
                            {
                                //MessageBox.Show( repo. );

                                string logMessage = "";
                                var remote = repo.Network.Remotes[ "origin" ];
                                var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                                Commands.Fetch( repo, remote.Name, refSpecs, null, logMessage );
                            }
                        }
                        catch( RepositoryNotFoundException )
                        {}
                        */

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

                        ListViewItem lvi = new ListViewItem()
                        {
                            Text = universe.Name,
                            ImageKey = universeSubfolder,
                            ToolTipText = universe.Description
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
                    // TODO iterate all repositories and decline to checkout if it was already checked out

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

                // TODO show name of the universe
                if( MessageBox.Show( $"Wirklich das Universum '{listViewUniverses.SelectedItems[ 0 ].ImageKey}' löschen?",
                                     "Wirklich löschen?",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                {
                    var directory = new DirectoryInfo( path ) { Attributes = FileAttributes.Normal };

                    foreach( var info in directory.GetFileSystemInfos( "*", SearchOption.AllDirectories ) )
                    {
                        info.Attributes = FileAttributes.Normal;
                    }

                    directory.Delete( true );
                }

                RefreshUniverses();
            }
        }
    }
}
