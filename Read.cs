using System.Drawing;
using System.Numerics;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
    {
        /// <summary>
        /// Read dynamically using the chosen function.
        /// </summary>
        /// <typeparam name="T">The type of data the chosen function returns.</typeparam>
        /// <param name="read">The function itself.</param>
        /// <returns>An item of the type returned by the function.</returns>
        public static T Read<T>(Func<T> read)
        {
            T value = read();
            return value;
        }

        /// <summary>
        /// Read a signed byte.
        /// </summary>
        /// <returns>A signed byte.</returns>
        public sbyte ReadSByte()
        {
            return Reader.ReadSByte();
        }

        /// <summary>
        /// Read an unsigned byte.
        /// </summary>
        /// <returns>An unsigned byte.</returns>
        public byte ReadByte()
        {
            return Reader.ReadByte();
        }

        /// <summary>
        /// Read a short.
        /// </summary>
        /// <returns>A short.</returns>
        public short ReadShort()
        {
            return BitConverter.ToInt16(Reads(() => Reader.ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read an unsigned short.
        /// </summary>
        /// <returns>An unsigned short.</returns>
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(Reads(() => Reader.ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read a integer.
        /// </summary>
        /// <returns>A integer.</returns>
        public int ReadInt()
        {
            return BitConverter.ToInt32(Reads(() => Reader.ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read an unsigned integer.
        /// </summary>
        /// <returns>An unsigned integer.</returns>
        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(Reads(() => Reader.ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read a long.
        /// </summary>
        /// <returns>A long.</returns>
        public long ReadLong()
        {
            return BitConverter.ToInt64(Reads(() => Reader.ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read an unsigned long.
        /// </summary>
        /// <returns>An unsigned long.</returns>
        public ulong ReadULong()
        {
            return BitConverter.ToUInt64(Reads(() => Reader.ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read a half.
        /// </summary>
        /// <returns>A half.</returns>
        public Half ReadHalf()
        {
            return BitConverter.ToHalf(Reads(() => Reader.ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read a float.
        /// </summary>
        /// <returns>A float.</returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(Reads(() => Reader.ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read a double.
        /// </summary>
        /// <returns>A double.</returns>
        public double ReadDouble()
        {
            return BitConverter.ToDouble(Reads(() => Reader.ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read a decimal.
        /// </summary>
        /// <returns>A decimal.</returns>
        public decimal ReadDecimal()
        {
            return ConverterUtility.ByteArrayToDecimal(Reads(() => Reader.ReadBytes(16), BigEndian), 0);
        }

        /// <summary>
        /// Read a varint.
        /// </summary>
        /// <returns>An integer.</returns>
        public int ReadVarint()
        {
            var value = Reader.Read7BitEncodedInt();

            if (BigEndian)
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                return BitConverter.ToInt32(bytes, 0);
            }

            return value;
        }

        /// <summary>
        /// Read a varint long.
        /// </summary>
        /// <returns>A long.</returns>
        public long ReadVarintLong()
        {
            var value = Reader.Read7BitEncodedInt64();

            if (BigEndian)
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                return BitConverter.ToInt64(bytes, 0);
            }

            return value;
        }

        /// <summary>
        /// Read a true or false boolean.
        /// </summary>
        /// <returns>A boolean.</returns>
        public bool ReadBool()
        {
            var value = ReadByte();
            if (value > 1)
                throw new InvalidDataException($"Read invalid boolean value: {value}.");
            return value != 0;
        }

        /// <summary>
        /// Read a char.
        /// </summary>
        /// <returns>A char.</returns>
        public char ReadChar()
        {
            return Reader.ReadChar();
        }

        /// <summary>
        /// Read a vector2.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector2.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public Vector2 ReadVector2(Vector2Order order = Vector2Order.YX)
        {
            float x;
            float y;
            switch (order)
            {
                case Vector2Order.XY:
                    x = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    return new Vector2(x, y);
                case Vector2Order.YX:
                    y = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Vector2(x, y);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a vector3.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector3.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public Vector3 ReadVector3(Vector3Order order = Vector3Order.XYZ)
        {
            float x;
            float y;
            float z;
            switch (order)
            {
                case Vector3Order.XYZ:
                    x = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    return new Vector3(x, y, z);
                case Vector3Order.XZY:
                    x = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    return new Vector3(x, y, z);
                case Vector3Order.ZYX:
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Vector3(x, y, z);
                case Vector3Order.YZX:
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Vector3(x, y, z);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a vector4.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector4.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public Vector4 ReadVector4(Vector4Order order = Vector4Order.XYZW)
        {
            float x;
            float y;
            float z;
            float w;
            switch (order)
            {
                case Vector4Order.XYZW:
                    x = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    w = Reader.ReadSingle();
                    return new Vector4(x, y, z, w);
                case Vector4Order.XZYW:
                    x = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    w = Reader.ReadSingle();
                    return new Vector4(x, y, z, w);
                case Vector4Order.WZYX:
                    w = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Vector4(x, y, z, w);
                case Vector4Order.WYZX:
                    w = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Vector4(x, y, z, w);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a quaternion.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A quaternion.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public Quaternion ReadQuaternion(Vector4Order order = Vector4Order.XYZW)
        {
            float x;
            float y;
            float z;
            float w;
            switch (order)
            {
                case Vector4Order.XYZW:
                    x = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    w = Reader.ReadSingle();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.XZYW:
                    x = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    w = Reader.ReadSingle();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.WZYX:
                    w = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.WYZX:
                    w = Reader.ReadSingle();
                    y = Reader.ReadSingle();
                    z = Reader.ReadSingle();
                    x = Reader.ReadSingle();
                    return new Quaternion(x, y, z, w);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a color.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A color.</returns>
        /// <exception cref="NotImplementedException">The provided order was not supported.</exception>
        public Color ReadColor(ColorOrder order = ColorOrder.ARGB)
        {
            byte red;
            byte green;
            byte blue;
            byte alpha;
            switch (order)
            {
                case ColorOrder.RGB:
                    red = Reader.ReadByte();
                    green = Reader.ReadByte();
                    blue = Reader.ReadByte();
                    return Color.FromArgb(red, green, blue);
                case ColorOrder.BGR:
                    blue = Reader.ReadByte();
                    green = Reader.ReadByte();
                    red = Reader.ReadByte();
                    return Color.FromArgb(red, green, blue);
                case ColorOrder.RGBA:
                    red = Reader.ReadByte();
                    green = Reader.ReadByte();
                    blue = Reader.ReadByte();
                    alpha = Reader.ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.BGRA:
                    blue = Reader.ReadByte();
                    green = Reader.ReadByte();
                    red = Reader.ReadByte();
                    alpha = Reader.ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.ARGB:
                    alpha = Reader.ReadByte();
                    red = Reader.ReadByte();
                    green = Reader.ReadByte();
                    blue = Reader.ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.ABGR:
                    alpha = Reader.ReadByte();
                    blue = Reader.ReadByte();
                    green = Reader.ReadByte();
                    red = Reader.ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                default:
                    throw new NotImplementedException($"The color order: {order}; Is not supported or does not exist.");
            }
        }
    }
}