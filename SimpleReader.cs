using Microsoft.VisualBasic;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    /// <summary>
    /// A reader that makes reading data easier.
    /// </summary>
    public partial class SimpleReader
    {
        /// <summary>
        /// A SimplerStream to share common stream methods between the reader and writer.
        /// </summary>
        private SimplerStream SimplerStream;

        /// <summary>
        /// The underlying stream.
        /// </summary>
        public Stream Stream { get => SimplerStream.Stream; }

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
        /// Whether or not the stream should read in big endian.
        /// </summary>
        public bool BigEndian { get; set; }

        /// <summary>
        /// The currently used varint length when reading varints.
        /// </summary>
        public VarintLength VarintSize { get; set; }

        /// <summary>
        /// The BinaryReader containing the underlying stream.
        /// </summary>
        private BinaryReader Reader;

        /// <summary>
        /// Create a new SimpleReader with a BinaryReader.
        /// </summary>
        /// <param name="reader">A BinaryReader.</param>
        /// <param name="bigendian">Whether or not the stream should be read in big endian.</param>
        public SimpleReader(BinaryReader reader, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(reader.BaseStream);
            Reader = new BinaryReader(Stream);
            BigEndian = bigendian;
        }

        /// <summary>
        /// Create a new SimpleReader with a stream.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="bigendian">Whether or not the stream should be read in big endian.</param>
        public SimpleReader(Stream stream, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(stream);
            Reader = new BinaryReader(Stream);
            BigEndian = bigendian;
        }

        /// <summary>
        /// Create a new SimpleReader with a byte array which makes a non-resizable memory stream for the reader.
        /// </summary>
        /// <param name="bytes">An array of bytes.</param>
        /// <param name="bigendian">Whether or not the stream should be read in big endian.</param>
        public SimpleReader(byte[] bytes, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(new MemoryStream(bytes));
            Reader = new BinaryReader(Stream);
            BigEndian = bigendian;
        }

        /// <summary>
        /// Create a new SimpleReader with a list of bytes which makes a non-resizable memory stream for the reader.
        /// </summary>
        /// <param name="bytes">A list of bytes.</param>
        /// <param name="bigendian">Whether or not the stream should be read in big endian.</param>
        public SimpleReader(List<byte> bytes, bool bigendian = false)
        {
            SimplerStream = new SimplerStream(new MemoryStream(bytes.ToArray()));
            Reader = new BinaryReader(Stream);
            BigEndian = bigendian;
        }

        /// <summary>
        /// Create a new SimpleReader by reading a file into the new stream.
        /// </summary>
        /// <param name="path">The path to a file.</param>
        /// <param name="bigendian">Whether or not the stream should be read in big endian.</param>
        public SimpleReader(string path, bool bigendian = false)
        {
            if (!File.Exists(path))
                throw new InvalidOperationException("The file at the specified path could not be found.");

            SimplerStream = new SimplerStream(new FileStream(path, FileMode.Open, FileAccess.ReadWrite));
            Reader = new BinaryReader(Stream);
            BigEndian = bigendian;
        }

        /// <summary>
        /// End the stream and release all of its resources.
        /// </summary>
        public void Finish()
        {
            SimplerStream.Finish();
        }

        /// <summary>
        /// End the stream, release all of its resources, and return it as a byte array.
        /// </summary>
        public byte[] FinishBytes()
        {
            return SimplerStream.FinishBytes();
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
        /// Set the position of the stream.
        /// </summary>
        /// <param name="position">The position to set the stream to.</param>
        public void SetPosition(long position)
        {
            SimplerStream.SetPosition(position);
        }
    }
}