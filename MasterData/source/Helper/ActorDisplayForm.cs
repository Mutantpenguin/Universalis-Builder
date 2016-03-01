using System.Collections.Generic;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class ActorDisplayForm : Form
    {
        public ActorDisplayForm( IEnumerable<Actor> actorList )
        {
            InitializeComponent();

            actorBindingSource.DataSource = actorList;
        }

        private void ActorDisplayForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }
    }
}
