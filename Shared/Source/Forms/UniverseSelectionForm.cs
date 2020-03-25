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
        private static readonly string UniversePath = Path.Combine( Directory.GetCurrentDirectory(), "Universes" );

        private static readonly string universeSettingsFilename = "universe.json";
        private static readonly string universeImageFilename = "image.jpg";

        public UniverseSelectionForm()
        {
            if( !Directory.Exists( UniversePath ) )
            {
                Directory.CreateDirectory( UniversePath );
            }

            File.SetAttributes( UniversePath, FileAttributes.Hidden );

            InitializeComponent();

            listViewUniverses.Font = new System.Drawing.Font( UniversalisFont.Family, 10 );

            this.Icon = Shared.Properties.Resources.icon;

            imageListUniverses.ImageSize = new System.Drawing.Size( 150, 150 );

            RefreshList();
        }

        public string UniverseID
        {
            get;
            private set;
        }

        private void RefreshList()
        {
            imageListUniverses.Images.Clear();
            listViewUniverses.Clear();


            string[] universeSubfolders = Directory.GetDirectories( UniversePath );

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
                        imageListUniverses.Images.Add( universe.ID.ToString(), Image.FromFile( universeImagePath ) );
                    }
                    else
                    {
                        imageListUniverses.Images.Add( universe.ID.ToString(), Shared.Properties.Resources.empty );
                    }

                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = universe.Name,
                        ImageKey = universe.ID.ToString(),
                        ToolTipText = universe.Description
                    };

                    listViewUniverses.Items.Add( lvi );
                }
            }
        }

        private void listViewUniverses_ItemActivate( object sender, EventArgs e )
        {
            UniverseID = listViewUniverses.SelectedItems[ 0 ].ImageKey;

            this.Close();
        }
    }
}
