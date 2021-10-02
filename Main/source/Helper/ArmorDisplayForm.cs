using System.Collections.Generic;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArmorDisplayForm : Form
    {
        public ArmorDisplayForm( IEnumerable<Armor> armorList )
        {
            InitializeComponent();

            armorBindingSource.DataSource = armorList;
        }

        private void ArmorDisplayForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewArmors_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                Armor armor = (Armor)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem;

                using( ArmorEditorForm armorEditorForm = new ArmorEditorForm( armor ) )
                {
                    armorEditorForm.ShowDialog( this );
                }
            }
        }
    }
}
