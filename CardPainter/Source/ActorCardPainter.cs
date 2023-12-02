using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Universalis
{
    public static class ActorCardPainter
    {
        #region members

        public const int CardWidthCm = 12;
        public const int CardHeightCm = 8;
        public const int SectionWidthCm = 8;

        private static readonly int SCardWidth = CardPainterHelpers.CmToPixel( CardWidthCm );
        private static readonly int SCardHeight = CardPainterHelpers.CmToPixel( CardHeightCm );
        private static readonly int SSectionsWidth = CardPainterHelpers.CmToPixel( SectionWidthCm );

        private static readonly int SSectionsPosX = CardPainterHelpers.CmToPixel( 4 );

        private static readonly Rectangle SPictureRect = new Rectangle( 0, CardPainterHelpers.CmToPixel( 0.5 ), SSectionsPosX, CardPainterHelpers.CmToPixel( 7 ) );

        private static readonly int SHitPointSize = CardPainterHelpers.CmToPixel( 0.3 );

        private static readonly Pen SLinePenBlack = Pens.Black;
        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CardPainterHelpers.CmToPixel( 0.02f ) );
        private static readonly Pen SStructureRedPen = new Pen( Color.Red, CardPainterHelpers.CmToPixel( 0.2f ) );
        private static readonly Pen SHitPointBorderPen = new Pen( Color.Black, CardPainterHelpers.CmToPixel( 0.015f ) );

        private static readonly Font Font0Dot2 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font Font0Dot25 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.25 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font Font0Dot3 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font Font0Dot35 = new Font( UniversalisFont.Family, CardPainterHelpers.CmToPixel( 0.35 ), FontStyle.Regular, GraphicsUnit.Pixel );

        private static readonly Font FontStandard = Font0Dot35;
        private static readonly Font FontName = Font0Dot3;
        private static readonly Font FontNameSmall = Font0Dot2;
        private static readonly Font FontSize = Font0Dot3;
        private static readonly Font FontPoints = Font0Dot2;
        private static readonly Font FontWeapon = Font0Dot3;
        private static readonly Font FontWeaponName = Font0Dot2;
        private static readonly Font FontWeaponRadius = Font0Dot25;
        private static readonly Font FontWk = Font0Dot3;
        private static readonly Font FontUnwieldy = Font0Dot3;
        private static readonly Font FontArmor = Font0Dot3;
        private static readonly Font FontArmorName = Font0Dot2;
        private static readonly Font FontEquipment = Font0Dot3;
        private static readonly Font FontTraits = Font0Dot3;
        private static readonly Font FontDisciplines = Font0Dot3;

        private static readonly Brush HitPointCritBrush = new SolidBrush( Color.Orange );
        private static readonly Brush HitPointNormalBrush = new SolidBrush( Color.White );
        private static readonly Brush HitPointCritTooLowBrush = new SolidBrush( Color.Red );

        private static readonly Brush WeaponFontBrush = new SolidBrush( DamageColor.red );
        private static readonly Brush ArmorFontBrush = new SolidBrush( DamageColor.green );

        private static readonly int SLineHeight = CardPainterHelpers.CmToPixel( 0.5 );
        private static readonly int SLineHeightDouble = ( SLineHeight * 2 );

        private static readonly int SImageMargin = SLineHeight / 10;
        private static readonly int SImageSize = SLineHeight - ( SImageMargin * 2 );

        private static readonly Image SectionHeaderTraits = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.SteelBlue );
        private static readonly Image SectionHeaderDisciplines = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.MediumPurple );
        private static readonly Image SectionHeaderWeapons = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.IndianRed );
        private static readonly Image SectionHeaderArmor = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.OliveDrab );
        private static readonly Image SectionHeaderEquipment = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.SlateGray );

        private static readonly StringFormat StringFormatHCenterVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        private static readonly StringFormat StringFormatHLeftVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        private static readonly StringFormat StringFormatHLeftVTop = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };

        private static readonly int XAttrFirstColumn = SSectionsPosX;
        private static readonly int XAttrSecondColumn = CardPainterHelpers.CmToPixel( 6.1 );
        private static readonly int XAttrThirdColumn = CardPainterHelpers.CmToPixel( 8.5 );

        private const String ActionsPointsMarker = "⊙";
        private const String UseOnceMarker = "○";
        private const String UnwieldyMarker = "◈";
        #endregion members

        #region weaponMembers
        private static readonly int WeaponWkWidth = CardPainterHelpers.CmToPixel( 0.5 );
        private static readonly int WeaponNameWidth = CardPainterHelpers.CmToPixel( 2.3 );
        private static readonly int WeaponRangeWidth = CardPainterHelpers.CmToPixel( 0.9 );
        private static readonly int WeaponStrengthWidth = CardPainterHelpers.CmToPixel( 0.5 );
        private static readonly int WeaponDamageWidth = CardPainterHelpers.CmToPixel( 0.5 );
        private static readonly int WeaponUnwieldyWidth = WeaponWkWidth / 3;

        private static readonly int WeaponWkStart = SSectionsPosX;
        private static readonly int WeaponNameStart = WeaponWkStart + WeaponWkWidth;
        private static readonly int WeaponRangeStart = WeaponNameStart + WeaponNameWidth;
        private static readonly int WeaponStrengthStart = WeaponRangeStart + WeaponRangeWidth;
        private static readonly int WeaponDamageStart = WeaponStrengthStart + WeaponStrengthWidth;

        private static readonly int WeaponRadiusMargin = SImageMargin + CardPainterHelpers.CmToPixel( 0.015f );
        #endregion

        public static Bitmap GetBitmap( Faction faction, Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            Bitmap img = new Bitmap( SCardWidth, SCardHeight );
            using( Graphics g = Graphics.FromImage( img ) )
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear( Color.White );

                DrawName( g, actor.Name );
                DrawFaction( g, faction);

                DrawPicture( g, actor.Img, actor.Active );

                DrawAttributes( g, actor );
                DrawCalculatedAttributes( g, actor );
                DrawMisc( g, actor );

                DrawHitPoints( g, actor );
                DrawPoints( g, actor );

                int headerEndY = CardPainterHelpers.CmToPixel( 1.5 );

                int traitsEndY = DrawTraits( g, actor.Traits, headerEndY );

                int weaponsEndY = DrawWeapons( g, actor, traitsEndY );

                int armorEndY = DrawArmor( g, actor, actor.Armor, weaponsEndY );

                int equipmentEndY = DrawEquipment( g, actor.Equipments, armorEndY );

                int disciplinesEndY = DrawDisciplines( g, actor.Disciplines, equipmentEndY );

                // show black lines between sections on the right side of the card
                if( headerEndY < traitsEndY )
                {
                    g.DrawLine( SStructureBlackPen, SSectionsPosX, traitsEndY, SCardWidth, traitsEndY );
                }

                if( traitsEndY < weaponsEndY )
                {
                    g.DrawLine( SStructureBlackPen, SSectionsPosX, weaponsEndY,     SCardWidth, weaponsEndY );
                }

                if( weaponsEndY < armorEndY )
                {
                    g.DrawLine( SStructureBlackPen, SSectionsPosX, armorEndY,       SCardWidth, armorEndY );
                }

                if( armorEndY < equipmentEndY )
                {
                    g.DrawLine( SStructureBlackPen, SSectionsPosX, equipmentEndY, SCardWidth, equipmentEndY );
                }

                if( equipmentEndY < disciplinesEndY )
                {
                    g.DrawLine( SStructureBlackPen, SSectionsPosX, disciplinesEndY, SCardWidth, disciplinesEndY );
                }

                // draw the structure last, otherwise "lower" elements could paint over it
                DrawStructure( g, disciplinesEndY );

                return img;
            }
        }

        private static void DrawStructure( Graphics g, int posY )
        {
            // line right of image
            g.DrawLine( SStructureBlackPen, SSectionsPosX, 0, SSectionsPosX, SCardHeight );

            // line under "Name"
            g.DrawLine( SStructureBlackPen, 0, CardPainterHelpers.CmToPixel( 0.5 ), SSectionsPosX, CardPainterHelpers.CmToPixel( 0.5 ) );

            // line above "Points"
            g.DrawLine( SStructureBlackPen, 0, CardPainterHelpers.CmToPixel( 7.5 ), SSectionsPosX, CardPainterHelpers.CmToPixel( 7.5 ) );
            
            // line under "Attribute"
            g.DrawLine( SStructureBlackPen, SSectionsPosX, CardPainterHelpers.CmToPixel( 1.5 ), SCardWidth, CardPainterHelpers.CmToPixel( 1.5 ) );

            // surrounding rectangle
            if( posY > SCardHeight )
            {
                // draw in red to know that not everything fits on the card
                g.DrawRectangle( SStructureRedPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
            }
            else
            {
                g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
            }
        }

        private static void DrawName( Graphics g, String actorName )
        {
            int posX = CardPainterHelpers.CmToPixel( 0.5 );
            int posY = 0;

            Size textSize = new Size( CardPainterHelpers.CmToPixel( 4 ) - posX, CardPainterHelpers.CmToPixel( 0.5 ) );
            Rectangle textRect = new Rectangle( new Point( posX, posY ), textSize );
            g.MeasureString( actorName, FontName, textSize, StringFormatHCenterVCenter, out _, out int linesFilled );

            g.DrawString( actorName, linesFilled > 1 ? FontNameSmall : FontName, Brushes.Black, textRect, StringFormatHCenterVCenter );
        }

        private static void DrawFaction( Graphics g, Faction faction )
        {
            Rectangle rect = new Rectangle( Point.Empty, new Size( CardPainterHelpers.CmToPixel( 0.5 ), CardPainterHelpers.CmToPixel( 0.5 ) ) );

            g.DrawImage( faction.Icon, rect );
        }

        private static void DrawPicture( Graphics g, Bitmap image, bool active )
        {
            if( image != null )
            {
                if( !active )
                {
                    using( ImageAttributes attributes = new ImageAttributes() )
                    {
                        attributes.SetColorMatrix( ImageHelper.colorMatrixGreyAndLight );

                        g.DrawImage( image, SPictureRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes );
                    }
                }
                else
                {
                    g.DrawImage( image, SPictureRect );
                }
            }
        }

        private static void DrawAttributes( Graphics g, Actor actor )
        {
            DrawAttribute( g, XAttrFirstColumn, 0,                "AGI",    actor.ModAGI() );
            DrawAttribute( g, XAttrFirstColumn, CardPainterHelpers.CmToPixel( 0.5 ), "NK",     actor.ModHTH() );
            DrawAttribute( g, XAttrFirstColumn, CardPainterHelpers.CmToPixel( 1 ),   "FK",     actor.ModLRC() );

            DrawAttribute( g, XAttrSecondColumn, 0,                 "KO",   actor.ModPHY() );
            DrawAttribute( g, XAttrSecondColumn, CardPainterHelpers.CmToPixel( 0.5 ),  "WN",   actor.ModAWA() );
            DrawAttribute( g, XAttrSecondColumn, CardPainterHelpers.CmToPixel( 1 ),    "EH",   actor.ModDET() );
        }

        private static void DrawAttribute( Graphics g, int posX, int posY, string name, int? attribute )
        {
            int widthName = CardPainterHelpers.CmToPixel( 0.9 );
            int widthAtt = CardPainterHelpers.CmToPixel( 1.2 );

            Rectangle rectName = new Rectangle( posX, posY, widthName, SLineHeight );
            Rectangle rectValue = new Rectangle( posX + widthName, posY, widthAtt, SLineHeight );

            g.DrawRectangle( SLinePenBlack, new Rectangle( posX, posY, widthName + widthAtt, SLineHeight ) );

            g.FillRectangle( Brushes.Black, rectName );

            CardPainterHelpers.DrawStringCentered( g, name, FontStandard, Brushes.White, rectName );

            if( !attribute.HasValue )
            {
                CardPainterHelpers.DrawStringCentered( g, "-", FontStandard, Brushes.Black, rectValue );
            }
            else
            {
                var value = attribute.Value;

                int printModValue = ( value < 0 ) ? 0 : value;
                var brush = ( value < 0 ) ? Brushes.Red : Brushes.Black;

                CardPainterHelpers.DrawStringCentered( g, printModValue.ToString(), FontStandard, brush, rectValue );
            }
        }

        private static void DrawCalculatedAttributes( Graphics g, Actor actor )
        {
            // WB - Wahrnehmungsbereich
            g.DrawImage( Properties.Resources.Wahrnehmungsbereich, new Rectangle( XAttrThirdColumn, SImageMargin, SImageSize, SImageSize ) );

            string modWbString = actor.ModAreaOfPerception().ToString();
            Size modWbSize = g.MeasureString( modWbString, FontStandard ).ToSize();
            CardPainterHelpers.DrawStringCentered( g, modWbString, FontStandard, Brushes.Black, new Rectangle( XAttrThirdColumn + CardPainterHelpers.CmToPixel( 0.5 ), 0, modWbSize.Width + CardPainterHelpers.CmToPixel( 0.1 ), CardPainterHelpers.CmToPixel( 0.5 ) ) );

            // GB - Gefahrenbereich
            int? dangerArea = actor.ModDangerArea();
            if( dangerArea.HasValue )
            {
                g.DrawImage( Properties.Resources.Gefahrenbereich, new Rectangle( XAttrThirdColumn, SLineHeight + SImageMargin, SImageSize, SImageSize ) );
                CardPainterHelpers.DrawStringCentered( g, dangerArea.Value.ToString(), FontStandard, Brushes.Black, new Rectangle( XAttrThirdColumn + CardPainterHelpers.CmToPixel( 0.5 ), SLineHeight, CardPainterHelpers.CmToPixel( 1 ), SLineHeight ) );
            }
        }

        private static void DrawHitPoints( Graphics g, Actor actor )
        {
            int margin = CardPainterHelpers.CmToPixel( 0.1 );

            int critThreshold = actor.ModCritThreshold();

            switch( actor.Archetype.Type )
            {
                case Archetype.EType.Infanterie:
                case Archetype.EType.Drohne:
                    int posX = SPictureRect.X + margin;
                    int posY = SPictureRect.Y + margin;

                    DrawHitPointCirclesVertical( g, actor.ModHitPoints(), critThreshold, posX, posY, SHitPointSize );
                    break;

                case Archetype.EType.Koloss:
                    int posXArmLeft = SPictureRect.X + margin;
                    int posYArmLeft = SPictureRect.Y + margin;

                    int posXArmRight = SPictureRect.Width - SHitPointSize - margin;
                    int posYArmRight = SPictureRect.Y + margin;

                    int posXMain = posXArmLeft + SHitPointSize + margin;
                    int posYMain = SPictureRect.Y + margin;
                    int widthMain = posXArmRight - margin - posXMain;

                    int posXLegs = posXMain;
                    int posYLegs = SPictureRect.Y + SPictureRect.Height - margin;
                    int widthLegs = widthMain;

                    // main
                    DrawHitPointCirclesHorizonzal( g, actor.ModHitPoints(), critThreshold, posXMain, posYMain, widthMain, down: true );

                    int modHitZoneHitPoints = actor.ModHitZoneHitPoints();

                    // left arm
                    DrawHitPointCirclesVertical( g, modHitZoneHitPoints, critThreshold, posXArmLeft, posYArmLeft, SHitPointSize );

                    // right arm
                    DrawHitPointCirclesVertical( g, modHitZoneHitPoints, critThreshold, posXArmRight, posYArmRight, SHitPointSize );

                    // legs
                    DrawHitPointCirclesHorizonzal( g, modHitZoneHitPoints, critThreshold, posXLegs, posYLegs, widthLegs, down: false );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }            
        }

        private static void DrawHitPointCirclesHorizonzal( Graphics g, int count, int critThreshold, int x, int y, int width, bool down )
        {
            int maxColumns = Math.Min( Convert.ToInt32( Math.Floor( (float)width / (float)SHitPointSize ) ), count );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int posX = x + ( ( width - ( maxColumns * SHitPointSize ) ) / 2 );
            int posY = y - ( down ? 0 : maxRows * SHitPointSize );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / ( 100.0f / critThreshold ) ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( posX + ( SHitPointSize * col ), posY + ( SHitPointSize * row ), SHitPointSize, SHitPointSize );

                g.FillEllipse( i > crit ? HitPointCritBrush : HitPointNormalBrush, rect );

                g.DrawEllipse( SHitPointBorderPen, rect );

                ++col;

                if( col == maxColumns )
                {
                    ++row;
                    col = 0;
                }
            }
        }

        private static void DrawHitPointCirclesVertical( Graphics g, int count, int critThreshold, int x, int y, int width )
        {
            int maxColumns = Convert.ToInt32( Math.Floor( (float)width / SHitPointSize ) );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / ( 100.0f / critThreshold ) ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( x + ( SHitPointSize * col ), y + ( SHitPointSize * row ), SHitPointSize, SHitPointSize );

                var brush = critThreshold < -50 ? HitPointCritTooLowBrush : i > crit ? HitPointCritBrush : HitPointNormalBrush;

                g.FillEllipse( brush, rect );

                g.DrawEllipse( SHitPointBorderPen, rect );

                ++row;

                if( row == maxRows )
                {
                    ++col;
                    row = 0;

                    if( col < maxColumns )
                    {
                        maxRows = Convert.ToInt32( Math.Ceiling( (float)( count - i ) / (float)( maxColumns - col ) ) );
                    }
                }
            }
        }

        private static void DrawPoints( Graphics g, Actor actor )
        {
            string points = $"{actor.Points}pkt";

            g.DrawString( points, FontPoints, Brushes.Black, new Rectangle( 0, CardPainterHelpers.CmToPixel( 7.5 ), SSectionsPosX, CardPainterHelpers.CmToPixel( 0.5 ) ), StringFormatHCenterVCenter );
        }

        private static void DrawMisc( Graphics g, Actor actor )
        {
            int sizeX = DrawType( g, XAttrThirdColumn, actor.Archetype.Type );
            int movementX = DrawSize( g, sizeX, actor.Archetype.Size );
            int weightX = DrawMovement( g, movementX, actor.Archetype.MovementType, actor.ModSpeed() );
        }

        private static int DrawType( Graphics g, int xOffset, Archetype.EType type )
        {
            int width = SLineHeight;

            Rectangle rect = new Rectangle( xOffset, SLineHeightDouble, width, SLineHeight );

            switch( type )
            {
                case Archetype.EType.Infanterie:
                    g.DrawImage( Properties.Resources.Infanterie, rect );
                    break;

                case Archetype.EType.Koloss:
                    g.DrawImage( Properties.Resources.Koloss, rect );
                    break;

                case Archetype.EType.Drohne:
                    g.DrawImage( Properties.Resources.Drohne, rect );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }

            g.DrawRectangle( SLinePenBlack, rect );

            return xOffset + width;
        }

        private static int DrawSize( Graphics g, int xOffset, Archetype.ESize size )
        {
            Bitmap img;

            switch( size )
            {
                case Archetype.ESize.Klein :
                    img = Properties.Resources.klein;
                    break;

                case Archetype.ESize.Mittel :
                    img = Properties.Resources.mittel;
                    break;

                case Archetype.ESize.Groß :
                    img = Properties.Resources.groß;
                    break;

                case Archetype.ESize.Riesig:
                    img = Properties.Resources.riesig;
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.ESize ) );
            }

            int width = SLineHeight;

            g.DrawImage( img, new Rectangle( xOffset + SImageMargin, SLineHeightDouble + SImageMargin, SImageSize, SImageSize ) );

            g.DrawRectangle( SLinePenBlack, new Rectangle( xOffset, SLineHeightDouble, width, SLineHeight ) );

            return xOffset + width;
        }

        private static int DrawMovement( Graphics g, int xOffset, Archetype.EMovementType movementType, int BW )
        {
            Bitmap img;

            switch( movementType )
            {
                case Archetype.EMovementType.Stationär:
                    img = Properties.ResourcesBewegung.bewegung_stationär;
                    break;

                case Archetype.EMovementType.Schweben:
                    img = Properties.ResourcesBewegung.bewegung_schweben;
                    break;

                case Archetype.EMovementType.Beine:
                    img = Properties.ResourcesBewegung.bewegung_beine;
                    break;

                case Archetype.EMovementType.Flug:
                    img = Properties.ResourcesBewegung.bewegung_flug;
                    break;

                case Archetype.EMovementType.Kette:
                    img = Properties.ResourcesBewegung.bewegung_kette;
                    break;

                case Archetype.EMovementType.Rad:
                    img = Properties.ResourcesBewegung.bewegung_rad;
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EMovementType ) );
            }

            int movementStringWidth = CardPainterHelpers.CmToPixel( 0.6 );
            int width = movementStringWidth + 3 * SImageMargin + SImageSize;

            g.DrawImage( img, new Rectangle( xOffset + SImageMargin, SLineHeightDouble + SImageMargin, SImageSize, SImageSize ) );

            CardPainterHelpers.DrawStringCentered( g, BW.ToString(), FontStandard, Brushes.Black, new Rectangle( xOffset + 2 * SImageMargin + SImageSize, SLineHeightDouble, movementStringWidth, SLineHeight ) );

            g.DrawRectangle( SLinePenBlack, new Rectangle( xOffset, SLineHeightDouble, width, SLineHeight ) );

            return xOffset + width;
        }

        private static void DrawSectionHeader( Graphics g, String name, Image sectionHeader, int posY )
        {
            Rectangle sectionRectangle = new Rectangle( SSectionsPosX, posY, sectionHeader.Width, sectionHeader.Height );

            g.DrawImageUnscaled(sectionHeader, sectionRectangle );

            g.DrawString( name, FontStandard, Brushes.White, sectionRectangle, StringFormatHLeftVCenter );
        }

        private static int DrawTraits( Graphics g, List<Actor.ActorTrait> actorTraitList, int posY )
        {
            if( actorTraitList.Count > 0 )
            {
                const String delimiter = ", ";

                StringBuilder builder = new StringBuilder();

                foreach( var entry in actorTraitList.Select( x => new { x.Trait, x.Level } )
                                                    .GroupBy( x => x )
                                                    .Select( x => new { Name = x.Key.Trait.FormattedName( x.Key.Level ), x.Key.Trait, Count = x.Count() } )
                                                    .Where( x => ( x.Trait.AP > 0 )
                                                                 ||
                                                                 ( x.Trait.UseOnce )
                                                                 ||
                                                                 ( !String.IsNullOrEmpty( x.Trait.Rules ) ) )
                                                    .OrderBy( x => x.Name )
                                                    .ToList() )
                {
                    builder.Append( entry.Name );

                    if( entry.Trait.AP > 0 )
                    {
                        builder.Append( StringHelper.NonBreakingSpace + ActionsPointsMarker + entry.Trait.AP );
                    }

                    if( entry.Trait.UseOnce )
                    {
                        builder.Append( StringHelper.NonBreakingSpace );
                        for( int j = 0; j < entry.Count; j++ )
                        {
                            builder.Append(UseOnceMarker);
                        }
                    }

                    builder.Append( delimiter );
                }

                String traitsString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                DrawSectionHeader( g, "Eigenschaften", SectionHeaderTraits, posY );
                posY += SLineHeight;

                Size size = g.MeasureString( traitsString, FontTraits, SSectionsWidth, StringFormatHLeftVTop ).ToSize();

                g.DrawString( traitsString, FontTraits, Brushes.Black, new Rectangle( SSectionsPosX, posY, SSectionsWidth, SCardHeight - posY ), StringFormatHLeftVTop );

                return posY + size.Height;
            }

            return posY;
        }

        private static int DrawWeapons( Graphics g, Actor actor, int posY )
        {
            int lineNumber = 1;

            Weapon weaponUnarmed = null;

            if( !actor.Weapons.Any( s => s.Weapon.Type == Weapon.EType.Nahkampf ) )
            {
                weaponUnarmed = actor.WeaponUnarmed();
            }

            if( ( actor.Weapons.Count == 0 ) && ( weaponUnarmed == null ) )
            {
                return posY;
            }
            else
            {
                DrawSectionHeader( g, "Waffen", SectionHeaderWeapons, posY );

                // Captions
                g.DrawImage( Properties.Resources.Stärke_weiss, new Rectangle( WeaponStrengthStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                g.DrawImage( Properties.Resources.Schaden_weiss, new Rectangle( WeaponDamageStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                g.DrawImage( Properties.Resources.Reichweite_weiss, new Rectangle( WeaponRangeStart + ( WeaponRangeWidth / 2 ) - ( SLineHeight / 2 ) + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                if( weaponUnarmed != null )
                {
                    DrawSingleWeapon( g, actor, weaponUnarmed, 1, posY + ( lineNumber * SLineHeight ) );

                    lineNumber++;
                }

                foreach( var weaponEntry in actor.Weapons.GroupBy( x => x.Weapon )
                                                            .Select( x => new { weapon = x.Key, count = x.Count() } )
                                                            .OrderBy( x => x.weapon.Class )
                                                            .ThenBy( x => x.weapon.RangeSort )
                                                            .ThenBy( x => x.weapon.Name ) )
                {
                    DrawSingleWeapon( g, actor, weaponEntry.weapon, weaponEntry.count, posY + ( lineNumber * SLineHeight ) );

                    lineNumber++;
                }

                int lineVertEnd = posY + ( lineNumber * SLineHeight );

                // right of name
                g.DrawLine( SLinePenBlack, WeaponNameStart + WeaponNameWidth, posY + SLineHeight, WeaponNameStart + WeaponNameWidth, lineVertEnd );
                // right of range
                g.DrawLine( SLinePenBlack, WeaponRangeStart + WeaponRangeWidth, posY + SLineHeight, WeaponRangeStart + WeaponRangeWidth, lineVertEnd );
                // right of strength
                g.DrawLine( SLinePenBlack, WeaponStrengthStart + WeaponStrengthWidth, posY + SLineHeight, WeaponStrengthStart + WeaponStrengthWidth, lineVertEnd );
                // right of damage
                g.DrawLine( SLinePenBlack, WeaponDamageStart + WeaponDamageWidth, posY + SLineHeight, WeaponDamageStart + WeaponDamageWidth, lineVertEnd );

                return posY + ( SLineHeight * lineNumber );
            }
        }

        private static void DrawSingleWeapon( Graphics g, Actor actor, Weapon weapon, int count, int posY )
        {
            g.DrawLine( SLinePenBlack, SSectionsPosX, posY + SLineHeight, SCardWidth, posY + SLineHeight );
            
            Rectangle wkRect = new Rectangle( WeaponWkStart, posY, WeaponWkWidth, SLineHeight );
            g.FillRectangle( Brushes.Black, wkRect );
            CardPainterHelpers.DrawStringCentered( g, weapon.Class.ToString(), FontWk, Brushes.White, wkRect );
            
            if( weapon.Unwieldy )
            {
                Rectangle unwieldyRect = new Rectangle( wkRect.Right - WeaponUnwieldyWidth, wkRect.Y, WeaponUnwieldyWidth, WeaponUnwieldyWidth );
                CardPainterHelpers.DrawStringCentered( g, UnwieldyMarker, FontUnwieldy, Brushes.White, unwieldyRect );
            }
            
            string weaponName = weapon.Name;

            if( weapon.UseOnce )
            {
                weaponName += Environment.NewLine;
                for( int j = 0; j < count; j++ )
                {
                    weaponName += UseOnceMarker;
                }
            }
            else
            {
                if( count > 1 )
                {
                    weaponName = $"{count}x {weapon.Name}";
                }
            }

            Size nameSize = new Size( WeaponNameWidth, SLineHeight );
            g.MeasureString( weaponName, FontWeaponName, nameSize, StringFormatHLeftVCenter, out int charsFitted, out _ );
            if( charsFitted < weaponName.Length )
            {
                weaponName = "NAME IST ZU LANG!";
            }

            g.DrawString( weaponName, FontWeaponName, Brushes.Black, new Rectangle( new Point( WeaponNameStart, posY ), nameSize ), StringFormatHLeftVCenter );

            if( weapon.AdditiveStrength )
            {
                CardPainterHelpers.DrawStringCentered( g, ( weapon.Strength + actor.ModPHY() ).ToString(), FontWeapon, WeaponFontBrush, new Rectangle( WeaponStrengthStart, posY, WeaponStrengthWidth, SLineHeight ) );
            }
            else
            {
                CardPainterHelpers.DrawStringCentered( g, weapon.FormattedStrength, FontWeapon, WeaponFontBrush, new Rectangle( WeaponStrengthStart, posY, WeaponStrengthWidth, SLineHeight ) );
            }

            CardPainterHelpers.DrawStringCentered( g, weapon.FormattedDamage, FontWeapon, WeaponFontBrush, new Rectangle( WeaponDamageStart, posY, WeaponDamageWidth, SLineHeight ) );

            if( Weapon.EType.Wurf == weapon.Type )
            {
                CardPainterHelpers.DrawStringCentered( g, Actor.ThrowRange( actor.ModPHY(), weapon.Unwieldy ), FontWeapon, WeaponFontBrush, new Rectangle( WeaponRangeStart, posY, WeaponRangeWidth, SLineHeight ) );
            }
            else
            {
                CardPainterHelpers.DrawStringCentered( g, weapon.FormattedRange, FontWeapon, WeaponFontBrush, new Rectangle( WeaponRangeStart, posY, WeaponRangeWidth, SLineHeight ) );
            }

            int remainderPosX = WeaponDamageStart + WeaponDamageWidth;

            if( weapon.SustainedFire > 0 )
            {
                var afImg = new Bitmap( SImageSize, SImageSize );

                int afSize = (int)(SImageSize / 2.5);

                using( var g_af = Graphics.FromImage( afImg ) )
                {
                    switch( weapon.SustainedFire )
                    {
                        case 1:
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - ( afSize / 2 ), ( SImageSize / 2 ) - ( afSize / 2 ), afSize, afSize ) );
                            break;

                        case 2:
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - afSize, ( SImageSize / 2 ) - afSize, afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ), ( SImageSize / 2 ), afSize, afSize ) );
                            break;

                        case 3:
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - afSize, ( SImageSize / 2 ) - afSize, afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - afSize, ( SImageSize / 2 ), afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ), ( SImageSize / 2 ) - ( afSize / 2 ), afSize, afSize ) );
                            break;

                        case 4:
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - afSize, ( SImageSize / 2 ) - afSize, afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ) - afSize, ( SImageSize / 2 ), afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ), ( SImageSize / 2 ) - afSize, afSize, afSize ) );
                            g_af.DrawImage( Properties.Resources.Autofeuer, new Rectangle( ( SImageSize / 2 ), ( SImageSize / 2 ), afSize, afSize ) );
                            break;
                    }
                }

                g.DrawImage( afImg, new Rectangle( remainderPosX + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                remainderPosX += SImageSize;
            }

            if( weapon.Reloadable )
            {
                g.DrawImage( Properties.Resources.nachladen, new Rectangle( remainderPosX + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                remainderPosX += SImageSize;
            }

            if( weapon.IndirectFire )
            {
                g.DrawImage( Properties.Resources.Indirekt, new Rectangle( remainderPosX + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                remainderPosX += SImageSize;
            }

            if( weapon.Radius > 0 )
            {
                Rectangle rect = new Rectangle( remainderPosX + WeaponRadiusMargin, posY + WeaponRadiusMargin, SLineHeight - ( 2 * WeaponRadiusMargin ), SLineHeight - ( 2 * WeaponRadiusMargin ) );
                g.FillEllipse( Brushes.Black, rect );
                CardPainterHelpers.DrawStringCentered( g, weapon.FormattedRadius, FontWeaponRadius, Brushes.White, rect );

                remainderPosX += SImageSize;
            }

            int damageEffectsPosX = DrawDamageEffects( g, remainderPosX, posY, weapon.EffectsImage );

            if( ( remainderPosX + damageEffectsPosX ) > SCardWidth )
            {
                Rectangle rect = new Rectangle( remainderPosX, posY, SCardWidth - remainderPosX, SLineHeight );
                g.FillRectangle( Brushes.Purple, rect );
                g.DrawString( "KEIN PLATZ", FontWeapon, Brushes.White, rect, StringFormatHCenterVCenter );
            }
        }

        private static int DrawDamageEffects( Graphics g, int posX, int posY, Image effectImage )
        {
            int effectImageWidthDraw = (int)( ( (float)SImageSize / (float)effectImage.Height ) * effectImage.Width );

            g.DrawImage( effectImage, new Rectangle( posX + SImageMargin, posY + SImageMargin, effectImageWidthDraw, SImageSize ) );

            return SImageMargin + effectImageWidthDraw;
        }

        private static int DrawArmor( Graphics g, Actor actor, Armor armor, int posY )
        {
            if( armor != null )
            {
                int nameWidth = CardPainterHelpers.CmToPixel( 3.7 );
                int protectionWidth = CardPainterHelpers.CmToPixel( 0.5 );
                int damageReductionWidth = CardPainterHelpers.CmToPixel( 0.5 );

                int protectionStart = SSectionsPosX + nameWidth;
                int damageReductionStart = protectionStart + protectionWidth;
                int effectsStart = damageReductionStart + damageReductionWidth;

                DrawSectionHeader( g, "Rüstung", SectionHeaderArmor, posY );

                g.DrawLine( SLinePenBlack, SSectionsPosX, posY + SLineHeightDouble, SSectionsWidth, posY + SLineHeightDouble );

                g.DrawString( armor.Name, FontArmorName, Brushes.Black, new Rectangle( SSectionsPosX, posY + SLineHeight, nameWidth, SLineHeight ), StringFormatHLeftVCenter );

                // Protection
                g.DrawLine( SLinePenBlack, protectionStart, posY + SLineHeight, protectionStart, posY + SLineHeightDouble );
                g.DrawImage( Properties.Resources.Schutz_weiss, new Rectangle( protectionStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                int actorModPHY = actor.ModPHY();

                if( armor.AdditiveProtection )
                {
                    CardPainterHelpers.DrawStringCentered( g, ( armor.Protection + actorModPHY ).ToString(), FontArmor, ArmorFontBrush, new Rectangle( protectionStart, posY + SLineHeight, protectionWidth, SLineHeight ) );
                }
                else
                {
                    CardPainterHelpers.DrawStringCentered( g, Math.Max( armor.Protection, actorModPHY ).ToString(), FontArmor, ArmorFontBrush, new Rectangle( protectionStart, posY + SLineHeight, protectionWidth, SLineHeight ) );
                }

                // Damage Reduction
                g.DrawLine( SLinePenBlack, damageReductionStart, posY + SLineHeight, damageReductionStart, posY + SLineHeightDouble );
                g.DrawImage( Properties.Resources.Schadensreduktion_weiss, new Rectangle( damageReductionStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                CardPainterHelpers.DrawStringCentered( g, armor.FormattedDamageReduction, FontArmor, ArmorFontBrush, new Rectangle( damageReductionStart, posY + SLineHeight, damageReductionWidth, SLineHeight ) );

                // Damage Effects
                g.DrawLine( SLinePenBlack, effectsStart, posY + SLineHeight, effectsStart, posY + SLineHeightDouble );

                int damageEffectsPosX = DrawDamageEffects( g, effectsStart, posY + SLineHeight, armor.EffectsImage );

                if( ( effectsStart + damageEffectsPosX ) > SCardWidth )
                {
                    Rectangle rect = new Rectangle( effectsStart, posY + SLineHeight, SCardWidth - effectsStart, SLineHeight );
                    g.FillRectangle( Brushes.Purple, rect );
                    g.DrawString( "KEIN PLATZ", FontArmor, Brushes.White, rect, StringFormatHCenterVCenter );
                }

                return posY + SLineHeight * 2;
            }
            else
            {
                return posY;
            }
        }

        private static int DrawEquipment( Graphics g, List<Actor.ActorEquipment> actorEquipmentList, int posY )
        {
            var equipList = actorEquipmentList.GroupBy( x => x.Equipment )
                                              .Select( x => new { equipment = x.Key, count = x.Count() } )
                                              .Where( x => ( x.equipment.AP > 0 )
                                                           ||
                                                           ( x.equipment.UseOnce )
                                                           ||
                                                           ( x.equipment.Unwieldy )
                                                           ||
                                                           ( !String.IsNullOrEmpty( x.equipment.Rules ) ) )
                                              .OrderBy( x => x.equipment.Name )
                                              .ToList();

            if( equipList.Count > 0 )
            {
                const string delimiter = ", ";

                StringBuilder builder = new StringBuilder();
                foreach( var entry in equipList )
                {
                    builder.Append( entry.equipment.Name );

                    if( entry.equipment.Unwieldy )
                    {
                        builder.Append( UnwieldyMarker );
                    }

                    if( entry.equipment.AP > 0 )
                    {
                        builder.Append( " " + ActionsPointsMarker + entry.equipment.AP );
                    }

                    if( entry.equipment.UseOnce )
                    {
                        builder.Append( StringHelper.NonBreakingSpace );
                        for( int i = 0; i < entry.count; i++ )
                        {
                            builder.Append(UseOnceMarker);
                        }
                    }
                    else
                    {
                        if( entry.count > 1 )
                        {
                            builder.Append( StringHelper.NonBreakingSpace + $"[x{entry.count}]" );
                        }
                    }

                    builder.Append( delimiter );
                }

                DrawSectionHeader( g, "Ausrüstung", SectionHeaderEquipment, posY );
                posY += SLineHeight;

                string equipmentString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                Size size = g.MeasureString( equipmentString, FontTraits, SSectionsWidth, StringFormatHLeftVTop ).ToSize();

                g.DrawString( equipmentString, FontEquipment, Brushes.Black, new Rectangle( SSectionsPosX, posY, SSectionsWidth, SCardHeight - posY ), StringFormatHLeftVTop );

                return posY + size.Height;
            }
            else
            {
                return posY;
            }
        }

        private static int DrawDisciplines( Graphics g, List<Actor.ActorDiscipline> actorDisciplineList, int posY )
        {
            if( actorDisciplineList.Count > 0 )
            {
                const String delimiter = ", ";

                StringBuilder builder = new StringBuilder();

                foreach( var entry in actorDisciplineList.Select( x => x.Discipline.FormattedName( x.Level ) )
                                                         .OrderBy( x => x )
                                                         .ToList() )
                {
                    builder.Append( entry );

                    builder.Append( delimiter );
                }

                String disciplinesString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                DrawSectionHeader( g, "Disziplinen", SectionHeaderDisciplines, posY );
                posY += SLineHeight;

                Size size = g.MeasureString( disciplinesString, FontDisciplines, SSectionsWidth, StringFormatHLeftVTop ).ToSize();

                g.DrawString( disciplinesString, FontDisciplines, Brushes.Black, new Rectangle( SSectionsPosX, posY, SSectionsWidth, SCardHeight - posY ), StringFormatHLeftVTop );

                return  posY + size.Height;
            }

            return posY;
        }
    }
}
