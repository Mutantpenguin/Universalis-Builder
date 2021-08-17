using System;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArchetypeSelectionForm : Form
    {
        public ArchetypeSelectionForm( Faction faction )
        {
            InitializeComponent();

            m_factionFilter = faction;

            filterType.ComboBox.DataSource = Profile.ETypeList;
            filterType.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            updateDataGridViewArchetypes();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Faction m_factionFilter;

        private void DataGridViewArchetypes_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewArchetypes );
        }

        private void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            updateDataGridViewArchetypes();
        }

        private void updateDataGridViewArchetypes()
        {
            archetypeBindingSource.DataSource = MasterDataStorage.Archetype.Archetypes.Where( s => s.Active )
                                                                                      .Where( s => ( m_factionFilter == null ) || ( m_factionFilter == s.Faction ) )
                                                                                      .Where( s => filterType.Enabled ? s.Profile.Type == ( (Profile.EType)filterType.ComboBox.SelectedValue ) : true )
                                                                                      .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                      .OrderBy( x => x.Name )
                                                                                      .ToList();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            if( dataGridViewArchetypes.SelectedRows.Count == 1 )
            {
                Archetype archetype = (Archetype)dataGridViewArchetypes.Rows[ dataGridViewArchetypes.SelectedRows[ 0 ].Index ].DataBoundItem;
                if( null != archetype )
                {
                    SelectedArchetype = archetype;
                }
            }

            Close();
        }

        public Archetype SelectedArchetype
        {
            get;
            private set;
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewArchetypes();
        }

        private void dataGridViewArchetypes_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                Archetype archetype = (Archetype)dataGridViewArchetypes.Rows[ e.RowIndex ].DataBoundItem;
                if( null != archetype )
                {
                    SelectedArchetype = archetype;
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewArchetypes_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Archetype archetype = (Archetype)dataGridViewArchetypes.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = archetype.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( archetype.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void checkBoxFilterType_Click( object sender, EventArgs e )
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Shared.Properties.Resources.ui_check_box : Shared.Properties.Resources.ui_check_box_uncheck;

            updateDataGridViewArchetypes();
        }

        private void dataGridViewArchetypes_KeyDown( object sender, KeyEventArgs e )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewArchetypes, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}
