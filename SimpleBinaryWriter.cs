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
        private Stack<KeyValuePair<long, long>> Offsets { get; set; } = new Stack<KeyValuePair<long, long>>();

        /// <summary>
        /// Length reservations to be filled later in the stream.
        /// </summary>
        private Stack<KeyValuePair<long, long>> Lengths { get; set; } = new Stack<KeyValuePair<long, long>>();

        /// <summary>
        /// Create a new <see cref="SimpleBinaryWriter"/> with a <see cref="BinaryWriter"/>.
        /// </summary>
        /// <param name="writer">A BinaryWriter.</param>
        public SimpleBinaryWriter(BinaryWriter writer)
        {
            SimpleBinaryStream = new SimpleBinaryStream(writer.BaseStream);
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryWriter"/> with a <see cref="System.IO.Stream"/>.
        /// </summary>
        /// <param name="stream">A stream.</param>
        public SimpleBinaryWriter(Stream stream)
        {
            SimpleBinaryStream = new SimpleBinaryStream(stream);
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryWriter"/> with a <see cref="byte"/> <see cref="Array"/>.
        /// </summary>
        /// <param name="bytes">A <see cref="byte"/> <see cref="Array"/>.</param>
        public SimpleBinaryWriter(byte[] bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes));
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryWriter"/> with a <see cref="List{T}"/> of <see cref="byte"/>.
        /// </summary>
        /// <param name="bytes">A <see cref="List{T}"/> of <see cref="byte"/>.</param>
        public SimpleBinaryWriter(List<byte> bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes.ToArray()));
            Writer = new BinaryWriter(Stream);
        }

        /// <summary>
        /// Create a new <see cref="SimpleBinaryWriter"/> by reading a file into a new <see cref="FileStream"/>.
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
        /// Set the current Varint length.
        /// </summary>
        /// <param name="length">The length Varints should be.</param>
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
            if (Reservations.Count != 0)
                throw new InvalidOperationException($"Not all reservations are filled: {string.Join(", ", Reservations.Keys)}");
            else if (Offsets.Count != 0)
                throw new InvalidOperationException($"Not all reserved offsets are filled. Remaining: {Offsets.Count}");
            else if (Lengths.Count != 0)
                throw new InvalidOperationException($"Not all reserved lengths are filled. Remaining: {Lengths.Count}");
            ((IDisposable)SimpleBinaryStream).Dispose();
            GC.SuppressFinalize(this);
        }

        public ValueTask DisposeAsync()
        {
            if (Reservations.Count != 0)
                throw new InvalidOperationException($"Not all reservations are filled: {string.Join(", ", Reservations.Keys)}");
            else if (Offsets.Count != 0)
                throw new InvalidOperationException($"Not all reserved offsets are filled. Remaining: {Offsets.Count}");
            else if (Lengths.Count != 0)
                throw new InvalidOperationException($"Not all reserved lengths are filled. Remaining: {Lengths.Count}");
            ValueTask task = ((IAsyncDisposable)Stream).DisposeAsync();
            GC.SuppressFinalize(this);
            return task;
        }
    }
}
