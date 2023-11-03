namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write the given number of null bytes to the stream.
        /// </summary>
        /// <param name="count">The amount to pad by.</param>
        public void PadBy(long count)
        {
            Writer.Write(new byte[count]);
        }

        /// <summary>
        /// Write bytes until the position of the stream reaches the desired alignment.
        /// </summary>
        /// <param name="align">The desired alignment.</param>
        public void Pad(long align)
        {
            long mod = Position % align;
            if (mod > 0)
                Writer.Write(new byte[align - mod]);
        }

        /// <summary>
        /// Write bytes until the position of the stream reaches the desired alignment starting from the given position.
        /// </summary>
        /// <param name="align">The desired alignment.</param>
        /// <param name="position">The position to start aligning from.</param>
        public void PadFrom(long align, long position)
        {
            Position = position;
            long mod = Position % align;
            if (mod > 0)
                Writer.Write(new byte[align - mod]);
        }
    }
}
