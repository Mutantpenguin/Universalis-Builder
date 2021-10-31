using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddWeaponToActorForm : Form
    {
        public AddWeaponToActorForm()
        {
            InitializeComponent();

            filterWeaponClass.ComboBox.DataSource = Weapon.EClassList;
            filterWeaponClass.ComboBox.SelectedIndex = 0;
            filterWeaponClass.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            filterType.ComboBox.DataSource = Weapon.ETypeList;
            filterType.ComboBox.SelectedIndex = 0;
            filterType.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            updateDataGridViewWeapons();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void DataGridViewWeapons_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewWeapons );
        }

        private void updateDataGridViewWeapons()
        {
            weaponBindingSource.DataSource = MasterDataStorage.Weapon.Weapons.Where( s => s.Active )
                                                                             .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                             .Where( s => filterWeaponClass.Enabled ? s.Class == (Weapon.EClass)filterWeaponClass.ComboBox.SelectedItem : true )
                                                                             .Where( s => filterType.Enabled ? s.Type == (Weapon.EType)filterType.ComboBox.SelectedItem : true )
                                                                             .OrderBy( x => x.Name )
                                                                             .ToList();
        }

        void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            updateDataGridViewWeapons();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            SelectedWeapons = new List<Weapon>();

            for( int i = 0; i < dataGridViewWeapons.SelectedRows.Count; i++ )
            {
                SelectedWeapons.Add( (Weapon)dataGridViewWeapons.Rows[ dataGridViewWeapons.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        public List<Weapon> SelectedWeapons
        {
            get;
            private set;
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewWeapons();
        }

        private void dataGridViewWeapons_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedWeapons = new List<Weapon>
                {
                    (Weapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void checkBoxFilterWeaponClass_Click( object sender, EventArgs e )
        {
            filterWeaponClass.Enabled = !filterWeaponClass.Enabled;

            checkBoxFilterWeaponClass.Image = checkBoxFilterWeaponClass.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            updateDataGridViewWeapons();
        }

        private void checkBoxFilterType_Click( object sender, EventArgs e )
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            updateDataGridViewWeapons();
        }

        private void dataGridViewWeapons_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Weapon weapon = (Weapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = weapon.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( weapon.Rules );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewWeapons_KeyDown( object sender, KeyEventArgs e )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewWeapons, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}
