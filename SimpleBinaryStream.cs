namespace SimpleBinary
{
    /// <summary>
    /// A binary stream wrapper that contains shared methods between <see cref="SimpleBinaryReader"/> and <see cref="SimpleBinaryWriter"/>.
    /// </summary>
    public partial class SimpleBinaryStream : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// The underlying stream.
        /// </summary>
        public virtual Stream Stream { get; private set; }

        /// <summary>
        /// Get the position of the underlying stream.
        /// </summary>
        public long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        /// <summary>
        /// Get the length of the stream.
        /// </summary>
        public long Length => Stream.Length;

        /// <summary>
        /// Get the remaining length of the stream.
        /// </summary>
        public long Remaining => Stream.Length - Stream.Position;

        /// <summary>
        /// Whether or not the stream can seek.
        /// </summary>
        public bool CanSeek => Stream.CanSeek;

        /// <summary>
        /// Whether or not the stream can be read from.
        /// </summary>
        public bool CanRead => Stream.CanRead;

        /// <summary>
        /// Whether or not the stream can be written to.
        /// </summary>
        public bool CanWrite => Stream.CanWrite;

        /// <summary>
        /// The steps into positions on the stream.
        /// </summary>
        private Stack<long> Steps { get; set; }

        /// <summary>
        /// Initialize a stream.
        /// </summary>
        public SimpleBinaryStream(Stream stream)
        {
            Stream = stream;
            Steps = new Stack<long>();
        }

        /// <summary>
        /// End the stream and release all of its resources.
        /// </summary>
        public void Finish()
        {
            if (Steps.Count != 0)
                throw new InvalidOperationException("The stream has not been stepped all the way back out yet.");

            Dispose();
        }

        /// <summary>
        /// End the stream, release all of its resources, and return it as a byte array.
        /// </summary>
        public byte[] FinishBytes()
        {
            byte[] bytes = ((MemoryStream)Stream).ToArray();
            Finish();
            return bytes;
        }

        /// <summary>
        /// End the stream, release all of its resources, and write it as an array of bytes to a file.
        /// </summary>
        /// <param name="path">The path to write the stream's bytes to.</param>
        /// <param name="overwrite">Whether or not to overwrite a file on the path if it already exists.</param>
        /// <exception cref="InvalidOperationException">A file was found already existing on the path and overwrite was set to false.</exception>
        public void FinishWrite(string path, bool overwrite = false)
        {
            if (File.Exists(path) && !overwrite)
                throw new InvalidOperationException("Cannot overwrite existing file on path if not allowed to.");

            File.WriteAllBytes(path, FinishBytes());
        }

        /// <summary>
        /// Get a <see cref="byte" /> array of the stream in its current state without disposing it.
        /// </summary>
        /// <returns>A <see cref="byte" /> array.</returns>
        public byte[] GetBytes()
        {
            return ((MemoryStream)Stream).ToArray();
        }

        public void Dispose()
        {
            ((IDisposable)Stream).Dispose();
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            ValueTask task = ((IAsyncDisposable)Stream).DisposeAsync();
            GC.SuppressFinalize(this);
            return task;
        }
    }
}