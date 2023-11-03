namespace SimpleBinary
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
        /// Convert a <see cref="byte"/> <see cref="Array"/> to a <see cref="decimal"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> <see cref="Array"/> to convert.</param>
        /// <param name="position">The position in the <see cref="Array"/> at which to begin.</param>
        /// <returns>A <see cref="decimal"/>.</returns>
        internal static decimal ToDecimal(this byte[] bytes, int position)
        {
            var i1 = BitConverter.ToInt32(bytes, position);
            var i2 = BitConverter.ToInt32(bytes, position + 4);
            var i3 = BitConverter.ToInt32(bytes, position + 8);
            var i4 = BitConverter.ToInt32(bytes, position + 12);

            return new decimal(new int[] { i1, i2, i3, i4 });
        }
    }
}