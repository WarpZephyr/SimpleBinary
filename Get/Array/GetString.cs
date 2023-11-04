using System.Text;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Get a <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetString(long position, Encoding encoding)
        {
            return Get(() => ReadString(encoding), position);
        }

        /// <summary>
        /// Get a fixed-size <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedString(long position, int length, Encoding encoding)
        {
            return Get(() => ReadFixedString(length, encoding), position);
        }

        /// <summary>
        /// Get an ASCII encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetASCII(long position)
        {
            return Get(() => ReadASCII(), position);
        }

        /// <summary>
        /// Get a ShiftJIS encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetShiftJIS(long position)
        {
            return Get(() => ReadShiftJIS(), position);
        }

        /// <summary>
        /// Get a EucJP encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetEucJP(long position)
        {
            return Get(() => ReadEucJP(), position);
        }

        /// <summary>
        /// Get a EucCN encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetEucCN(long position)
        {
            return Get(() => ReadEucCN(), position);
        }

        /// <summary>
        /// Get a EucKR encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetEucKR(long position)
        {
            return Get(() => ReadEucKR(), position);
        }

        /// <summary>
        /// Get a UTF8 encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetUTF8(long position)
        {
            return Get(() => ReadUTF8(), position);
        }

        /// <summary>
        /// Get a UTF16 encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetUTF16(long position)
        {
            return Get(() => ReadUTF16(), position);
        }

        /// <summary>
        /// Get a fixed-size ASCII encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedASCII(long position, int length)
        {
            return Get(() => ReadFixedASCII(length), position);
        }

        /// <summary>
        /// Get a fixed-size ShiftJIS encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedShiftJIS(long position, int length)
        {
            return Get(() => ReadFixedShiftJIS(length), position);
        }

        /// <summary>
        /// Get a fixed-size EucJP encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedEucJP(long position, int length)
        {
            return Get(() => ReadFixedEucJP(length), position);
        }

        /// <summary>
        /// Get a fixed-size EucCN encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedEucCN(long position, int length)
        {
            return Get(() => ReadFixedEucCN(length), position);
        }

        /// <summary>
        /// Get a fixed-size EucKR encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedEucKR(long position, int length)
        {
            return Get(() => ReadFixedEucKR(length), position);
        }

        /// <summary>
        /// Get a fixed-size UTF8 encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedUTF8(long position, int length)
        {
            return Get(() => ReadFixedUTF8(length), position);
        }

        /// <summary>
        /// Get a fixed-size UTF16 encoded <see cref="string" /> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>A <see cref="string" />.</returns>
        public string GetFixedUTF16(long position, int length)
        {
            return Get(() => ReadFixedUTF16(length), position);
        }
    }
}
