using System.Text;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Read a <see cref="string" /> until a terminator is found with the specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadString(Encoding encoding)
        {
            var stringBytes = new List<byte>();
            int terminatorSize = encoding.IsSingleByte ? 1 : encoding.GetByteCount("\0");

            bool terminatorFound;
            do
            {
                // Set terminatorFound to true
                terminatorFound = true;
                byte[] bytes = ReadBytes(terminatorSize);
                for (int i = 0; i < terminatorSize; i++)
                {
                    // If a value is not a terminator set terminatorFound to false and break out of the for loop. 
                    if (bytes[i] != 0)
                    {
                        terminatorFound = false;
                        break;
                    }
                }
            } while (!terminatorFound);

            return encoding.GetString(stringBytes.ToArray());
        }

        /// <summary>
        /// Read a fixed-size <see cref="string" /> of the specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedString(int length, Encoding encoding)
        {
            return encoding.GetString(ReadBytes(encoding.IsSingleByte ? length : length * encoding.GetByteCount("\0")));
        }

        /// <summary>
        /// Read an ASCII encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadASCII()
        {
            return ReadString(SimpleBinaryEncoding.ASCII);
        }

        /// <summary>
        /// Read a ShiftJIS encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadShiftJIS()
        {
            return ReadString(SimpleBinaryEncoding.ShiftJIS);
        }

        /// <summary>
        /// Read a EucJP encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadEucJP()
        {
            return ReadString(SimpleBinaryEncoding.EucJP);
        }

        /// <summary>
        /// Read a EucCN encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadEucCN()
        {
            return ReadString(SimpleBinaryEncoding.EucCN);
        }

        /// <summary>
        /// Read a EucKR encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadEucKR()
        {
            return ReadString(SimpleBinaryEncoding.EucKR);
        }

        /// <summary>
        /// Read a UTF8 encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadUTF8()
        {
            return ReadString(SimpleBinaryEncoding.UTF8);
        }

        /// <summary>
        /// Read a UTF16 encoded <see cref="string" /> until a terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadUTF16()
        {
            return ReadString(BigEndian ? SimpleBinaryEncoding.UTF16BE : SimpleBinaryEncoding.UTF16);
        }

        /// <summary>
        /// Read a fixed-size ASCII encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedASCII(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.ASCII);
        }

        /// <summary>
        /// Read a fixed-size ShiftJIS encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedShiftJIS(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.ShiftJIS);
        }

        /// <summary>
        /// Read a fixed-size EucJP encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedEucJP(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.EucJP);
        }

        /// <summary>
        /// Read a fixed-size EucCN encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedEucCN(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.EucCN);
        }

        /// <summary>
        /// Read a fixed-size EucKR encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedEucKR(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.EucKR);
        }

        /// <summary>
        /// Read a fixed-size UTF8 encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedUTF8(int length)
        {
            return ReadFixedString(length, SimpleBinaryEncoding.UTF8);
        }

        /// <summary>
        /// Read a fixed-size UTF16 encoded <see cref="string" />.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string ReadFixedUTF16(int length)
        {
            return ReadFixedString(length, BigEndian ? SimpleBinaryEncoding.UTF16BE : SimpleBinaryEncoding.UTF16);
        }
    }
}
