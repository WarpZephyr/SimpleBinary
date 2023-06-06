using System.Buffers.Binary;
using System.Data.Common;

namespace SimpleStream
{
    public partial class SimplerStream : IDisposable, IAsyncDisposable
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
            private set => Stream.Position = value;
        }

        /// <summary>
        /// Get the length of the underlying stream.
        /// </summary>
        public long Length => Stream.Length;

        /// <summary>
        /// Get the remaining length of the stream.
        /// </summary>
        public long Remaining => Stream.Length - Position;

        /// <summary>
        /// The steps into positions on the stream.
        /// </summary>
        private Stack<long> Steps { get; set; }

        /// <summary>
        /// Initialize a stream.
        /// </summary>
        public SimplerStream(Stream stream)
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
            byte[] bytes = ((MemoryStream)Stream).ToArray();
            return bytes;
        }

        /// <summary>
        /// Set the position of the stream.
        /// </summary>
        /// <param name="position">The position to set the stream to.</param>
        /// <exception cref="ArgumentOutOfRangeException">The position cannot be less than 0 or greater than the length of the stream.</exception>
        public void SetPosition(long position)
        {
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position), "The specified position cannot be negative.");
            if (position > Length)
                throw new ArgumentOutOfRangeException(nameof(position), "The specified position cannot go beyond the stream");
            Position = position;
        }

        /// <summary>
        /// Whether or not the <see cref="SimplerStream" /> has been disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Releases all resources used by the <see cref="SimplerStream" />
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
                    Stream.Dispose();

                IsDisposed = true;
            }
        }

        /// <summary>
        /// Asynchronously releases the unmanaged resources used by the <see cref="SimplerStream" />.
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
            await Stream.DisposeAsync().ConfigureAwait(false);
        }
    }
}