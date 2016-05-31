using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Tesserakt
{
    public static class CardPainter
    {
        #region members
        public const int dpi = 500;

        public const int cardWidthCm = 12;
        public const int cardHeightCm = 8;

        private static readonly int s_cardWidth = CmToPixel( cardWidthCm );
        private static readonly int s_cardHeight = CmToPixel( cardHeightCm );

        private static readonly Rectangle s_pictureRect = new Rectangle( 0, CmToPixel( 0.5 ), CmToPixel( 4 ), CmToPixel( 7 ) );

        private static readonly int s_substancePointSize = CmToPixel( 0.3 );

        private static readonly Pen linePen = Pens.Black;
        private static readonly Pen structureBlackPen = new Pen( Color.Black, CmToPixel( 0.02f ) );
        private static readonly Pen structureRedPen = new Pen( Color.Red, CmToPixel( 0.2f ) );
        private static readonly Pen substanceBorderPen = new Pen( Color.Black, CmToPixel( 0.015f ) );
        private static readonly Pen unwieldyCirclePen = new Pen( Color.White, CmToPixel( 0.015f ) );

        private static readonly Font font0dot2 = new Font( TesseraktFonts.FontFamilyNovaSquare, CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font font0dot3 = new Font( TesseraktFonts.FontFamilyNovaSquare, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
        private static readonly Font font0dot35 = new Font( TesseraktFonts.FontFamilyNovaSquare, CmToPixel( 0.35 ), FontStyle.Regular, GraphicsUnit.Pixel );

        private static readonly Font fontStandard = font0dot35;
        private static readonly Font fontStandardSmall = font0dot2;
        private static readonly Font fontName = font0dot3;
        private static readonly Font fontNameSmall = font0dot2;
        private static readonly Font fontPoints = font0dot2;
        private static readonly Font fontWeapon = font0dot3;
        private static readonly Font fontWeaponSmall = font0dot2;
        private static readonly Font fontWeaponName = font0dot2;
        private static readonly Font fontWK = font0dot3;
        private static readonly Font fontArmor = font0dot3;
        private static readonly Font fontArmorName = font0dot2;
        private static readonly Font fontEquipment = font0dot3;
        private static readonly Font fontTraits = font0dot3;

        private static readonly Brush substanceCritBrush = new SolidBrush( Color.Orange );
        private static readonly Brush substanceNormalBrush = new SolidBrush( Color.White );

        private static readonly Brush weaponFontBrush = new SolidBrush( DamageColor.red );
        private static readonly Brush armorFontBrush = new SolidBrush( DamageColor.green );

        private static readonly int s_lineHeight = CmToPixel( 0.5 );
        private static readonly int s_lineHeightDouble = s_lineHeight * 2;

        private static readonly int s_imageMargin = s_lineHeight / 10;
        private static readonly int s_imageMarginDouble = s_imageMargin * 2;

        private static readonly Brush titleBackgroundBrush = Brushes.Gray;

        private static readonly StringFormat stringFormatHCenterVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        private static readonly StringFormat stringFormatHRightVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center
        };

        private static readonly StringFormat stringFormatHLeftVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        private static readonly StringFormat stringFormatHLeftVTop = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };

        private static readonly int xAttFirstColumn = CmToPixel( 4 );
        private static readonly int xAttSecondColumn = CmToPixel( 6.1 );
        private static readonly int xAttThirdColumn = CmToPixel( 8.5 );
        #endregion members

        #region armorMembers
        private static readonly int weapon_posX = CmToPixel( 4 );

        private static readonly int weapon_wkWidth = CmToPixel( 0.5 );
        private static readonly int weapon_nameWidth = CmToPixel( 3.3 ) - s_lineHeight;
        private static readonly int weapon_potentialWidth = CmToPixel( 0.5 );
        private static readonly int weapon_substanceWidth = CmToPixel( 0.5 );
        private static readonly int weapon_rangeWidth = CmToPixel( 0.9 );

        private static readonly int weapon_wkStart = weapon_posX;
        private static readonly int weapon_nameStart = weapon_wkStart + weapon_wkWidth;
        private static readonly int weapon_typeStart = weapon_nameStart + weapon_nameWidth;
        private static readonly int weapon_potentialStart = weapon_typeStart + s_lineHeight;
        private static readonly int weapon_substanceStart = weapon_potentialStart + weapon_potentialWidth;
        private static readonly int weapon_rangeStart = weapon_substanceStart + weapon_substanceWidth;

        private static readonly int weapon_radiusMargin = s_imageMargin + CmToPixel( 0.015f );
        #endregion

        public static Bitmap getBitmap( Group.GroupActor groupActor )
        {
            return( getBitmap( groupActor.Actor, groupActor.ActorOutfit, groupActor.CustomName ) );
        }

        public static Bitmap getBitmap( Actor actor, Actor.ActorOutfit actorOutfit )
        {
            return ( getBitmap( actor, actorOutfit, String.Empty ) );
        }

        private static Bitmap getBitmap( Actor actor, Actor.ActorOutfit actorOutfit, string customName )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            Bitmap img = new Bitmap( s_cardWidth, s_cardHeight );
            using( Graphics g = Graphics.FromImage( img ) )
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear( Color.White );

                drawName( g, actor.Name, customName );
                drawFaction( g, actor.Faction );
                drawType( g, actor.Type );
                drawPicture( g, actor.Img );
                drawAttributes( g, actor, actorOutfit );
                drawCalculatedAttributes( g, actor, actorOutfit );
                drawSize( g, actor.Size );
                drawMovement( g, actor.MovementType );
                drawWeight( g, actor, actorOutfit );
                drawSubstance( g, actor );
                drawPoints( g, actor, actorOutfit );

                int traitsEndY = drawTraits( g, actor.ActorTraitsList );

                int weaponsCount = drawWeapons( g, actor, actorOutfit, traitsEndY );

                int armorPosY = traitsEndY + ( s_lineHeight * weaponsCount );
                drawArmor( g, actor.Armor, armorPosY );

                int equipmentYPos = armorPosY + s_lineHeight * ( ( null == actor.Armor ? 0 : 2 ) );
                int equipmentEndY = equipmentYPos;
                if( actorOutfit != null )
                {
                    equipmentEndY = drawEquipment( g, actorOutfit.ActorEquipmentList, equipmentYPos );
                }

                // draw the structure last, otherwise "lower" elements could paint over it
                drawStructure( g, equipmentEndY );

                return ( img );
            }
        }

        private static int CmToPixel( double cm )
        {
            return ( Convert.ToInt32( cm / 2.54f * dpi ) );
        }

        private static void drawStructure( Graphics g, int equipmentEndY )
        {
            // line right of image
            g.DrawLine( structureBlackPen, CmToPixel( 4 ), 0, CmToPixel( 4 ), s_cardHeight );

            // line under "Name"
            g.DrawLine( structureBlackPen, 0, CmToPixel( 0.5 ), CmToPixel( 4 ), CmToPixel( 0.5 ) );

            // line above "Schock"
            g.DrawLine( structureBlackPen, 0, CmToPixel( 7.5 ), CmToPixel( 4 ), CmToPixel( 7.5 ) );
            
            // line under "Attribute"
            g.DrawLine( structureBlackPen, CmToPixel( 4 ), CmToPixel( 1.5 ), s_cardWidth, CmToPixel( 1.5 ) );

            // surrounding rectangle
            if( equipmentEndY > s_cardHeight )
            {
                g.DrawRectangle( structureRedPen, 0, 0, s_cardWidth - 1, s_cardHeight - 1 );
            }
            else
            {
                g.DrawRectangle( structureBlackPen, 0, 0, s_cardWidth - 1, s_cardHeight - 1 );
            }
        }

        private static void drawName( Graphics g, String actorName, string customName )
        {
            int posX = CmToPixel( 0.5 );
            int posY = 0;

            string name = actorName + ( String.IsNullOrEmpty( customName ) ? String.Empty : ( Environment.NewLine + customName ) );

            Size textSize = new Size( CmToPixel( 3.5 ) - posX, CmToPixel( 0.5 ) );

            int charsFitted, linesFilled;
            g.MeasureString( name, fontName, textSize, stringFormatHCenterVCenter, out charsFitted, out linesFilled );

            if( linesFilled > 1 )
            {
                g.DrawString( name, fontNameSmall, Brushes.Black, new Rectangle( new Point( posX, posY ), textSize ), stringFormatHCenterVCenter );
            }
            else
            {
                g.DrawString( name, fontName, Brushes.Black, new Rectangle( new Point( posX, posY ), textSize ), stringFormatHCenterVCenter );
            }
        }

        private static void drawFaction( Graphics g, Faction faction )
        {
            if( null != faction )
            {
                g.DrawImage( faction.Icon, new Rectangle( Point.Empty, new Size( CmToPixel( 0.5 ), CmToPixel( 0.5 ) ) ) );
            }
        }

        private static void drawType( Graphics g, Actor.EType type )
        {
            Rectangle rect = new Rectangle( new Point( CmToPixel( 3.5 ), 0 ), new Size( CmToPixel( 0.5 ), CmToPixel( 0.5 ) ) );

            switch( type )
            {
                case Actor.EType.Infanterie:
                    g.DrawImage( Properties.Resources.infantry, rect );
                    break;

                case Actor.EType.MIKe:
                    g.DrawImage( Properties.Resources.mike, rect );
                    break;

                case Actor.EType.Drohne:
                    g.DrawImage( Properties.Resources.drohne, rect );
                    break;

                case Actor.EType.Fahrzeug:
                    g.DrawImage( Properties.Resources.fahrzeug, rect );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.EType ) );
            }

            g.DrawRectangle( linePen, rect );
        }

        private static void drawPicture( Graphics g, Bitmap image )
        {
            if( image != null )
            {
                g.DrawImage( image, s_pictureRect );
            }
        }

        private static void drawAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            drawAttribute( g, xAttFirstColumn, 0, "AGI", actor.ModAGI( actorOutfit ) );// TODO only for EMP, actor.BaseAGI( actorOutfit ) );
            drawAttribute( g, xAttFirstColumn, CmToPixel( 0.5 ), "BW", actor.ModBW( actorOutfit ) );// TODO only for EMP, actor.BaseBW( actorOutfit ) );
            drawAttribute( g, xAttFirstColumn, CmToPixel( 1 ), "KK", actor.ModKK( actorOutfit ) );// TODO only for EMP, actor.BaseKK() );

            drawAttribute( g, xAttSecondColumn, 0, "HAK", actor.ModHAK( actorOutfit ) );// TODO only for EMP, actor.BaseHAK() );
            drawAttribute( g, xAttSecondColumn, CmToPixel( 0.5 ), "AFG", actor.ModAFG( actorOutfit ) );// TODO only for EMP, actor.BaseAFG() );
            drawAttribute( g, xAttSecondColumn, CmToPixel( 1 ), "SH", actor.ModSH( actorOutfit ) );// TODO only for EMP, actor.BaseSH() );
        }

        private static void drawAttribute( Graphics g, int posX, int posY, string name, int attribModValue ) // TODO only for EMP, int attribBaseValue )
        {
            int widthName = CmToPixel( 0.9 );
            int widthAtt = CmToPixel( 0.6 );
            int height = CmToPixel( 0.5 );

            Rectangle rect_name = new Rectangle( posX, posY, widthName, height );
            Rectangle rect_modified = new Rectangle( posX + widthName, posY, 2 * widthAtt, height );
            // TODO only for EMP
            //Rectangle rect_normal = new Rectangle( posX + widthName + widthAtt, posY, widthAtt, height );

            g.DrawRectangle( linePen, new Rectangle( posX, posY, widthName + widthAtt + widthAtt, height ) );

            g.FillRectangle( Brushes.Black, rect_name );

            g.DrawString( name, fontStandard, Brushes.White, rect_name, stringFormatHCenterVCenter );

            int printModValue = attribModValue < 0 ? 0 : attribModValue;
            // TODO only for EMP
            // int printBaseValue = attribBaseValue < 0 ? 0 : attribBaseValue;

            // TODO only for EMP
            //g.DrawString( printModValue.ToString(), fontStandard, attribModValue < 0 ? Brushes.Red : Brushes.Black, rect_modified, stringFormatHRightVCenter );
            g.DrawString( printModValue.ToString(), fontStandard, attribModValue < 0 ? Brushes.Red : Brushes.Black, rect_modified, stringFormatHCenterVCenter );

            /* TODO only for EMP
            if( printModValue != printBaseValue )
            {
                g.DrawString( "(" + printBaseValue.ToString() + ")", fontStandardSmall, attribBaseValue < 0 ? Brushes.Orange : Brushes.Gray, rect_normal, stringFormatHLeftVCenter );
            }
            */
        }

        private static void drawCalculatedAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            // GB - Gefahrenbereich
            g.DrawImage( Properties.Resources.danger, new Rectangle( xAttThirdColumn, CmToPixel( 0.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );
            g.DrawString( $"{actor.GB( actorOutfit )}cm", fontStandard, Brushes.Black, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ), 0, CmToPixel( 1 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );

            // WB - Wahrnehmungsbereich
            g.DrawImage( Properties.Resources.eye, new Rectangle( xAttThirdColumn, CmToPixel( 0.55 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );

            string fovAndModWbString = $"{(int)actor.Fov}°/{actor.ModWB( actorOutfit )}cm";

            // TODO only for EMP
            Size fovAndModWbSize = g.MeasureString( fovAndModWbString, fontStandard ).ToSize();

            g.DrawString( fovAndModWbString, fontStandard, Brushes.Black, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ), CmToPixel( 0.5 ), fovAndModWbSize.Width + CmToPixel( 0.1 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );

            /* TODO only for EMP
            if( actor.WB( actorOutfit ) != actor.ModWB( actorOutfit ) )
            {
                string wbString = $"({actor.WB( actorOutfit )}cm)";
                g.DrawString( wbString, fontStandardSmall, Brushes.Gray, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ) + fovAndModWbSize.Width, CmToPixel( 0.5 ), CmToPixel( 1 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );
            }
            */
        }

        private static void drawSubstance( Graphics g, Actor actor )
        {
            int margin = CmToPixel( 0.1 );

            switch( actor.Type )
            {
                case Actor.EType.Infanterie:
                case Actor.EType.Drohne:
                case Actor.EType.Fahrzeug: // TODO implement completely different HitZones for vehicles? like chassis, engine and so on?
                    int posX = s_pictureRect.X + margin;
                    int posY = s_pictureRect.Y + margin;

                    drawSubstanceCirclesVertical( g, actor.SZ, posX, posY, s_substancePointSize );
                    break;

                case Actor.EType.MIKe:
                    int posXArmLeft = s_pictureRect.X + margin;
                    int posYArmLeft = s_pictureRect.Y + margin;

                    int posXArmRight = s_pictureRect.Width - s_substancePointSize - margin;
                    int posYArmRight = s_pictureRect.Y + margin;

                    int posXMain = posXArmLeft + s_substancePointSize + margin;
                    int posYMain = s_pictureRect.Y + margin;
                    int widthMain = posXArmRight - margin - posXMain;

                    int posXLegs = posXMain;
                    int posYLegs = s_pictureRect.Y + s_pictureRect.Height - margin;
                    int widthLegs = widthMain;

                    // main
                    drawSubstanceCirclesHorizonzal( g, actor.SZ, posXMain, posYMain, widthMain, down: true );

                    // left arm
                    drawSubstanceCirclesVertical( g, actor.HitZoneSZ, posXArmLeft, posYArmLeft, s_substancePointSize );

                    // right arm
                    drawSubstanceCirclesVertical( g, actor.HitZoneSZ, posXArmRight, posYArmRight, s_substancePointSize );

                    // legs
                    drawSubstanceCirclesHorizonzal( g, actor.HitZoneSZ, posXLegs, posYLegs, widthLegs, down: false );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.EType ) );
            }            
        }

        private static void drawSubstanceCirclesHorizonzal( Graphics g, int count, int x, int y, int width, bool down )
        {
            int maxColumns = Math.Min( Convert.ToInt32( Math.Floor( (float)width / (float)s_substancePointSize ) ), count );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int posX = x + ( ( width - ( maxColumns * s_substancePointSize ) ) / 2 );
            int posY = y - ( down ? 0 : maxRows * s_substancePointSize );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / 2.0f ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( posX + ( s_substancePointSize * col ), posY + ( s_substancePointSize * row ), s_substancePointSize, s_substancePointSize );

                if( i > crit )
                {
                    g.FillEllipse( substanceCritBrush, rect );
                }
                else
                {
                    g.FillEllipse( substanceNormalBrush, rect );
                }

                g.DrawEllipse( substanceBorderPen, rect );

                ++col;

                if( col == maxColumns )
                {
                    ++row;
                    col = 0;
                }
            }
        }

        private static void drawSubstanceCirclesVertical( Graphics g, int count, int x, int y, int width )
        {
            int maxColumns = Convert.ToInt32( Math.Floor( (float)width / s_substancePointSize ) );
            int maxRows = Convert.ToInt32( Math.Ceiling( (float)count / (float)maxColumns ) );

            int row = 0;
            int col = 0;

            int crit = Convert.ToInt32( Math.Ceiling( count / 2.0f ) );

            for( int i = 1; i <= count; i++ )
            {
                Rectangle rect = new Rectangle( x + ( s_substancePointSize * col ), y + ( s_substancePointSize * row ), s_substancePointSize, s_substancePointSize );

                if( i > crit )
                {
                    g.FillEllipse( substanceCritBrush, rect );
                }
                else
                {
                    g.FillEllipse( substanceNormalBrush, rect );
                }

                g.DrawEllipse( substanceBorderPen, rect );

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

        private static void drawPoints( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit  )
        {
            string points = $"{actor.Points( actorOutfit )}pkt";

            if( actorOutfit != null )
            {
                points = actorOutfit.Name + " - " + points;
            }

            g.DrawString( points, fontPoints, Brushes.Black, new Rectangle( 0, CmToPixel( 7.5 ), CmToPixel( 4 ), CmToPixel( 0.5 ) ), stringFormatHCenterVCenter );
        }

        private static void drawSize( Graphics g, Actor.ESize size )
        {
            Bitmap img = null;

            switch( size )
            {
                case Actor.ESize.Klein :
                    img = Properties.Resources.size_small;
                    break;

                case Actor.ESize.Mittel :
                    img = Properties.Resources.size_medium;
                    break;

                case Actor.ESize.Groß :
                    img = Properties.Resources.size_big;
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Actor.ESize ) );
            }

            int sizeInPixel = CmToPixel( 0.4 );

            g.DrawImage( img, new Rectangle( xAttThirdColumn, CmToPixel( 1.05 ), sizeInPixel, sizeInPixel ) );
        }

        private static void drawMovement( Graphics g, EMovementType movementType )
        {
            Bitmap img = null;

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

            g.DrawImage( img, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ), CmToPixel( 1.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );
        }

        private static void drawWeight( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            int x1 = xAttThirdColumn + CmToPixel( 1 );

            g.DrawImage( Properties.Resources.weight, new Rectangle( x1, CmToPixel( 1.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );

            g.DrawString( $"{actor.Weight + actor.LoadoutWeight( actorOutfit, withSelfSustaining: true ):n1}", fontStandardSmall, Brushes.Black, new Rectangle( x1 + CmToPixel( 0.4 ), CmToPixel( 1 ), CmToPixel( 2 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );
        }

        private static int drawTraits( Graphics g, List<Actor.ActorTrait> actorTraitList )
        {
            int posY = CmToPixel( 1.5 );

            if( actorTraitList.Count > 0 )
            {
                int posX = CmToPixel( 4 );
                int width = CmToPixel( 8 );
                string delimiter = ", ";

                StringBuilder builder = new StringBuilder();
                foreach( Actor.ActorTrait trait in actorTraitList.OrderBy( x => x.Name ) )
                {
                    builder.Append( trait.Name );

                    if( trait.Level > 0 )
                    {
                        builder.Append( " " + trait.Level );
                    }

                    builder.Append( delimiter );
                }

                string traitsString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                // Title-Background
                g.FillRectangle( titleBackgroundBrush, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ) );

                // Title
                g.DrawString( "Eigenschaften", fontStandard, Brushes.White, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ), stringFormatHLeftVCenter );
                posY += s_lineHeight;

                Size size = g.MeasureString( traitsString, fontTraits, width, stringFormatHLeftVTop ).ToSize();

                g.DrawString( traitsString, fontTraits, Brushes.Black, new Rectangle( posX, posY, width, s_cardHeight - posY ), stringFormatHLeftVTop );

                return ( posY + size.Height );
            }

            return ( posY );
        }

        private static int drawWeapons( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit, int posY )
        {
            if( actorOutfit == null )
            {
                return ( 0 );
            }

            g.DrawLine( linePen, weapon_posX, posY + s_lineHeight, s_cardWidth, posY + s_lineHeight );

            // Title-Background
            g.FillRectangle( titleBackgroundBrush, new Rectangle( weapon_posX, posY, s_cardWidth, s_lineHeight ) );

            // Title
            g.DrawString( "Waffen", fontStandard, Brushes.White, new Rectangle( weapon_wkStart, posY, weapon_wkWidth + weapon_nameWidth, s_lineHeight ), stringFormatHLeftVCenter );

            // Captions
            g.DrawImage( Properties.Resources.potential_white, new Rectangle( weapon_potentialStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
            g.DrawImage( Properties.Resources.weapon_substance_white, new Rectangle( weapon_substanceStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
            g.DrawImage( Properties.Resources.weapon_range_white, new Rectangle( weapon_rangeStart + ( weapon_rangeWidth / 2 ) - ( s_lineHeight / 2 ) + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );

            int lineNumber = 1;

            if( actorOutfit.ActorWeaponsList.FirstOrDefault( s => s.Weapon.Type == Weapon.EType.Nahkampf ) == null )
            {
                Weapon weaponCC = actor.unarmedCC( actorOutfit );

                if( weaponCC != null )
                {
                    drawWeapon( g, actor, actorOutfit, actor.unarmedCC( actorOutfit ), 1, posY + ( lineNumber * s_lineHeight ) );

                    lineNumber++;
                }
            }

            foreach( var weaponEntry in actorOutfit.ActorWeaponsList.GroupBy( x => x.Weapon.ID )
                                                                    .Select( x => new { weapon = WeaponStorage.Instance.Get( x.Key ), count = x.Count() } )
                                                                    .OrderBy( x => x.weapon.WK )
                                                                    .ThenBy( x => x.weapon.RangeSort )
                                                                    .ThenBy( x => x.weapon.Name ) )
            {
                drawWeapon( g, actor, actorOutfit, weaponEntry.weapon, weaponEntry.count, posY + ( lineNumber * s_lineHeight ) );

                lineNumber++;
            }

            int lineVertEnd = posY + ( lineNumber * s_lineHeight );

            // right of name
            g.DrawLine( linePen, weapon_wkStart, posY, weapon_wkStart, lineVertEnd );
            // right of wk
            g.DrawLine( linePen, weapon_potentialStart, posY, weapon_potentialStart, lineVertEnd );
            // right of potential
            g.DrawLine( linePen, weapon_substanceStart, posY, weapon_substanceStart, lineVertEnd );
            // right of substance
            g.DrawLine( linePen, weapon_rangeStart, posY, weapon_rangeStart, lineVertEnd );
            // right of range
            g.DrawLine( linePen, weapon_rangeStart + weapon_rangeWidth, posY, weapon_rangeStart + weapon_rangeWidth, lineVertEnd );

            return( lineNumber );
        }

        private static void drawWeapon( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit, Weapon weapon, int count, int posY )
        {
            g.DrawLine( linePen, weapon_posX, posY + s_lineHeight, s_cardWidth, posY + s_lineHeight );

            Rectangle wkRect = new Rectangle( weapon_wkStart, posY, weapon_wkWidth, s_lineHeight );
            g.FillRectangle( Brushes.Black, wkRect );
            g.DrawString( weapon.WK.ToString(), fontWK, Brushes.White, wkRect, stringFormatHCenterVCenter );

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

            Size nameSize = new Size( weapon_nameWidth, s_lineHeight );
            int charsFitted, linesFilled;
            g.MeasureString( weaponName, fontWeaponName, nameSize, stringFormatHLeftVCenter, out charsFitted, out linesFilled );
            if( charsFitted < weaponName.Length )
            {
                weaponName = "NAME IST ZU LANG!";
            }

            g.DrawString( weaponName, fontWeaponName, Brushes.Black, new Rectangle( new Point( weapon_nameStart, posY ), nameSize ), stringFormatHLeftVCenter );

            drawDamageType( g, weapon_potentialStart, posY, weapon.DamageTypeImage );

            g.DrawString( weapon.Potential.ToString(), fontWeapon, weaponFontBrush, new Rectangle( weapon_potentialStart, posY, weapon_potentialWidth, s_lineHeight ), stringFormatHCenterVCenter );

            g.DrawString( weapon.FormattedSubstance, fontWeapon, weaponFontBrush, new Rectangle( weapon_substanceStart, posY, weapon_substanceWidth, s_lineHeight ), stringFormatHCenterVCenter );

            if( Weapon.EType.Wurf == weapon.Type )
            {
                // TODO only for EMP
                // if( actor.ModKK( actorOutfit ) == actor.BaseKK() )
                // {
                g.DrawString( Actor.ThrowRange( actor.ModKK( actorOutfit ) ), fontWeapon, weaponFontBrush, new Rectangle( weapon_rangeStart, posY, weapon_rangeWidth, s_lineHeight ), stringFormatHCenterVCenter );
                // }
                // else
                // {
                // g.DrawString( Actor.ThrowRange( actor.ModKK( actorOutfit ) ), fontWeaponSmall, Brushes.Red, new Rectangle( rangeStart, gnah, rangeWidth, s_lineHeight / 2 ), stringFormatHCenterVCenter );
                // g.DrawString( Actor.ThrowRange( actor.BaseKK() ), fontWeaponSmall, Brushes.Orange, new Rectangle( rangeStart, gnah + ( s_lineHeight / 2 ), rangeWidth, s_lineHeight / 2 ), stringFormatHCenterVCenter );
                // }
            }
            else
            {
                g.DrawString( weapon.FormattedRange, fontWeapon, weaponFontBrush, new Rectangle( weapon_rangeStart, posY, weapon_rangeWidth, s_lineHeight ), stringFormatHCenterVCenter );
            }

            int remainderPosX = weapon_rangeStart + weapon_rangeWidth;

            if( weapon.AF > 0 )
            {
                remainderPosX += s_imageMargin;

                int width = ( s_lineHeight - s_imageMarginDouble ) / 3;

                for( int j = 0; j < weapon.AF; j++ )
                {
                    g.DrawImage( Properties.Resources.patrone, new Rectangle( remainderPosX, posY + s_imageMargin, width, s_lineHeight - s_imageMarginDouble ) );

                    remainderPosX += width;
                }
            }

            if( weapon.Radius > 0 )
            {
                Rectangle rect = new Rectangle( remainderPosX + weapon_radiusMargin, posY + weapon_radiusMargin, s_lineHeight - ( 2 * weapon_radiusMargin ), s_lineHeight - ( 2 * weapon_radiusMargin ) );
                g.FillEllipse( Brushes.Black, rect );

                GraphicsPath path = new GraphicsPath();
                path.AddString( weapon.FormattedRadius, fontWeapon.FontFamily, (int)fontWeapon.Style, fontWeapon.Size, new Point( 0, 0 ), StringFormat.GenericTypographic );

                // Determine physical size of the character when rendered
                Rectangle area = Rectangle.Round( path.GetBounds() );

                // Slide it to be centered in the specified bounds
                Point offset = new Point( rect.Left + ( rect.Width / 2 - area.Width / 2) - area.Left, rect.Top + ( rect.Height / 2 - area.Height / 2 ) - area.Top );

                Matrix translate = new Matrix();
                translate.Translate( offset.X, offset.Y );

                path.Transform( translate );

                // Now render it however desired
                g.FillPath( Brushes.White, path );


                remainderPosX += s_lineHeight;
            }

            drawDamageEffects( g, remainderPosX, posY, weapon.EffectsImage );
        }

        private static void drawDamageEffects( Graphics g, int posX, int posY, Image effectImage )
        {
            int effectImageHeightDraw = s_lineHeight - s_imageMarginDouble;
            int effectImageWidthDraw = (int)( ( (float)effectImageHeightDraw / (float)effectImage.Height ) * effectImage.Width );

            g.DrawImage( effectImage, new Rectangle( posX + s_imageMargin, posY + s_imageMargin, effectImageWidthDraw, effectImageHeightDraw ) );
        }

        private static void drawDamageType( Graphics g, int endPosX, int posY, Image typeImage )
        {
            int typeImageHeightDraw = s_lineHeight - s_imageMarginDouble;
            int typeImageWidthDraw = (int)( ( (float)typeImageHeightDraw / (float)typeImage.Height ) * typeImage.Width );

            g.DrawImage( typeImage, new Rectangle( endPosX - s_imageMargin - typeImageWidthDraw, posY + s_imageMargin, typeImageWidthDraw, typeImageHeightDraw ) );
        }

        private static void drawArmor( Graphics g, Armor armor, int posY )
        {
            if( armor != null )
            {
                int posX = CmToPixel( 4 );

                int nameWidth = CmToPixel( 3.3 );
                int typesWidth = s_lineHeight * 4;
                int potentialWidth = CmToPixel( 0.5 );
                int camouflageWidth = CmToPixel( 0.5 );

                int typesStart = posX + nameWidth;
                int potentialStart = typesStart + typesWidth;
                int effectsStart = potentialStart + potentialWidth;
                int camouflageStart = s_cardWidth - s_lineHeight;

                g.DrawLine( linePen, posX, posY + s_lineHeight, s_cardWidth, posY + s_lineHeight );

                // Title-Background
                g.FillRectangle( titleBackgroundBrush, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ) );

                // Title
                g.DrawString( "Rüstung", fontStandard, Brushes.White, new Rectangle( posX, posY, nameWidth, s_lineHeight ), stringFormatHLeftVCenter );

                // Potential
                g.DrawImage( Properties.Resources.potential_white, new Rectangle( potentialStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
                g.DrawLine( linePen, effectsStart, posY, effectsStart, posY + s_lineHeightDouble );
                g.DrawString( armor.Potential.ToString(), fontWeapon, armorFontBrush, new Rectangle( potentialStart, posY + s_lineHeight, potentialWidth, s_lineHeight ), stringFormatHCenterVCenter );

                // Camouflage
                if( armor.Camouflage != Armor.ECamouflage.Keine )
                {
                    Image img = ( armor.Camouflage == Armor.ECamouflage.Passiv ) ? Properties.Resources.camo_passive_white : Properties.Resources.camo_active_white;

                    g.DrawImage( img, new Rectangle( camouflageStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
                    g.DrawLine( linePen, camouflageStart, posY, camouflageStart, posY + s_lineHeightDouble );
                    g.DrawString( armor.CamouflageLevel.ToString(), fontWeapon, armorFontBrush, new Rectangle( camouflageStart, posY + s_lineHeight, camouflageWidth, s_lineHeight ), stringFormatHCenterVCenter );
                }

                g.DrawLine( linePen, posX, posY + s_lineHeightDouble, s_cardWidth, posY + s_lineHeightDouble );

                g.DrawString( armor.Name, fontArmorName, Brushes.Black, new Rectangle( posX, posY + s_lineHeight, nameWidth, s_lineHeight ), stringFormatHLeftVCenter );

                drawDamageType( g, potentialStart, posY + s_lineHeight, armor.TypesImage );

                drawDamageEffects( g, effectsStart, posY + s_lineHeight, armor.EffectsImage );

                g.DrawLine( linePen, potentialStart, posY, potentialStart, posY + s_lineHeightDouble );
            }
        }

        private static int drawEquipment( Graphics g, List<Actor.ActorEquipment> actorEquipmentList, int posY )
        {
            var equipList = actorEquipmentList.GroupBy( x => x.Equipment.ID )
                                              .Select( x => new { equipment = EquipmentStorage.Instance.Get( x.Key ), count = x.Count() } )
                                              .Where( x => ( x.equipment.AP > 0 ) || ( !String.IsNullOrEmpty( x.equipment.Rules ) ) )
                                              .OrderBy( x => x.equipment.Name )
                                              .ToList();

            if( equipList.Count > 0 )
            {
                int posX = CmToPixel( 4 );
                const string delimiter = ", ";

                StringBuilder builder = new StringBuilder();
                foreach( var entry in equipList )
                {
                    builder.Append( entry.equipment.Name );

                    if( entry.equipment.AP > 0 )
                    {
                        builder.Append( " " + entry.equipment.AP + "⊙" );
                    }

                    if( entry.equipment.UseOnce )
                    {
                        builder.Append( " " );
                        for( int i = 0; i < entry.count; i++ )
                        {
                            builder.Append( "○" );
                        }
                    }
                    else
                    {
                        if( entry.count > 1 )
                        {
                            builder.Append( $" [x{entry.count}]" );
                        }
                    }

                    builder.Append( delimiter );
                }

                // Title-Background
                g.FillRectangle( titleBackgroundBrush, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ) );

                // Title
                g.DrawString( "Ausrüstung", fontStandard, Brushes.White, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ), stringFormatHLeftVCenter );
                posY += s_lineHeight;

                string equipmentString = builder.Remove( builder.Length - delimiter.Length, delimiter.Length ).ToString();

                int width = CmToPixel( 8 );

                Size size = g.MeasureString( equipmentString, fontTraits, width, stringFormatHLeftVTop ).ToSize();

                g.DrawString( equipmentString, fontEquipment, Brushes.Black, new Rectangle( posX, posY, width, s_cardHeight - posY ), stringFormatHLeftVTop );

                return ( posY + size.Height );
            }
            else
            {
                return ( posY );
            }
        }
    }
}
