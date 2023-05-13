namespace SimpleStream
{
    public static class Extensions
    {
        /// <summary>
        /// Get a bit from a byte.
        /// </summary>
        /// <param name="b">The byte.</param>
        /// <param name="bitNumber">The bit to get.</param>
        /// <returns>A bool indicating whether or not the bit is set to 0 or 1.</returns>
        public static bool GetBit(this byte b, int bitNumber)
        {
            return ((b >> bitNumber) & 1) != 0;
        }

        /// <summary>
        /// Convert an array of the specified type to a single string.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array of the specified type.</param>
        /// <returns>A string.</returns>
        public static string ArrayToString<T>(this T[] array)
        {
            string str = "";
            foreach (var item in array)
                str += $"{item?.ToString()} | ";
            return str.Substring(0, str.Length - 3);
        }
    }
}