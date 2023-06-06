using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    /// <summary>
    /// A writer that makes writing data easier.
    /// </summary>
    public partial class SimpleWriter : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// A SimplerStream to share common stream methods between the reader and writer.
        /// </summary>
        private SimplerStream SimplerStream { get; set; }

        /// <summary>
        /// The underlying stream.
        /// </summary>
        public Stream Stream => SimplerStream.Stream;

        /// <summary>
        /// Get the length of the underlying stream.
        /// </summary>
        public long Length => SimplerStream.Length;

        /// <summary>
        /// Get the position of the underlying stream.
        /// </summary>
        public long Position => SimplerStream.Position;

        /// <summary>
        /// Get the remaining length of the stream.
        /// </summary>
        public long Remaining => SimplerStream.Remaining;

        /// <summary>
        /// Whether or not the stream should write in big endian.
        /// </summary>
        public bool BigEndian { get; set; }

        /// <summary>
        /// The currently used VarintLengthType type when writing Varints.
        /// </summary>
        public VarintLengthType VarintType { get; set; }

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
        private Dictionary<string, long> Reservations { get; set; }

        /// <summary>
        /// Offset reservations to be filled later in the stream.
        /// </summary>
        private Dictionary<long, long> Offsets { get; set; }

        /// <summary>
        /// Length reservations to be filled later in the stream.
        /// </summary>
        private Dictionary<long, long> Lengths { get; set; } 

        /// <summary>
        /// Create a new SimpleWriter with a BinaryWriter.
        /// </summary>
        /// <param name="writer">A BinaryWriter.</param>
        /// <param name="bigendian">Whether or not the stream should be write in big endian.</param>
        public SimpleWriter(BinaryWriter writer, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(writer.BaseStream);
            Writer = new BinaryWriter(Stream);
            BigEndian = bigendian;
            Reservations = new Dictionary<string, long>();
            Offsets = new Dictionary<long, long>();
            Lengths = new Dictionary<long, long>();
        }

        /// <summary>
        /// Create a new SimpleWriter with a stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="bigendian">Whether or not the stream should be write in big endian.</param>
        public SimpleWriter(Stream stream, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(stream);
            Writer = new BinaryWriter(Stream);
            BigEndian = bigendian;
            Reservations = new Dictionary<string, long>();
            Offsets = new Dictionary<long, long>();
            Lengths = new Dictionary<long, long>();
        }

        /// <summary>
        /// Create a new SimpleWriter with a byte array which makes a non-resizable memory stream for the reader.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        /// <param name="bigendian">Whether or not the stream should be write in big endian.</param>
        public SimpleWriter(byte[] bytes, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(new MemoryStream(bytes));
            Writer = new BinaryWriter(Stream);
            BigEndian = bigendian;
            Reservations = new Dictionary<string, long>();
            Offsets = new Dictionary<long, long>();
            Lengths = new Dictionary<long, long>();
        }

        /// <summary>
        /// Create a new SimpleWriter with a list of bytes which makes a non-resizable memory stream for the reader.
        /// </summary>
        /// <param name="bytes">A list of bytes.</param>
        /// <param name="bigendian">Whether or not the stream should be write in big endian.</param>
        public SimpleWriter(List<byte> bytes, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(new MemoryStream(bytes.ToArray()));
            Writer = new BinaryWriter(Stream);
            BigEndian = bigendian;
            Reservations = new Dictionary<string, long>();
            Offsets = new Dictionary<long, long>();
            Lengths = new Dictionary<long, long>();
        }

        /// <summary>
        /// Create a new SimpleWriter by reading a file into the new stream.
        /// </summary>
        /// <param name="path">The path to a file.</param>
        /// <param name="bigendian">Whether or not the stream should be write in big endian.</param>
        public SimpleWriter(string path, bool bigendian = false)
        {
            if (!File.Exists(path))
                throw new InvalidOperationException("The file at the specified path could not be found.");

            SimplerStream = new SimplerStream(new FileStream(path, FileMode.Open, FileAccess.Read));
            Writer = new BinaryWriter(Stream);
            BigEndian = bigendian;
            Reservations = new Dictionary<string, long>();
            Offsets = new Dictionary<long, long>();
            Lengths = new Dictionary<long, long>();
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

            SimplerStream.Finish();
            Writer.Dispose();
        }

        /// <summary>
        /// End the stream, release all of its resources, and return it as a byte array.
        /// </summary>
        public byte[] FinishBytes()
        {
            byte[] bytes = ((MemoryStream)SimplerStream.Stream).ToArray();
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
            SimplerStream.FinishWrite(path, overwrite);
        }

        /// <summary>
        /// Get a <see cref="byte" /> array of the stream in its current state without disposing it.
        /// </summary>
        /// <returns>A <see cref="byte" /> array.</returns>
        public byte[] GetBytes()
        {
            return SimplerStream.GetBytes();
        }

        /// <summary>
        /// Set the position of the stream.
        /// </summary>
        /// <param name="position">The position to set the stream to.</param>
        public void SetPosition(long position)
        {
            SimplerStream.SetPosition(position);
        }

        public void SetVarintLength(long length)
        {
            VarintType = length switch
            {
                4 => VarintLengthType.Int,
                8 => VarintLengthType.Long,
                _ => throw new NotSupportedException($"The length: {length} is not supported as a {nameof(VarintLengthType)}."),
            };
        }

        /// <summary>
        /// Whether or not the <see cref="SimpleWriter" /> has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Releases all resources used by the <see cref="SimpleWriter" />
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                    Writer.Dispose();

                IsDisposed = true;
            }
        }

        /// <summary>
        /// Asynchronously releases the unmanaged resources used by the <see cref="SimpleWriter" />.
        /// </summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            await Writer.DisposeAsync().ConfigureAwait(false);
        }
    }
}
