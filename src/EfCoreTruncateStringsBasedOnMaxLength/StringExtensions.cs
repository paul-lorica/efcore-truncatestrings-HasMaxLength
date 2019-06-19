using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace EfCoreTruncateStringsBasedOnMaxLength
{
    public static class StringExtensions
    {
        public static string SanitizeToDigitsOnly(this string value)
        {
            return (value == null) ? "" : Regex.Replace(value, @"\D", "");
        }

        public static string Truncate(this string s, int length, ILogger logger = null)
        {
            string result;

            if (string.IsNullOrEmpty(s) || s.Length <= length)
            {
                result = s;
            }
            else
            {
                if (length <= 0)
                {
                    result = string.Empty;
                }
                else
                {
                    result = s.Substring(0, length);

                    logger?.LogWarning("Truncated string:{stringToTruncate}", s);
                }
            }

            return result;
        }
    }
}