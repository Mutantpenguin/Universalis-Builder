using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class ImageHelper
    {
        public static readonly Size imageSize = new Size( 400, 700 );
        public static readonly Size iconSize = new Size( 150, 150 );

        public static Image CreateIconFromImage( Image img )
        {
            if( null != img )
            {
                if( img.Width == img.Height )
                {
                    if( ( img.Width <= ImageHelper.iconSize.Width )
                        &&
                        ( img.Height <= ImageHelper.iconSize.Height ) )
                    {
                        return( img );
                    }
                    else
                    {
                        Image bmp = new Bitmap( ImageHelper.iconSize.Width, ImageHelper.iconSize.Height );
                        using( Graphics g = Graphics.FromImage( bmp ) )
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.Clear( Color.White );
                            g.DrawImage( img, new Rectangle( Point.Empty, bmp.Size ), new Rectangle( new Point( 0, 0 ), img.Size ), GraphicsUnit.Pixel );
                        }

                        return ( bmp );
                    }
                }
                else
                {
                    using( ImageSelectionForm imageSelectionForm = new ImageSelectionForm( "Icon auswählen", img, ImageHelper.iconSize ) )
                    {
                        if( imageSelectionForm.ShowDialog() == DialogResult.OK )
                        {
                            return( imageSelectionForm.Image );
                        }
                    }
                }
            }

            return ( null );
        }

        public static Image LoadImage( string path )
        {
            try
            {
                using( FileStream fs = new FileStream( path, FileMode.Open, FileAccess.Read ) )
                {
                    Bitmap original = new Bitmap( fs );
                    Bitmap converted = new Bitmap( original.Width, original.Height );

                    using( Graphics gr = Graphics.FromImage( converted ) )
                    {
                        gr.Clear( Color.White );
                        gr.DrawImage( original, new Rectangle( Point.Empty, converted.Size ) );
                    }

                    return ( converted );
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Das Bild konnte nicht geladen werden: {ex.Message}" );
                return ( null );
            }
        }

        public static bool ImagesIdentical( Image img_1, Image img_2 )
        {
            String firstImage = ImageBase64Helper.ImageToBase64( img_1 );
            String secondImage = ImageBase64Helper.ImageToBase64( img_2 );

            if( firstImage.Equals( secondImage ) )
            {
                return ( true );
            }
            else
            {
                return ( false );
            }
        }
    }
}
