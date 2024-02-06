using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using static Universalis.CardPainterHelpers;
using static Universalis.Helper.Drawing;

namespace Universalis
{
    internal class ActivationCardPainter
    {
        #region members

        public const float CardWidthCm = 4f;
        public const float CardHeightCm = 5f;

        public static readonly int SCardWidth = CmToPixel( CardWidthCm );
        public static readonly int SCardHeight = CmToPixel( CardHeightCm );

        private static readonly int SIconSize = SCardWidth;

        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CmToPixel( 0.02f ) );

        private static readonly Font FontName = new Font( UniversalisFont.Family, CmToPixel( 0.35 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontAGI = new Font( UniversalisFont.Family, CmToPixel( 0.7 ), FontStyle.Regular, GraphicsUnit.Pixel );

        #endregion members

        public static Bitmap GetBitmap( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            Bitmap img = new Bitmap( SCardWidth, SCardHeight );
            using( Graphics g = Graphics.FromImage( img ) )
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                g.Clear( Color.Black );

                DrawContent( g, actor );

                DrawStructure( g );

                return img;
            }
        }

        private static void DrawContent( Graphics g, Actor actor )
        {
            var attributes = new ImageAttributes();
            attributes.SetWrapMode( WrapMode.TileFlipXY );
            var iconSize = actor.Icon.Size;
            g.DrawImage( actor.Icon, new Rectangle( 0, 0, SIconSize, SIconSize ), 0, 0, iconSize.Width, iconSize.Height, GraphicsUnit.Pixel, attributes );

            int margin = CmToPixel( 0.1f );
            int circleDiameter = SCardWidth / 4;
            int circleLeft = SCardWidth - circleDiameter - margin;
            int circleTop = margin;

            Rectangle rect = new Rectangle( circleLeft, circleTop, circleDiameter, circleDiameter );
            g.FillEllipse( Brushes.Black, rect );

            var attributeAGI = actor.ModAGI();
            var attributeAGIstring = attributeAGI.HasValue ? attributeAGI.Value.ToString() : "-";
            DrawStringCentered( g, attributeAGIstring, FontAGI, Brushes.White, rect );

            var footerRectangle = new Rectangle( 0, SIconSize, SCardWidth, SCardHeight - SIconSize );
            var font = FindFontSingleLine( g, actor.Name, footerRectangle.Size, FontName );
            DrawStringCentered( g, actor.Name, font, Brushes.White, footerRectangle );
        }

        private static void DrawStructure( Graphics g )
        {
            g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
        }
    }
}
