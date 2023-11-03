namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write a given number of empty blocks of the given size from the current position.
        /// </summary>
        /// <param name="blockSize">The size of each block.</param>
        /// <param name="count">The number of blocks to write.</param>
        public void WriteBlock(long blockSize, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Writer.Write(new byte[blockSize]);
            }
        }

        /// <summary>
        /// Write a given number of empty blocks of the given size, going to the next block before starting if necessary.
        /// </summary>
        /// <param name="blockSize">The size of each block.</param>
        /// <param name="count">The number of blocks to write.</param>
        public void WriteAlignedBlock(long blockSize, int count)
        {
            long mod = Position % blockSize;
            if (mod != 0)
            {
                long add = blockSize - mod;
                if (Position + add >= Length)
                {
                    Writer.Write(new byte[add]);
                }
                else
                {
                    Position += add;
                }
            }

            WriteBlock(blockSize, count);
        }

        /// <summary>
        /// Write a <see cref="byte"/> array and fill the remaining block space from the current position.
        /// </summary>
        /// <param name="buffer">The <see cref="byte"/> array to write.</param>
        /// <param name="blockSize">The size of each block.</param>
        public void WriteBlock(byte[] buffer, long blockSize)
        {
            WriteBytes(buffer);
            long mod = Position % blockSize;
            if (mod != 0)
            {
                Writer.Write(new byte[blockSize - mod]);
            }
        }

        /// <summary>
        /// Write a <see cref="byte"/> array and fill the remaining block space, going to the next block before starting if necessary.
        /// </summary>
        /// <param name="buffer">The <see cref="byte"/> array to write.</param>
        /// <param name="blockSize">The size of each block.</param>
        public void WriteAlignedBlock(byte[] buffer, long blockSize)
        {
            if (Position % blockSize != 0)
            {
                long add = blockSize - (Position % blockSize);
                if (Position + add >= Length)
                {
                    Writer.Write(new byte[add]);
                }
                else
                {
                    Position += add;
                }
            }

            WriteBlock(buffer, blockSize);
        }

        /// <summary>
        /// Write the same byte the specified number of times.
        /// </summary>
        /// <param name="count">The number of times to write the byte.</param>
        /// <param name="pattern">The value to write.</param>
        public void WritePattern(long count, byte pattern)
        {
            byte[] bytes = new byte[count];
            if (pattern != 0)
                for (int i = 0; i < count; i++)
                    bytes[i] = pattern;
            WriteBytes(bytes);
        }
    }
}
