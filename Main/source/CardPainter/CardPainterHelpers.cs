using System;
using System.Drawing;

namespace Universalis
{
    public static class CardPainterHelpers
    {
        public const int Dpi = 500;

        public const string ActionsPointsMarker = "⊙";

        public static readonly StringFormat StringFormatHCenterVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public static readonly StringFormat StringFormatHLeftVCenter = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        public static readonly StringFormat StringFormatHLeftVTop = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };

        public static int CmToPixel( double cm )
        {
            return Convert.ToInt32( cm / 2.54f * Dpi );
        }
    }
}
