using System;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class EnterNameForm : Form
    {
        public EnterNameForm( string outfitName, bool emptyNameAllowed )
        {
            InitializeComponent();

            textBoxName.Text = outfitName;

            m_emptyNameAllowed = emptyNameAllowed;
        }

        private bool m_emptyNameAllowed;

        public string NewName
        {
            get
            {
                return ( textBoxName.Text );
            }
        }

        private void EnterNameForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( this.DialogResult == DialogResult.OK )
            {
                if( !m_emptyNameAllowed )
                {
                    if( String.IsNullOrEmpty( textBoxName.Text ) )
                    {
                        MessageBox.Show( "Der Name darf nicht leer sein!",
                                         String.Empty,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Stop );
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
