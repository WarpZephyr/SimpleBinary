namespace SimpleStream
{
    public partial class SimplerStream
    {
        /// <summary>
        /// Skip a single byte.
        /// </summary>
        public void Skip()
        {
            Seek(1);
        }

        /// <summary>
        /// Skip the specified number of bytes.
        /// </summary>
        /// <param name="count">The number of bytes to skip.</param>
        public void Skip(long count)
        {
            Seek(count);
        }
    }

    public partial class SimpleReader
    {
        /// <summary>
        /// Skip a single byte.
        /// </summary>
        public void Skip()
        {
            SimplerStream.Skip();
        }

        /// <summary>
        /// Skip the specified number of bytes.
        /// </summary>
        /// <param name="count">The number of bytes to skip.</param>
        public void Skip(long count)
        {
            SimplerStream.Skip(count);
        }
    }

    public partial class SimpleWriter
    {
        /// <summary>
        /// Skip a single byte.
        /// </summary>
        public void Skip()
        {
            SimplerStream.Skip();
        }

        /// <summary>
        /// Skip the specified number of bytes.
        /// </summary>
        /// <param name="count">The number of bytes to skip.</param>
        public void Skip(long count)
        {
            SimplerStream.Skip(count);
        }
    }
}