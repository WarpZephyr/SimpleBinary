namespace SimpleBinary
{
    public partial class SimpleBinaryStream
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
}