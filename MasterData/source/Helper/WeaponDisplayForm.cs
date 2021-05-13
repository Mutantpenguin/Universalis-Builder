using System.Collections.Generic;
using System.Windows.Forms;

namespace Universalis
{
    public partial class WeaponDisplayForm : Form
    {
        public WeaponDisplayForm( IEnumerable<Weapon> weaponList )
        {
            InitializeComponent();

            weaponBindingSource.DataSource = weaponList;
        }

        private void WeaponDisplayForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewWeapons_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                Weapon weapon = (Weapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem;

                using( WeaponEditorForm weaponEditorForm = new WeaponEditorForm( weapon ) )
                {
                    weaponEditorForm.ShowDialog( this );
                }
            }
        }
    }
}
