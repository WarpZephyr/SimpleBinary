namespace SimpleBinary
{
    public partial class SimpleBinaryStream
    {
        /// <summary>
        /// Seek forward by one byte.
        /// </summary>
        public void Seek()
        {
            BaseStream.Seek(1, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek the specified number of bytes starting from the current position of the stream.
        /// </summary>
        /// <param name="count">The number of bytes to seek from the current position of the stream.</param>
        public void Seek(long count)
        {
            BaseStream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek the specified number of bytes starting from the specified seek origin.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="origin">The seek origin from which to start seeking.</param>
        public void Seek(long count, SeekOrigin origin)
        {
            BaseStream.Seek(count, origin);
        }

        /// <summary>
        /// Go to the specified position and then start seeking from it.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="position">The position from which to start seeking.</param>
        public void Seek(long count, long position) 
        {
            Position = position;
            BaseStream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek to the specified seek origin.
        /// </summary>
        /// <param name="origin">The seek origin to seek to.</param>
        public void Seek(SeekOrigin origin)
        {
            BaseStream.Seek(0, origin);
        }

        /// <summary>
        /// Seek backward by one byte.
        /// </summary>
        public void SeekBackward()
        {
            BaseStream.Seek(-1, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek backward by the specified number of bytes starting from the current position of the stream.
        /// </summary>
        /// <param name="count">The number of bytes to seek backward by.</param>
        public void SeekBackward(long count)
        {
            BaseStream.Seek(-count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek backward by the specified number of bytes starting from the specified seek origin.
        /// </summary>
        /// <param name="count">The number of bytes to seek backward by.</param>
        /// <param name="origin">The seek origin from which to start seeking backwards from.</param>
        public void SeekBackward(long count, SeekOrigin origin)
        {
            BaseStream.Seek(-count, origin);
        }
    }
}