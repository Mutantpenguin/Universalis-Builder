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

        private static readonly int SMargin = CardPainterHelpers.CmToPixel( 0.2 );
        private static readonly int SRectangleRadius = CardPainterHelpers.CmToPixel( 0.25 );

        private static readonly int STitleHeight = CardPainterHelpers.CmToPixel( 0.75 );
        private static readonly int SFooterHeight = CardPainterHelpers.CmToPixel( 0.75 );

        private static readonly int SContentWidth = SCardWidth - ( 2 * SMargin );

        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CardPainterHelpers.CmToPixel( 0.02f ) );

        private static readonly Font Font0Dot2 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
        
        private static readonly Font FontRules = new Font( "Arial", CardPainterHelpers.CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );

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

                DrawContent( g, power );

                DrawFooter( g, power );

                DrawStructure( g );

                return img;
            }
        }

        private static void DrawTitle( Graphics g, Discipline discipline, Power power )
        {
            var rect = new Rectangle( SMargin, SMargin, SContentWidth, STitleHeight );

            SolidBrush disciplineBrush = new SolidBrush( discipline.Color );
            CardPainterHelpers.FillRoundedRectangle( g, disciplineBrush, rect, SRectangleRadius );

            var textColor = CardPainterHelpers.ContrastFontColor( discipline.Color );

            var font = CardPainterHelpers.FindFont( g, power.Name, rect.Size, Font0Dot2 );

            CardPainterHelpers.DrawStringCentered( g, power.Name, font, new SolidBrush(textColor), rect );
        }

        private static void DrawContent( Graphics g, Power power )
        {
            var contentTop = SMargin + STitleHeight + SMargin;
            var contentHeight = SCardHeight - 4 * SMargin - STitleHeight - SFooterHeight;
            
            var rect = new Rectangle( SMargin, contentTop, SContentWidth, contentHeight );

            var font = CardPainterHelpers.FindFont( g, power.Rules, rect.Size, FontRules );

            g.DrawString( power.Rules, font, Brushes.Black, rect );
        }

        private static void DrawFooter( Graphics g, Power power )
        {
            var rect = new Rectangle( SMargin, SCardHeight - SFooterHeight - SMargin, SContentWidth, SFooterHeight );

            CardPainterHelpers.FillRoundedRectangle( g, Brushes.Black, rect, SRectangleRadius );
        }

        private static void DrawStructure( Graphics g )
        {
            g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
        }
    }
}
