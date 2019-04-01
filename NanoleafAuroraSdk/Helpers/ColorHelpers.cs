using System;

namespace NanoleafAuroraSdk.Helpers
{
    internal static class ColorHelpers
    {
        internal static string ConvertColorToHex(System.Drawing.Color c)
        {
            return $"{c.R.ToString("X2")} {c.G.ToString("X2")} {c.B.ToString("X2")}";
        }

        internal static String ConvertColorToRgb(System.Drawing.Color c)
        {
            return $"{c.R} {c.G} {c.B}";
        }
    }
}
