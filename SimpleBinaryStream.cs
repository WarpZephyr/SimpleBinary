namespace SimpleBinary
{
    /// <summary>
    /// A <see cref="System.IO.Stream"/> wrapper that contains shared methods between <see cref="SimpleBinaryReader"/> and <see cref="SimpleBinaryWriter"/>.
    /// </summary>
    public partial class SimpleBinaryStream : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// The underlying <see cref="System.IO.Stream"/>.
        /// </summary>
        public virtual Stream Stream { get; private set; }

        /// <summary>
        /// Get the position of the <see cref="System.IO.Stream"/>.
        /// </summary>
        public long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        /// <summary>
        /// Get the length of the <see cref="System.IO.Stream"/>.
        /// </summary>
        public long Length => Stream.Length;

        /// <summary>
        /// Get the remaining length of the <see cref="System.IO.Stream"/>.
        /// </summary>
        public long Remaining => Stream.Length - Stream.Position;

        /// <summary>
        /// Whether or not the <see cref="System.IO.Stream"/> can seek.
        /// </summary>
        public bool CanSeek => Stream.CanSeek;

        /// <summary>
        /// Whether or not the <see cref="System.IO.Stream"/> can be read from.
        /// </summary>
        public bool CanRead => Stream.CanRead;

        /// <summary>
        /// Whether or not the s<see cref="System.IO.Stream"/>tream can be written to.
        /// </summary>
        public bool CanWrite => Stream.CanWrite;

        /// <summary>
        /// The steps into positions on the <see cref="System.IO.Stream"/>.
        /// </summary>
        private Stack<long> Steps { get; set; }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryStream"/>.
        /// </summary>
        public SimpleBinaryStream(Stream stream)
        {
            Stream = stream;
            Steps = new Stack<long>();
        }

        /// <summary>
        /// End the <see cref="System.IO.Stream"/>, release all of its resources, and return it as a <see cref="byte"/> <see cref="Array"/>.
        /// </summary>
        public byte[] FinishBytes()
        {
            byte[] bytes = ((MemoryStream)Stream).ToArray();
            Dispose();
            return bytes;
        }

        /// <summary>
        /// End the <see cref="System.IO.Stream"/>, release all of its resources, and write it as a <see cref="byte"/> <see cref="Array"/> to a file.
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
        /// Get a <see cref="byte" /> <see cref="Array"/> of the <see cref="System.IO.Stream"/> in its current state without disposing it.
        /// </summary>
        /// <returns>A <see cref="byte" /> <see cref="Array"/>.</returns>
        public byte[] GetBytes()
        {
            return ((MemoryStream)Stream).ToArray();
        }

        public void Dispose()
        {
            if (Steps.Count != 0)
                throw new InvalidOperationException("The Stream has not been stepped all the way back out yet.");

            ((IDisposable)Stream).Dispose();
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            if (Steps.Count != 0)
                throw new InvalidOperationException("The Stream has not been stepped all the way back out yet.");

            ValueTask task = ((IAsyncDisposable)Stream).DisposeAsync();
            GC.SuppressFinalize(this);
            return task;
        }
    }
}