using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class EnterNameForm : Form
    {
        public EnterNameForm( string name, bool emptyNameAllowed )
        {
            InitializeComponent();

            textBoxName.Text = name;

            m_emptyNameAllowed = emptyNameAllowed;
        }

        private readonly bool m_emptyNameAllowed;

        public string NewName => ( textBoxName.Text );

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

        private void buttonRandomName_Click( object sender, EventArgs e )
        {
            MessageBox.Show( "asdasd" );
        }
    }
}
