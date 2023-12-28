using System;

namespace Universalis
{
    public static class CardPainterHelpers
    {
        public const int Dpi = 500;

        public const string ActionsPointsMarker = "⊙";

        public static int CmToPixel( double cm )
        {
            return Convert.ToInt32( cm / 2.54f * Dpi );
        }
    }
}
