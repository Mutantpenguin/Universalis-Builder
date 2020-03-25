using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class UniverseSelectionForm : Form
    {
        public delegate Form FormToOpen( string universePath, string universeName );

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

            listViewUniverses.Font = new System.Drawing.Font( UniversalisFont.Family, 10 );

            labelNoUniverses.Font = new System.Drawing.Font( UniversalisFont.Family, 20 );
            labelNoUniverses.Left = ( this.ClientSize.Width - labelNoUniverses.Width ) / 2;
            labelNoUniverses.Top = ( this.ClientSize.Height - labelNoUniverses.Height ) / 2;

            this.Icon = Shared.Properties.Resources.icon;

            imageListUniverses.ImageSize = new System.Drawing.Size( 200, 200 );

            RefreshList();
        }

        private readonly FormToOpen formToOpen;

        private void RefreshList()
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
                        var universe = JsonConvert.DeserializeObject<Universe>( File.ReadAllText( universeSettingsPath ) );

                        var universeImagePath = Path.Combine( universeSubfolder, universeImageFilename );
                        if( File.Exists( universeImagePath ) )
                        {
                            imageListUniverses.Images.Add( universeSubfolder, System.Drawing.Image.FromFile( universeImagePath ) );
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
                    panelNoUniverses.Visible = true;
                }
            }
            else
            {
                listViewUniverses.Visible = false;
                panelNoUniverses.Visible = true;
            }
        }

        private void listViewUniverses_ItemActivate( object sender, EventArgs e )
        {
            this.Hide();

            formToOpen( listViewUniverses.SelectedItems[ 0 ].ImageKey, listViewUniverses.SelectedItems[ 0 ].Text ).ShowDialog( this );

            this.Close();
        }

        private void UniverseSelectionForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Application.Exit();
            }
        }
    }
}
