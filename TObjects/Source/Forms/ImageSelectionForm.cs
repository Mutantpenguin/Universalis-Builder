using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ImageSelectionForm : Form
    {
        public ImageSelectionForm( string title, Image img, Size maxImageSize )
        {
            InitializeComponent();

            this.Text = title;

            m_maxImageSize = maxImageSize;

            m_rectSizeProportion = new PointF( 1.0f, (float)maxImageSize.Height / maxImageSize.Width );

            CalculateRectangle();

            this.MouseWheel += ImageSelectionForm_MouseWheel;

            pictureBoxImage.Image = img;
        }

        public Image Image
        {
            get;
            private set;
        }

        private void ImageSelectionForm_MouseWheel( object sender, MouseEventArgs e )
        {
            if( e.Delta > 0 )
            {
                m_zoom -= zoomStep;
            }
            else
            {
                m_zoom += zoomStep;
            }

            CalculateRectangle();

            pictureBoxImage.Invalidate();
        }

        private void CalculateRectangle()
        {
            m_rectSizeX = Convert.ToInt32( baseSize * m_rectSizeProportion.X * ( 1.0f + ( m_zoom / 100.0f ) ) );
            m_rectSizeY = Convert.ToInt32( baseSize * m_rectSizeProportion.Y * ( 1.0f + ( m_zoom / 100.0f ) ) );
        }

        private void ImageSelectionForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private readonly Size m_maxImageSize;

        private readonly PointF m_rectSizeProportion;

        private int m_zoom = 0;

        private const int zoomStep = 5;

        private const int baseSize = 80;

        private int m_rectSizeX;
        private int m_rectSizeY;

        private void pictureBoxImage_Paint( object sender, PaintEventArgs e )
        {
            using( Pen pen = new Pen( Color.Red, 1 ) )
            {
                e.Graphics.DrawRectangle( pen, GetRectangleForSelection() );
            }
        }

        private Rectangle GetRectangleForSelection()
        {
            Point localMousePosition = this.PointToClient( MousePosition );

            int posX = localMousePosition.X;
            int posY = localMousePosition.Y;
            int sizeX = ( 2 * m_rectSizeX ) - 1;
            int sizeY = ( 2 * m_rectSizeY ) - 1;

            if( posY + m_rectSizeY >= pictureBoxImage.Height )
            {
                posY = pictureBoxImage.Height - m_rectSizeY;
            }
            else if( posY - m_rectSizeY <= 0 )
            {
                posY = m_rectSizeY;
            }

            if( posX + m_rectSizeX >= pictureBoxImage.Width )
            {
                posX = pictureBoxImage.Width - m_rectSizeX;
            }
            else if( posX - m_rectSizeX <= 0 )
            {
                posX = m_rectSizeX;
            }

            return ( new Rectangle( posX - m_rectSizeX, posY - m_rectSizeY, sizeX, sizeY ) );
        }

        private void pictureBoxImage_MouseMove( object sender, MouseEventArgs e )
        {
            pictureBoxImage.Invalidate();
        }

        private void pictureBoxImage_MouseClick( object sender, MouseEventArgs e )
        {
            if( pictureBoxImage.Image != null )
            {
                Image img = pictureBoxImage.Image;

                double scaleScreen = (float)pictureBoxImage.Width / pictureBoxImage.Height;
                double scaleImage = (float)img.Width / img.Height;

                Rectangle rectMark = GetRectangleForSelection();

                int x, y;
                double scaleX, scaleY;

                if( scaleScreen >= scaleImage )
                {
                    double imageWidthScreen = (float)img.Width / img.Height * pictureBoxImage.Height;

                    scaleX = (float)img.Width / imageWidthScreen;
                    scaleY = (float)img.Height / pictureBoxImage.Height;

                    x = Convert.ToInt32( ( rectMark.X - ( pictureBoxImage.Width - imageWidthScreen ) / 2 ) * scaleX );
                    y = Convert.ToInt32( rectMark.Y * scaleY );
                }
                else
                {
                    double imageHeightScreen = (float)img.Height / img.Width * pictureBoxImage.Width;

                    scaleX = (float)img.Width / pictureBoxImage.Width;
                    scaleY = (float)img.Height / imageHeightScreen;

                    x = Convert.ToInt32( rectMark.X * scaleX );
                    y = Convert.ToInt32( ( rectMark.Y - ( pictureBoxImage.Height - imageHeightScreen ) / 2 ) * scaleY );
                }

                int width = Convert.ToInt32( rectMark.Width * scaleX );
                int height = Convert.ToInt32( rectMark.Height * scaleY );

                if( width > m_maxImageSize.Width
                    ||
                    height > m_maxImageSize.Height )
                {
                    Image = new Bitmap( m_maxImageSize.Width, m_maxImageSize.Height );
                }
                else
                {
                    Image = new Bitmap( width, height );
                }

                using( Graphics g = Graphics.FromImage( Image ) )
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.Clear( Color.White );

                    g.DrawImage( pictureBoxImage.Image, new Rectangle( Point.Empty, Image.Size ), new Rectangle( x, y, width, height ), GraphicsUnit.Pixel );
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
