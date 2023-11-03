using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write an <see cref="Array"/> of bytes, reversing them if in BigEndian.
        /// </summary>
        /// <param name="bytes">The <see cref="Array"/> of bytes to write.</param>
        private void WriteEndian(byte[] bytes)
        {
            byte[] store = bytes;
            if (BigEndian)
                Array.Reverse(store);
            Writer.Write(store);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="sbyte" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteSByteArray(sbyte[] values)
        {
            PerformOnArray(WriteSByte, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="byte" />.
        /// </summary>
        /// <param name="bytes">The values to write.</param>
        public void WriteByteArray(byte[] bytes)
        {
            Writer.Write(bytes);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="short" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteShortArray(short[] values)
        {
            PerformOnArray(WriteShort, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="ushort" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteUShortArray(ushort[] values)
        {
            PerformOnArray(WriteUShort, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="int" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteIntArray(int[] values)
        {
            PerformOnArray(WriteInt, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="uint" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteUIntArray(uint[] values)
        {
            PerformOnArray(WriteUInt, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="long" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteLongArray(long[] values)
        {
            PerformOnArray(WriteLong, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="ulong" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteULongArray(ulong[] values)
        {
            PerformOnArray(WriteULong, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Half" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteHalfArray(Half[] values)
        {
            PerformOnArray(WriteHalf, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="float" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteFloatArray(float[] values)
        {
            PerformOnArray(WriteFloat, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="double" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteDoubleArray(double[] values)
        {
            PerformOnArray(WriteDouble, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="decimal" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteDecimalArray(decimal[] values)
        {
            PerformOnArray(WriteDecimal, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of Varints depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteVarintArray(long[] values)
        {
            PerformOnArray(WriteVarint, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="int"/>, each 7-bit encoded.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void Write7BitEncodedIntArray(int[] values)
        {
            PerformOnArray(Write7BitEncodedInt, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="long"/>, each 7-bit encoded.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void Write7BitEncodedLongArray(long[] values)
        {
            PerformOnArray(Write7BitEncodedLong, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="char" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteCharArray(char[] values)
        {
            PerformOnArray(WriteChar, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="bool" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        public void WriteBoolArray(bool[] values)
        {
            PerformOnArray(WriteBool, values);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Vector2" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector2Array(Vector2[] values, Vector2Order order = Vector2Order.XY)
        {
            foreach (var value in values)
                WriteVector2(value, order);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Vector3" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector3Array(Vector3[] values, Vector3Order order = Vector3Order.XYZ)
        {
            foreach (var value in values)
                WriteVector3(value, order);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Vector4" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector4Array(Vector4[] values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteVector4(value, order);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Quaternion" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteQuaternionArray(Quaternion[] values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteQuaternion(value, order);
        }

        /// <summary>
        /// Write an <see cref="Array"/> of <see cref="Color" />.
        /// </summary>
        /// <param name="values">The values to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteColorArray(Color[] values, ColorOrder order = ColorOrder.ARGB)
        {
            foreach (var value in values)
                WriteColor(value, order);
        }
    }
}