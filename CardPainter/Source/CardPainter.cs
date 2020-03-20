using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Universalis
{
    public static class CardPainter
    {
        #region members
        public const int Dpi = 500;

        public const int CardWidthCm = 12;
        public const int CardHeightCm = 8;
        public const int SectionWidthCm = 8;

        private static readonly int SCardWidth = CmToPixel( CardWidthCm );
        private static readonly int SCardHeight = CmToPixel( CardHeightCm );
        private static readonly int SSectionsWidth = CmToPixel( SectionWidthCm );

        private static readonly int SSectionsPosX = CmToPixel( 4 );

        private static readonly Rectangle SPictureRect = new Rectangle( 0, CmToPixel( 0.5 ), SSectionsPosX, CmToPixel( 7 ) );

        private static readonly int SSubstancePointSize = CmToPixel( 0.3 );

        private static readonly Pen SLinePenBlack = Pens.Black;
        private static readonly Pen SStructureBlackPen = new Pen( Color.Black, CmToPixel( 0.02f ) );
        private static readonly Pen SStructureRedPen = new Pen( Color.Red, CmToPixel( 0.2f ) );
        private static readonly Pen SSubstanceBorderPen = new Pen( Color.Black, CmToPixel( 0.015f ) );
        // TODO maybe still needed later
        // private static readonly Pen unwieldyCirclePen = new Pen( Color.White, CmToPixel( 0.015f ) );

        private static readonly Font Font0Dot2 = new Font( UniversalisFont.Family, CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font Font0Dot3 = new Font( UniversalisFont.Family, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font Font0Dot35 = new Font( UniversalisFont.Family, CmToPixel( 0.35 ), FontStyle.Regular, GraphicsUnit.Pixel );

        private static readonly Font FontStandard = Font0Dot35;
        private static readonly Font FontStandardSmall = Font0Dot2;
        private static readonly Font FontName = Font0Dot3;
        private static readonly Font FontNameSmall = Font0Dot2;
        private static readonly Font FontSize = Font0Dot3;
        private static readonly Font FontPoints = Font0Dot2;
        private static readonly Font FontWeapon = Font0Dot3;
        private static readonly Font FontWeaponName = Font0Dot2;
        private static readonly Font FontWk = Font0Dot3;
        private static readonly Font FontArmor = Font0Dot3;
        private static readonly Font FontArmorName = Font0Dot2;
        private static readonly Font FontEquipment = Font0Dot3;
        private static readonly Font FontTraits = Font0Dot3;

        private static readonly Brush SubstanceCritBrush = new SolidBrush( Color.Orange );
        private static readonly Brush SubstanceNormalBrush = new SolidBrush( Color.White );

        private static readonly Brush WeaponFontBrush = new SolidBrush( DamageColor.red );
        private static readonly Brush ArmorFontBrush = new SolidBrush( DamageColor.green );

        private static readonly int SLineHeight = CmToPixel( 0.5 );
        private static readonly int SLineHeightDouble = ( SLineHeight * 2 );

        private static readonly int SImageMargin = SLineHeight / 10;
        private static readonly int SImageSize = SLineHeight - ( SImageMargin * 2 );

        private static readonly Image SectionHeaderTraits = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.SteelBlue );
        private static readonly Image SectionHeaderWeapons = SectionHeader.Create( SSectionsWidth, SLineHeight, Color.OrangeRed );
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
        private static readonly int XAttrSecondColumn = CmToPixel( 6.1 );
        private static readonly int XAttrThirdColumn = CmToPixel( 8.5 );

        private const String NonBreakingSpace = "\u00a0";
        #endregion members

        #region weaponMembers
        private static readonly int WeaponWkWidth = CmToPixel( 0.5 );
        private static readonly int WeaponNameWidth = CmToPixel( 3.3 ) - SLineHeight;
        private static readonly int WeaponPotentialWidth = CmToPixel( 0.5 );
        private static readonly int WeaponSubstanceWidth = CmToPixel( 0.5 );
        private static readonly int WeaponRangeWidth = CmToPixel( 0.9 );

        private static readonly int WeaponWkStart = SSectionsPosX;
        private static readonly int WeaponNameStart = WeaponWkStart + WeaponWkWidth;
        private static readonly int WeaponTypeStart = WeaponNameStart + WeaponNameWidth;
        private static readonly int WeaponPotentialStart = WeaponTypeStart + SLineHeight;
        private static readonly int WeaponSubstanceStart = WeaponPotentialStart + WeaponPotentialWidth;
        private static readonly int WeaponRangeStart = WeaponSubstanceStart + WeaponSubstanceWidth;

        private static readonly int WeaponRadiusMargin = SImageMargin + CmToPixel( 0.015f );
        #endregion

        public static Bitmap GetBitmap( Group.GroupActor groupActor )
        {
            return( GetBitmap( groupActor.Actor, groupActor.ActorOutfit, groupActor.CustomName, groupActor.CustomImg ) );
        }

        public static Bitmap GetBitmap( Actor actor, Actor.ActorOutfit actorOutfit )
        {
            return ( GetBitmap( actor, actorOutfit, String.Empty ) );
        }

        private static Bitmap GetBitmap( Actor actor, Actor.ActorOutfit actorOutfit, string customName, Bitmap customImage = null )
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

                DrawName( g, actor.Name, customName );
                DrawFaction( g, actor.Faction );

                DrawPicture( g, customImage ?? actor.Img );

                DrawAttributes( g, actor, actorOutfit );
                DrawCalculatedAttributes( g, actor, actorOutfit );
                DrawMisc( g, actor, actorOutfit );

                DrawSubstance( g, actor );
                DrawPoints( g, actor, actorOutfit );

                int traitsEndY = DrawTraits( g, actor.ActorTraitsList );

                int weaponsCount = DrawWeapons( g, actor, actorOutfit, traitsEndY );

                int armorPosY = traitsEndY + ( SLineHeight * weaponsCount );
                DrawArmor( g, actor.Armor, armorPosY );

                int equipmentYPos = armorPosY + SLineHeight * ( ( null == actor.Armor ? 0 : 2 ) );
                int equipmentEndY = equipmentYPos;
                if( actorOutfit != null )
                {
                    equipmentEndY = DrawEquipment( g, actorOutfit.ActorEquipmentList, equipmentYPos );
                }

                // draw the structure last, otherwise "lower" elements could paint over it
                DrawStructure( g, equipmentEndY );

                // show black lines between sections on the right side of the card
                g.DrawLine( SStructureBlackPen, SSectionsPosX, traitsEndY,    SCardWidth, traitsEndY );
                g.DrawLine( SStructureBlackPen, SSectionsPosX, armorPosY,     SCardWidth, armorPosY );
                g.DrawLine( SStructureBlackPen, SSectionsPosX, equipmentYPos, SCardWidth, equipmentYPos );

                return ( img );
            }
        }

        public static int CmToPixel( double cm )
        {
            return ( Convert.ToInt32( cm / 2.54f * Dpi ) );
        }

        private static void DrawStructure( Graphics g, int equipmentEndY )
        {
            // line right of image
            g.DrawLine( SStructureBlackPen, SSectionsPosX, 0, SSectionsPosX, SCardHeight );

            // line under "Name"
            g.DrawLine( SStructureBlackPen, 0, CmToPixel( 0.5 ), SSectionsPosX, CmToPixel( 0.5 ) );

            // line above "Points"
            g.DrawLine( SStructureBlackPen, 0, CmToPixel( 7.5 ), SSectionsPosX, CmToPixel( 7.5 ) );
            
            // line under "Attribute"
            g.DrawLine( SStructureBlackPen, SSectionsPosX, CmToPixel( 1.5 ), SCardWidth, CmToPixel( 1.5 ) );

            // surrounding rectangle
            if( equipmentEndY > SCardHeight )
            {
                // draw in red to know that not everything fits on the card
                g.DrawRectangle( SStructureRedPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
            }
            else
            {
                g.DrawRectangle( SStructureBlackPen, 0, 0, SCardWidth - 1, SCardHeight - 1 );
            }
        }

        private static void DrawName( Graphics g, String actorName, string customName )
        {
            int posX = CmToPixel( 0.5 );
            int posY = 0;

            string name = actorName + ( String.IsNullOrEmpty( customName ) ? String.Empty : ( Environment.NewLine + customName ) );

            Size textSize = new Size( CmToPixel( 4 ) - posX, CmToPixel( 0.5 ) );
            Rectangle textRect = new Rectangle( new Point( posX, posY ), textSize );

            int charsFitted, linesFilled;
            g.MeasureString( name, FontName, textSize, StringFormatHCenterVCenter, out charsFitted, out linesFilled );

            g.DrawString( name, linesFilled > 1 ? FontNameSmall : FontName, Brushes.Black, textRect, StringFormatHCenterVCenter );
        }

        private static void DrawFaction( Graphics g, Faction faction )
        {
            Rectangle rect = new Rectangle( Point.Empty, new Size( CmToPixel( 0.5 ), CmToPixel( 0.5 ) ) );

            g.DrawImage( faction.Icon, rect );

            g.DrawRectangle( SLinePenBlack, rect );
        }

        private static void DrawPicture( Graphics g, Bitmap image )
        {
            if( image != null )
            {
                g.DrawImage( image, SPictureRect );
            }
        }

        private static void DrawAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            DrawAttribute( g, XAttrFirstColumn, 0, "AGI", actor.ModAGI( actorOutfit ) );
            DrawAttribute( g, XAttrFirstColumn, CmToPixel( 0.5 ), "BW", actor.ModBW( actorOutfit ) );
            DrawAttribute( g, XAttrFirstColumn, CmToPixel( 1 ), "KO", actor.ModKO( actorOutfit ) );

            DrawAttribute( g, XAttrSecondColumn, 0, "FK", actor.ModFK( actorOutfit ) );
            DrawAttribute( g, XAttrSecondColumn, CmToPixel( 0.5 ), "WN", actor.ModWN( actorOutfit ) );
            DrawAttribute( g, XAttrSecondColumn, CmToPixel( 1 ), "EH", actor.ModEH( actorOutfit ) );
        }

        private static void DrawAttribute( Graphics g, int posX, int posY, string name, int attribModValue )
        {
            int widthName = CmToPixel( 0.9 );
            int widthAtt = CmToPixel( 0.6 );

            Rectangle rectName = new Rectangle( posX, posY, widthName, SLineHeight );
            Rectangle rectModified = new Rectangle( posX + widthName, posY, 2 * widthAtt, SLineHeight );

            g.DrawRectangle( SLinePenBlack, new Rectangle( posX, posY, widthName + widthAtt + widthAtt, SLineHeight ) );

            g.FillRectangle( Brushes.Black, rectName );

            Helpers.DrawStringCentered( g, name, FontStandard, Brushes.White, rectName );

            int printModValue = attribModValue < 0 ? 0 : attribModValue;
            Helpers.DrawStringCentered( g, printModValue.ToString(), FontStandard, attribModValue < 0 ? Brushes.Red : Brushes.Black, rectModified );
        }

        private static void DrawCalculatedAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            // WB - Wahrnehmungsbereich
            g.DrawImage( Properties.Resources.Wahrnehmungsbereich, new Rectangle( XAttrThirdColumn, SImageMargin, SImageSize, SImageSize ) );

            string fovAndModWbString = $"{(int)actor.Fov}°/{actor.ModWB( actorOutfit )}cm";
            Size fovAndModWbSize = g.MeasureString( fovAndModWbString, FontStandard ).ToSize();
            Helpers.DrawStringCentered( g, fovAndModWbString, FontStandard, Brushes.Black, new Rectangle( XAttrThirdColumn + CmToPixel( 0.5 ), 0, fovAndModWbSize.Width + CmToPixel( 0.1 ), CmToPixel( 0.5 ) ) );

            // GB - Gefahrenbereich
            g.DrawImage( Properties.Resources.Gefahrenbereich, new Rectangle( XAttrThirdColumn, SLineHeight + SImageMargin, SImageSize, SImageSize ) );
            Helpers.DrawStringCentered( g, $"{actor.GB( actorOutfit )}cm", FontStandard, Brushes.Black, new Rectangle( XAttrThirdColumn + CmToPixel( 0.5 ), SLineHeight, CmToPixel( 1 ), SLineHeight ) );
        }

        private static void DrawSubstance( Graphics g, Actor actor )
        {
            int margin = CmToPixel( 0.1 );

            switch( actor.Type )
            {
                case Actor.EType.Infanterie:
                case Actor.EType.Fahrzeug: // TODO implement completely different HitZones for vehicles? like chassis, engine and so on?
                    int posX = SPictureRect.X + margin;
                    int posY = SPictureRect.Y + margin;

                    DrawSubstanceCirclesVertical( g, actor.TP, posX, posY, SSubstancePointSize );
                    break;

                case Actor.EType.Mech:
                case Actor.EType.Koloss:
                    int posXArmLeft = SPictureRect.X + margin;
                    int posYArmLeft = SPictureRect.Y + margin;

                    int posXArmRight = SPictureRect.Width - SSubstancePointSize - margin;
                    int posYArmRight = SPictureRect.Y + margin;

                    int posXMain = posXArmLeft + SSubstancePointSize + margin;
                    int posYMain = SPictureRect.Y + margin;
                    int widthMain = posXArmRight - margin - posXMain;

                    int posXLegs = posXMain;
                    int posYLegs = SPictureRect.Y + SPictureRect.Height - margin;
                    int widthLegs = widthMain;

                    // main
                    DrawSubstanceCirclesHorizonzal( g, actor.TP, posXMain, posYMain, widthMain, down: true );

                    // left arm
                    DrawSubstanceCirclesVertical( g, actor.HitZoneTP, posXArmLeft, posYArmLeft, SSubstancePointSize );

                    // right arm
                    DrawSubstanceCirclesVertical( g, actor.HitZoneTP, posXArmRight, posYArmRight, SSubstancePointSize );

                    // legs
                    DrawSubstanceCirclesHorizonzal( g, actor.HitZoneTP, posXLegs, posYLegs, widthLegs, down: false );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.EType ) );
            }            
        }

        private static void DrawSubstanceCirclesHorizonzal( Graphics g, int count, int x, int y, int width, bool down )
        {
            int maxColumns = Math.Min( Convert.ToInt32( Math.Floor( (float)width / (float)SSubstancePointSize ) ), count );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int posX = x + ( ( width - ( maxColumns * SSubstancePointSize ) ) / 2 );
            int posY = y - ( down ? 0 : maxRows * SSubstancePointSize );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / 2.0f ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( posX + ( SSubstancePointSize * col ), posY + ( SSubstancePointSize * row ), SSubstancePointSize, SSubstancePointSize );

                g.FillEllipse( i > crit ? SubstanceCritBrush : SubstanceNormalBrush, rect );

                g.DrawEllipse( SSubstanceBorderPen, rect );

                ++col;

                if( col == maxColumns )
                {
                    ++row;
                    col = 0;
                }
            }
        }

        private static void DrawSubstanceCirclesVertical( Graphics g, int count, int x, int y, int width )
        {
            int maxColumns = Convert.ToInt32( Math.Floor( (float)width / SSubstancePointSize ) );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / 2.0f ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( x + ( SSubstancePointSize * col ), y + ( SSubstancePointSize * row ), SSubstancePointSize, SSubstancePointSize );

                g.FillEllipse( i > crit ? SubstanceCritBrush : SubstanceNormalBrush, rect );

                g.DrawEllipse( SSubstanceBorderPen, rect );

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

        private static void DrawPoints( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit  )
        {
            string points = $"{actor.Points( actorOutfit )}pkt";

            if( actorOutfit != null )
            {
                points = actorOutfit.Name + " - " + points;
            }

            g.DrawString( points, FontPoints, Brushes.Black, new Rectangle( 0, CmToPixel( 7.5 ), SSectionsPosX, CmToPixel( 0.5 ) ), StringFormatHCenterVCenter );
        }

        private static void DrawMisc( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            DrawType( g, actor.Type );
            DrawSize( g, actor.Size );
            DrawMovement( g, actor.MovementType );
            DrawWeight( g, actor, actorOutfit );
        }

        private static void DrawType( Graphics g, Actor.EType type )
        {
            Rectangle rect = new Rectangle( XAttrThirdColumn, SLineHeightDouble, SLineHeight, SLineHeight );

            switch( type )
            {
                case Actor.EType.Infanterie:
                    g.DrawImage( Properties.Resources.Infanterie, rect );
                    break;

                case Actor.EType.Mech:
                    g.DrawImage( Properties.Resources.Mech, rect );
                    break;

                case Actor.EType.Koloss:
                    g.DrawImage( Properties.Resources.Koloss, rect );
                    break;

                case Actor.EType.Fahrzeug:
                    g.DrawImage( Properties.Resources.Fahrzeug, rect );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.EType ) );
            }

            g.DrawRectangle( SLinePenBlack, rect );
        }

        private static void DrawSize( Graphics g, Actor.ESize size )
        {
            Bitmap img;

            switch( size )
            {
                case Actor.ESize.Klein :
                    img = Properties.Resources.klein;
                    break;

                case Actor.ESize.Mittel :
                    img = Properties.Resources.mittel;
                    break;

                case Actor.ESize.Groß :
                    img = Properties.Resources.groß;
                    break;

                case Actor.ESize.Riesig:
                    img = Properties.Resources.riesig;
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.ESize ) );
            }

            g.DrawImage( img, new Rectangle( XAttrThirdColumn + SLineHeight + SImageMargin, SLineHeightDouble + SImageMargin, SImageSize, SImageSize ) );

            g.DrawRectangle( SLinePenBlack, new Rectangle( XAttrThirdColumn + SLineHeight, SLineHeightDouble, SLineHeight, SLineHeight ) );
        }

        private static void DrawMovement( Graphics g, EMovementType movementType )
        {
            Bitmap img;

            switch( movementType )
            {
                case EMovementType.Stationär:
                    img = Properties.ResourcesBewegung.bewegung_stationär;
                    break;

                case EMovementType.Antigrav:
                    img = Properties.ResourcesBewegung.bewegung_antigrav;
                    break;

                case EMovementType.Fuss:
                    img = Properties.ResourcesBewegung.bewegung_fuss;
                    break;

                case EMovementType.Flug:
                    img = Properties.ResourcesBewegung.bewegung_flug;
                    break;

                case EMovementType.Kette:
                    img = Properties.ResourcesBewegung.bewegung_kette;
                    break;

                case EMovementType.Rad:
                    img = Properties.ResourcesBewegung.bewegung_rad;
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( EMovementType ) );
            }

            g.DrawImage( img, new Rectangle( XAttrThirdColumn + SLineHeightDouble + SImageMargin, SLineHeightDouble + SImageMargin, SImageSize, SImageSize ) );

            g.DrawRectangle( SLinePenBlack, new Rectangle( XAttrThirdColumn + SLineHeightDouble, SLineHeightDouble, SLineHeight, SLineHeight ) );
        }

        private static void DrawWeight( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            int x1 = XAttrThirdColumn + 3 * SLineHeight;

            int weightStringWidth = CmToPixel( 0.8 );

            g.DrawImage( Properties.Resources.Gewicht, new Rectangle( x1 + SImageMargin, SLineHeightDouble + SImageMargin, SImageSize, SImageSize ) );

            Helpers.DrawStringCentered( g, $"{actor.Weight + actor.LoadoutWeight( actorOutfit, withSelfSustaining: true ):n1}", FontStandardSmall, Brushes.Black, new Rectangle( x1 + 2 * SImageMargin + SImageSize, SLineHeightDouble, weightStringWidth, SLineHeight ) );

            g.DrawRectangle( SLinePenBlack, new Rectangle( x1, SLineHeightDouble, weightStringWidth + 3 * SImageMargin + SImageSize, SLineHeight ) );
        }

        private static void DrawSectionHeader( Graphics g, String name, Image sectionHeader, int posY )
        {
            Rectangle sectionRectangle = new Rectangle( SSectionsPosX, posY, sectionHeader.Width, sectionHeader.Height );

            g.DrawImageUnscaled(sectionHeader, sectionRectangle );

            g.DrawString( name, FontStandard, Brushes.White, sectionRectangle, StringFormatHLeftVCenter );
        }

        private static int DrawTraits( Graphics g, List<Actor.ActorTrait> actorTraitList )
        {
            int posY = CmToPixel( 1.5 );

            if( actorTraitList.Count > 0 )
            {
                const String delimiter = ", ";

                StringBuilder builder = new StringBuilder();
                foreach( Actor.ActorTrait trait in actorTraitList.OrderBy( x => x.Name ) )
                {
                    builder.Append( trait.Name );

                    if( trait.Level > 0 )
                    {
                        builder.Append( NonBreakingSpace + trait.Level );
                    }

                    builder.Append( delimiter );
                }

                String traitsString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                DrawSectionHeader( g, "Eigenschaften", SectionHeaderTraits, posY );
                posY += SLineHeight;

                Size size = g.MeasureString( traitsString, FontTraits, SSectionsWidth, StringFormatHLeftVTop ).ToSize();

                g.DrawString( traitsString, FontTraits, Brushes.Black, new Rectangle( SSectionsPosX, posY, SSectionsWidth, SCardHeight - posY ), StringFormatHLeftVTop );

                return ( posY + size.Height );
            }

            return ( posY );
        }

        private static int DrawWeapons( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit, int posY )
        {
            if( actorOutfit == null )
            {
                return ( 0 );
            }

            int lineNumber = 1;

            Weapon weaponUnarmed = null;

            if( actorOutfit.ActorWeaponsList.FirstOrDefault( s => s.Weapon.Type == Weapon.EType.Nahkampf ) == null )
            {
                weaponUnarmed = actor.WeaponUnarmed( actorOutfit );
            }

            if( ( actorOutfit.ActorWeaponsList.Count == 0 ) && ( weaponUnarmed == null ) )
            {
                return ( 0 );
            }
            else
            {
                DrawSectionHeader( g, "Waffen", SectionHeaderWeapons, posY );

                // Captions
                g.DrawImage( Properties.Resources.Stärke_weiss, new Rectangle( WeaponPotentialStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                g.DrawImage( Properties.Resources.Schaden_weiss, new Rectangle( WeaponSubstanceStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                g.DrawImage( Properties.Resources.Reichweite_weiss, new Rectangle( WeaponRangeStart + ( WeaponRangeWidth / 2 ) - ( SLineHeight / 2 ) + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                if( weaponUnarmed != null )
                {
                    DrawWeapon( g, actor, actorOutfit, weaponUnarmed, 1, posY + ( lineNumber * SLineHeight ) );

                    lineNumber++;
                }

                foreach( var weaponEntry in actorOutfit.ActorWeaponsList.GroupBy( x => x.Weapon.ID )
                                                                    .Select( x => new { weapon = WeaponStorage.Instance.Get( x.Key ), count = x.Count() } )
                                                                    .OrderBy( x => x.weapon.WK )
                                                                    .ThenBy( x => x.weapon.RangeSort )
                                                                    .ThenBy( x => x.weapon.Name ) )
                {
                    DrawWeapon( g, actor, actorOutfit, weaponEntry.weapon, weaponEntry.count, posY + ( lineNumber * SLineHeight ) );

                    lineNumber++;
                }

                Weapon weaponDetonation = actor.WeaponDetonation( actorOutfit );
                if( weaponDetonation != null )
                {
                    DrawWeapon( g, actor, actorOutfit, weaponDetonation, 1, posY + ( lineNumber * SLineHeight ) );

                    lineNumber++;
                }

                int lineVertEnd = posY + ( lineNumber * SLineHeight );

                // right of name
                g.DrawLine( SLinePenBlack, WeaponWkStart, posY + SLineHeight, WeaponWkStart, lineVertEnd );
                // right of wk
                g.DrawLine( SLinePenBlack, WeaponPotentialStart, posY + SLineHeight, WeaponPotentialStart, lineVertEnd );
                // right of potential
                g.DrawLine( SLinePenBlack, WeaponSubstanceStart, posY + SLineHeight, WeaponSubstanceStart, lineVertEnd );
                // right of substance
                g.DrawLine( SLinePenBlack, WeaponRangeStart, posY + SLineHeight, WeaponRangeStart, lineVertEnd );
                // right of range
                g.DrawLine( SLinePenBlack, WeaponRangeStart + WeaponRangeWidth, posY + SLineHeight, WeaponRangeStart + WeaponRangeWidth, lineVertEnd );

                return( lineNumber );
            }
        }

        private static void DrawWeapon( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit, Weapon weapon, int count, int posY )
        {
            g.DrawLine( SLinePenBlack, SSectionsPosX, posY + SLineHeight, SCardWidth, posY + SLineHeight );

            Rectangle wkRect = new Rectangle( WeaponWkStart, posY, WeaponWkWidth, SLineHeight );
            g.FillRectangle( Brushes.Black, wkRect );
            Helpers.DrawStringCentered( g, weapon.WK.ToString(), FontWk, Brushes.White, wkRect );

            if( weapon.Unwieldy )
            {
                /* TODO which is nicer? THe circle or the triangles?
                Rectangle circleRect = new Rectangle( wkRect.Location, wkRect.Size );
                circleRect.Inflate( CmToPixel( -0.05 ), CmToPixel( -0.05 ) );
                g.DrawEllipse( unwieldyCirclePen, circleRect );
                */
                Point[] pointsLeft = new Point[ 3 ] { new Point( wkRect.Location.X, wkRect.Location.Y + ( wkRect.Size.Height / 2 ) ),
                                                      new Point( wkRect.Location.X + CmToPixel( 0.1 ), wkRect.Location.Y + ( wkRect.Size.Height / 3 ) ),
                                                      new Point( wkRect.Location.X + CmToPixel( 0.1 ), wkRect.Location.Y + ( wkRect.Size.Height / 3 * 2 ) ) };
                Point[] pointsRight = new Point[ 3 ] { new Point( wkRect.Location.X + wkRect.Size.Width, wkRect.Location.Y + ( wkRect.Size.Height / 2 ) ),
                                                       new Point( wkRect.Location.X + wkRect.Size.Width - CmToPixel( 0.1 ), wkRect.Location.Y + ( wkRect.Size.Height / 3 ) ),
                                                       new Point( wkRect.Location.X + wkRect.Size.Width - CmToPixel( 0.1 ), wkRect.Location.Y + ( wkRect.Size.Height / 3 * 2 ) ) };
                g.FillPolygon( Brushes.White, pointsLeft );
                g.FillPolygon( Brushes.White, pointsRight );
            }

            string weaponName = weapon.Name;

            if( weapon.UseOnce )
            {
                weaponName += Environment.NewLine;
                for( int j = 0; j < count; j++ )
                {
                    weaponName += "○";
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
            int charsFitted, linesFilled;
            g.MeasureString( weaponName, FontWeaponName, nameSize, StringFormatHLeftVCenter, out charsFitted, out linesFilled );
            if( charsFitted < weaponName.Length )
            {
                weaponName = "NAME IST ZU LANG!";
            }

            g.DrawString( weaponName, FontWeaponName, Brushes.Black, new Rectangle( new Point( WeaponNameStart, posY ), nameSize ), StringFormatHLeftVCenter );

            DrawDamageType( g, WeaponPotentialStart, posY, weapon.DamageTypeImage );

            if( weapon.AdditivePotential )
            {
                Helpers.DrawStringCentered( g, ( weapon.Potential + actor.ModKO( actorOutfit ) ).ToString(), FontWeapon, WeaponFontBrush, new Rectangle( WeaponPotentialStart, posY, WeaponPotentialWidth, SLineHeight ) );
            }
            else
            {
                Helpers.DrawStringCentered( g, weapon.FormattedPotential, FontWeapon, WeaponFontBrush, new Rectangle( WeaponPotentialStart, posY, WeaponPotentialWidth, SLineHeight ) );
            }

            Helpers.DrawStringCentered( g, weapon.FormattedSubstance, FontWeapon, WeaponFontBrush, new Rectangle( WeaponSubstanceStart, posY, WeaponSubstanceWidth, SLineHeight ) );

            if( Weapon.EType.Wurf == weapon.Type )
            {
                Helpers.DrawStringCentered( g, Actor.ThrowRange( actor.ModKO( actorOutfit ) ), FontWeapon, WeaponFontBrush, new Rectangle( WeaponRangeStart, posY, WeaponRangeWidth, SLineHeight ) );
            }
            else
            {
                Helpers.DrawStringCentered( g, weapon.FormattedRange, FontWeapon, WeaponFontBrush, new Rectangle( WeaponRangeStart, posY, WeaponRangeWidth, SLineHeight ) );
            }

            int remainderPosX = WeaponRangeStart + WeaponRangeWidth;

            if( weapon.AF > 0 )
            {
                remainderPosX += SImageMargin;

                int width = ( SImageSize ) / 3;

                for( int j = 0; j < weapon.AF; j++ )
                {
                    g.DrawImage( Properties.Resources.patrone, new Rectangle( remainderPosX, posY + SImageMargin, width, SImageSize ) );

                    remainderPosX += width;
                }
            }

            if( weapon.IndirectFire )
            {
                g.DrawImage( Properties.Resources.Indirekt, new Rectangle( remainderPosX + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                remainderPosX += SLineHeight;
            }

            if( weapon.Radius > 0 )
            {
                Rectangle rect = new Rectangle( remainderPosX + WeaponRadiusMargin, posY + WeaponRadiusMargin, SLineHeight - ( 2 * WeaponRadiusMargin ), SLineHeight - ( 2 * WeaponRadiusMargin ) );
                g.FillEllipse( Brushes.Black, rect );
                Helpers.DrawStringCentered( g, weapon.FormattedRadius, FontWeapon, Brushes.White, rect );

                remainderPosX += SLineHeight;
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

            return ( SImageMargin + effectImageWidthDraw );
        }

        private static void DrawDamageType( Graphics g, int endPosX, int posY, Image typeImage )
        {
            int typeImageWidthDraw = (int)( ( (float)SImageSize / (float)typeImage.Height ) * typeImage.Width );

            g.DrawImage( typeImage, new Rectangle( endPosX - SImageMargin - typeImageWidthDraw, posY + SImageMargin, typeImageWidthDraw, SImageSize ) );
        }

        private static void DrawArmor( Graphics g, Armor armor, int posY )
        {
            if( armor != null )
            {
                int nameWidth = CmToPixel( 3.3 );
                int typesWidth = SLineHeight * 4;
                int potentialWidth = CmToPixel( 0.5 );
                int camouflageWidth = CmToPixel( 0.5 );

                int typesStart = SSectionsPosX + nameWidth;
                int potentialStart = typesStart + typesWidth;
                int effectsStart = potentialStart + potentialWidth;
                int camouflageStart = SCardWidth - SLineHeight;

                DrawSectionHeader( g, "Rüstung", SectionHeaderArmor, posY );

                g.DrawLine( SLinePenBlack, SSectionsPosX, posY + SLineHeightDouble, SSectionsWidth, posY + SLineHeightDouble );

                g.DrawString( armor.Name, FontArmorName, Brushes.Black, new Rectangle( SSectionsPosX, posY + SLineHeight, nameWidth, SLineHeight ), StringFormatHLeftVCenter );

                // Potential
                g.DrawLine( SLinePenBlack, potentialStart, posY + SLineHeight, potentialStart, posY + SLineHeightDouble );
                g.DrawImage( Properties.Resources.Schutz_weiss, new Rectangle( potentialStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );

                Helpers.DrawStringCentered( g, armor.Potential.ToString(), FontArmor, ArmorFontBrush, new Rectangle( potentialStart, posY + SLineHeight, potentialWidth, SLineHeight ) );

                g.DrawLine( SLinePenBlack, effectsStart, posY + SLineHeight, effectsStart, posY + SLineHeightDouble );

                // Camouflage
                if( armor.Camouflage != Armor.ECamouflage.Keine )
                {
                    Image img = ( armor.Camouflage == Armor.ECamouflage.Passiv ) ? Properties.Resources.camo_passive_white : Properties.Resources.camo_active_white;

                    g.DrawImage( img, new Rectangle( camouflageStart + SImageMargin, posY + SImageMargin, SImageSize, SImageSize ) );
                    g.DrawLine( SLinePenBlack, camouflageStart, posY + SLineHeight, camouflageStart, posY + SLineHeightDouble );
                    Helpers.DrawStringCentered( g, armor.CamouflageLevel.ToString(), FontArmor, ArmorFontBrush, new Rectangle( camouflageStart, posY + SLineHeight, camouflageWidth, SLineHeight ) );
                }

                DrawDamageType( g, potentialStart, posY + SLineHeight, armor.TypesImage );

                int damageEffectsPosX = DrawDamageEffects( g, effectsStart, posY + SLineHeight, armor.EffectsImage );

                if( ( effectsStart + damageEffectsPosX ) > SCardWidth )
                {
                    Rectangle rect = new Rectangle( effectsStart, posY + SLineHeight, SCardWidth - effectsStart, SLineHeight );
                    g.FillRectangle( Brushes.Purple, rect );
                    g.DrawString( "KEIN PLATZ", FontArmor, Brushes.White, rect, StringFormatHCenterVCenter );
                }
            }
        }

        private static int DrawEquipment( Graphics g, List<Actor.ActorEquipment> actorEquipmentList, int posY )
        {
            var equipList = actorEquipmentList.GroupBy( x => x.Equipment.ID )
                                              .Select( x => new { equipment = EquipmentStorage.Instance.Get( x.Key ), count = x.Count() } )
                                              .Where( x => ( x.equipment.AP > 0 )
                                                           ||
                                                           ( x.equipment.UseOnce )
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

                    if( entry.equipment.AP > 0 )
                    {
                        builder.Append( " ⊙" + entry.equipment.AP );
                    }

                    if( entry.equipment.UseOnce )
                    {
                        builder.Append( NonBreakingSpace );
                        for( int i = 0; i < entry.count; i++ )
                        {
                            builder.Append( "○" );
                        }
                    }
                    else
                    {
                        if( entry.count > 1 )
                        {
                            builder.Append( NonBreakingSpace + $"[x{entry.count}]" );
                        }
                    }

                    builder.Append( delimiter );
                }

                DrawSectionHeader( g, "Ausrüstung", SectionHeaderEquipment, posY );
                posY += SLineHeight;

                string equipmentString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                Size size = g.MeasureString( equipmentString, FontTraits, SSectionsWidth, StringFormatHLeftVTop ).ToSize();

                g.DrawString( equipmentString, FontEquipment, Brushes.Black, new Rectangle( SSectionsPosX, posY, SSectionsWidth, SCardHeight - posY ), StringFormatHLeftVTop );

                return ( posY + size.Height );
            }
            else
            {
                return ( posY );
            }
        }
    }
}
