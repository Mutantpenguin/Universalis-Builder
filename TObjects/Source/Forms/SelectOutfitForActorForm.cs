using System;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class SelectOutfitForActorForm : Form
    {
        public SelectOutfitForActorForm( Actor actor )
        {
            InitializeComponent();

            actorOutfitBindingSource.DataSource = actor.ActorOutfitsList.OrderBy( x => x.Name );

            textBoxActorName.Text = actor.Name;
        }

        public Actor.ActorOutfit SelectedOutfit
        {
            get;
            private set;
        }

        private void dataGridViewOutfits_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            this.DialogResult = DialogResult.OK;

            SelectedOutfit = (Actor.ActorOutfit)dataGridViewOutfits.Rows[ e.RowIndex ].DataBoundItem;

            Close();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            if( dataGridViewOutfits.SelectedRows.Count == 1 )
            {
                SelectedOutfit = (Actor.ActorOutfit)dataGridViewOutfits.SelectedRows[ 0 ].DataBoundItem;

                Close();
            }
        }

        private void dataGridViewOutfits_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
                CloseWithSelected();
            }
        }
    }
}
