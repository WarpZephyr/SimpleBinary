using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Read the provided struct type. 
        /// </summary>
        /// <typeparam name="TStruct">The type of the struct.</typeparam>
        /// <returns>The read struct.</returns>
        public TStruct? ReadStruct<TStruct>() where TStruct : struct
        {
            byte[] bytes = Reader.ReadBytes(Marshal.SizeOf(typeof(TStruct)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            object? obj = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TStruct));
            if (obj == null)
                return null;

            TStruct structure = (TStruct)obj;
            handle.Free();

            return structure;
        }

        /// <summary>
        /// Read an <see cref="sbyte" />.
        /// </summary>
        /// <returns>An <see cref="sbyte" />.</returns>
        public sbyte ReadSByte()
        {
            return Reader.ReadSByte();
        }

        /// <summary>
        /// Read a <see cref="byte" />.
        /// </summary>
        /// <returns>A <see cref="byte" />.</returns>
        public byte ReadByte()
        {
            return Reader.ReadByte();
        }

        /// <summary>
        /// Read a <see cref="short" />.
        /// </summary>
        /// <returns>A <see cref="short" />.</returns>
        public short ReadShort()
        {
            return BitConverter.ToInt16(PerformThenReverse(() => ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="ushort" />.
        /// </summary>
        /// <returns>A <see cref="ushort" />.</returns>
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(PerformThenReverse(() => ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read an <see cref="int" />.
        /// </summary>
        /// <returns>An <see cref="int" />.</returns>
        public int ReadInt()
        {
            return BitConverter.ToInt32(PerformThenReverse(() => ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="uint" />.
        /// </summary>
        /// <returns>A <see cref="uint" />.</returns>
        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(PerformThenReverse(() => ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="long" />.
        /// </summary>
        /// <returns>A <see cref="long" />.</returns>
        public long ReadLong()
        {
            return BitConverter.ToInt64(PerformThenReverse(() => ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="ulong" />.
        /// </summary>
        /// <returns>A <see cref="ulong" />.</returns>
        public ulong ReadULong()
        {
            return BitConverter.ToUInt64(PerformThenReverse(() => ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="Half" />.
        /// </summary>
        /// <returns>A <see cref="Half" />.</returns>
        public Half ReadHalf()
        {
            return BitConverter.ToHalf(PerformThenReverse(() => ReadBytes(2), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="float" />.
        /// </summary>
        /// <returns>A <see cref="float" />.</returns>
        public float ReadFloat()
        {
            return BitConverter.ToSingle(PerformThenReverse(() => ReadBytes(4), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="double" />.
        /// </summary>
        /// <returns>A <see cref="double" />.</returns>
        public double ReadDouble()
        {
            return BitConverter.ToDouble(PerformThenReverse(() => ReadBytes(8), BigEndian), 0);
        }

        /// <summary>
        /// Read a <see cref="decimal" />.
        /// </summary>
        /// <returns>A <see cref="decimal" />.</returns>
        public decimal ReadDecimal()
        {
            return PerformThenReverse(() => ReadBytes(16), BigEndian).ToDecimal(0);
        }

        /// <summary>
        /// Read a <see cref="char" />.
        /// </summary>
        /// <returns>A <see cref="char" />.</returns>
        public char ReadChar()
        {
            return Reader.ReadChar();
        }

        /// <summary>
        /// Read a <see cref="bool" />.
        /// </summary>
        /// <returns>A <see cref="bool" />.</returns>
        public bool ReadBool()
        {
            var value = ReadByte();
            if (value > 1 && ValidateBools)
                throw new InvalidDataException($"Read invalid boolean value: {value}.");
            return value != 0;
        }

        /// <summary>
        /// Read a Varint depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <returns>A <see cref="long" />.</returns>
        public long ReadVarint()
        {
            return VarintType switch
            {
                VarintLengthType.Byte => ReadSByte(),
                VarintLengthType.Short => ReadShort(),
                VarintLengthType.Int => ReadInt(),
                VarintLengthType.Long => ReadLong(),
                _ => throw new NotSupportedException($"The {nameof(VarintLengthType)}: {VarintType}; Is not supported."),
            };
        }

        /// <summary>
        /// Read an unsigned Varint depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <returns>A <see cref="ulong" />.</returns>
        public ulong ReadUnsignedVarint()
        {
            return VarintType switch
            {
                VarintLengthType.Byte => ReadByte(),
                VarintLengthType.Short => ReadUShort(),
                VarintLengthType.Int => ReadUInt(),
                VarintLengthType.Long => ReadULong(),
                _ => throw new NotSupportedException($"The {nameof(VarintLengthType)}: {VarintType}; Is not supported."),
            };
        }

        /// <summary>
        /// Read a 7-bit encoded <see cref="int" />.
        /// </summary>
        /// <returns>An <see cref="int" />.</returns>
        public int Read7BitEncodedInt()
        {
            int value = Reader.Read7BitEncodedInt();
            if (BigEndian)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                return BitConverter.ToInt32(bytes);
            }
            return value;
        }

        /// <summary>
        /// Read a 7-bit encoded <see cref="long" />.
        /// </summary>
        /// <returns>A <see cref="long" />.</returns>
        public long Read7BitEncodedLong()
        {
            long value = Reader.Read7BitEncodedInt64();
            if (BigEndian)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                return BitConverter.ToInt64(bytes);
            }
            return value;
        }

        /// <summary>
        /// Read a <see cref="Vector2" />.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector2" />.</returns>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector2Order" /> was not supported.</exception>
        public Vector2 ReadVector2(Vector2Order order = Vector2Order.XY)
        {
            float x;
            float y;
            switch (order)
            {
                case Vector2Order.XY:
                    x = ReadFloat();
                    y = ReadFloat();
                    return new Vector2(x, y);
                case Vector2Order.YX:
                    y = ReadFloat();
                    x = ReadFloat();
                    return new Vector2(x, y);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a <see cref="Vector3" />.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector3" />.</returns>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector3Order" /> was not supported.</exception>
        public Vector3 ReadVector3(Vector3Order order = Vector3Order.XYZ)
        {
            float x;
            float y;
            float z;
            switch (order)
            {
                case Vector3Order.XYZ:
                    x = ReadFloat();
                    y = ReadFloat();
                    z = ReadFloat();
                    return new Vector3(x, y, z);
                case Vector3Order.XZY:
                    x = ReadFloat();
                    z = ReadFloat();
                    y = ReadFloat();
                    return new Vector3(x, y, z);
                case Vector3Order.ZYX:
                    z = ReadFloat();
                    y = ReadFloat();
                    x = ReadFloat();
                    return new Vector3(x, y, z);
                case Vector3Order.YZX:
                    y = ReadFloat();
                    z = ReadFloat();
                    x = ReadFloat();
                    return new Vector3(x, y, z);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a <see cref="Vector4" />.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector4" />.</returns>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector4Order" /> was not supported.</exception>
        public Vector4 ReadVector4(Vector4Order order = Vector4Order.XYZW)
        {
            float x;
            float y;
            float z;
            float w;
            switch (order)
            {
                case Vector4Order.XYZW:
                    x = ReadFloat();
                    y = ReadFloat();
                    z = ReadFloat();
                    w = ReadFloat();
                    return new Vector4(x, y, z, w);
                case Vector4Order.XZYW:
                    x = ReadFloat();
                    z = ReadFloat();
                    y = ReadFloat();
                    w = ReadFloat();
                    return new Vector4(x, y, z, w);
                case Vector4Order.WZYX:
                    w = ReadFloat();
                    z = ReadFloat();
                    y = ReadFloat();
                    x = ReadFloat();
                    return new Vector4(x, y, z, w);
                case Vector4Order.WYZX:
                    w = ReadFloat();
                    y = ReadFloat();
                    z = ReadFloat();
                    x = ReadFloat();
                    return new Vector4(x, y, z, w);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a <see cref="Quaternion" />.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Quaternion" />.</returns>
        /// <exception cref="NotImplementedException">The provided <see cref="Vector4Order" /> was not supported.</exception>
        public Quaternion ReadQuaternion(Vector4Order order = Vector4Order.XYZW)
        {
            float x;
            float y;
            float z;
            float w;
            switch (order)
            {
                case Vector4Order.XYZW:
                    x = ReadFloat();
                    y = ReadFloat();
                    z = ReadFloat();
                    w = ReadFloat();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.XZYW:
                    x = ReadFloat();
                    z = ReadFloat();
                    y = ReadFloat();
                    w = ReadFloat();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.WZYX:
                    w = ReadFloat();
                    z = ReadFloat();
                    y = ReadFloat();
                    x = ReadFloat();
                    return new Quaternion(x, y, z, w);
                case Vector4Order.WYZX:
                    w = ReadFloat();
                    y = ReadFloat();
                    z = ReadFloat();
                    x = ReadFloat();
                    return new Quaternion(x, y, z, w);
                default:
                    throw new NotImplementedException($"The order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a <see cref="Color" />.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Color" />.</returns>
        /// <exception cref="NotImplementedException">The provided <see cref="ColorOrder" /> was not supported.</exception>
        public Color ReadColor(ColorOrder order = ColorOrder.ARGB)
        {
            byte red;
            byte green;
            byte blue;
            byte alpha;
            switch (order)
            {
                case ColorOrder.RGB:
                    red = ReadByte();
                    green = ReadByte();
                    blue = ReadByte();
                    return Color.FromArgb(red, green, blue);
                case ColorOrder.BGR:
                    blue = ReadByte();
                    green = ReadByte();
                    red = ReadByte();
                    return Color.FromArgb(red, green, blue);
                case ColorOrder.RGBA:
                    red = ReadByte();
                    green = ReadByte();
                    blue = ReadByte();
                    alpha = ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.BGRA:
                    blue = ReadByte();
                    green = ReadByte();
                    red = ReadByte();
                    alpha = ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.ARGB:
                    alpha = ReadByte();
                    red = ReadByte();
                    green = ReadByte();
                    blue = ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                case ColorOrder.ABGR:
                    alpha = ReadByte();
                    blue = ReadByte();
                    green = ReadByte();
                    red = ReadByte();
                    return Color.FromArgb(alpha, red, green, blue);
                default:
                    throw new NotImplementedException($"The color order: {order}; Is not supported or does not exist.");
            }
        }

        /// <summary>
        /// Read a <see cref="byte"/> value as the specified <see cref="Enum"/>, throwing an exception if not present.
        /// </summary>
        public TEnum ReadEnum8<TEnum>() where TEnum : Enum
        {
            return ParseEnum<TEnum, byte>(ReadByte());
        }

        /// <summary>
        /// Read a two <see cref="byte"/> value as the specified <see cref="Enum"/>, throwing an exception if not present.
        /// </summary>
        public TEnum ReadEnum16<TEnum>() where TEnum : Enum
        {
            return ParseEnum<TEnum, ushort>(ReadUShort());
        }

        /// <summary>
        /// Read a four <see cref="byte"/> value as the specified <see cref="Enum"/>, throwing an exception if not present.
        /// </summary>
        public TEnum ReadEnum32<TEnum>() where TEnum : Enum
        {
            return ParseEnum<TEnum, uint>(ReadUInt());
        }

        /// <summary>
        /// Read an eight <see cref="byte"/> value as the specified <see cref="Enum"/>, throwing an exception if not present.
        /// </summary>
        public TEnum ReadEnum64<TEnum>() where TEnum : Enum
        {
            return ParseEnum<TEnum, ulong>(ReadULong());
        }
    }
}