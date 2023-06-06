namespace SimpleStream
{
    public partial class SimplerStream
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
            SetPosition(position);
            long mod = Position % align;
            if (mod > 0)
                Position += align - mod;
        }
    }

    public partial class SimpleReader
    {
        /// <summary>
        /// Advances the stream position until it meets the specified alignment.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        public void Align(long align)
        {
            SimplerStream.Align(align);
        }

        /// <summary>
        /// Advances the stream position until it meets the specified alignment starting from the specified position.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        /// <param name="position">The position from which to start aligning.</param>
        public void AlignFrom(long align, long position)
        {
            SimplerStream.AlignFrom(align, position);
        }
    }

    public partial class SimpleWriter
    {
        /// <summary>
        /// Advances the stream position until it meets the specified alignment.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        public void Align(long align)
        {
            SimplerStream.Align(align);
        }

        /// <summary>
        /// Advances the stream position until it meets the specified alignment starting from the specified position.
        /// </summary>
        /// <param name="align">The amount to align by.</param>
        /// <param name="position">The position from which to start aligning.</param>
        public void AlignFrom(long align, long position)
        {
            SimplerStream.AlignFrom(align, position);
        }
    }
}