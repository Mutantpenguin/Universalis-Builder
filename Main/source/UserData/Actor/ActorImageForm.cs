using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ActorImageForm : Form
    {
        public ActorImageForm()
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

        private void buttonUpload_Click( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.imageFilePath;

                if( iconFileDialog.ShowDialog( this ) == DialogResult.OK )
                {
                    Properties.Settings.Default.imageFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    Image = ImageHelper.LoadImage( iconFileDialog.FileName );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void buttonWebcam_Click( object sender, EventArgs e )
        {
            Image = (Image)pictureBoxWebcam.Image.Clone();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        private void ActorImageForm_Load( object sender, EventArgs e )
        {
            filterInfoCollection = new FilterInfoCollection( FilterCategory.VideoInputDevice );

            if( filterInfoCollection.Count > 0 )
            {
                foreach( FilterInfo Device in filterInfoCollection )
                {
                    comboBoxCameraDevice.Items.Add( Device.Name );
                }

                comboBoxCameraDevice.SelectedIndex = 0;
            }
            else
            {
                buttonWebcam.Enabled = false;
                comboBoxCameraDevice.Enabled = false;
                pictureBoxWebcam.Visible = false;
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

        private void comboBoxCameraDevice_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( videoCaptureDevice != null )
            {
                videoCaptureDevice.Stop();

                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            }

            videoCaptureDevice = new VideoCaptureDevice( filterInfoCollection[ comboBoxCameraDevice.SelectedIndex ].MonikerString );

            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;

            videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities[ videoCaptureDevice.VideoCapabilities.Length - 1 ];

            videoCaptureDevice.Start();
        }
    }
}
