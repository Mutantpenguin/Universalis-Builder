using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FormSplash : Form
    {
        public FormSplash( UniverseSelectionForm.FormToOpen formToOpen )
        {
            this.formToOpen = formToOpen;

            using( var player = new System.Media.SoundPlayer( Shared.Properties.Resources.startup_sound ) )
            {
                player.Play();
            }

            InitializeComponent();

            timerFadeIn.Start();
        }

        private readonly UniverseSelectionForm.FormToOpen formToOpen;

        const double fadeInTime = 2500.0;
        const double fadeOutTime = 2000.0;

        private void timerFadeIn_Tick( object sender, EventArgs e )
        {
            this.Opacity += 1.0 / ( fadeInTime / timerFadeIn.Interval );

            if( this.Opacity >= 1 )
            {
                timerFadeIn.Stop();

                timerWait.Start();
            }
        }

        private void timerWait_Tick( object sender, EventArgs e )
        {
            timerWait.Stop();

            timerFadeOut.Start();
        }

        private void timerFadeOut_Tick( object sender, EventArgs e )
        {
            this.Opacity -= 1.0 / ( fadeOutTime / timerFadeOut.Interval );

            if( this.Opacity <= 0 )
            {
                timerFadeOut.Stop();

                this.Hide();

                using( var form = new UniverseSelectionForm( formToOpen ) )
                {
                    form.ShowDialog( this );
                }

                this.Close();
            }
        }
    }
}
