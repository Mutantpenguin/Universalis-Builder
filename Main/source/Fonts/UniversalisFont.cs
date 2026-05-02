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

        private static readonly PrivateFontCollection PFC;

        static UniversalisFont()
        {
            PFC = new PrivateFontCollection();

            // load Font from Resource
            byte[] fontData = Properties.Resources.NovaFlat_Regular;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            try
            {
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, 0);
                PFC.AddMemoryFont(fontPtr, fontData.Length);

                Family = PFC.Families.First(s => s.Name.Equals(Name));
            }
            finally
            {
                Marshal.FreeCoTaskMem(fontPtr);
            }
        }

        private const string Name = "Nova Flat";
        public const string FileName = "NovaFlat-Regular.ttf";

        public static readonly FontFamily Family;
    }
}
