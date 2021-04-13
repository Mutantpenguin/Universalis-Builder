using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universalis
{
    public partial class CloneForm : Form
    {
        BackgroundWorker BackgroundWorkerClone = new BackgroundWorker();

        readonly string UniversesPath;
        readonly Uri RepositoryURL;

        public CloneForm( string universesPath, Uri repositoryURL )
        {
            UniversesPath = universesPath;
            RepositoryURL = repositoryURL;

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
                this.DialogResult = DialogResult.OK;
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

            Repository.Clone( RepositoryURL.ToString(), Path.Combine( UniversesPath, Guid.NewGuid().ToString() ), co );
        }
    }
}
