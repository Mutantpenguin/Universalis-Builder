using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Universalis.Helper
{
    internal static class ButtonText
    {
        public static void Draw(Button button, string text, Graphics g)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddString(text, UniversalisFont.Family, (int)FontStyle.Bold, 20, button.ClientRectangle, StringFormat.GenericTypographic);

                var pathBounds = path.GetBounds();

                float xOffset = (button.ClientRectangle.Width - pathBounds.Width) / 2.0f;
                float yOffset = (button.ClientRectangle.Height - pathBounds.Height) / 6.0f * 5.0f;

                Matrix m = new Matrix();
                m.Translate(xOffset, yOffset);
                path.Transform(m);

                g.SmoothingMode = SmoothingMode.AntiAlias;

                Brush fillBrush = Brushes.Black;

                if(!button.Enabled)
                {
                    fillBrush = Brushes.Gray;
                }

                g.FillPath(fillBrush, path);
            }
        }
    }
}
