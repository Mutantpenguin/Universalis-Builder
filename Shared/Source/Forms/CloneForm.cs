using LibGit2Sharp;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public partial class CloneForm : Form
    {
        private BackgroundWorker BackgroundWorkerClone = new BackgroundWorker();

        private readonly Uri RepositoryURL;

        public string UniversePath
        {
            get;
            private set;
        }

        public CloneForm( string universesPath, Uri repositoryURL )
        {
            RepositoryURL = repositoryURL;

            UniversePath = Path.Combine( universesPath, Guid.NewGuid().ToString() );

            InitializeComponent();

            labelObjects.Text = String.Empty;
            labelBytes.Text = String.Empty;

            BackgroundWorkerClone.DoWork += BackgroundWorkerClone_DoWork;

            BackgroundWorkerClone.RunWorkerAsync();

            BackgroundWorkerClone.RunWorkerCompleted += BackgroundWorkerClone_RunWorkerCompleted;
        }

        private void BackgroundWorkerClone_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            if( e.Error != null )
            {
                MessageBox.Show( e.Error.Message );

                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                if( Universe.Load( UniversePath ) == null )
                {
                    MessageBox.Show( "This is not a valid universe!",
                                     "Invalid universe",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );

                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }

            this.Close();
        }

        private void BackgroundWorkerClone_DoWork( object sender, DoWorkEventArgs e )
        {
            var co = new CloneOptions()
            {
                OnTransferProgress = progress =>
                {
                    this.Invoke( new MethodInvoker( () =>
                    {
                        labelObjects.Text = $"{progress.ReceivedObjects}/{progress.TotalObjects}";
                        labelBytes.Text = $"{Math.Round((decimal)progress.ReceivedBytes / 1024 / 1024, 3 )} MiB";
                    } ) );

                    return ( true );
                }
            };

            Repository.Clone( RepositoryURL.ToString(), UniversePath, co );
        }
    }
}
