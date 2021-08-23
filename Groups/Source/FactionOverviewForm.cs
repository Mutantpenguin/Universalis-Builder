using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FactionOverviewForm : Form
    {
        public FactionOverviewForm( string universePath, Universe universe )
        {
            if( Properties.Settings.Default.UpgradeSettings )
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
                Properties.Settings.Default.Save();
            }

            using( ProgressForm progressForm = new ProgressForm( universe.Logo ) )
            {
                Storage.BackgroundWorkerProvider backgroundWorkerProvider = () => progressForm.CreateBackgroundWorker();

                MasterDataStorage.Setup( universePath, backgroundWorkerProvider );

                UserDataStorage.Setup( universe.ID, backgroundWorkerProvider );

                progressForm.ShowDialog();
            }

            InitializeComponent();

            m_universe = universe;

            listViewFactions.Font = new Font( UniversalisFont.Family, 10 );

            labelHeader.Text = universe.NameWithVersion();
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            this.Icon = Shared.Properties.Resources.icon;

            imageListFactions.ImageSize = new System.Drawing.Size( 150, 150 );

            RefreshList();
        }

        private readonly Universe m_universe;

        private void RefreshList()
        {
            imageListFactions.Images.Clear();
            listViewFactions.Clear();

            foreach( string type in MasterDataStorage.Faction.Factions.Where( s => s.Active )
                                                                      .Select( x => x.Type )
                                                                      .Distinct()
                                                                      .OrderBy( x => x ) )
            {
                ListViewGroup group = new ListViewGroup( type );
                
                listViewFactions.Groups.Add( group );

                foreach( Faction faction in MasterDataStorage.Faction.Factions.Where( s => s.Active )
                                                                              .Where( x => x.Type == type )
                                                                              .OrderBy( x => x.Name ) )
                {
                    imageListFactions.Images.Add( faction.ID.ToString(), faction.Icon );

                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = faction.Name + " ( " + UserDataStorage.Group.Groups.Where( s => s.Active )
                                                                                  .Count( x => x.Faction == faction ) + " )",
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
            Faction faction = MasterDataStorage.Faction.Factions.First( x => x.ID.ToString() == listViewFactions.SelectedItems[ 0 ].ImageKey );

            using( GroupManagerForm groupManagerForm = new GroupManagerForm( m_universe, faction ) )
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
                if( Path.GetExtension( fileName ) == ".unigrp" )
                {
                    try
                    {
                        Group groupLoaded = GroupStorage.Load( fileName );

                        Group group = UserDataStorage.Group.FindByID( groupLoaded.ID );

                        if( group == null )
                        {
                            UserDataStorage.Group.Add( groupLoaded );

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
                                    UserDataStorage.Group.Save( group );

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
                                        Group groupNew = GroupStorage.Create( groupLoaded.Faction );
                                        groupNew.Set( groupLoaded );
                                        groupNew.Name = $"(Neuer Import von) {groupLoaded.Name}";
                                        UserDataStorage.Group.Save( groupNew );

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

        private void pictureBoxInfo_Click( object sender, EventArgs e )
        {
            using( var infoForm = new InfoForm( m_universe ) )
            {
                infoForm.ShowDialog();
            }
        }
    }
}
