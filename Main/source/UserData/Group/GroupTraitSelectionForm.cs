using System;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupTraitSelectionForm : Form
    {
        public GroupTraitSelectionForm( Faction faction )
        {
            InitializeComponent();

            m_factionFilter = faction;

            updateDataGridViewGroupTraits();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Faction m_factionFilter;

        private void updateDataGridViewGroupTraits()
        {
            groupTraitBindingSource.DataSource = MasterDataStorage.GroupTrait.GroupTraits.Where( s => s.Active )
                                                                                         .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                         .Where( s => s.FactionPermissions?.Granted( m_factionFilter ) ?? true )
                                                                                         .Where( s => toolStripMenuItemPositives.Checked ? true : ( s.PointsPerModel <= 0 ) )
                                                                                         .Where( s => toolStripMenuItemNegatives.Checked ? true : ( s.PointsPerModel >= 0 ) )
                                                                                         .Where( s => toolStripMenuItemNeutrals.Checked ? true : ( s.PointsPerModel != 0 ) )
                                                                                         .OrderBy( x => x.Name )
                                                                                         .ToList();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            if( dataGridViewGroupTraits.SelectedRows.Count == 1 )
            {
                GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.Rows[ dataGridViewGroupTraits.SelectedRows[ 0 ].Index ].DataBoundItem;
                if( null != groupTrait )
                {
                    SelectedGroupTrait = groupTrait;
                }
            }

            Close();
        }

        public GroupTrait SelectedGroupTrait
        {
            get;
            private set;
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewGroupTraits();
        }

        private void dataGridViewGroupTraits_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.Rows[ e.RowIndex ].DataBoundItem;
                if( null != groupTrait )
                {
                    SelectedGroupTrait = groupTrait;
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewGroupTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                GroupTrait groupTrait = (GroupTrait)dataGridViewGroupTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = groupTrait.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( groupTrait.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewGroupTraits_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
                CloseWithSelected();
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewGroupTraits, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }

        private void toolStripMenuItemPositives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewGroupTraits();
        }

        private void toolStripMenuItemNegatives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewGroupTraits();
        }

        private void toolStripMenuItemNeutrals_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewGroupTraits();
        }
    }
}
