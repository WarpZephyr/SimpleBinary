namespace SimpleStream
{
    internal static class ConverterUtility
    {
        /// <summary>
        /// Convert a byte array to a decimal.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <param name="position">The position in the array at which to begin.</param>
        /// <returns>A decimal.</returns>
        internal static decimal ByteArrayToDecimal(byte[] bytes, int position)
        {
            var i1 = BitConverter.ToInt32(bytes, position);
            var i2 = BitConverter.ToInt32(bytes, position + 4);
            var i3 = BitConverter.ToInt32(bytes, position + 8);
            var i4 = BitConverter.ToInt32(bytes, position + 12);

            return new decimal(new int[] { i1, i2, i3, i4 });
        }
    }
}
