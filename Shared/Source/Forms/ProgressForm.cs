using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            using( var player = new SoundPlayer( Shared.Properties.Resources.startup_sound ) )
            {
                player.Play();
            }

            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            labelVersion.Text = $"Version {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString( 2 )}";
            labelVersion.Font = new System.Drawing.Font( UniversalisFont.Family, 8 );

            labelMessage.Font = new System.Drawing.Font( UniversalisFont.Family, 10 );
        }

        private bool m_automaticClose = false;
        private readonly List<BackgroundWorker> m_backgroundWorker = new List<BackgroundWorker>();

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
            int maximumOld = progressBar.Maximum;
            progressBar.Maximum += 100;

            BackgroundWorker progressorBackgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            progressorBackgroundWorker.ProgressChanged += ( sender, e ) =>
            {
                progressBar.Value = maximumOld + e.ProgressPercentage;
                labelMessage.Text = (string)e.UserState;
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
