using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class EquipmentManagerForm : Form
    {
        public EquipmentManagerForm()
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle( Properties.Resources.icon_equipment.GetHicon() );

            HasPermissions.DefaultCellStyle.NullValue = null;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void DataGridViewEquipment_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewEquipment );

            if( e.RowIndex != -1 )
            {
                if( e.ColumnIndex == HasPermissions.Index )
                {
                    Equipment equipment = (Equipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem;

                    if( equipment.Permissions != null )
                    {
                        e.Value = Properties.Resources.outline_key_black_18dp;
                    }
                }
            }
        }

        private void refreshGridView()
        {
            List<Equipment> equipment = MasterDataStorage.Equipment.Equipments.Where( s => s.Active )
                                                                              .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                              .OrderBy( x => x.Name )
                                                                              .ToList();

            equipmentBindingSource.DataSource = equipment;
            dataGridViewEquipment.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {equipment.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonEquipmentAdd_Click( object sender, EventArgs e )
        {
            Equipment equipment = EquipmentStorage.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editEquipment( equipment );

            refreshGridView();

            dataGridViewEquipment.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewEquipment.Rows )
            {
                if( equipment.ID == ( (Equipment)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonEquipmentDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewEquipment.SelectedCells.Count > 0 )
            {
                Equipment equipment = (Equipment)dataGridViewEquipment.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Ausrüstung '{equipment.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Equipment.Delete( equipment );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewEquipment.SelectedRows.Count > 0 )
            {
                Equipment equipmentSource = (Equipment)dataGridViewEquipment.SelectedRows[ 0 ].DataBoundItem;

                Equipment equipmentNew = EquipmentStorage.Create();
                equipmentNew.Set( equipmentSource );
                equipmentNew.Name = $"(Kopie von) {equipmentSource.Name}";
                MasterDataStorage.Equipment.Save( equipmentNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editEquipment( equipmentNew );
            }
        }

        private void dataGridViewEquipment_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editEquipment( (Equipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editEquipment( Equipment equipment )
        {
            using( EquipmentEditorForm equipmentEditorForm = new EquipmentEditorForm( equipment ) )
            {
                this.Hide();

                equipmentEditorForm.ShowDialog( this );

                this.Show();
            }

            equipmentBindingSource.ResetBindings( false );
        }

        private void EquipmentManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewEquipment_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Equipment equipment = (Equipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( equipment.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewEquipment, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editEquipment( (Equipment)dataGridViewEquipment.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewEquipment_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editEquipment( (Equipment)dataGridViewEquipment.CurrentRow.DataBoundItem );
            }
        }
    }
}
