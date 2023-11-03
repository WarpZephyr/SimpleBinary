using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    /// <summary>
    /// A writer that makes writing binary data easier.
    /// </summary>
    public partial class SimpleBinaryWriter : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// A <see cref="SimpleBinary.SimpleBinaryStream" /> for seeking, skipping, among other actions.
        /// </summary>
        public SimpleBinaryStream SimpleBinaryStream { get; set; }

        /// <summary>
        /// The underlying stream.
        /// </summary>
        public Stream Stream => SimpleBinaryStream.Stream;

        /// <summary>
        /// Get the length of the underlying stream.
        /// </summary>
        public long Length => SimpleBinaryStream.Length;

        /// <summary>
        /// Get or set the position of the underlying stream.
        /// </summary>
        public long Position
        {
            get => SimpleBinaryStream.Position;
            set => SimpleBinaryStream.Position = value;
        }

        /// <summary>
        /// Get the remaining length of the stream.
        /// </summary>
        public long Remaining => SimpleBinaryStream.Remaining;

        /// <summary>
        /// Whether or not the stream should write in big endian.
        /// </summary>
        public bool BigEndian { get; set; } = false;

        /// <summary>
        /// The currently used VarintLengthType type when writing Varints.
        /// </summary>
        public VarintLengthType VarintType { get; set; } = VarintLengthType.Int;

        /// <summary>
        /// The current length of Varints in bytes.
        /// </summary>
        public long VarintLength => (long)VarintType;

        /// <summary>
        /// The BinaryWriter containing the underlying stream.
        /// </summary>
        private BinaryWriter Writer { get; set; }

        /// <summary>
        /// Reservations to be filled later in the stream.
        /// </summary>
        private Dictionary<string, long> Reservations { get; set; } = new Dictionary<string, long>();

        /// <summary>
        /// Offset reservations to be filled later in the stream.
        /// </summary>
        private Dictionary<long, long> Offsets { get; set; } = new Dictionary<long, long>();

        /// <summary>
        /// Length reservations to be filled later in the stream.
        /// </summary>
        private Dictionary<long, long> Lengths { get; set; } = new Dictionary<long, long>();

        /// <summary>
        /// Create a new SimpleWriter with a BinaryWriter.
        /// </summary>
        /// <param name="writer">A BinaryWriter.</param>
        public SimpleBinaryWriter(BinaryWriter writer)
        {
            SimpleBinaryStream = new SimpleBinaryStream(writer.BaseStream);
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new SimpleWriter with a stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        public SimpleBinaryWriter(Stream stream)
        {
            SimpleBinaryStream = new SimpleBinaryStream(stream);
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new SimpleWriter with a byte array.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        public SimpleBinaryWriter(byte[] bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes));
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new SimpleWriter with a list of bytes.
        /// </summary>
        /// <param name="bytes">A list of bytes.</param>
        public SimpleBinaryWriter(List<byte> bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes.ToArray()));
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new SimpleWriter by reading a file into a new stream.
        /// </summary>
        /// <param name="path">The path to a file.</param>
        public SimpleBinaryWriter(string path)
        {
            if (Directory.Exists(path))
                throw new InvalidOperationException("The specified path was a directory and not a file.");
            if (!File.Exists(path))
                throw new InvalidOperationException("The file at the specified path could not be found.");

            SimpleBinaryStream = new SimpleBinaryStream(new FileStream(path, FileMode.Open, FileAccess.Write));
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// End the stream and release all of its resources.
        /// </summary>
        /// <exception cref="InvalidOperationException">Not all reservations have been filled.</exception>
        public void Finish()
        {
            if (Reservations.Count != 0)
                throw new InvalidOperationException($"Not all reservations are filled: {string.Join(", ", Reservations.Keys)}");
            else if (Offsets.Count != 0)
                throw new InvalidOperationException($"Not all reserved offsets are filled. Remaining: {Offsets.Count}");
            else if (Lengths.Count != 0)
                throw new InvalidOperationException($"Not all reserved lengths are filled. Remaining: {Lengths.Count}");
            Dispose();
        }

        /// <summary>
        /// End the stream, release all of its resources, and return it as a byte array.
        /// </summary>
        public byte[] FinishBytes()
        {
            byte[] bytes = ((MemoryStream)SimpleBinaryStream.Stream).ToArray();
            Dispose();
            return bytes;
        }

        /// <summary>
        /// End the stream, release all of its resources, and write it as an array of bytes to a file.
        /// </summary>
        /// <param name="path">The path to write the stream's bytes to.</param>
        /// <param name="overwrite">Whether or not to overwrite a file on the path if it already exists.</param>
        public void FinishWrite(string path, bool overwrite = false)
        {
            SimpleBinaryStream.FinishWrite(path, overwrite);
        }

        /// <summary>
        /// Get a <see cref="byte" /> array of the stream in its current state without disposing it.
        /// </summary>
        /// <returns>A <see cref="byte" /> array.</returns>
        public byte[] GetBytes()
        {
            return SimpleBinaryStream.GetBytes();
        }

        /// <summary>
        /// Set the current varint length.
        /// </summary>
        /// <param name="length">The length varints should be.</param>
        /// <exception cref="NotSupportedException">The provided length was not supported.</exception>
        public void SetVarintLength(long length)
        {
            VarintType = length switch
            {
                1 => VarintLengthType.Byte,
                2 => VarintLengthType.Short,
                4 => VarintLengthType.Int,
                8 => VarintLengthType.Long,
                _ => throw new NotSupportedException($"The length: {length} is not supported as a {nameof(VarintLengthType)}."),
            };
        }

        public void Dispose()
        {
            ((IDisposable)SimpleBinaryStream).Dispose();
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
