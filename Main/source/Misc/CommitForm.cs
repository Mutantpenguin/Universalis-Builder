using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class CommitForm : Form
    {
        public CommitForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
        }

        public String CommitMessage = String.Empty;

        private void buttonCommit_Click( object sender, EventArgs e )
        {
            CommitMessage = textBoxCommitMessage.Text;
        }

        private void textBoxCommitMessage_TextChanged( object sender, EventArgs e )
        {
            if( !String.IsNullOrEmpty( textBoxCommitMessage.Text ) )
            {
                buttonCommit.Enabled = true;
            }
            else
            {
                buttonCommit.Enabled = false;
            }
        }
    }
}
