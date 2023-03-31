using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ActorWebcamImageForm : Form
    {
        public ActorWebcamImageForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                components?.Dispose();

                pictureBoxWebcam.Image?.Dispose();
            }

            base.Dispose( disposing );
        }

        public Image Image;

        private void buttonWebcam_Click( object sender, EventArgs e )
        {
            Image = (Image)pictureBoxWebcam.Image.Clone();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        VideoCaptureDevice videoCaptureDevice;

        private void ActorImageForm_Load( object sender, EventArgs e )
        {
            var filterInfoCollection = new FilterInfoCollection( FilterCategory.VideoInputDevice );

            if( filterInfoCollection.Count == 0 )
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                VideoCaptureDeviceForm form = new VideoCaptureDeviceForm();
                switch (form.ShowDialog())
                {
                    case DialogResult.OK:
                        videoCaptureDevice = form.VideoDevice;
                        videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                        videoCaptureDevice.Start();

                        break;

                    default:
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();

                        break;
                }
            }
        }

        private void VideoCaptureDevice_NewFrame( object sender, AForge.Video.NewFrameEventArgs eventArgs )
        {
            pictureBoxWebcam.Image?.Dispose();
            pictureBoxWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void ActorImageForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( videoCaptureDevice?.IsRunning == true )
            {
                videoCaptureDevice.Stop();
            }
        }

        private void ActorImageForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }
    }
}
