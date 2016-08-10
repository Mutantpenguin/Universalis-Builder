using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tesserakt
{
    static class Helpers
    {
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
    }
}
