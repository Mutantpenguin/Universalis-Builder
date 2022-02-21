using System;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddArmorToActorForm : Form
    {
        public AddArmorToActorForm( Archetype archetype )
        {
            InitializeComponent();

            m_archetype = archetype;

            updateDataGridViewArmor();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Archetype m_archetype;

        private void DataGridViewArmor_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewArmor );
        }

        private void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            updateDataGridViewArmor();
        }

        private void updateDataGridViewArmor()
        {
            armorBindingSource.DataSource = MasterDataStorage.Armor.Armors.Where( s => s.Active )
                                                                          .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                          .Where( s => s.Permissions != null ? s.Permissions.Granted( m_archetype ) : true )
                                                                          .OrderBy( x => x.Name )
                                                                          .ToList();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            if( dataGridViewArmor.SelectedRows.Count == 1 )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ dataGridViewArmor.SelectedRows[ 0 ].Index ].DataBoundItem;
                if( null != armor )
                {
                    SelectedArmor = armor;
                }
            }

            Close();
        }

        public Armor SelectedArmor
        {
            get;
            private set;
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewArmor();
        }

        private void dataGridViewArmor_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;
                if( null != armor )
                {
                    SelectedArmor = armor;
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewArmor_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = armor.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( armor.Rules );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewArmor_KeyDown( object sender, KeyEventArgs e )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewArmor, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}
