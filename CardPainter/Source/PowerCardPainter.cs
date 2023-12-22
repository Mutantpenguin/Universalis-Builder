using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using static Universalis.CardPainterHelpers;

namespace Universalis
{
    public class PowerCardPainter
    {
        #region members

        public const double CardWidthCm = 6.3;
        public const double CardHeightCm = 8.8;

        private static readonly int SCardWidth = CmToPixel( CardWidthCm );
        private static readonly int SCardHeight = CmToPixel( CardHeightCm );

        private static readonly int SMargin = CmToPixel( 0.2 );
        private static readonly int SRectangleRadius = CmToPixel( 0.25 );

        private static readonly int STitleHeight = CmToPixel( 0.75 );
        private static readonly int SFooterHeight = CmToPixel( 0.75 );
        
        private static readonly int SFooterPadding = CmToPixel( 0.1 );

        private static readonly int SContentWidth = SCardWidth - ( 2 * SMargin );

        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CmToPixel( 0.02f ) );

        private static readonly Font Font0Dot2 = new Font( UniversalisFont.Family, CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
        
        private static readonly Font FontRules = new Font( "Arial", CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );

        private static readonly Font FontAP = new Font( UniversalisFont.Family, CmToPixel( 0.6 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontAttributeBig = new Font( UniversalisFont.Family, CmToPixel( 0.6 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontAttributeSmall = new Font( UniversalisFont.Family, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font FontDamageApplication = new Font( UniversalisFont.Family, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );

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

                DrawTitle( g, discipline.Color, power.Name );

                DrawRules( g, power.Rules );

                DrawFooter( g, power );

                DrawStructure( g );

                return img;
            }
        }

        private static void DrawTitle( Graphics g, Color disciplineColor, string name )
        {
            var rect = new Rectangle( SMargin, SMargin, SContentWidth, STitleHeight );

            SolidBrush disciplineBrush = new SolidBrush( disciplineColor );
            FillRoundedRectangle( g, disciplineBrush, rect, SRectangleRadius );

            var textColor = ContrastFontColor( disciplineColor );

            var font = FindFont( g, name, rect.Size, Font0Dot2 );

            DrawStringCentered( g, name, font, new SolidBrush(textColor), rect );
        }

        private static void DrawRules( Graphics g, string rules )
        {
            var contentTop = SMargin + STitleHeight + SMargin;
            var contentHeight = SCardHeight - 4 * SMargin - STitleHeight - SFooterHeight;
            
            var rect = new Rectangle( SMargin, contentTop, SContentWidth, contentHeight );

            var font = FindFont( g, rules, rect.Size, FontRules );

            g.DrawString( rules, font, Brushes.Black, rect );
        }

        private static void DrawFooter( Graphics g, Power power )
        {
            var rectFooter = new Rectangle( SMargin, SCardHeight - SFooterHeight - SMargin, SContentWidth, SFooterHeight );

            var footerElementWidth = ( SContentWidth - ( 5 * SFooterPadding ) ) / 6;
            var footerElementHeight = SFooterHeight - ( 2 * SFooterPadding );

            FillRoundedRectangle( g, Brushes.Black, rectFooter, SRectangleRadius );

            var rectAP = new Rectangle( rectFooter.Left + SFooterPadding, rectFooter.Top + SFooterPadding, footerElementWidth, footerElementHeight );
            DrawStringCentered( g, $"{power.AP}{ActionsPointsMarker}", FontAP, Brushes.White, rectAP );

            var imgOffset = ( footerElementWidth - footerElementHeight ) / 2;

            var footerElementImageSize = footerElementHeight;

            var rectAttribute = new Rectangle( rectFooter.Left + ( 2 * SFooterPadding ) + footerElementWidth, rectFooter.Top + SFooterPadding, footerElementWidth, footerElementHeight );
            if( power.Modifier == 0 )
            {
                DrawStringCentered( g, power.Attribute.ToString(), FontAttributeBig, Brushes.White, rectAttribute );
            }
            else
            {
                string modifierString;
                Brush modifierBrush;
                if( power.Modifier > 0 )
                {
                    modifierString = "+" + power.Modifier.ToString();
                    modifierBrush = Brushes.LightGreen;
                }
                else
                {
                    modifierString = power.Modifier.ToString();
                    modifierBrush = Brushes.Red;
                }

                var stringSize = g.MeasureString( modifierString, FontAttributeSmall );

                g.DrawString( power.Attribute.ToString(), FontAttributeSmall, Brushes.White, rectAttribute.Location );
                var modifierRect = new PointF( rectAttribute.Right - stringSize.Width, rectAttribute.Bottom - stringSize.Height );
                g.DrawString( modifierString, FontAttributeSmall, modifierBrush, modifierRect );
            }
            
            var rectTarget = new Rectangle( rectFooter.Left + ( 3 * SFooterPadding ) + ( 2 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Target )
            {
                case Power.ETarget.Nutzer:
                    g.DrawImage( Properties.ResourcesKräfte.ZielNutzer, rectTarget );
                    break;

                case Power.ETarget.Bereich:
                    g.DrawImage( Properties.ResourcesKräfte.ZielBereich, rectTarget );
                    break;

                case Power.ETarget.Modell:
                    g.DrawImage( Properties.ResourcesKräfte.ZielModell, rectTarget );
                    break;

                default:
                    // TODO
                    break;
            }

            var rectRange = new Rectangle( rectFooter.Left + ( 4 * SFooterPadding ) + ( 3 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Range )
            {
                case Power.ERange.Distanz:
                    g.DrawImage( Properties.ResourcesKräfte.WirkungsabstandDistanz, rectRange );
                    break;

                case Power.ERange.Berührung:
                    g.DrawImage( Properties.ResourcesKräfte.WirkungsabstandBerührung, rectRange );
                    break;
                
                default:
                    // TODO
                    break;
            }

            var rectDamageApplication = new Rectangle( rectFooter.Left + ( 5 * SFooterPadding ) + ( 4 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.DamageApplication )
            {   
                case Power.EDamageApplication.Keinen:
                    break;

                case Power.EDamageApplication.Misserfolg:
                    g.DrawImage( Properties.ResourcesKräfte.SchadenMisserfolg, rectDamageApplication );
                    break;

                case Power.EDamageApplication.Automatisch:
                    g.DrawImage( Properties.ResourcesKräfte.SchadenAutomatisch, rectDamageApplication );
                    break;

                default:
                    // TODO
                    break;
            }

            if( power.DamageApplication != Power.EDamageApplication.Keinen )
            {
                DrawStringCentered( g, power.DamageValue.ToString(), FontDamageApplication, Brushes.White, rectDamageApplication );
            }

            var rectDuration = new Rectangle( rectFooter.Left + ( 6 * SFooterPadding ) + ( 5 * footerElementWidth ) + imgOffset, rectFooter.Top + SFooterPadding, footerElementImageSize, footerElementImageSize );
            switch( power.Duration )
            {
                case Power.EDuration.Sofort:
                    g.DrawImage( Properties.ResourcesKräfte.DauerSofort, rectDuration );
                    break;

                case Power.EDuration.Dauerhaft:
                    g.DrawImage( Properties.ResourcesKräfte.DauerDauerhaft, rectDuration );
                    break;

                default:
                    // TODO
                    break;
            }
        }

        private static void DrawStructure( Graphics g )
        {
            g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
        }
    }
}
