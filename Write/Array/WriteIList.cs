using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="sbyte" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteSBytes(IList<sbyte> values)
        {
            PerformOnIList(WriteSByte, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="byte" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteBytes(IList<byte> values)
        {
            PerformOnIList(WriteByte, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="short" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteShorts(IList<short> values)
        {
            PerformOnIList(WriteShort, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="ushort" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteUShorts(IList<ushort> values)
        {
            PerformOnIList(WriteUShort, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="int" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteInts(IList<int> values)
        {
            PerformOnIList(WriteInt, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="uint" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteUInts(IList<uint> values)
        {
            PerformOnIList(WriteUInt, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="long" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteLongs(IList<long> values)
        {
            PerformOnIList(WriteLong, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="ulong" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteULongs(IList<ulong> values)
        {
            PerformOnIList(WriteULong, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Half" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteHalfs(IList<Half> values)
        {
            PerformOnIList(WriteHalf, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="float" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteFloats(IList<float> values)
        {
            PerformOnIList(WriteFloat, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="double" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteDoubles(IList<double> values)
        {
            PerformOnIList(WriteDouble, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="decimal" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteDecimals(IList<decimal> values)
        {
            PerformOnIList(WriteDecimal, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="char" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteChars(IList<char> values)
        {
            PerformOnIList(WriteChar, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="bool" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteBools(IList<bool> values)
        {
            PerformOnIList(WriteBool, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteVarints(IList<long> values)
        {
            PerformOnIList(WriteVarint, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="int"/>, each 7-bit encoded.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void Write7BitEncodedInts(IList<int> values)
        {
            PerformOnIList(Write7BitEncodedInt, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="long"/>, each 7-bit encoded.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void Write7BitEncodedLongs(IList<long> values)
        {
            PerformOnIList(Write7BitEncodedLong, values);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Vector2" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector2s(IList<Vector2> values, Vector2Order order = Vector2Order.XY)
        {
            foreach (var value in values)
                WriteVector2(value, order);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Vector3" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector3s(IList<Vector3> values, Vector3Order order = Vector3Order.XYZ)
        {
            foreach (var value in values)
                WriteVector3(value, order);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Vector4" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector4s(IList<Vector4> values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteVector4(value, order);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Quaternion" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteQuaternions(IList<Quaternion> values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteQuaternion(value, order);
        }

        /// <summary>
        /// Write an <see cref="IList{T}"/> of <see cref="Color" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteColors(IList<Color> values, ColorOrder order = ColorOrder.ARGB)
        {
            foreach (var value in values)
                WriteColor(value, order);
        }
    }
}