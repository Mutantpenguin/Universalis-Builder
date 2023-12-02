using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Universalis
{
    public static class CardPainterHelpers
    {
        public const int Dpi = 500;

        public static int CmToPixel( double cm )
        {
            return Convert.ToInt32( cm / 2.54f * Dpi );
        }

        public static Color ContrastFontColor( Color color )
        {
            // Counting the perceptive luminance - human eye favors green color...      
            double luminance = ( 0.299 * color.R + 0.587 * color.G + 0.114 * color.B ) / 255;

            if( luminance > 0.5 )
            {
                return Color.Black; // bright colors
            }
            else
            {
                return Color.White; // dark colors
            }
        }

        public static void DrawStringCentered( Graphics g, String text, Font font, Brush brush, Rectangle rect )
        {
            GraphicsPath path = new GraphicsPath();
            path.AddString( text, font.FontFamily, (int)font.Style, font.Size, new Point( 0, 0 ), StringFormat.GenericTypographic );

            // Determine physical size of the character when rendered
            Rectangle area = Rectangle.Round( path.GetBounds() );

            // Slide it to be centered in the specified bounds
            Point offset = new Point( rect.Left + ( rect.Width / 2 - area.Width / 2) - area.Left, rect.Top + ( rect.Height / 2 - area.Height / 2 ) - area.Top );

            Matrix translate = new Matrix();
            translate.Translate( offset.X, offset.Y );

            path.Transform( translate );

            // Now render it however desired
            g.FillPath( brush, path );
        }

        public static void FillRoundedRectangle( Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius )
        {
            if( graphics == null )
                throw new ArgumentNullException( "graphics" );
            if( brush == null )
                throw new ArgumentNullException( "brush" );

            using( GraphicsPath path = RoundedRect( bounds, cornerRadius ) )
            {
                graphics.FillPath( brush, path );
            }
        }

        private static GraphicsPath RoundedRect( Rectangle bounds, int radius )
        {
            int diameter = radius * 2;
            Size size = new Size( diameter, diameter );
            Rectangle arc = new Rectangle( bounds.Location, size );
            GraphicsPath path = new GraphicsPath();

            if( radius == 0 )
            {
                path.AddRectangle( bounds );
                return path;
            }

            // top left arc  
            path.AddArc( arc, 180, 90 );

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc( arc, 270, 90 );

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc( arc, 0, 90 );

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc( arc, 90, 90 );

            path.CloseFigure();
            return path;
        }
    }
}
