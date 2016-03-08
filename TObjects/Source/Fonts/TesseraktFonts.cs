
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tesserakt
{
    public static class TesseraktFonts
    {
        static TesseraktFonts()
        {
            // load Font from Resource
            byte[] fontData = TObjects.Properties.Resources.NovaSquare;
            IntPtr fontPtr = Marshal.AllocCoTaskMem( fontData.Length );
            Marshal.Copy( fontData, 0, fontPtr, fontData.Length );
            m_pfc.AddMemoryFont( fontPtr, fontData.Length );
            Marshal.FreeCoTaskMem( fontPtr );

            FontFamilyNovaSquare = m_pfc.Families.First( s => s.Name.Equals( NovaSquareName ) );
        }

        private const string NovaSquareName = "Nova Square";
        public const string NovaSquareFileName = "NovaSquare.ttf";

        private static PrivateFontCollection m_pfc = new PrivateFontCollection();

        public static readonly FontFamily FontFamilyNovaSquare;
    }
}
