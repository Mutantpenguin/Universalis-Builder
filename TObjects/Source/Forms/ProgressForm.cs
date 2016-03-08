using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            using( var player = new SoundPlayer( TObjects.Properties.Resources.startup_sound ) )
            {
                player.Play();
            }

            InitializeComponent();
        }

        private bool m_automaticClose = false;
        private List<BackgroundWorker> m_backgroundWorker = new List<BackgroundWorker>();

        private void ProgressForm_Load( object sender, System.EventArgs e )
        {
            processBackgroundWorker();
        }

        private void processBackgroundWorker()
        {
            if( m_backgroundWorker.Count > 0 )
            {
                m_backgroundWorker[ 0 ].RunWorkerAsync();
            }
            else
            {
                m_automaticClose = true;
                Close();
            }
        }

        public BackgroundWorker CreateBackgroundWorker()
        {
            BackgroundWorker progressorBackgroundWorker = new BackgroundWorker();

            progressorBackgroundWorker.WorkerReportsProgress = true;

            progressorBackgroundWorker.ProgressChanged += ( sender, e ) =>
            {
                progressBar.Value = e.ProgressPercentage;
                textBoxMessage.Text = (string)e.UserState;
            };

            progressorBackgroundWorker.RunWorkerCompleted += ( sender, e ) =>
            {
                m_backgroundWorker.Remove( progressorBackgroundWorker );

                timerProgress.Start();
            };

            m_backgroundWorker.Add( progressorBackgroundWorker );

            return( progressorBackgroundWorker );
        }

        private void timerProgress_Tick( object sender, System.EventArgs e )
        {
            timerProgress.Stop();

            processBackgroundWorker();
        }

        private void ProgressForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            e.Cancel = !m_automaticClose;
        }
    }
}
