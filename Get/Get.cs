using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Get a value using the chosen <see cref="Func{T}"/> and return to the previous position.
        /// </summary>
        /// <typeparam name="T">The type of the value the <see cref="Func{T}"/> returns.</typeparam>
        /// <param name="read">The <see cref="Func{T}"/> for a reading.</param>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>The value returned by the <see cref="Func{TResult}"/>.</returns>
        private T Get<T>(Func<T> read, long position)
        {
            SimpleBinaryStream.StepIn(position);
            T value = read();
            SimpleBinaryStream.StepOut();
            return value;
        }

        /// <summary>
        /// Get a struct at the specified position.
        /// </summary>
        /// <typeparam name="TStruct">The type of the struct.</typeparam>
        /// <param name="position">The position to get the struct at.</param>
        /// <returns>The read struct.</returns>
        public TStruct? GetStruct<TStruct>(long position) where TStruct : struct
        {
            return Get(ReadStruct<TStruct>, position);
        }

        /// <summary>
        /// Get an <see cref="sbyte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="sbyte"/>.</returns>
        public sbyte GetSByte(long position)
        {
            return Get(ReadSByte, position);
        }

        /// <summary>
        /// Get a <see cref="byte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="byte"/>.</returns>
        public byte GetByte(long position)
        {
            return Get(ReadByte, position);
        }

        /// <summary>
        /// Get a <see cref="short"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="short"/>.</returns>
        public short GetShort(long position)
        {
            return Get(ReadShort, position);
        }

        /// <summary>
        /// Get a <see cref="ushort"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="ushort"/>.</returns>
        public ushort GetUShort(long position)
        {
            return Get(ReadUShort, position);
        }

        /// <summary>
        /// Get a <see cref="int"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public int GetInt(long position)
        {
            return Get(ReadInt, position);
        }

        /// <summary>
        /// Get a <see cref="uint"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="uint"/>.</returns>
        public uint GetUInt(long position)
        {
            return Get(ReadUInt, position);
        }

        /// <summary>
        /// Get a <see cref="long"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public long GetLong(long position)
        {
            return Get(ReadLong, position);
        }

        /// <summary>
        /// Get a <see cref="ulong"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="ulong"/>.</returns>
        public ulong GetULong(long position)
        {
            return Get(ReadULong, position);
        }

        /// <summary>
        /// Get a <see cref="Half"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="Half"/>.</returns>
        public Half GetHalf(long position)
        {
            return Get(ReadHalf, position);
        }

        /// <summary>
        /// Get a <see cref="float"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="float"/>.</returns>
        public float GetFloat(long position)
        {
            return Get(ReadFloat, position);
        }

        /// <summary>
        /// Get a <see cref="double"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="double"/>.</returns>
        public double GetDouble(long position)
        {
            return Get(ReadDouble, position);
        }

        /// <summary>
        /// Get a <see cref="decimal"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="decimal"/>.</returns>
        public decimal GetDecimal(long position)
        {
            return Get(ReadDecimal, position);
        }

        /// <summary>
        /// Get a <see cref="char"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="char"/>.</returns>
        public char GetChar(long position)
        {
            return Get(ReadChar, position);
        }

        /// <summary>
        /// Get a <see cref="bool"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        public bool GetBool(long position)
        {
            return Get(ReadBool, position);
        }

        /// <summary>
        /// Get a Varint at the specified position depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public long GetVarint(long position)
        {
            return Get(ReadVarint, position);
        }

        /// <summary>
        /// Get an unsigned Varint at the specified position depending on the set <see cref="VarintLengthType"/>.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="ulong"/>.</returns>
        public ulong GetUnsignedVarint(long position)
        {
            return Get(ReadUnsignedVarint, position);
        }

        /// <summary>
        /// Get a 7-bit encoded <see cref="int"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="int"/>.</returns>
        public int Get7BitEncodedInt(long position)
        {
            return Get(Read7BitEncodedInt, position);
        }

        /// <summary>
        /// Get a 7-bit encoded <see cref="long"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public long Get7BitEncodedLong(long position)
        {
            return Get(Read7BitEncodedLong, position);
        }

        /// <summary>
        /// Get a <see cref="Vector2"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector2"/>.</returns>
        public Vector2 GetVector2(long position, Vector2Order order = Vector2Order.XY)
        {
            return Get(() => ReadVector2(order), position);
        }

        /// <summary>
        /// Get a <see cref="Vector3"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector3"/>.</returns>
        public Vector3 GetVector3(long position, Vector3Order order = Vector3Order.XYZ)
        {
            return Get(() => ReadVector3(order), position);
        }

        /// <summary>
        /// Get a <see cref="Vector4"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Vector4"/>.</returns>
        public Vector4 GetVector4(long position, Vector4Order order = Vector4Order.XYZW)
        {
            return Get(() => ReadVector4(order), position);
        }

        /// <summary>
        /// Get a <see cref="Quaternion"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Quaternion"/>.</returns>
        public Quaternion GetQuaternion(long position, Vector4Order order = Vector4Order.XYZW)
        {
            return Get(() => ReadQuaternion(order), position);
        }

        /// <summary>
        /// Get a <see cref="Color"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get the value at.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A <see cref="Color"/>.</returns>
        public Color GetColor(long position, ColorOrder order = ColorOrder.ARGB)
        {
            return Get(() => ReadColor(order), position);
        }

        /// <summary>
        /// Get a one <see cref="byte"/> <see cref="Enum"/> at the specified position.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="Enum"/>.</returns>
        public TEnum GetEnum8<TEnum>(long position) where TEnum : Enum
        {
            return Get(() => ReadEnum8<TEnum>(), position);
        }

        /// <summary>
        /// Get a two <see cref="byte"/> <see cref="Enum"/> at the specified position.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="Enum"/>.</returns>
        public TEnum GetEnum16<TEnum>(long position) where TEnum : Enum
        {
            return Get(() => ReadEnum16<TEnum>(), position);
        }

        /// <summary>
        /// Get a four <see cref="byte"/> <see cref="Enum"/> at the specified position.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="Enum"/>.</returns>
        public TEnum GetEnum32<TEnum>(long position) where TEnum : Enum
        {
            return Get(() => ReadEnum32<TEnum>(), position);
        }

        /// <summary>
        /// Get an eight <see cref="byte"/> <see cref="Enum"/> at the specified position.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="position">The position to get the value at.</param>
        /// <returns>An <see cref="Enum"/>.</returns>
        public TEnum GetEnum64<TEnum>(long position) where TEnum : Enum
        {
            return Get(() => ReadEnum64<TEnum>(), position);
        }
    }
}