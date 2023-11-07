namespace SimpleBinary
{
    /// <summary>
    /// A <see cref="Stream"/> wrapper that contains shared methods between <see cref="SimpleBinaryReader"/> and <see cref="SimpleBinaryWriter"/>.
    /// </summary>
    public partial class SimpleBinaryStream : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// The underlying <see cref="Stream"/>.
        /// </summary>
        public virtual Stream BaseStream { get; private set; }

        /// <summary>
        /// Get the position of the <see cref="Stream"/>.
        /// </summary>
        public long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }

        /// <summary>
        /// Get the length of the <see cref="Stream"/>.
        /// </summary>
        public long Length => BaseStream.Length;

        /// <summary>
        /// Get the remaining length of the <see cref="Stream"/>.
        /// </summary>
        public long Remaining => BaseStream.Length - BaseStream.Position;

        /// <summary>
        /// Whether or not the <see cref="Stream"/> can seek.
        /// </summary>
        public bool CanSeek => BaseStream.CanSeek;

        /// <summary>
        /// Whether or not the <see cref="Stream"/> can be read from.
        /// </summary>
        public bool CanRead => BaseStream.CanRead;

        /// <summary>
        /// Whether or not the s<see cref="Stream"/>tream can be written to.
        /// </summary>
        public bool CanWrite => BaseStream.CanWrite;

        /// <summary>
        /// The steps into positions on the <see cref="Stream"/>.
        /// </summary>
        private Stack<long> Steps { get; set; }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryStream"/> that uses a <see cref="MemoryStream"/>.
        /// </summary>
        public SimpleBinaryStream()
        {
            BaseStream = new MemoryStream();
            Steps = new Stack<long>();
        }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryStream"/> with a <see cref="Stream"/>.
        /// </summary>
        public SimpleBinaryStream(Stream stream)
        {
            BaseStream = stream;
            Steps = new Stack<long>();
        }

        /// <summary>
        /// End the <see cref="Stream"/>, release all of its resources, and return it as a <see cref="byte"/> <see cref="Array"/>.
        /// </summary>
        public byte[] FinishBytes()
        {
            byte[] bytes = ((MemoryStream)BaseStream).ToArray();
            Dispose();
            return bytes;
        }

        /// <summary>
        /// End the <see cref="Stream"/>, release all of its resources, and write it as a <see cref="byte"/> <see cref="Array"/> to a file.
        /// </summary>
        /// <param name="path">The path to write to.</param>
        /// <param name="overwrite">Whether or not to overwrite a file on the path if it already exists.</param>
        /// <exception cref="InvalidOperationException">A file was found already existing on the path and overwrite was set to false.</exception>
        public void FinishWrite(string path, bool overwrite = false)
        {
            if (File.Exists(path) && !overwrite)
                throw new InvalidOperationException("Cannot overwrite existing file on path if not allowed to.");

            File.WriteAllBytes(path, FinishBytes());
        }

        /// <summary>
        /// Get a <see cref="byte" /> <see cref="Array"/> of the <see cref="Stream"/> in its current state without disposing it.
        /// </summary>
        /// <returns>A <see cref="byte" /> <see cref="Array"/>.</returns>
        public byte[] GetBytes()
        {
            return ((MemoryStream)BaseStream).ToArray();
        }

        public void Dispose()
        {
            if (Steps.Count != 0)
                throw new InvalidOperationException("The Stream has not been stepped all the way back out yet.");

            ((IDisposable)BaseStream).Dispose();
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            if (Steps.Count != 0)
                throw new InvalidOperationException("The Stream has not been stepped all the way back out yet.");

            ValueTask task = ((IAsyncDisposable)BaseStream).DisposeAsync();
            GC.SuppressFinalize(this);
            return task;
        }
    }
}