using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;
using System.Text;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Read the specified number of bytes from the stream into a buffer starting at the specified position.
        /// </summary>
        /// <param name="bytes">The <see cref="Array"/> to read bytes into.</param>
        /// <param name="index">The index in the array to start from.</param>
        /// <param name="count">The amount to read into the <see cref="Array"/>.</param>
        /// <exception cref="EndOfStreamException">The requested number of bytes goes beyond the stream.</exception>
        public void ReadBytes(byte[] bytes, int index, int count)
        {
            if (count > Remaining)
                throw new EndOfStreamException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            Reader.Read(bytes, index, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="sbyte" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="sbyte" />.</returns>
        public sbyte[] ReadSBytes(int count)
        {
            return RepeatIntoArray(ReadSByte, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="byte" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="byte" />.</returns>
        public byte[] ReadBytes(int count)
        {
            if (count > Remaining)
                throw new EndOfStreamException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            return Reader.ReadBytes(count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="short" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="short" />.</returns>
        public short[] ReadShorts(int count)
        {
            return RepeatIntoArray(ReadShort, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="ushort" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ushort" />.</returns>
        public ushort[] ReadUShorts(int count)
        {
            return RepeatIntoArray(ReadUShort, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="int" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="int" />.</returns>
        public int[] ReadInts(int count)
        {
            return RepeatIntoArray(ReadInt, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="uint" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="uint" />.</returns>
        public uint[] ReadUInts(int count)
        {
            return RepeatIntoArray(ReadUInt, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="long" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long" />.</returns>
        public long[] ReadLongs(int count)
        {
            return RepeatIntoArray(ReadLong, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="ulong" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ulong" />.</returns>
        public ulong[] ReadULongs(int count)
        {
            return RepeatIntoArray(ReadULong, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Half" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Half" />.</returns>
        public Half[] ReadHalfs(int count)
        {
            return RepeatIntoArray(ReadHalf, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="float" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="float" />.</returns>
        public float[] ReadFloats(int count)
        {
            return RepeatIntoArray(ReadFloat, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="double" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="double" />.</returns>
        public double[] ReadDoubles(int count)
        {
            return RepeatIntoArray(ReadDouble, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="decimal" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="decimal" />.</returns>
        public decimal[] ReadDecimals(int count)
        {
            return RepeatIntoArray(ReadDecimal, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long" />.</returns>
        public long[] ReadVarints(int count)
        {
            return RepeatIntoArray(ReadVarint, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of unsigned Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ulong" />.</returns>
        public ulong[] ReadUnsignedVarints(int count)
        {
            return RepeatIntoArray(ReadUnsignedVarint, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="int" />, each 7-bit encoded.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="int" />.</returns>
        public int[] Read7BitEncodedInts(int count)
        {
            return RepeatIntoArray(Read7BitEncodedInt, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="long" />, each 7-bit encoded.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long" />.</returns>
        public long[] Read7BitEncodedLongs(int count)
        {
            return RepeatIntoArray(Read7BitEncodedLong, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="bool" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="bool" />.</returns>
        public bool[] ReadBools(int count)
        {
            return RepeatIntoArray(() => ReadBool(), count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="char" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="char" />.</returns>
        public char[] ReadChars(int count)
        {
            return RepeatIntoArray(ReadChar, count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Vector2" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector2"/> should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector2" />.</returns>
        public Vector2[] ReadVector2s(int count, Vector2Order order = Vector2Order.XY)
        {
            return RepeatIntoArray(() => ReadVector2(order), count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Vector3" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector3"/> should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector3" />.</returns>
        public Vector3[] ReadVector3s(int count, Vector3Order order = Vector3Order.XYZ)
        {
            return RepeatIntoArray(() => ReadVector3(order), count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Vector4" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector4"/> should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector4" />.</returns>
        public Vector4[] ReadVector4s(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return RepeatIntoArray(() => ReadVector4(order), count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Quaternion" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Quaternion"/> should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Quaternion" />.</returns>
        public Quaternion[] ReadQuaternions(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return RepeatIntoArray(() => ReadQuaternion(order), count);
        }

        /// <summary>
        /// Read an <see cref="Array"/> of <see cref="Color" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Color"/> should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Color" />.</returns>
        public Color[] ReadColors(int count, ColorOrder order = ColorOrder.ARGB)
        {
            return RepeatIntoArray(() => ReadColor(order), count);
        }

        /// <summary>
        /// Read an <see cref="Array" /> of terminated strings using the specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of each <see cref="string" />.</param>
        /// <returns>An <see cref="Array" /> of <see cref="string" />.</returns>
        public string[] ReadStrings(int count, Encoding encoding)
        {
            return RepeatIntoArray(() => ReadString(encoding), count);
        }

        /// <summary>
        /// Read an <see cref="Array" /> of fixed-size strings.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="length">The length of each <see cref="string" />.</param>
        /// <param name="encoding">The <see cref="Encoding" /> of each <see cref="string" />.</param>
        /// <returns>An <see cref="Array" /> of <see cref="string" />.</returns>
        public string[] ReadFixedStrings(int count, int length, Encoding encoding)
        {
            return RepeatIntoArray(() => ReadFixedString(length, encoding), count);
        }
    }
}