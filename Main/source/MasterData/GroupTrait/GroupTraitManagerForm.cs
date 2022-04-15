using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupTraitManagerForm : Form
    {
        public GroupTraitManagerForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            HasPermissions.DefaultCellStyle.NullValue = null;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void refreshGridView()
        {
            List<GroupTrait> groupTraits = MasterDataStorage.GroupTrait.GroupTraits.Where( s => s.Active )
                                                                       .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                       .Where( s => toolStripMenuItemPositives.Checked ? true : ( s.PointsPerModel <= 0 ) )
                                                                       .Where( s => toolStripMenuItemNegatives.Checked ? true : ( s.PointsPerModel >= 0 ) )
                                                                       .Where( s => toolStripMenuItemNeutrals.Checked ? true : ( s.PointsPerModel != 0 ) )
                                                                       .OrderBy( s => s.Name )
                                                                       .ToList();

            groupTraitBindingSource.DataSource = groupTraits;
            dataGridViewGroupTraits.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {groupTraits.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemPositives_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemNegatives_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemNeutrals_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonGroupTraitAdd_Click( object sender, EventArgs e )
        {
            GroupTrait groupTrait = GroupTraitStorage.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editGroupTrait( groupTrait );

            refreshGridView();

            dataGridViewGroupTraits.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewGroupTraits.Rows )
            {
                if( groupTrait.ID == ( (GroupTrait)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonGroupTraitDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroupTraits.SelectedCells.Count > 0 )
            {
                GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Gruppeneigenschaft '{groupTrait.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.GroupTrait.Delete( groupTrait );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroupTraits.SelectedRows.Count > 0 )
            {
                GroupTrait groupTraitSource = (GroupTrait)dataGridViewGroupTraits.SelectedRows[ 0 ].DataBoundItem;

                GroupTrait groupTraitNew = GroupTraitStorage.Create();
                groupTraitNew.Set( groupTraitSource );
                groupTraitNew.Name = $"(Kopie von) {groupTraitSource.Name}";
                MasterDataStorage.GroupTrait.Save( groupTraitNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editGroupTrait( groupTraitNew );
            }
        }

        private void dataGridViewGroupTraits_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editGroupTrait( (GroupTrait)dataGridViewGroupTraits.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editGroupTrait( GroupTrait groupTrait )
        {
            using( GroupTraitEditorForm groupTraitEditorForm = new GroupTraitEditorForm( groupTrait ) )
            {
                this.Hide();

                groupTraitEditorForm.ShowDialog( this );

                this.Show();
            }

            groupTraitBindingSource.ResetBindings( false );
        }

        private void GroupTraitManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewGroupTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( groupTrait.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewGroupTraits, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroupTrait( (GroupTrait)dataGridViewGroupTraits.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroupTraits_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroupTrait( (GroupTrait)dataGridViewGroupTraits.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroupTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            if( e.RowIndex != -1 )
            {
                if( e.ColumnIndex == HasPermissions.Index )
                {
                    GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.Rows[ e.RowIndex ].DataBoundItem;

                    if( groupTrait.FactionPermissions != null )
                    {
                        e.Value = Properties.Resources.outline_key_black_18dp;
                    }
                }
            }
        }
    }
}
