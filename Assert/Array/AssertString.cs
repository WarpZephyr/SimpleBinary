using System.Text;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Assert the next read <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertString(Encoding encoding, params string[] options)
        {
            return Assert(ReadString(encoding), options);
        }

        /// <summary>
        /// Assert the next read fixed-size <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedString(int length, Encoding encoding, params string[] options)
        {
            return Assert(ReadFixedString(length, encoding), options);
        }

        /// <summary>
        /// Assert the next readn ASCII encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertASCII(params string[] options)
        {
            return Assert(ReadASCII(), options);
        }

        /// <summary>
        /// Assert the next read ShiftJIS encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertShiftJIS(params string[] options)
        {
            return Assert(ReadShiftJIS(), options);
        }

        /// <summary>
        /// Assert the next read EucJP encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertEucJP(params string[] options)
        {
            return Assert(ReadEucJP(), options);
        }

        /// <summary>
        /// Assert the next read EucCN encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertEucCN(params string[] options)
        {
            return Assert(ReadEucCN(), options);
        }

        /// <summary>
        /// Assert the next read EucKR encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertEucKR(params string[] options)
        {
            return Assert(ReadEucKR(), options);
        }

        /// <summary>
        /// Assert the next read UTF8 encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertUTF8(params string[] options)
        {
            return Assert(ReadUTF8(), options);
        }

        /// <summary>
        /// Assert the next read UTF16 encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertUTF16(params string[] options)
        {
            return Assert(ReadUTF16(), options);
        }

        /// <summary>
        /// Assert the next read fixed-size ASCII encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedASCII(int length, params string[] options)
        {
            return Assert(ReadFixedASCII(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size ShiftJIS encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
		/// <param name="length">The length of the <see cref="string" />.</param>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedShiftJIS(int length, params string[] options)
        {
            return Assert(ReadFixedShiftJIS(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size EucJP encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedEucJP(int length, params string[] options)
        {
            return Assert(ReadFixedEucJP(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size EucCN encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <param name="length">The length of the <see cref="string" />.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedEucCN(int length, params string[] options)
        {
            return Assert(ReadFixedEucCN(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size EucKR encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedEucKR(int length, params string[] options)
        {
            return Assert(ReadFixedEucKR(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size UTF8 encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedUTF8(int length, params string[] options)
        {
            return Assert(ReadFixedUTF8(length), options);
        }

        /// <summary>
        /// Assert the next read fixed-size UTF16 encoded <see cref="string" /> is equal to one of the provided values.
        /// </summary>
        /// <param name="length">The length of the <see cref="string" />.</param>
		/// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public string AssertFixedUTF16(int length, params string[] options)
        {
            return Assert(ReadFixedUTF16(length), options);
        }
    }
}
