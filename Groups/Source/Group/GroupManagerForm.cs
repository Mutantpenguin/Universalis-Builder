using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupManagerForm : Form    
    {
        public GroupManagerForm( Faction faction )
        {
            InitializeComponent();

            textBoxFactionDescription.Font = new System.Drawing.Font( UniversalisFont.Family, 10 );

            this.Icon = Shared.Properties.Resources.icon;

            m_faction = faction;

            pictureBoxFaction.Image = faction.Icon;
            textBoxFactionDescription.Text = faction.Description;

            RefreshGroupsGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Faction m_faction;

        private void dataGridViewGroups_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editGroup( (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editGroup( Group group )
        {
            using( GroupEditorForm groupEditorForm = new GroupEditorForm( group ) )
            {
                this.Hide();

                groupEditorForm.ShowDialog( this );

                this.Show();
            }

            groupBindingSource.ResetBindings( false );
        }

        private void toolStripButtonAddGroups_Click( object sender, EventArgs e )
        {
            Group group = GroupStorage.Instance.Create( m_faction );

            toolStripTextBoxSearch.Text = String.Empty;
            RefreshGroupsGridView();

            editGroup( group );

            dataGridViewGroups.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewGroups.Rows )
            {
                if( group.ID == ( (Group)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonDeleteGroup_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group group = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Gruppe '{group.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    GroupStorage.Instance.Delete( group );

                    RefreshGroupsGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group groupSource = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                if( IsValid( groupSource ) )
                {
                    Group groupNew = GroupStorage.Instance.Create( groupSource.Faction );
                    groupNew.Set( groupSource );
                    groupNew.Name = $"(Kopie von) {groupSource.Name}";
                    GroupStorage.Save( groupNew );

                    toolStripTextBoxSearch.Text = String.Empty;
                    RefreshGroupsGridView();

                    editGroup( groupNew );
                }
            }
        }

        private void RefreshGroupsGridView()
        {
            List<Group> groups = GroupStorage.Instance.Groups.Where( s => s.Faction.ID == m_faction.ID )
                                                             .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                             .OrderBy( x => x.Name ).ThenBy( x => x.Points )
                                                             .ToList();

            groupBindingSource.DataSource = groups;
            dataGridViewGroups.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {groups.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            RefreshGroupsGridView();
        }

        private void dataGridViewGroups_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Group group = (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem;

                string toolTipText = String.Empty;

                if( group.HasMissingActors() )
                {
                    toolTipText += "Gelöschte Modelle vorhanden!";
                }

                if( group.HasMissingActorOutfits() )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine : String.Empty ) + "Fehlende Outfits!";
                }

                toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + $"Anzahl Modelle: {group.GroupActorList.Count}{Environment.NewLine}{ToolTipHelper.FormatMaxWidth( group.Description )}";

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( toolTipText );
            }
        }

        private void toolStripButtonPrint_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group group = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                if( IsValid( group ) )
                {
                    GroupPDFExporter.GeneratePDF( group, Path.ChangeExtension( Path.GetTempFileName(), "pdf" ) );
                }
            }
        }

        private void toolStripButtonExportFile_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group group = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                if( IsValid( group ) )
                {
                    using( SaveFileDialog cardSaveFileDialog = new SaveFileDialog() )
                    {
                        cardSaveFileDialog.InitialDirectory = Properties.Settings.Default.groupSavePath;
                        cardSaveFileDialog.Filter = "Einsatzgruppe (*.tesgro)|*.tesgro";
                        cardSaveFileDialog.FileName = $"{group.Faction.Name} - {group.Name} - {group.Points}pts";

                        if( cardSaveFileDialog.ShowDialog() == DialogResult.OK )
                        {
                            Properties.Settings.Default.groupSavePath = Path.GetDirectoryName( cardSaveFileDialog.FileName );
                            Properties.Settings.Default.Save();

                            try
                            {
                                GroupStorage.SaveAs( group, cardSaveFileDialog.FileName );
                            }
                            catch( Exception ex )
                            {
                                MessageBox.Show( "Die Gruppe konnte nicht exportiert werden: " + ex.Message );
                            }
                        }
                    }
                }
            }
        }

        private static bool IsValid( Group group )
        {
            if( group.GroupActorList.Exists( x => x.ActorOutfit == null ) )
            {
                MessageBox.Show( "Bei mindestens einem Modell fehlt noch ein Outfit!" );

                return ( false );
            }
            else if( group.GroupActorList.Exists( x => x == null ) )
            {
                MessageBox.Show( "Mindestens ein Modell wurde gelöscht!" );

                return ( false );
            }

            return ( true );
        }

        private void GroupManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Close();
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewGroups_CellPainting( object sender, DataGridViewCellPaintingEventArgs e )
        {
            if( e.ColumnIndex == nameDataGridViewTextBoxColumn.Index && e.RowIndex != -1 )
            {
                Group group = (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem;

                Image imgInactiveActors = null;
                Image imgMissingActorOutfits = null;

                if( group.HasMissingActors() )
                {
                    imgInactiveActors = Properties.Resources.exclamation_red;
                }

                if( group.HasMissingActorOutfits() )
                {
                    imgMissingActorOutfits = Properties.Resources.exclamation;
                }

                if( imgInactiveActors != null || imgMissingActorOutfits != null )
                {
                    e.PaintBackground( e.CellBounds, true );
                    e.PaintContent( e.CellBounds );

                    if( imgInactiveActors != null && imgMissingActorOutfits != null )
                    {
                        e.Graphics.DrawImageUnscaled( imgMissingActorOutfits, e.CellBounds.X + e.CellBounds.Width - (int)( imgMissingActorOutfits.Width * 1.5 ) - imgInactiveActors.Width, e.CellBounds.Y + ( ( e.CellBounds.Height - imgMissingActorOutfits.Height ) / 2 ) );
                        e.Graphics.DrawImageUnscaled( imgInactiveActors, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveActors.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveActors.Height ) / 2 ) );
                    }
                    else if( imgInactiveActors != null && imgMissingActorOutfits == null )
                    {
                        e.Graphics.DrawImageUnscaled( imgInactiveActors, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveActors.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveActors.Height ) / 2 ) );
                    }
                    else if( imgInactiveActors == null && imgMissingActorOutfits != null )
                    {
                        e.Graphics.DrawImageUnscaled( imgMissingActorOutfits, e.CellBounds.X + e.CellBounds.Width - (int)( imgMissingActorOutfits.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgMissingActorOutfits.Height ) / 2 ) );
                    }

                    e.Handled = true;
                }
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewGroups, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroup( (Group)dataGridViewGroups.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroups_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroup( (Group)dataGridViewGroups.CurrentRow.DataBoundItem );
            }
        }
    }
}
