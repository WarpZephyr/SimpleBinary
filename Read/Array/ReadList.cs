using System.Drawing;
using System.Numerics;
using System.Text;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="sbyte" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="sbyte" />.</returns>
        public List<sbyte> ReadSByteList(int count)
        {
            return RepeatIntoList(ReadSByte, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="byte" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="byte" />.</returns>
        public List<byte> ReadByteList(int count)
        {
            return RepeatIntoList(ReadByte, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="short" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="short" />.</returns>
        public List<short> ReadShortList(int count)
        {
            return RepeatIntoList(ReadShort, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="ushort" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="ushort" />.</returns>
        public List<ushort> ReadUShortList(int count)
        {
            return RepeatIntoList(ReadUShort, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="int" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="int" />.</returns>
        public List<int> ReadIntList(int count)
        {
            return RepeatIntoList(ReadInt, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="uint" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="uint" />.</returns>
        public List<uint> ReadUIntList(int count)
        {
            return RepeatIntoList(ReadUInt, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="long" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="long" />.</returns>
        public List<long> ReadLongList(int count)
        {
            return RepeatIntoList(ReadLong, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="ulong" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="ulong" />.</returns>
        public List<ulong> ReadULongList(int count)
        {
            return RepeatIntoList(ReadULong, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Half" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Half" />.</returns>
        public List<Half> ReadHalfList(int count)
        {
            return RepeatIntoList(ReadHalf, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="float" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="float" />.</returns>
        public List<float> ReadFloatList(int count)
        {
            return RepeatIntoList(ReadFloat, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="double" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="double" />.</returns>
        public List<double> ReadDoubleList(int count)
        {
            return RepeatIntoList(ReadDouble, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="decimal" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="decimal" />.</returns>
        public List<decimal> ReadDecimalList(int count)
        {
            return RepeatIntoList(ReadDecimal, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="bool" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="bool" />.</returns>
        public List<bool> ReadBoolList(int count)
        {
            return RepeatIntoList(() => ReadBool(), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="char" />.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="char" />.</returns>
        public List<char> ReadCharList(int count)
        {
            return RepeatIntoList(ReadChar, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="long" />.</returns>
        public List<long> ReadVarintList(int count)
        {
            return RepeatIntoList(ReadVarint, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of unsigned Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="long" />.</returns>
        public List<ulong> ReadUnsignedVarintList(int count)
        {
            return RepeatIntoList(ReadUnsignedVarint, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="int" />, each 7-bit encoded.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="int" />.</returns>
        public List<int> Read7BitEncodedIntList(int count)
        {
            return RepeatIntoList(Read7BitEncodedInt, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="long" />, each 7-bit encoded.
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="long" />.</returns>
        public List<long> Read7BitEncodedLongList(int count)
        {
            return RepeatIntoList(Read7BitEncodedLong, count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Vector2" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector2"/> should be read in.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Vector2" />.</returns>
        public List<Vector2> ReadVector2List(int count, Vector2Order order = Vector2Order.XY)
        {
            return RepeatIntoList(() => ReadVector2(order), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Vector3" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector3"/> should be read in.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Vector3" />.</returns>
        public List<Vector3> ReadVector3List(int count, Vector3Order order = Vector3Order.XYZ)
        {
            return RepeatIntoList(() => ReadVector3(order), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Vector4" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Vector4"/> should be read in.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Vector4" />.</returns>
        public List<Vector4> ReadVector4List(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return RepeatIntoList(() => ReadVector4(order), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Quaternion" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Quaternion"/> should be read in.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Quaternion" />.</returns>
        public List<Quaternion> ReadQuaternionList(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return RepeatIntoList(() => ReadQuaternion(order), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}"/> of <see cref="Color" />
        /// </summary>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order each <see cref="Color"/> should be read in.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Color" />.</returns>
        public List<Color> ReadColorList(int count, ColorOrder order = ColorOrder.ARGB)
        {
            return RepeatIntoList(() => ReadColor(order), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}" /> of terminated strings using the specified <see cref="Encoding" />.
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of each <see cref="string" />.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>A <see cref="List{T}" /> of <see cref="string" />.</returns>
        public List<string> ReadStringList(Encoding encoding, int count)
        {
            return RepeatIntoList(() => ReadString(encoding), count);
        }

        /// <summary>
        /// Read a <see cref="List{T}" /> of fixed-size strings.
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of each <see cref="string" />.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="length">The length of each <see cref="string" />.</param>
        /// <returns>A <see cref="List{T}" /> of <see cref="string" />.</returns>
        public List<string> ReadFixedStringList(Encoding encoding, int count, int length)
        {
            return RepeatIntoList(() => ReadFixedString(encoding, length), count);
        }
    }
}
