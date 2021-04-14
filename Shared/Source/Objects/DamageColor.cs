using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Universalis
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

        public static Image Colorize( Image image, EType color )
        {
            using( ImageAttributes imageAttributes = new ImageAttributes() )
            {
                ColorMatrix colorMatrix = null;

                switch( color )
                {
                    case EType.Green:
                        colorMatrix = s_colorMatrixGreen;
                        break;

                    case EType.Red:
                        colorMatrix = s_colorMatrixRed;
                        break;

                    default:
                        throw new ArgumentException( "unkown DamageColor.EType", nameof( color ) );
                }

                return ( ImageHelper.Colorize( image, colorMatrix ) );
            }
            
        }
    }
}