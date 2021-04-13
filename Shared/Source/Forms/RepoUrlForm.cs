using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class RepoUrlForm : Form
    {
        public Uri RepositoryURL
        {
            get;
            private set;
        }

        public RepoUrlForm()
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            try
            {
                RepositoryURL = new Uri( textBoxURL.Text );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch( UriFormatException ex )
            {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
