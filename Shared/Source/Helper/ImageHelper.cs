using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class ImageHelper
    {
        public static readonly Size imageSize = new Size( 400, 700 );
        public static readonly Size iconSize = new Size( 150, 150 );

        public static Image CreateIconFromImage( Image img, bool withTransparency )
        {
            if( null != img )
            {
                if( img.Width == img.Height )
                {
                    Image bmp = new Bitmap( ImageHelper.iconSize.Width, ImageHelper.iconSize.Height );
                    using( Graphics g = Graphics.FromImage( bmp ) )
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        if( !withTransparency )
                        {
                            g.Clear( Color.White );
                        }
                        g.DrawImage( img, new Rectangle( Point.Empty, bmp.Size ), new Rectangle( new Point( 0, 0 ), img.Size ), GraphicsUnit.Pixel );
                    }

                    return bmp;
                }
                else
                {
                    MessageBox.Show( "Es sind nur quadratische Bilder erlaubt!",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Stop );
                }
            }

            return null;
        }

        public static Image LoadImage( string path )
        {
            try
            {
                using( FileStream fs = new FileStream( path, FileMode.Open, FileAccess.Read ) )
                {
                    return new Bitmap( fs );
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Das Bild konnte nicht geladen werden: {ex.Message}" );
                return null;
            }
        }

        public static Bitmap Colorize( Image image, ColorMatrix colorMatrix )
        {
            if( null == image )
            {
                throw new ArgumentNullException( nameof( image ) );
            }

            using( ImageAttributes imageAttributes = new ImageAttributes() )
            {
                
                imageAttributes.SetColorMatrix( colorMatrix );

                Bitmap image_colorized = new Bitmap( image.Width, image.Height );
                using( Graphics drawing = Graphics.FromImage( image_colorized ) )
                {
                    drawing.DrawImage( image, new Rectangle( Point.Empty, image.Size ), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes );
                }

                return image_colorized;
            }
        }

        // grey and "lighter"
        public static readonly ColorMatrix colorMatrixGreyAndLight = new ColorMatrix( new float[][]
        {
            new float[] { 0.3f,  0.3f,  0.3f,  0, 0 },
            new float[] { 0.59f, 0.59f, 0.59f, 0, 0 },
            new float[] { 0.11f, 0.11f, 0.11f, 0, 0 },
            new float[] { 0,     0,     0,     1, 0 },
            new float[] { 0.25f, 0.25f, 0.25f, 0, 1 }
        } );
    }
}
