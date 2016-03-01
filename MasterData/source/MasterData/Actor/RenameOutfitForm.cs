using System;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class RenameOutfitForm : Form
    {
        public RenameOutfitForm( string outfitName )
        {
            InitializeComponent();

            textBoxName.Text = outfitName;
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Der Name darf nicht leer sein!" );
            }
            else
            {
                Close();
            }
        }

        public string NameNew
        {
            get
            {
                return ( textBoxName.Text );
            }
        }
    }
}
