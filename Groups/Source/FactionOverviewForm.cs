using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class FactionOverviewForm : Form
    {
        public FactionOverviewForm()
        {
            if( Properties.Settings.Default.UpgradeSettings )
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
                Properties.Settings.Default.Save();
            }

            Storage.Setup();

            using( ProgressForm progressForm = new ProgressForm() )
            {
                // load the masterdata
                FactionStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                TraitStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                ArmorStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                WeaponStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                EquipmentStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );

                // load Actors after loading the masterdata
                ActorStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );

                // load Groups after loading the Actors
                GroupStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );

                progressForm.ShowDialog();
            }

            InitializeComponent();

            listViewFactions.Font = new System.Drawing.Font( TesseraktFonts.FontFamilyNovaSquare, 10 );

            this.Icon = Properties.Resources.icon;

            imageListFactions.ImageSize = new System.Drawing.Size( 150, 150 );

            RefreshList();
        }

        private void RefreshList()
        {
            imageListFactions.Images.Clear();
            listViewFactions.Clear();

            foreach( Faction.EType type in Faction.ETypeList.OrderBy( x => x.ToString() ) )
            {
                ListViewGroup group = new ListViewGroup( type.ToString() );
                
                listViewFactions.Groups.Add( group );

                foreach( Faction faction in FactionStorage.Instance.Factions.Where( x => x.Type == type )
                                                                            .OrderBy( x => x.Name ) )
                {
                    imageListFactions.Images.Add( faction.ID.ToString(), faction.Icon );

                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = faction.Name + " ( " + GroupStorage.Instance.Groups.Count( x => x.Faction == faction ) + " )",
                        ImageKey = faction.ID.ToString(),
                        ToolTipText = faction.Description,
                        Group = group
                    };

                    listViewFactions.Items.Add( lvi );
                }
            }
        }

        private void listViewFactions_ItemActivate( object sender, EventArgs e )
        {
            Faction faction = FactionStorage.Instance.Factions.First( x => x.ID.ToString() == listViewFactions.SelectedItems[ 0 ].ImageKey );

            using( GroupManagerForm groupManagerForm = new GroupManagerForm( faction ) )
            {
                this.Hide();

                groupManagerForm.ShowDialog( this );

                this.Show();
            }
        }

        private void FactionOverviewForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Application.Exit();
            }
        }

        private void FactionOverviewForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            switch( MessageBox.Show( "Wirklich beenden?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) )
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        private void FactionOverviewForm_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FactionOverviewForm_DragDrop( object sender, DragEventArgs e )
        {
            string[] fileList = (string[])e.Data.GetData( DataFormats.FileDrop, false );

            foreach( string fileName in fileList )
            {
                if( Path.GetExtension( fileName ) == ".tesgro" )
                {
                    try
                    {
                        Group groupLoaded = GroupStorage.Load( fileName );

                        Group group = GroupStorage.Instance.FindByID( groupLoaded.ID );

                        if( group == null )
                        {
                            GroupStorage.Instance.Add( groupLoaded );

                            MessageBox.Show( $"Die Gruppe '{groupLoaded.Name}' der Fraktion '{groupLoaded.Faction.Name}' wurde importiert" );

                            RefreshList();
                        }
                        else
                        {
                            if( groupLoaded.Equals( group ) )
                            {
                                MessageBox.Show( $"Die Gruppe '{groupLoaded.Name}' der Fraktion '{groupLoaded.Faction.Name}' ist bereits identisch vorhanden!",
                                                 "",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Information );
                            }
                            else
                            {
                                if( MessageBox.Show( $"Die Gruppe '{groupLoaded.Name}' der Fraktion '{groupLoaded.Faction.Name}' existiert bereits mit Unterschieden." + Environment.NewLine + Environment.NewLine + "Soll Sie überschreiben werden?",
                                                     "Gruppe bereits vorhanden",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question ) == DialogResult.Yes )
                                {
                                    // overwrite
                                    group.Set( groupLoaded );
                                    GroupStorage.Save( group );

                                    RefreshList();
                                }
                                else
                                {
                                    if( MessageBox.Show( $"Wollen Sie die Gruppe '{groupLoaded.Name}' der Fraktion '{groupLoaded.Faction.Name}' stattdessen als neue Gruppe importieren?",
                                                         "Gruppe als neue Gruppe importieren",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question ) == DialogResult.Yes )
                                    {
                                        // create as new Group
                                        Group groupNew = GroupStorage.Instance.Create( groupLoaded.Faction );
                                        groupNew.Set( groupLoaded );
                                        groupNew.Name = $"(Neuer Import von) {groupLoaded.Name}";
                                        GroupStorage.Save( groupNew );

                                        RefreshList();
                                    }
                                }
                            }
                        }
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Gruppen-Datei '{Path.GetFileName( fileName )}':\n{ex.Message}" );
                    }
                }
            }
        }
    }
}
