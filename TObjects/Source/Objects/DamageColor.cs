using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tesserakt
{
    public static class DamageColor
    {
        public enum EType
        {
            Original,
            Red,
            Green
        }

        public static readonly Color red = Color.FromArgb( 204, 0, 0 );
        public static readonly Color green = Color.FromArgb( 0, 127, 0 );

        private static readonly ColorMatrix s_colorMatrixRed = ColorHelper.ColorToColorMatrix( red );
        private static readonly ColorMatrix s_colorMatrixGreen = ColorHelper.ColorToColorMatrix( green );

        public static Image Colorize( Image image, DamageColor.EType color )
        {
            if( null == image )
            {
                throw new ArgumentNullException( nameof( image ) );
            }

            using( ImageAttributes imageAttributes = new ImageAttributes() )
            {
                switch( color )
                {
                    case DamageColor.EType.Green:
                        imageAttributes.SetColorMatrix( s_colorMatrixGreen );
                        break;

                    case DamageColor.EType.Red:
                        imageAttributes.SetColorMatrix( s_colorMatrixRed );
                        break;

                    default:
                        throw new ArgumentException( "unkown DamageColor.EType", nameof( color ) );
                }

                Bitmap image_colorized = new Bitmap( image.Width, image.Height );
                using( Graphics drawing = Graphics.FromImage( image_colorized ) )
                {
                    drawing.DrawImage( image, new Rectangle( Point.Empty, image.Size ), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes );
                }

                return ( image_colorized );
            }
            
        }
    }
}