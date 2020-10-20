using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArchetypeManagerForm : Form
    {
        public ArchetypeManagerForm()
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            filterFaction.ComboBox.DataSource = MasterDataStorage.Faction.Factions.OrderBy( x => x.Name )
                                                                                  .ToList();
            filterFaction.ComboBox.DisplayMember = nameof(Faction.Name);
            filterFaction.ComboBox.SelectionChangeCommitted += FilterFaction_SelectionChangeCommitted;

            filterType.ComboBox.DataSource = Profile.ETypeList;
            filterType.ComboBox.SelectionChangeCommitted += FilterType_SelectionChangeCommitted;

            dataGridViewArchetypes.CellFormatting += DataGridViewArchetypes_CellFormatting;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void DataGridViewArchetypes_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewArchetypes );
        }

        private void FilterFaction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            refreshGridView();
        }

        private void FilterType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            refreshGridView();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void refreshGridView()
        {
            List<Archetype> archetype = MasterDataStorage.Archetype.Archetypes.Where( s => filterFaction.Enabled ? s.Faction.ID == ((Faction)filterFaction.ComboBox.SelectedValue).ID : true )
                                                                              .Where( s => filterType.Enabled ? s.Profile.Type == ((Profile.EType)filterType.ComboBox.SelectedValue) : true )
                                                                              .Where( s => s.Name.ToUpper().Contains(toolStripTextBoxSearch.Text.ToUpper()))
                                                                              .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                              .OrderBy( x => x.Name )
                                                                              .ToList();

            archetypeBindingSource.DataSource = archetype;
            dataGridViewArchetypes.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {archetype.Count}";
        }

        private void toolStripButtonArchetypeAdd_Click( object sender, EventArgs e )
        {
            using( FactionSelectionForm factionSelectionForm = new FactionSelectionForm() )
            {
                if( factionSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( factionSelectionForm.SelectedFaction != null )
                    {
                        Archetype archetype = MasterDataStorage.Archetype.Create( factionSelectionForm.SelectedFaction );

                        toolStripTextBoxSearch.Text = String.Empty;
                        refreshGridView();

                        editArchetype( archetype );

                        dataGridViewArchetypes.ClearSelection();
                        foreach( DataGridViewRow row in dataGridViewArchetypes.Rows )
                        {
                            if( archetype.ID == ((Archetype)row.DataBoundItem).ID )
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButtonArchetypeDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetypes.SelectedCells.Count > 0 )
            {
                Archetype archetype = (Archetype)dataGridViewArchetypes.SelectedRows[ 0 ].DataBoundItem;

                var actorsWithArchetype = MasterDataStorage.Actor.ActorsWithArchetype( archetype );

                if( actorsWithArchetype.Any() )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithArchetype ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else if( MessageBox.Show( $"Archetyp '{archetype.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Archetype.Delete( archetype );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetypes.SelectedRows.Count > 0 )
            {
                Archetype archetypeSource = (Archetype)dataGridViewArchetypes.SelectedRows[ 0 ].DataBoundItem;

                Archetype archetypeNew = MasterDataStorage.Archetype.Create( archetypeSource.Faction );
                archetypeNew.Set( archetypeSource );
                archetypeNew.Name = $"(Kopie von) {archetypeSource.Name}";
                MasterDataStorage.Archetype.Save( archetypeNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editArchetype( archetypeNew );
            }
        }

        private void dataGridViewArchetype_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editArchetype( (Archetype)dataGridViewArchetypes.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editArchetype( Archetype archetype )
        {
            using( ArchetypeEditorForm archetypeEditorForm = new ArchetypeEditorForm( archetype ) )
            {
                this.Hide();

                archetypeEditorForm.ShowDialog( this );

                this.Show();
            }

            archetypeBindingSource.ResetBindings( false );
        }

        private void ArchetypeManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewArchetype_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Archetype archetype = (Archetype)dataGridViewArchetypes.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( archetype.Description );
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetypes.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithArchetype( (Archetype)dataGridViewArchetypes.SelectedRows[ 0 ].DataBoundItem ) ) )
                {
                    actorDisplay.ShowDialog( this );
                }
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewArchetypes, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editArchetype( (Archetype)dataGridViewArchetypes.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewArchetype_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editArchetype( (Archetype)dataGridViewArchetypes.CurrentRow.DataBoundItem );
            }
        }

        private void checkBoxFilterFaction_Click(object sender, EventArgs e)
        {
            filterFaction.Enabled = !filterFaction.Enabled;

            checkBoxFilterFaction.Image = checkBoxFilterFaction.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }

        private void checkBoxFilterType_Click(object sender, EventArgs e)
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }
    }
}
