using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class EquipmentManagerForm : Form
    {
        public EquipmentManagerForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void refreshGridView()
        {
            List<Equipment> equipment = EquipmentStorage.Instance.Equipments.Where( s => s.Active )
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
            Equipment equipment = EquipmentStorage.Instance.Create();

            toolStripTextBoxSearch.Text = String.Empty;
            refreshGridView();

            editEquipment( equipment );

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

                var actorsWithEquipment = ActorStorage.Instance.ActorsWithEquipment( equipment );

                if( actorsWithEquipment.Count() > 0 )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithEquipment ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else if( MessageBox.Show( $"Ausrüstung '{equipment.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    EquipmentStorage.Delete( equipment );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewEquipment.SelectedRows.Count > 0 )
            {
                Equipment equipmentSource = (Equipment)dataGridViewEquipment.SelectedRows[ 0 ].DataBoundItem;

                Equipment equipmentNew = EquipmentStorage.Instance.Create();
                equipmentNew.Set( equipmentSource );
                equipmentNew.Name = $"(Kopie von) {equipmentSource.Name}";
                EquipmentStorage.Save( equipmentNew );

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
                equipmentEditorForm.FormClosed += delegate
                {
                    this.Show();

                    this.BeginInvoke( new MethodInvoker( () => this.dataGridViewEquipment.Focus() ) );
                };

                this.Hide();

                equipmentEditorForm.ShowDialog( this );
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

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewEquipment.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithEquipment( (Equipment)dataGridViewEquipment.SelectedRows[ 0 ].DataBoundItem ) ) )
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
