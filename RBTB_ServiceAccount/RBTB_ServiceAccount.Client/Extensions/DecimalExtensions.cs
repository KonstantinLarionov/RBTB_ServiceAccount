using JetBrains.Annotations;
using System.Globalization;

namespace RBTB_ServiceAccount.Client.Extensions
{
    internal static class DecimalExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo {NumberDecimalSeparator = @"."};

        [NotNull]
        public static string ToFormattedString(this decimal value) => value.ToString(NumberFormat);
    }
}
