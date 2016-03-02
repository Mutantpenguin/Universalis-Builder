using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tesserakt
{
    class ColorHelper
    {
        public static ColorMatrix ColorToColorMatrix( Color c )
        {
            Func<int,float> f = x => { return( 100.0f / 255.0f * x / 100.0f ); };

            float max = f( 255 );

            float[][] s_colorMatrix = { new float[] { max - f( c.R ),  0,               0,               0,               0 },
                                        new float[] { 0,               max - f( c.G ),  0,               0,               0 },
                                        new float[] { 0,               0,               max - f( c.B ),  0,               0 },
                                        new float[] { 0,               0,               0,               f( c.A ),        0 },
                                        new float[] { f( c.R ),        f( c.G ),        f( c.B ),        max - f( c.A ),  1 } };

            return ( new ColorMatrix( s_colorMatrix ) );
        }
    }
}
