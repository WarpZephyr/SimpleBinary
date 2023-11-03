using System.Text;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write a <see cref="string" /> with specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" /></param>
        public void WriteString(string value, Encoding encoding)
        {
            Writer.Write(encoding.GetBytes(value));
        }

        /// <summary>
        /// Write a fixed-size <see cref="string" /> with the specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" /></param>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <param name="padding">The padding to add to the written <see cref="string" /></param>
        public void WriteFixedString(string value, Encoding encoding, int length, byte padding = 0)
        {
            byte[] fixstr = new byte[length];
            for (int i = 0; i < length; i++)
                fixstr[i] = padding;

            byte[] bytes = encoding.GetBytes(value);
            Array.Copy(bytes, fixstr, Math.Min(length, bytes.Length));
            Writer.Write(fixstr);
        }

        /// <summary>
        /// Write an ASCII encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteASCII(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.ASCII);
        }

        /// <summary>
        /// Write a ShiftJIS encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteShiftJIS(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.ShiftJIS);
        }

        /// <summary>
        /// Write a EucJP encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteEucJP(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.EucJP);
        }

        /// <summary>
        /// Write a EucCN encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteEucCN(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.EucCN);
        }

        /// <summary>
        /// Write a EucKR encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteEucKR(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.EucKR);
        }

        /// <summary>
        /// Write a UTF8 encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteUTF8(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0" : value, SimpleBinaryEncoding.UTF8);
        }

        /// <summary>
        /// Write a UTF16 encoded <see cref="string" /> with a terminator if specified.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to write.</param>
        /// <param name="terminate">Whether or not to add a terminator to the written <see cref="string" />.</param>
        public void WriteUTF16(string value, bool terminate = false)
        {
            WriteString(terminate ? value + "\0\0" : value, BigEndian ? SimpleBinaryEncoding.UTF16BE : SimpleBinaryEncoding.UTF16);
        }
    }
}
