using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FormSplash : Form
    {
        public FormSplash( Options options )
        {
            Options = options;

            using( var player = new System.Media.SoundPlayer( Shared.Properties.Resources.startup_sound ) )
            {
                player.Play();
            }

            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            timerFadeIn.Start();
        }

        private readonly Options Options;

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

                ShowUniverseSelectionForm();
            }
        }

        private void ShowUniverseSelectionForm()
        {
            this.Hide();
            
            var form = new UniverseSelectionForm( Options );

            form.FormClosed += delegate
            {
                form.Dispose();
                this.Close();
            };
            
            form.Show( this );
        }

        private void FormSplash_KeyDown( object sender, KeyEventArgs e )
        {
            EndPrematurely();
        }

        private void FormSplash_MouseClick( object sender, MouseEventArgs e )
        {
            EndPrematurely();
        }

        private void EndPrematurely()
        {
            timerFadeIn.Stop();
            timerWait.Stop();
            timerFadeOut.Stop();

            ShowUniverseSelectionForm();
        }
    }
}
