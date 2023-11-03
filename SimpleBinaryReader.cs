using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    /// <summary>
    /// A reader that makes reading binary data easier.
    /// </summary>
    public partial class SimpleBinaryReader : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// A <see cref="SimpleBinary.SimpleBinaryStream" /> for seeking, skipping, among other actions.
        /// </summary>
        public readonly SimpleBinaryStream SimpleBinaryStream;

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
        /// Whether or not the stream should read in big endian.
        /// </summary>
        public bool BigEndian { get; set; } = false;

        /// <summary>
        /// Whether or not reading booleans should throw if encountering a value other than 0 or 1.
        /// </summary>
        public bool ValidateBools { get; set; } = true;

        /// <summary>
        /// The currently used VarintLengthType type when reading Varints.
        /// </summary>
        public VarintLengthType VarintType { get; set; } = VarintLengthType.Int;

        /// <summary>
        /// The current length of Varints in bytes.
        /// </summary>
        public long VarintLength => (long)VarintType;

        /// <summary>
        /// The BinaryReader containing the underlying stream.
        /// </summary>
        private readonly BinaryReader Reader;

        /// <summary>
        /// Create a new SimpleReader with a BinaryReader.
        /// </summary>
        /// <param name="reader">A BinaryReader.</param>
        public SimpleBinaryReader(BinaryReader reader)
        {
            SimpleBinaryStream = new SimpleBinaryStream(reader.BaseStream);
            Reader = new BinaryReader(Stream);
        }

        /// <summary>
        /// Create a new SimpleReader with a stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        public SimpleBinaryReader(Stream stream)
        {
            SimpleBinaryStream = new SimpleBinaryStream(stream);
            Reader = new BinaryReader(Stream);

        }

        /// <summary>
        /// Create a new SimpleReader with a byte array.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        public SimpleBinaryReader(byte[] bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes));
            Reader = new BinaryReader(Stream);
        }

        /// <summary>
        /// Create a new SimpleReader with a list of bytes.
        /// </summary>
        /// <param name="bytes">A list of bytes.</param>
        public SimpleBinaryReader(List<byte> bytes)
        {
            SimpleBinaryStream = new SimpleBinaryStream(new MemoryStream(bytes.ToArray()));
            Reader = new BinaryReader(Stream);
        }

        /// <summary>
        /// Create a new SimpleReader by reading a file into the new stream.
        /// </summary>
        /// <param name="path">The path to a file.</param>
        public SimpleBinaryReader(string path)
        {
            if (!File.Exists(path))
                throw new InvalidOperationException("The file at the specified path could not be found.");

            SimpleBinaryStream = new SimpleBinaryStream(new FileStream(path, FileMode.Open, FileAccess.Read));
            Reader = new BinaryReader(Stream);
        }

        /// <summary>
        /// End the stream and release all of its resources.
        /// </summary>
        public void Finish()
        {
            Dispose();
        }

        /// <summary>
        /// End the stream, release all of its resources, and return it as a byte array.
        /// </summary>
        /// <returns>A <see cref="byte" /> array.</returns>
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