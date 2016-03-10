
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
            using( PrivateFontCollection pfc = new PrivateFontCollection() )
            {
                // load Font from Resource
                byte[] fontData = TObjects.Properties.Resources.NovaSquare;
                IntPtr fontPtr = Marshal.AllocCoTaskMem( fontData.Length );
                Marshal.Copy( fontData, 0, fontPtr, fontData.Length );
                pfc.AddMemoryFont( fontPtr, fontData.Length );
                Marshal.FreeCoTaskMem( fontPtr );

                FontFamilyNovaSquare = pfc.Families.First( s => s.Name.Equals( NovaSquareName ) );
            }
        }

        private const string NovaSquareName = "Nova Square";
        public const string NovaSquareFileName = "NovaSquare.ttf";

        public static readonly FontFamily FontFamilyNovaSquare;
    }
}
