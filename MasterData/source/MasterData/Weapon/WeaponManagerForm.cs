using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class WeaponManagerForm : Form
    {
        public WeaponManagerForm()
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            filterWK.ComboBox.DataSource = Weapon.EClassList;
            filterWK.ComboBox.SelectedIndex = 0;
            filterWK.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            filterType.ComboBox.DataSource = Weapon.ETypeList;
            filterType.ComboBox.SelectedIndex = 0;
            filterType.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            filterDamageType.ComboBox.DataSource = DamageType.ETypeList;
            filterDamageType.ComboBox.SelectedIndex = 0;
            filterDamageType.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void refreshGridView()
        {
            List<Weapon> weapons = WeaponStorage.Instance.Weapons.Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                 .Where( s => filterWK.Enabled ? s.WK == (Weapon.EClass)filterWK.ComboBox.SelectedItem : true )
                                                                 .Where( s => filterType.Enabled ? s.Type == (Weapon.EType)filterType.ComboBox.SelectedItem : true )
                                                                 .Where( s => filterDamageType.Enabled ? s.DamageType.Type == (DamageType.EType)filterDamageType.ComboBox.SelectedItem : true )
                                                                 .OrderBy( x => x.Name )
                                                                 .ToList();

            weaponBindingSource.DataSource = weapons;
            dataGridViewWeapons.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {weapons.Count}";
        }

        private void checkBoxFilterWK_Click( object sender, EventArgs e )
        {
            filterWK.Enabled = !filterWK.Enabled;

            checkBoxFilterWK.Image = checkBoxFilterWK.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }

        private void checkBoxFilterDamageType_Click( object sender, EventArgs e )
        {
            filterDamageType.Enabled = !filterDamageType.Enabled;

            checkBoxFilterDamageType.Image = checkBoxFilterDamageType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }

        private void checkBoxFilterType_Click( object sender, EventArgs e )
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonWeaponAdd_Click( object sender, EventArgs e )
        {
            Weapon weapon = WeaponStorage.Instance.Create();

            toolStripTextBoxSearch.Text = String.Empty;
            refreshGridView();

            editWeapon( weapon );

            dataGridViewWeapons.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewWeapons.Rows )
            {
                if( weapon.ID == ( (Weapon)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonWeaponDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewWeapons.SelectedCells.Count > 0 )
            {
                Weapon weapon = (Weapon)dataGridViewWeapons.SelectedRows[ 0 ].DataBoundItem;

                var actorsWithWeapon = ActorStorage.Instance.ActorsWithWeapon( weapon );

                if( actorsWithWeapon.Any() )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithWeapon ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else if( MessageBox.Show( $"Waffe '{weapon.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    WeaponStorage.Instance.Delete( weapon );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewWeapons.SelectedRows.Count > 0 )
            {
                Weapon weaponSource = (Weapon)dataGridViewWeapons.SelectedRows[ 0 ].DataBoundItem;

                Weapon weaponNew = WeaponStorage.Instance.Create();
                weaponNew.Set( weaponSource );
                weaponNew.Name = $"(Kopie von) {weaponSource.Name}";
                WeaponStorage.Save( weaponNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editWeapon( weaponNew );
            }
        }

        private void dataGridViewWeapons_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editWeapon( (Weapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editWeapon( Weapon weapon )
        {
            using( WeaponEditorForm weaponEditorForm = new WeaponEditorForm( weapon ) )
            {
                this.Hide();

                weaponEditorForm.ShowDialog( this );

                this.Show();
            }

            weaponBindingSource.ResetBindings( false );
        }

        private void WeaponManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewWeapons_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Weapon weapon = (Weapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( weapon.Description );
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewWeapons.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithWeapon( (Weapon)dataGridViewWeapons.SelectedRows[ 0 ].DataBoundItem ) ) )
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
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewWeapons, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editWeapon( (Weapon)dataGridViewWeapons.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewWeapons_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editWeapon( (Weapon)dataGridViewWeapons.CurrentRow.DataBoundItem );
            }
        }
    }
}
