namespace SimpleStream
{
    public partial class SimplerStream
    {
        /// <summary>
        /// Seek the specified number of bytes starting from the current position of the stream.
        /// </summary>
        /// <param name="count">The number of bytes to seek from the current position of the stream.</param>
        public void Seek(long count)
        {
            Stream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek the specified number of bytes starting from the specified seek origin.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="origin">The seek origin from which to start seeking.</param>
        public void Seek(long count, SeekOrigin origin)
        {
            Stream.Seek(count, origin);
        }

        /// <summary>
        /// Go to the specified position and then start seeking from it.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="position">The position from which to start seeking.</param>
        public void Seek(long count, long position) 
        {
            SetPosition(position);
            Stream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek to the specified seek origin.
        /// </summary>
        /// <param name="origin">The seek origin to seek to.</param>
        public void Seek(SeekOrigin origin)
        {
            Stream.Seek(0, origin);
        }
    }

    public partial class SimpleReader
    {
        /// <summary>
        /// Seek the specified number of bytes starting from the current position of the stream.
        /// </summary>
        /// <param name="count">The number of bytes to seek from the current position of the stream.</param>
        public void Seek(long count)
        {
            SimplerStream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek the specified number of bytes starting from the specified seek origin.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="origin">The seek origin from which to start seeking.</param>
        public void Seek(long count, SeekOrigin origin)
        {
            SimplerStream.Seek(count, origin);
        }

        /// <summary>
        /// Go to the specified position and then start seeking from it.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="position">The position from which to start seeking.</param>
        public void Seek(long count, long position)
        {
            SimplerStream.Seek(count, position);
        }

        /// <summary>
        /// Seek to the specified seek origin.
        /// </summary>
        /// <param name="origin">The seek origin to seek to.</param>
        public void Seek(SeekOrigin origin)
        {
            SimplerStream.Seek(origin);
        }
    }

    public partial class SimpleWriter
    {
        /// <summary>
        /// Seek the specified number of bytes starting from the current position of the stream.
        /// </summary>
        /// <param name="count">The number of bytes to seek from the current position of the stream.</param>
        public void Seek(long count)
        {
            SimplerStream.Seek(count, SeekOrigin.Current);
        }

        /// <summary>
        /// Seek the specified number of bytes starting from the specified seek origin.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="origin">The seek origin from which to start seeking.</param>
        public void Seek(long count, SeekOrigin origin)
        {
            SimplerStream.Seek(count, origin);
        }

        /// <summary>
        /// Go to the specified position and then start seeking from it.
        /// </summary>
        /// <param name="count">The number of bytes to seek.</param>
        /// <param name="position">The position from which to start seeking.</param>
        public void Seek(long count, long position)
        {
            SimplerStream.Seek(count, position);
        }

        /// <summary>
        /// Seek to the specified seek origin.
        /// </summary>
        /// <param name="origin">The seek origin to seek to.</param>
        public void Seek(SeekOrigin origin)
        {
            SimplerStream.Seek(origin);
        }
    }
}