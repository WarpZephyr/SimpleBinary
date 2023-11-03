namespace SimpleBinary
{
    public partial class SimpleBinaryStream
    {
        /// <summary>
        /// Advances the stream position until it meets the specified alignment.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        public void Align(long align)
        {
            long mod = Position % align;
            if (mod > 0)
                Position += align - mod;
        }

        /// <summary>
        /// Advances the stream position until it meets the specified alignment starting from the specified position.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        /// <param name="position">The position from which to start aligning.</param>
        public void AlignFrom(long align, long position)
        {
            Position = position;
            long mod = Position % align;
            if (mod > 0)
                Position += align - mod;
        }
    }
}