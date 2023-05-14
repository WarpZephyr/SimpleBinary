using System.Drawing;
using System.Numerics;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Write a sbyte.
        /// </summary>
        /// <param name="value">The sbyte to write.</param>
        public void WriteSByte(sbyte value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a byte.
        /// </summary>
        /// <param name="value">The byte to write.</param>
        public void WriteByte(byte value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a short.
        /// </summary>
        /// <param name="value">The short to write.</param>
        public void WriteShort(short value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a ushort.
        /// </summary>
        /// <param name="value">The ushort to write.</param>
        public void WriteUShort(ushort value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a int.
        /// </summary>
        /// <param name="value">The int to write.</param>
        public void WriteInt(int value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a uint.
        /// </summary>
        /// <param name="value">The uint to write.</param>
        public void WriteUInt(uint value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a long.
        /// </summary>
        /// <param name="value">The long to write.</param>
        public void WriteLong(long value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write an unsigned long.
        /// </summary>
        /// <param name="value">The ulong to write.</param>
        public void WriteULong(ulong value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a half.
        /// </summary>
        /// <param name="value">The half to write.</param>
        public void WriteHalf(Half value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a float.
        /// </summary>
        /// <param name="value">The float to write.</param>
        public void WriteFloat(float value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a double.
        /// </summary>
        /// <param name="value">The double to write.</param>
        public void WriteDouble(double value)
        {
            WriteBytes(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write a decimal.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        public void WriteDecimal(decimal value)
        {
            WriteInts(decimal.GetBits(value));
        }

        /// <summary>
        /// Write a varint depending on the set size.
        /// </summary>
        /// <param name="value">The value to write as a varint.</param>
        public void WriteVarint(long value)
        {
            switch (VarintSize)
            {
                case VarintLength.Int:
                    WriteInt((int)value);
                    break;
                case VarintLength.Long:
                    WriteLong(value);
                    break;
                default:
                    throw new NotSupportedException($"The VarintLength: {VarintSize}; Is not supported.");
            }
        }

        /// <summary>
        /// Write a 7-bit encoded int.
        /// </summary>
        /// <param name="value">An int to write as a 7-bit encoded int.</param>
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
        /// Write a 7-bit encoded long.
        /// </summary>
        /// <param name="value">A long to write as a 7-bit encoded long.</param>
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
        /// Write a true or false boolean.
        /// </summary>
        /// <param name="value">The bool to write.</param>
        public void WriteBool(bool value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a char.
        /// </summary>
        /// <param name="value">The char to write.</param>
        public void WriteChar(char value)
        {
            Writer.Write(value);
        }

        /// <summary>
        /// Write a color.
        /// </summary>
        /// <param name="color">The color to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
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
                    throw new NotImplementedException($"The color order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a vector2.
        /// </summary>
        /// <param name="vector">The vector2 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
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
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a vector3.
        /// </summary>
		/// <param name="vector">The vector3 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>A vector3.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
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
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a vector4.
        /// </summary>
		/// <param name="vector">The vector4 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
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
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a quaternion.
        /// </summary>
		/// <param name="quaternion">The quaternion to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
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
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Write a sbyte.
        /// </summary>
        /// <param name="value">The sbyte to write.</param>
        public void Write(sbyte value)
        {
            WriteSByte(value);
        }

        /// <summary>
        /// Write a byte.
        /// </summary>
        /// <param name="value">The byte to write.</param>
        public void Write(byte value)
        {
            WriteByte(value);
        }

        /// <summary>
        /// Write a short.
        /// </summary>
        /// <param name="value">The short to write.</param>
        public void Write(short value)
        {
            WriteShort(value);
        }

        /// <summary>
        /// Write a ushort.
        /// </summary>
        /// <param name="value">The ushort to write.</param>
        public void Write(ushort value)
        {
            WriteUShort(value);
        }

        /// <summary>
        /// Write a int.
        /// </summary>
        /// <param name="value">The int to write.</param>
        public void Write(int value)
        {
            WriteInt(value);
        }

        /// <summary>
        /// Write a uint.
        /// </summary>
        /// <param name="value">The uint to write.</param>
        public void Write(uint value)
        {
            WriteUInt(value);
        }

        /// <summary>
        /// Write a long.
        /// </summary>
        /// <param name="value">The long to write.</param>
        public void Write(long value)
        {
            WriteLong(value);
        }

        /// <summary>
        /// Write a ulong.
        /// </summary>
        /// <param name="value">The long to write.</param>
        public void Write(ulong value)
        {
            WriteULong(value);
        }

        /// <summary>
        /// Write a half.
        /// </summary>
        /// <param name="value">The half to write.</param>
        public void Write(Half value)
        {
            WriteHalf(value);
        }

        /// <summary>
        /// Write a float.
        /// </summary>
        /// <param name="value">The float to write.</param>
        public void Write(float value)
        {
            WriteFloat(value);
        }

        /// <summary>
        /// Write a double.
        /// </summary>
        /// <param name="value">The double to write.</param>
        public void Write(double value)
        {
            WriteDouble(value);
        }

        /// <summary>
        /// Write a decimal.
        /// </summary>
        /// <param name="value">The decimal to write.</param>
        public void Write(decimal value)
        {
            WriteDecimal(value);
        }

        /// <summary>
        /// Write a true or false boolean.
        /// </summary>
        /// <param name="value">The bool to write.</param>
        public void Write(bool value)
        {
            WriteBool(value);
        }

        /// <summary>
        /// Write a char.
        /// </summary>
        /// <param name="value">The char to write.</param>
        public void Write(char value)
        {
            WriteChar(value);
        }

        /// <summary>
        /// Write a color.
        /// </summary>
        /// <param name="color">The color to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void Write(Color color, ColorOrder order = ColorOrder.ARGB)
        {
            WriteColor(color, order);
        }

        /// <summary>
        /// Write a vector2.
        /// </summary>
        /// <param name="vector">The vector2 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void Write(Vector2 vector, Vector2Order order = Vector2Order.YX)
        {
            WriteVector2(vector, order);
        }

        /// <summary>
        /// Write a vector3.
        /// </summary>
		/// <param name="vector">The vector3 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>A vector3.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void Write(Vector3 vector, Vector3Order order = Vector3Order.XYZ)
        {
            WriteVector3(vector, order);
        }

        /// <summary>
        /// Write a vector4.
        /// </summary>
		/// <param name="vector">The vector4 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void Write(Vector4 vector, Vector4Order order = Vector4Order.XYZW)
        {
            WriteVector4(vector, order);
        }

        /// <summary>
        /// Write a quaternion.
        /// </summary>
		/// <param name="quaternion">The quaternion to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void Write(Quaternion quaternion, Vector4Order order = Vector4Order.XYZW)
        {
            WriteQuaternion(quaternion, order);
        }

        /// <summary>
        /// Write a vector2.
        /// </summary>
        /// <param name="vector">The vector2 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void WriteVector(Vector2 vector, Vector2Order order = Vector2Order.YX)
        {
            WriteVector2(vector, order);
        }

        /// <summary>
        /// Write a vector3.
        /// </summary>
		/// <param name="vector">The vector3 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>A vector3.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void WriteVector(Vector3 vector, Vector3Order order = Vector3Order.XYZ)
        {
            WriteVector3(vector, order);
        }

        /// <summary>
        /// Write a vector4.
        /// </summary>
		/// <param name="vector">The vector4 to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void WriteVector(Vector4 vector, Vector4Order order = Vector4Order.XYZW)
        {
            WriteVector4(vector, order);
        }

        /// <summary>
        /// Write a quaternion.
        /// </summary>
		/// <param name="quaternion">The quaternion to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public void WriteVector(Quaternion quaternion, Vector4Order order = Vector4Order.XYZW)
        {
            WriteQuaternion(quaternion, order);
        }
    }
}