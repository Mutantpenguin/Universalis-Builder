using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddEquipmentToActorForm : Form
    {
        public AddEquipmentToActorForm(Faction faction, Archetype archetype )
        {
            InitializeComponent();

            m_faction = faction;
            m_archetype = archetype;

            updateDataGridViewEquipment();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Faction m_faction;
        private readonly Archetype m_archetype;

        private void DataGridViewEquipment_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewEquipment );
        }

        private void updateDataGridViewEquipment()
        {
            equipmentBindingSource.DataSource = MasterDataStorage.Equipment.Equipments.Where( s => s.Active )
                                                                                      .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                      .Where( s => s.Permissions?.Granted(m_faction, m_archetype ) ?? true )
                                                                                      .OrderBy( x => x.Name )
                                                                                      .ToList();
        }

        public List<Equipment> SelectedEquipment
        {
            get;
            private set;
        }

        private void dataGridViewEquipment_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedEquipment = new List<Equipment>
                {
                    (Equipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewEquipment();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            SelectedEquipment = new List<Equipment>();

            for( int i = 0; i < dataGridViewEquipment.SelectedRows.Count; i++ )
            {
                SelectedEquipment.Add( (Equipment)dataGridViewEquipment.Rows[ dataGridViewEquipment.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        private void dataGridViewEquipment_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Equipment equipment = (Equipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = equipment.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( equipment.Rules );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewEquipment_KeyDown( object sender, KeyEventArgs e )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewEquipment, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}
