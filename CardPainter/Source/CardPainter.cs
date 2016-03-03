using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tesserakt
{
    public class CardPainter : IDisposable
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

        // TODO readonly
        private readonly Font font0dot2;
        private readonly Font font0dot3;
        private readonly Font font0dot35;

        private readonly Font fontStandard;
        private readonly Font fontStandardSmall;
        private readonly Font fontName;
        private readonly Font fontNameSmall;
        private readonly Font fontPoints;
        private readonly Font fontWeapon;
        private readonly Font fontWeaponSmall;
        private readonly Font fontWeaponName;
        private readonly Font fontWK;
        private readonly Font fontArmor;
        private readonly Font fontArmorName;
        private readonly Font fontEquipment;
        private readonly Font fontTraits;

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

        private static readonly PrivateFontCollection m_pfc = new PrivateFontCollection();
        #endregion members

        public CardPainter()
        {
            // load Font from Resource
            byte[] fontData = TObjects.Properties.Resources.NovaSquare;
            IntPtr fontPtr = Marshal.AllocCoTaskMem( fontData.Length );
            Marshal.Copy( fontData, 0, fontPtr, fontData.Length );
            m_pfc.AddMemoryFont( fontPtr, fontData.Length );
            Marshal.FreeCoTaskMem( fontPtr );

            FontFamily fontFamilyNovaSquare = m_pfc.Families.First( s => s.Name.Equals( TesseraktFonts.NovaSquareName ) );

            font0dot2 = new Font( fontFamilyNovaSquare, CmToPixel( 0.2 ), FontStyle.Regular, GraphicsUnit.Pixel );
            font0dot3 = new Font( fontFamilyNovaSquare, CmToPixel( 0.3 ), FontStyle.Regular, GraphicsUnit.Pixel );
            font0dot35 = new Font( fontFamilyNovaSquare, CmToPixel( 0.35 ), FontStyle.Regular, GraphicsUnit.Pixel );

            fontStandard = font0dot35;
            fontStandardSmall = font0dot2;
            fontName = font0dot3;
            fontNameSmall = font0dot2;
            fontPoints = font0dot2;
            fontWeapon = font0dot3;
            fontWeaponSmall = font0dot2;
            fontWeaponName = font0dot2;
            fontWK = font0dot3;
            fontArmor = font0dot3;
            fontArmorName = font0dot2;
            fontEquipment = font0dot3;
            fontTraits = font0dot3;
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                font0dot2.Dispose();
                font0dot3.Dispose();
                font0dot35.Dispose();

                fontStandard.Dispose();
                fontStandardSmall.Dispose();
                fontName.Dispose();
                fontNameSmall.Dispose();
                fontPoints.Dispose();
                fontWeapon.Dispose();
                fontWeaponSmall.Dispose();
                fontWeaponName.Dispose();
                fontWK.Dispose();
                fontArmor.Dispose();
                fontArmorName.Dispose();
                fontEquipment.Dispose();
                fontTraits.Dispose();
            }
        }

        public Bitmap getBitmap( Group.GroupActor groupActor )
        {
            return( getBitmap( groupActor.Actor, groupActor.ActorOutfit, groupActor.CustomName ) );
        }

        public Bitmap getBitmap( Actor actor, Actor.ActorOutfit actorOutfit )
        {
            return ( getBitmap( actor, actorOutfit, String.Empty ) );
        }

        private Bitmap getBitmap( Actor actor, Actor.ActorOutfit actorOutfit, string customName )
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

        private void drawStructure( Graphics g, int equipmentEndY )
        {
            // line right of image
            g.DrawLine( structureBlackPen, CmToPixel( 4 ), 0, CmToPixel( 4 ), CmToPixel( s_cardHeight ) );

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

        private void drawName( Graphics g, String actorName, string customName )
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

        private void drawFaction( Graphics g, Faction faction )
        {
            if( null != faction )
            {
                g.DrawImage( faction.Icon, new Rectangle( Point.Empty, new Size( CmToPixel( 0.5 ), CmToPixel( 0.5 ) ) ) );
            }
        }

        private void drawType( Graphics g, Actor.EType type )
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

                default:
                    throw new InvalidOperationException( "unkown Actor.EType" );
            }

            g.DrawRectangle( linePen, rect );
        }

        private void drawPicture( Graphics g, Bitmap image )
        {
            if( image != null )
            {
                g.DrawImage( image, s_pictureRect );
            }
        }

        private void drawAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            drawAttribute( g, xAttFirstColumn, 0, "AGI", actor.ModAGI( actorOutfit ) );// TODO only for EMP, actor.BaseAGI( actorOutfit ) );
            drawAttribute( g, xAttFirstColumn, CmToPixel( 0.5 ), "BW", actor.ModBW( actorOutfit ) );// TODO only for EMP, actor.BaseBW( actorOutfit ) );
            drawAttribute( g, xAttFirstColumn, CmToPixel( 1 ), "KK", actor.ModKK( actorOutfit ) );// TODO only for EMP, actor.BaseKK() );

            drawAttribute( g, xAttSecondColumn, 0, "HAK", actor.ModHAK( actorOutfit ) );// TODO only for EMP, actor.BaseHAK() );
            drawAttribute( g, xAttSecondColumn, CmToPixel( 0.5 ), "AFG", actor.ModAFG( actorOutfit ) );// TODO only for EMP, actor.BaseAFG() );
            drawAttribute( g, xAttSecondColumn, CmToPixel( 1 ), "SH", actor.ModSH( actorOutfit ) );// TODO only for EMP, actor.BaseSH() );
        }

        private void drawAttribute( Graphics g, int posX, int posY, string name, int attribModValue ) // TODO only for EMP, int attribBaseValue )
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

        private void drawCalculatedAttributes( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            // PGB - Persönlicher Gefahrenbereich
            g.DrawImage( Properties.Resources.danger, new Rectangle( xAttThirdColumn, CmToPixel( 0.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );
            g.DrawString( $"{actor.PGB( actorOutfit )}cm", fontStandard, Brushes.Black, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ), 0, CmToPixel( 1 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );

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

        private void drawSubstance( Graphics g, Actor actor )
        {
            int margin = CmToPixel( 0.1 );

            switch( actor.Type )
            {
                case Actor.EType.Infanterie:
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
                    throw new InvalidOperationException( "unkown Actor.EType" );
            }            
        }

        private void drawSubstanceCirclesHorizonzal( Graphics g, int count, int x, int y, int width, bool down )
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

        private void drawSubstanceCirclesVertical( Graphics g, int count, int x, int y, int width )
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

        private void drawPoints( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit  )
        {
            string points = $"{actor.Points( actorOutfit )}pkt";

            if( actorOutfit != null )
            {
                points = actorOutfit.Name + " - " + points;
            }

            g.DrawString( points, fontPoints, Brushes.Black, new Rectangle( 0, CmToPixel( 7.5 ), CmToPixel( 4 ), CmToPixel( 0.5 ) ), stringFormatHCenterVCenter );
        }

        private void drawSize( Graphics g, Actor.ESize size )
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
            }

            int sizeInPixel = CmToPixel( 0.4 );

            g.DrawImage( img, new Rectangle( xAttThirdColumn, CmToPixel( 1.05 ), sizeInPixel, sizeInPixel ) );
        }

        private void drawMovement( Graphics g, EMovementType movementType )
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
            }

            g.DrawImage( img, new Rectangle( xAttThirdColumn + CmToPixel( 0.5 ), CmToPixel( 1.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );
        }

        private void drawWeight( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit )
        {
            int x1 = xAttThirdColumn + CmToPixel( 1 );

            g.DrawImage( Properties.Resources.weight, new Rectangle( x1, CmToPixel( 1.05 ), CmToPixel( 0.4 ), CmToPixel( 0.4 ) ) );

            g.DrawString( $"{actor.Weight + actor.LoadoutWeight( actorOutfit, withSelfSustaining: true ):n1}", fontStandardSmall, Brushes.Black, new Rectangle( x1 + CmToPixel( 0.4 ), CmToPixel( 1 ), CmToPixel( 2 ), CmToPixel( 0.5 ) ), stringFormatHLeftVCenter );
        }

        private int drawTraits( Graphics g, List<Actor.ActorTrait> actorTraitList )
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

        private int drawWeapons( Graphics g, Actor actor, Actor.ActorOutfit actorOutfit, int posY )
        {
            if( actorOutfit == null )
            {
                return ( 0 );
            }

            if( actorOutfit.ActorWeaponsList.Count > 0 )
            {
                int posX = CmToPixel( 4 );

                int wkWidth = CmToPixel( 0.5 );
                int nameWidth = CmToPixel( 3.3 ) - s_lineHeight;
                int potentialWidth = CmToPixel( 0.5 );
                int substanceWidth = CmToPixel( 0.5 );
                int rangeWidth = CmToPixel( 0.9 );

                int wkStart = posX;
                int nameStart = wkStart + wkWidth;
                int typeStart = nameStart + nameWidth;
                int potentialStart = typeStart + s_lineHeight;
                int substanceStart = potentialStart + potentialWidth;
                int rangeStart = substanceStart + substanceWidth;

                g.DrawLine( linePen, posX, posY + s_lineHeight, s_cardWidth, posY + s_lineHeight );

                // Title-Background
                g.FillRectangle( titleBackgroundBrush, new Rectangle( posX, posY, s_cardWidth, s_lineHeight ) );

                // Title
                g.DrawString( "Waffen", fontStandard, Brushes.White, new Rectangle( wkStart, posY, wkWidth + nameWidth, s_lineHeight ), stringFormatHLeftVCenter );

                // Captions
                g.DrawImage( Properties.Resources.potential_white, new Rectangle( potentialStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
                g.DrawImage( Properties.Resources.weapon_substance_white, new Rectangle( substanceStart + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );
                g.DrawImage( Properties.Resources.weapon_range_white, new Rectangle( rangeStart + ( rangeWidth / 2 ) - ( s_lineHeight / 2 ) + s_imageMargin, posY + s_imageMargin, s_lineHeight - s_imageMarginDouble, s_lineHeight - s_imageMarginDouble ) );

                int i = 1;
                foreach( var entry in actorOutfit.ActorWeaponsList.GroupBy( x => x.Weapon.ID )
                                                                  .Select( x => new { weapon = WeaponStorage.Instance.Get( x.Key ), count = x.Count() } )
                                                                  .OrderBy( x => x.weapon.WK )
                                                                  .ThenBy( x => x.weapon.RangeSort )
                                                                  .ThenBy( x => x.weapon.Name ) )
                {
                    g.DrawLine( linePen, posX, posY + ( ( i + 1 ) * s_lineHeight ), s_cardWidth, posY + ( ( i + 1 ) * s_lineHeight ) );

                    Weapon weapon = entry.weapon;

                    Rectangle wkRect = new Rectangle( wkStart, posY + ( i * s_lineHeight ), wkWidth, s_lineHeight );
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

                    if( entry.weapon.UseOnce )
                    {
                        weaponName += Environment.NewLine;
                        for( int j = 0; j < entry.count; j++ )
                        {
                            weaponName += "○";
                        }
                    }
                    else
                    {
                        if( entry.count > 1 )
                        {
                            weaponName = $"{entry.count}x {weapon.Name}";
                        }
                    }

                    Size nameSize = new Size( nameWidth, s_lineHeight );
                    int charsFitted, linesFilled;
                    g.MeasureString( weaponName, fontWeaponName, nameSize, stringFormatHLeftVCenter, out charsFitted, out linesFilled );
                    if( charsFitted < weaponName.Length )
                    {
                        weaponName = "NAME IST ZU LANG!";
                    }

                    g.DrawString( weaponName, fontWeaponName, Brushes.Black, new Rectangle( new Point( nameStart, posY + ( i * s_lineHeight ) ), nameSize ), stringFormatHLeftVCenter );

                    drawDamageType( g, potentialStart, posY + ( i * s_lineHeight ), weapon.DamageTypeImage );

                    g.DrawString( weapon.Potential.ToString(), fontWeapon, weaponFontBrush, new Rectangle( potentialStart, posY + ( i * s_lineHeight ), potentialWidth, s_lineHeight ), stringFormatHCenterVCenter );

                    g.DrawString( weapon.FormattedSubstance, fontWeapon, weaponFontBrush, new Rectangle( substanceStart, posY + ( i * s_lineHeight ), substanceWidth, s_lineHeight ), stringFormatHCenterVCenter );

                    if( Weapon.EType.Wurf == weapon.Type )
                    {
                        // TODO only for EMP
                        // if( actor.ModKK( actorOutfit ) == actor.BaseKK() )
                        // {
                        g.DrawString( Actor.ThrowRange( actor.ModKK( actorOutfit ) ), fontWeapon, weaponFontBrush, new Rectangle( rangeStart, posY + ( i * s_lineHeight ), rangeWidth, s_lineHeight ), stringFormatHCenterVCenter );
                        // }
                        // else
                        // {
                        // g.DrawString( Actor.ThrowRange( actor.ModKK( actorOutfit ) ), fontWeaponSmall, Brushes.Red, new Rectangle( rangeStart, posY + ( i * s_lineHeight ), rangeWidth, s_lineHeight / 2 ), stringFormatHCenterVCenter );
                        // g.DrawString( Actor.ThrowRange( actor.BaseKK() ), fontWeaponSmall, Brushes.Orange, new Rectangle( rangeStart, posY + ( i * s_lineHeight ) + ( s_lineHeight / 2 ), rangeWidth, s_lineHeight / 2 ), stringFormatHCenterVCenter );
                        // }
                    }
                    else
                    {
                        g.DrawString( weapon.FormattedRange, fontWeapon, weaponFontBrush, new Rectangle( rangeStart, posY + ( i * s_lineHeight ), rangeWidth, s_lineHeight ), stringFormatHCenterVCenter );
                    }

                    int remainderPosX = rangeStart + rangeWidth;

                    if( weapon.AF > 0 )
                    {
                        remainderPosX += s_imageMargin;

                        int width = ( s_lineHeight - s_imageMarginDouble ) / 3;

                        for( int j = 0; j < weapon.AF; j++ )
                        {
                            g.DrawImage( Properties.Resources.patrone, new Rectangle( remainderPosX, posY + ( i * s_lineHeight ) + s_imageMargin, width, s_lineHeight - s_imageMarginDouble ) );

                            remainderPosX += width;
                        }
                    }

                    if( weapon.Radius > 0 )
                    {
                        int margin = s_imageMargin + CmToPixel( 0.015f );

                        Rectangle rect = new Rectangle( remainderPosX + margin, posY + ( i * s_lineHeight ) + margin, s_lineHeight - ( 2 * margin ), s_lineHeight - ( 2 * margin ) );
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

                    drawDamageEffects( g, remainderPosX, posY + ( i * s_lineHeight ), weapon.EffectsImage );

                    i++;
                }

                // right of name
                g.DrawLine( linePen, wkStart, posY, wkStart, posY + ( i * s_lineHeight ) );
                // right of wk
                g.DrawLine( linePen, potentialStart, posY, potentialStart, posY + ( i * s_lineHeight ) );
                // right of potential
                g.DrawLine( linePen, substanceStart, posY, substanceStart, posY + ( i * s_lineHeight ) );
                // right of substance
                g.DrawLine( linePen, rangeStart, posY, rangeStart, posY + ( i * s_lineHeight ) );
                // right of range
                g.DrawLine( linePen, rangeStart + rangeWidth, posY, rangeStart + rangeWidth, posY + ( i * s_lineHeight ) );

                return( i );
            }
            else
            {
                return( 0 );
            }
        }

        private void drawDamageEffects( Graphics g, int posX, int posY, Image effectImage )
        {
            int effectImageHeightDraw = s_lineHeight - s_imageMarginDouble;
            int effectImageWidthDraw = (int)( ( (float)effectImageHeightDraw / (float)effectImage.Height ) * effectImage.Width );

            g.DrawImage( effectImage, new Rectangle( posX + s_imageMargin, posY + s_imageMargin, effectImageWidthDraw, effectImageHeightDraw ) );
        }

        private void drawDamageType( Graphics g, int endPosX, int posY, Image typeImage )
        {
            int typeImageHeightDraw = s_lineHeight - s_imageMarginDouble;
            int typeImageWidthDraw = (int)( ( (float)typeImageHeightDraw / (float)typeImage.Height ) * typeImage.Width );

            g.DrawImage( typeImage, new Rectangle( endPosX - s_imageMargin - typeImageWidthDraw, posY + s_imageMargin, typeImageWidthDraw, typeImageHeightDraw ) );
        }

        private void drawArmor( Graphics g, Armor armor, int posY )
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

        private int drawEquipment( Graphics g, List<Actor.ActorEquipment> actorEquipmentList, int posY )
        {
            var equipList = actorEquipmentList.GroupBy( x => x.Equipment.ID )
                                              .Select( x => new { equipment = EquipmentStorage.Instance.Get( x.Key ), count = x.Count() } )
                                              .Where( x => !String.IsNullOrEmpty( x.equipment.Rules ) )
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
