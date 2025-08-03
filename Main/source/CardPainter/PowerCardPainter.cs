using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Universalis.CardPainterHelpers;
using static Universalis.Helper.Drawing;

namespace Universalis
{
    public class PowerCardPainter
    {
        #region members

        public const float CardWidthCm = 6.3f;
        public const float CardHeightCm = 8.8f;

        public static readonly int SCardWidth = CmToPixel( CardWidthCm );
        public static readonly int SCardHeight = CmToPixel( CardHeightCm );

        private static readonly int SMargin = CmToPixel( 0.2 );
        private static readonly int SRectangleRadius = CmToPixel( 0.25 );

        private static readonly int STitleHeight = CmToPixel( 0.75 );
        private static readonly int SFooterHeight = CmToPixel( 0.75 );
        
        private static readonly int SFooterPadding = CmToPixel( 0.1 );

        private static readonly int SContentWidth = SCardWidth - ( 2 * SMargin );

        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CmToPixel( 0.02f ) );

        private static readonly Font FontTitle = new Font( UniversalisFont.Family, CmToPixel( 0.5 ), FontStyle.Regular, GraphicsUnit.Pixel );
        
        private static readonly Font FontRules = new Font( "Arial", CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );

        private static readonly Font FontAP = new Font( UniversalisFont.Family, CmToPixel( 0.6 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontAttributeBig = new Font( UniversalisFont.Family, CmToPixel( 0.6 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontAttributeSmall = new Font( UniversalisFont.Family, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontDamageApplication = new Font( UniversalisFont.Family, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );

        #endregion members

        public static Bitmap GetBitmap( Discipline discipline, Power power, bool monochrome )
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
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                g.Clear( Color.White );

                DrawTitle( g, discipline.Color, power.Name, monochrome );

                DrawRules( g, power.Rules );

                DrawFooter( g, power, monochrome );

                DrawStructure( g );

                return img;
            }
        }

        private static void DrawTitle( Graphics g, Color disciplineColor, string name, bool monochrome )
        {
            Color textColor = Color.Black;

            {
                var borderRect = new Rectangle( 0, 0, SCardWidth, STitleHeight );

                if( !monochrome )
                {
                    var disciplineBrush = new SolidBrush( disciplineColor );
                    g.FillRectangle( disciplineBrush, borderRect );

                    textColor = ContrastFontColor( disciplineColor );
                }

                g.DrawRectangle( SStructureBlackPen, borderRect );
            }

            {
                var fontRect = new Rectangle( SMargin, 0, SContentWidth, STitleHeight );
            
                var font = FindFontSingleLine( g, name, fontRect.Size, FontTitle );

                g.DrawString( name, font, new SolidBrush( textColor ), fontRect, StringFormatHCenterVCenter );
            }
        }

        private static void DrawRules( Graphics g, string rules )
        {
            var contentTop = SMargin + STitleHeight + SMargin;
            var contentHeight = SCardHeight - 4 * SMargin - STitleHeight - SFooterHeight;
            
            var rect = new Rectangle( SMargin, contentTop, SContentWidth, contentHeight );

            var font = FindFontMultiLine( g, rules, rect.Size, FontRules );

            g.DrawString( rules, font, Brushes.Black, rect );
        }

        private static void DrawFooter( Graphics g, Power power, bool monochrome )
        {
            var rectFooter = new Rectangle( SMargin, SCardHeight - SFooterHeight - SMargin, SContentWidth, SFooterHeight );

            var footerElementWidth = ( SContentWidth - ( 7 * SFooterPadding ) ) / 6;
            var footerElementHeight = SFooterHeight - ( 2 * SFooterPadding );

            RoundedRectangle( g, SStructureBlackPen, rectFooter, SRectangleRadius );

            var rectAP = new Rectangle( rectFooter.Left + SFooterPadding, rectFooter.Top + SFooterPadding, footerElementWidth, footerElementHeight );
            DrawStringCentered( g, $"{power.AP}{ActionsPointsMarker}", FontAP, Brushes.Black, rectAP );

            var imgOffset = ( footerElementWidth - footerElementHeight ) / 2;

            var footerElementImageSize = footerElementHeight;

            var rectAttribute = new Rectangle( rectFooter.Left + ( 2 * SFooterPadding ) + footerElementWidth, rectFooter.Top + SFooterPadding, footerElementWidth, footerElementHeight );
            if( power.Modifier == 0 )
            {
                DrawStringCentered( g, power.Attribute.ToString(), FontAttributeBig, Brushes.Black, rectAttribute );
            }
            else
            {
                string modifierString;
                Brush modifierBrush;
                if( power.Modifier > 0 )
                {
                    modifierString = "+" + power.Modifier.ToString();
                    modifierBrush = Brushes.Green;
                }
                else
                {
                    modifierString = power.Modifier.ToString();
                    modifierBrush = Brushes.Red;
                }

                g.DrawString( power.Attribute.ToString(), FontAttributeSmall, Brushes.Black, rectAttribute.Location );

                var stringSize = g.MeasureString( modifierString, FontAttributeSmall, rectAttribute.Size, StringFormatHRightVBottom ).ToSize();
                var modifierRect = new Rectangle( new Point( rectAttribute.Right, rectAttribute.Bottom ) - stringSize, stringSize );
                modifierRect.Inflate( 6, 6 );
                g.DrawString( modifierString, FontAttributeSmall, modifierBrush, modifierRect, StringFormatHRightVBottom );
            }

            var rectDamageApplication = new Rectangle( rectFooter.Left + ( 3 * SFooterPadding ) + ( 2 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.DamageApplication )
            {
                case Power.EDamageApplication.Keinen:
                    break;

                case Power.EDamageApplication.Misserfolg:
                    g.DrawImage( Properties.ResourcesPowerCard.SchadenMisserfolg, rectDamageApplication );
                    DrawStringCentered( g, power.DamageValue.ToString(), FontDamageApplication, Brushes.Black, rectDamageApplication );
                    break;

                case Power.EDamageApplication.Automatisch:
                    g.DrawImage( Properties.ResourcesPowerCard.SchadenAutomatisch, rectDamageApplication );
                    DrawStringCentered( g, power.DamageValue.ToString(), FontDamageApplication, Brushes.White, rectDamageApplication );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( power.DamageApplication ) );
            }

            var rectTarget = new Rectangle( rectFooter.Left + ( 4 * SFooterPadding ) + ( 3 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Target )
            {
                case Power.ETarget.Nutzer:
                    g.DrawImage( Properties.ResourcesPowerCard.ZielNutzer, rectTarget );
                    break;

                case Power.ETarget.Bereich:
                    g.DrawImage( Properties.ResourcesPowerCard.ZielBereich, rectTarget );
                    break;

                case Power.ETarget.Modell:
                    g.DrawImage( Properties.ResourcesPowerCard.ZielModell, rectTarget );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( power.Target ) );
            }

            var rectRange = new Rectangle( rectFooter.Left + ( 5 * SFooterPadding ) + ( 4 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Range )
            {
                case Power.ERange.Distanz:
                    g.DrawImage( Properties.ResourcesPowerCard.ReichweiteDistanz, rectRange );
                    break;

                case Power.ERange.Berührung:
                    g.DrawImage( Properties.ResourcesPowerCard.ReichweiteBerührung, rectRange );
                    break;
                
                default:
                    throw new InvalidOperationException( "unkown " + nameof( power.Range ) );
            }

            var rectDuration = new Rectangle( rectFooter.Left + ( 6 * SFooterPadding ) + ( 5 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Duration )
            {
                case Power.EDuration.Sofort:
                    g.DrawImage( Properties.ResourcesPowerCard.DauerSofort, rectDuration );
                    break;

                case Power.EDuration.Dauerhaft:
                    g.DrawImage( Properties.ResourcesPowerCard.DauerDauerhaft, rectDuration );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( power.Duration ) );
            }
        }

        private static void DrawStructure( Graphics g )
        {
            g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
        }
    }
}
