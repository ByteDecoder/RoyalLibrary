using System;

namespace ByteDecoder.RoyalLibrary
{
    /// <summary>
    /// Operations on string types.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to double.
        /// </summary>
        /// <param name="source">string source.</param>
        /// <returns>string converted to double type.</returns>
        public static double ToDouble(this string source)
        {
            try
            {
                var result = double.Parse(source);
                return result;
            }
            catch (FormatException)
            {
                return double.NaN;
            }
        }
    }
}