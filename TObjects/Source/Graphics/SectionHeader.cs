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

                // WrapMode.TileFlipX is needed here, because LinearGradientBrush has a bug which may lead to wrongly colored pixels at the end of the gradient 
                using( LinearGradientBrush sectionTitleBackgroundBrushGradient = new LinearGradientBrush( sectionRectangle,
                                                                                                          Color.FromArgb( 255, backgroundColor ),
                                                                                                          Color.FromArgb( 0, backgroundColor ),
                                                                                                          LinearGradientMode.Horizontal )
                                                                                     {
                                                                                        WrapMode = WrapMode.TileFlipX
                                                                                     }  )
                {
                    g.FillRectangle( sectionTitleBackgroundBrushGradient, sectionRectangle );
                }

                return( temp );
            }
        }
    }
}
