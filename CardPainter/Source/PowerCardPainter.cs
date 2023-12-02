using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Universalis
{
    public class PowerCardPainter
    {
        #region members

        public const double CardWidthCm = 6.3;
        public const double CardHeightCm = 8.8;

        private static readonly int SCardWidth = CardPainterHelpers.CmToPixel( CardWidthCm );
        private static readonly int SCardHeight = CardPainterHelpers.CmToPixel( CardHeightCm );

        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CardPainterHelpers.CmToPixel( 0.02f ) );

        private static readonly Font Font0Dot2 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );

        #endregion members

        public static Bitmap GetBitmap( Discipline discipline, Power power )
        {
            if( null == discipline )
            {
                throw new ArgumentNullException( nameof( discipline ) );
            }

            if( null == power )
            {
                throw new ArgumentNullException( nameof( power ) );
            }

            Bitmap img = new Bitmap( SCardWidth, SCardHeight );
            using( Graphics g = Graphics.FromImage( img ) )
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear( Color.White );

                DrawTitle( g, discipline, power );

                DrawStructure( g );

                return img;
            }
        }

        private static void DrawTitle( Graphics g, Discipline discipline, Power power )
        {
            var margin = CardPainterHelpers.CmToPixel( 0.1 );
            var width = SCardWidth - (2 * margin);
            var height = CardPainterHelpers.CmToPixel( 1 );
            var rect = new Rectangle( margin, margin, width, height );
            var radius = CardPainterHelpers.CmToPixel( 0.25 );

            CardPainterHelpers.FillRoundedRectangle( g, new SolidBrush( discipline.Color ), rect, radius );

            var textColor = CardPainterHelpers.ContrastFontColor( discipline.Color );

            var font = CardPainterHelpers.FindFont( g, power.Name, rect.Size, Font0Dot2 );

            CardPainterHelpers.DrawStringCentered( g, power.Name, font, new SolidBrush(textColor), rect );
        }

        private static void DrawStructure( Graphics g )
        {
            g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
        }
    }
}
