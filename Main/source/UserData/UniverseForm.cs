using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class UniverseForm : Form
    {
        public UniverseForm( Universe universe, bool deityMode )
        {
            m_universe = universe;

            m_deityMode = deityMode;

            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            this.CenterToParent();

            labelHeader.Text = universe.NameWithVersion();
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            listViewFactions.Font = new Font( UniversalisFont.Family, 10 );

            SetupDisciplines();

            RefreshFactionsList();
        }

        private readonly Universe m_universe;

        private readonly bool m_deityMode;

        private void RefreshFactionsList()
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
            this.Hide();

            Faction faction = MasterDataStorage.Faction.Factions.First( x => x.ID.ToString() == listViewFactions.SelectedItems[ 0 ].ImageKey );

            GroupManagerForm groupManagerForm = new GroupManagerForm( m_universe, faction );

            groupManagerForm.FormClosed += delegate
            {
                this.Show();

                groupManagerForm.Dispose();
            };

            groupManagerForm.Show( this );
        }

        private void UniverseForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Close();
            }
        }

        private void UniverseForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( !m_deityMode )
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
        }

        private void UniverseForm_DragEnter( object sender, DragEventArgs e )
        {
            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void UniverseForm_DragDrop( object sender, DragEventArgs e )
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

                            RefreshFactionsList();
                        }
                        else
                        {
                            if( groupLoaded.Equals( group ) )
                            {
                                MessageBox.Show( $"Die Gruppe '{groupLoaded.Name}' der Fraktion '{groupLoaded.Faction.Name}' ist bereits identisch vorhanden!",
                                                 String.Empty,
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

                                    RefreshFactionsList();
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

                                        RefreshFactionsList();
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

        private void SetupDisciplines()
        {
            if( MasterDataStorage.Discipline.Disciplines.Count == 0 )
            {
                panelDisciplines.Visible = false;
            }
            else
            {
                imageListDisciplines.Images.Clear();
                listViewDisciplines.Clear();

                foreach( string type in MasterDataStorage.Faction.Factions.Where( s => s.Active )
                                                                          .Select( x => x.Type )
                                                                          .Distinct()
                                                                          .OrderBy( x => x ) )
                {
                    foreach( Discipline discipline in MasterDataStorage.Discipline.Disciplines.Where( s => s.Active )
                                                                                              .OrderBy( x => x.Name ) )
                    {
                        // TODO generate Icon
                        if( discipline.Icon != null )
                        {
                            imageListDisciplines.Images.Add( discipline.ID.ToString(), discipline.Icon );
                        }
                        else
                        {
                            var imageSize = imageListDisciplines.ImageSize;
                            var disciplineIcon = new Bitmap( imageSize.Width, imageSize.Height );

                            using( var g = Graphics.FromImage( disciplineIcon ) )
                            {
                                g.Clear( discipline.Color );
                            }

                            imageListDisciplines.Images.Add( discipline.ID.ToString(), disciplineIcon );
                        }

                        ListViewItem lvi = new ListViewItem()
                        {
                            Text = discipline.Name,
                            ImageKey = discipline.ID.ToString(),
                            ToolTipText = discipline.Description,
                        };

                        listViewDisciplines.Items.Add( lvi );
                    }
                }
            }
        }

        private void pictureBoxInfo_Click( object sender, EventArgs e )
        {
            using( var infoForm = new UniverseInfoForm( m_universe ) )
            {
                infoForm.ShowDialog();
            }
        }
    }
}
