using System;
using System.Text.RegularExpressions;

namespace Universalis
{
    public static class ToolTipHelper
    {
        private const int s_toolTipMaxCharsPerLine = 50;

        public static string FormatMaxWidth( string text )
        {
            if( String.IsNullOrEmpty( text ) )
            {
                return null;
            }
            else
            {
                return Regex.Replace( text, "(.{" + s_toolTipMaxCharsPerLine + "}\\s)", "$1" + Environment.NewLine );
            }
        }
    }
}
