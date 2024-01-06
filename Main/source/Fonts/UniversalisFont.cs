
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace Universalis
{
    public static class UniversalisFont
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, in uint pcFonts);

        static UniversalisFont()
        {
            using( PrivateFontCollection pfc = new PrivateFontCollection() )
            {
                // load Font from Resource
                byte[] fontData = Properties.Resources.NovaRound_Regular;
                IntPtr fontPtr = Marshal.AllocCoTaskMem( fontData.Length );
                Marshal.Copy( fontData, 0, fontPtr, fontData.Length );
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, 0);
                pfc.AddMemoryFont( fontPtr, fontData.Length );
                Marshal.FreeCoTaskMem( fontPtr );

                Family = pfc.Families.First( s => s.Name.Equals( Name ) );
            }
        }

        private const string Name = "Nova Round";
        public const string FileName = "NovaRound-Regular.ttf";

        public static readonly FontFamily Family;
    }
}
