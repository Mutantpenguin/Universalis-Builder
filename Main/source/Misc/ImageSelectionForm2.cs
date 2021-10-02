using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ImageSelectionForm2 : Form
    {
        public ImageSelectionForm2( string title, Image img, Size maxImageSize )
        {
            InitializeComponent();

            this.Text = title;

            m_maxImageSize = maxImageSize;

            m_img = img;

            movingPoint.X = Convert.ToInt32( ( pictureBoxImage.Width / 2 ) - ( m_img.Width / 2 ) );
            movingPoint.Y = Convert.ToInt32( ( pictureBoxImage.Height / 2 ) - ( m_img.Height / 2 ) );

            transform.Translate( movingPoint.X, movingPoint.Y );

            pictureBoxImage.Select();

            ClientSize = new Size( 100, 200 );

            pictureBoxImage.MouseWheel += PictureBoxImage_MouseWheel;
        }

        private void ImageSelectionForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        public Image Image
        {
            get;
            private set;
        }

        Matrix transform = new Matrix();

        private const float s_dScaleValue = 0.1f;

        private readonly Image m_img;

        private readonly Size m_maxImageSize;

        private const int baseSize = 80;

        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        private void pictureBoxImage_Paint( object sender, PaintEventArgs e )
        {
            e.Graphics.Clear( Color.White );

            e.Graphics.Transform = transform;

            e.Graphics.DrawImage( m_img, Point.Empty );
        }

        private void pictureBoxImage_MouseDown( object sender, MouseEventArgs e )
        {
            pictureBoxImage.Cursor = Cursors.NoMove2D;

            panning = true;

            startingPoint = e.Location;
        }

        private void pictureBoxImage_MouseUp( object sender, MouseEventArgs e )
        {
            pictureBoxImage.Cursor = Cursors.SizeAll;

            panning = false;
        }

        private void pictureBoxImage_MouseMove( object sender, MouseEventArgs e )
        {
            if( panning )
            {
                movingPoint = new Point( e.Location.X - startingPoint.X, e.Location.Y - startingPoint.Y );

                startingPoint = e.Location;

                transform.Translate( movingPoint.X, movingPoint.Y, MatrixOrder.Append );

                pictureBoxImage.Invalidate();
            }
        }

        private void PictureBoxImage_MouseWheel( object sender, MouseEventArgs e )
        {
            if( pictureBoxImage.Focused && e.Delta != 0 )
            {
                transform.Translate( -e.Location.X, -e.Location.Y, MatrixOrder.Append );

                if( e.Delta > 0 )
                {
                    transform.Scale( 1 + s_dScaleValue, 1 + s_dScaleValue, MatrixOrder.Append );
                }
                else
                {
                    transform.Scale( 1 - s_dScaleValue, 1 - s_dScaleValue, MatrixOrder.Append );
                }

                transform.Translate( e.Location.X, e.Location.Y, MatrixOrder.Append );

                pictureBoxImage.Invalidate();
            }
        }
    }
}
