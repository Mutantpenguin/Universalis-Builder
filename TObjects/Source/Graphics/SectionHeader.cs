using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tesserakt
{
    public static class SectionHeader
    {
        private static readonly Color backgroundColor = Color.SteelBlue;

        public static Image Create( int width, int height )
        {
            Image temp = new Bitmap( width, height );

            using( Graphics g = Graphics.FromImage( temp ) )
            {
                g.Clear( backgroundColor );

                Rectangle sectionRectangle = new Rectangle( 0, 0, width, height );

                using( TextureBrush patternBrush = new TextureBrush( TObjects.Properties.Resources.section_pattern, WrapMode.Tile ) )
                {
                    patternBrush.ScaleTransform( 0.4f, 0.4f );
                    g.FillRectangle( patternBrush, sectionRectangle );
                }

                using( LinearGradientBrush sectionTitleBackgroundBrushGradient = new LinearGradientBrush( new Point( 0, 0 ),
                                                                                                          new Point( width, 0 ),
                                                                                                          Color.FromArgb( 255, backgroundColor ),
                                                                                                          Color.FromArgb( 0, backgroundColor ) ) )
                {
                    TODO a Problem here. somehow with the current settings, a blue vertical bar gets drawn at the end
                    g.FillRectangle( sectionTitleBackgroundBrushGradient, sectionRectangle );

                    temp.Save( "C:\\Users\\lobedama\\Desktop\\gnah.bmp", System.Drawing.Imaging.ImageFormat.Bmp );
                }

                return( temp );
            }
        }
    }
}
