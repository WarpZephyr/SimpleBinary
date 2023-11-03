using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Write an <see cref="sbyte" />.
        /// </summary>
        /// <param name="value">The <see cref="sbyte" /> to write.</param>
        public void WriteSByte(sbyte value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a <see cref="byte" />.
        /// </summary>
        /// <param name="value">The <see cref="byte" /> to write.</param>
        public void WriteByte(byte value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a <see cref="short" />.
        /// </summary>
        /// <param name="value">The <see cref="short" /> to write.</param>
        public void WriteShort(short value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="ushort" />.
        /// </summary>
        /// <param name="value">The <see cref="ushort" /> to write.</param>
        public void WriteUShort(ushort value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write an <see cref="int" />.
        /// </summary>
        /// <param name="value">The <see cref="int" /> to write.</param>
        public void WriteInt(int value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="uint" />.
        /// </summary>
        /// <param name="value">The <see cref="uint" /> to write.</param>
        public void WriteUInt(uint value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="long" />.
        /// </summary>
        /// <param name="value">The <see cref="long" /> to write.</param>
        public void WriteLong(long value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="ulong" />.
        /// </summary>
        /// <param name="value">The <see cref="ulong" /> to write.</param>
        public void WriteULong(ulong value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="Half" />.
        /// </summary>
        /// <param name="value">The <see cref="Half" /> to write.</param>
        public void WriteHalf(Half value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="float" />.
        /// </summary>
        /// <param name="value">The <see cref="float" /> to write.</param>
        public void WriteFloat(float value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="double" />.
        /// </summary>
        /// <param name="value">The <see cref="double" /> to write.</param>
        public void WriteDouble(double value)
        {
            WriteEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a <see cref="decimal" />.
        /// </summary>
        /// <param name="value">The <see cref="decimal" /> to write.</param>
        public void WriteDecimal(decimal value)
        {
            WriteInts(decimal.GetBits(value));
        }

        /// <summary>
        /// Write a <see cref="char" />.
        /// </summary>
        /// <param name="value">The <see cref="char" /> to write.</param>
        public void WriteChar(char value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a <see cref="bool" />.
        /// </summary>
        /// <param name="value">The <see cref="bool" /> to write.</param>
        public void WriteBool(bool value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a Varint depending on the set VarintType.
        /// </summary>
        /// <param name="value">The value to write as a Varint.</param>
        public void WriteVarint(long value)
        {
            switch (VarintType)
            {
                case VarintLengthType.Byte:
                    WriteSByte((sbyte)value);
                    break;
                case VarintLengthType.Short:
                    WriteShort((short)value);
                    break;
                case VarintLengthType.Int:
                    WriteInt((int)value);
                    break;
                case VarintLengthType.Long:
                    WriteLong(value);
                    break;
                default:
                    throw new NotSupportedException($"The {nameof(VarintLengthType)}: {VarintType}; Is not supported.");
            }
        }

        /// <summary>
        /// Write an unsigned Varint depending on the set VarintType.
        /// </summary>
        /// <param name="value">The value to write as a Varint.</param>
        public void WriteUnsignedVarint(ulong value)
        {
            switch (VarintType)
            {
                case VarintLengthType.Byte:
                    WriteByte((byte)value);
                    break;
                case VarintLengthType.Short:
                    WriteUShort((ushort)value);
                    break;
                case VarintLengthType.Int:
                    WriteUInt((uint)value);
                    break;
                case VarintLengthType.Long:
                    WriteULong(value);
                    break;
                default:
                    throw new NotSupportedException($"The {nameof(VarintLengthType)}: {VarintType}; Is not supported.");
            }
        }

        /// <summary>
        /// Write a 7-bit encoded <see cref="int" />.
        /// </summary>
        /// <param name="value">An <see cref="int" /> to write as a 7-bit encoded <see cref="int" />.</param>
        public void Write7BitEncodedInt(int value)
        {
            var store = value;
            if (BigEndian)
            {
                var bytes = BitConverter.GetBytes(store);
                Array.Reverse(bytes);
                store = BitConverter.ToInt32(bytes, 0);
            }
            Writer.Write7BitEncodedInt(store);
        }

        /// <summary>
        /// Write a 7-bit encoded <see cref="long" />.
        /// </summary>
        /// <param name="value">A <see cref="long" /> to write as a 7-bit encoded <see cref="long" />.</param>
        public void Write7BitEncodedLong(long value)
        {
            var store = value;
            if (BigEndian)
            {
                var bytes = BitConverter.GetBytes(store);
                Array.Reverse(bytes);
                store = BitConverter.ToInt64(bytes, 0);
            }
            Writer.Write7BitEncodedInt64(store);
        }

        /// <summary>
        /// Write a <see cref="Vector2" />.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2" /> to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector2Order" /> was not supported.</exception>
        public void WriteVector2(Vector2 vector, Vector2Order order = Vector2Order.YX)
        {
            float x = vector.X;
            float y = vector.Y;
            switch (order)
            {
                case Vector2Order.XY:
                    WriteFloat(x);
                    WriteFloat(y);
                    break;
                case Vector2Order.YX:
                    WriteFloat(y);
                    WriteFloat(x);
                    break;
                default:
                    throw new NotImplementedException($"The {nameof(Vector2Order)}: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a <see cref="Vector3" />.
        /// </summary>
		/// <param name="vector">The <see cref="Vector3" /> to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector3Order" /> was not supported.</exception>
        public void WriteVector3(Vector3 vector, Vector3Order order = Vector3Order.XYZ)
        {
            float x = vector.X;
            float y = vector.Y;
            float z = vector.Z;
            switch (order)
            {
                case Vector3Order.XYZ:
                    WriteFloat(x);
                    WriteFloat(y);
                    WriteFloat(z);
                    break;
                case Vector3Order.XZY:
                    WriteFloat(x);
                    WriteFloat(z);
                    WriteFloat(y);
                    break;
                case Vector3Order.ZYX:
                    WriteFloat(z);
                    WriteFloat(y);
                    WriteFloat(x);
                    break;
                case Vector3Order.YZX:
                    WriteFloat(y);
                    WriteFloat(z);
                    WriteFloat(x);
                    break;
                default:
                    throw new NotImplementedException($"The {nameof(Vector3Order)}: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a <see cref="Vector4" />.
        /// </summary>
		/// <param name="vector">The <see cref="Vector4" /> to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector4Order" /> was not supported.</exception>
        public void WriteVector4(Vector4 vector, Vector4Order order = Vector4Order.XYZW)
        {
            float x = vector.X;
            float y = vector.Y;
            float z = vector.Z;
            float w = vector.W;
            switch (order)
            {
                case Vector4Order.XYZW:
                    WriteFloat(x);
                    WriteFloat(y);
                    WriteFloat(z);
                    WriteFloat(w);
                    break;
                case Vector4Order.XZYW:
                    WriteFloat(x);
                    WriteFloat(z);
                    WriteFloat(y);
                    WriteFloat(w);
                    break;
                case Vector4Order.WZYX:
                    WriteFloat(w);
                    WriteFloat(z);
                    WriteFloat(y);
                    WriteFloat(x);
                    break;
                case Vector4Order.WYZX:
                    WriteFloat(w);
                    WriteFloat(y);
                    WriteFloat(z);
                    WriteFloat(x);
                    break;
                default:
                    throw new NotImplementedException($"The {nameof(Vector4Order)}: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a <see cref="Quaternion" />.
        /// </summary>
		/// <param name="quaternion">The <see cref="Quaternion" /> to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector4Order"> was not supported.</exception>
        public void WriteQuaternion(Quaternion quaternion, Vector4Order order = Vector4Order.XYZW)
        {
            float x = quaternion.X;
            float y = quaternion.Y;
            float z = quaternion.Z;
            float w = quaternion.W;
            switch (order)
            {
                case Vector4Order.XYZW:
                    WriteFloat(x);
                    WriteFloat(y);
                    WriteFloat(z);
                    WriteFloat(w);
                    break;
                case Vector4Order.XZYW:
                    WriteFloat(x);
                    WriteFloat(z);
                    WriteFloat(y);
                    WriteFloat(w);
                    break;
                case Vector4Order.WZYX:
                    WriteFloat(w);
                    WriteFloat(z);
                    WriteFloat(y);
                    WriteFloat(x);
                    break;
                case Vector4Order.WYZX:
                    WriteFloat(w);
                    WriteFloat(y);
                    WriteFloat(z);
                    WriteFloat(x);
                    break;
                default:
                    throw new NotImplementedException($"The {nameof(Vector4Order)}: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a <see cref="Color" />.
        /// </summary>
        /// <param name="color">The <see cref="Color" /> to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided <see cref="ColorOrder" /> was not supported.</exception>
        public void WriteColor(Color color, ColorOrder order = ColorOrder.ARGB)
        {
            byte red = color.R;
            byte green = color.G;
            byte blue = color.B;
            byte alpha = color.A;
            switch (order)
            {
                case ColorOrder.RGB:
                    WriteByte(red);
                    WriteByte(green);
                    WriteByte(blue);
                    break;
                case ColorOrder.BGR:
                    WriteByte(blue);
                    WriteByte(green);
                    WriteByte(red);
                    break;
                case ColorOrder.RGBA:
                    WriteByte(red);
                    WriteByte(green);
                    WriteByte(blue);
                    WriteByte(alpha);
                    break;
                case ColorOrder.BGRA:
                    WriteByte(blue);
                    WriteByte(green);
                    WriteByte(red);
                    WriteByte(alpha);
                    break;
                case ColorOrder.ARGB:
                    WriteByte(alpha);
                    WriteByte(red);
                    WriteByte(green);
                    WriteByte(blue);
                    break;
                case ColorOrder.ABGR:
                    WriteByte(alpha);
                    WriteByte(blue);
                    WriteByte(green);
                    WriteByte(red);
                    break;
                default:
                    throw new NotImplementedException($"The {nameof(ColorOrder)}: {order}; Is not supported or does not exist.");
            }
        }
    }
}