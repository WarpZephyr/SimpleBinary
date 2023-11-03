using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;
using static SimpleBinary.Generics;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Try to read an <see cref="sbyte"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="sbyte"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadSByte(out sbyte value)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadSByte();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="byte"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="byte"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadByte(out byte value)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadByte();
            return true;
        }

        /// <summary>
        /// Try to read an <see cref="short"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="short"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadShort(out short value)
        {
            value = default;
            if (Remaining < 2 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadShort();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="ushort"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="ushort"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadUShort(out ushort value)
        {
            value = default;
            if (Remaining < 2 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadUShort();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="int"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="int"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadInt(out int value)
        {
            value = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadInt();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="uint"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="uint"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadUInt(out uint value)
        {
            value = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadUInt();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="long"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="long"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadLong(out long value)
        {
            value = default;
            if (Remaining < 8 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadLong();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="ulong"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="ulong"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadULong(out ulong value)
        {
            value = default;
            if (Remaining < 8 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadULong();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Half"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Half"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadHalf(out Half value)
        {
            value = default;
            if (Remaining < 2 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadHalf();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="float"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="float"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadFloat(out float value)
        {
            value = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadFloat();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="double"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="double"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadDouble(out double value)
        {
            value = default;
            if (Remaining < 8 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadDouble();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="decimal"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="decimal"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadDecimal(out decimal value)
        {
            value = default;
            if (Remaining < 16 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadDecimal();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="char"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="char"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadChar(out char value)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadChar();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="bool"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="bool"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadBool(out bool value)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadBool();
            return true;
        }

        /// <summary>
        /// Try to read a Varint and return true if successful.
        /// </summary>
        /// <param name="value">The read Varint if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadVarint(out long value)
        {
            value = default;
            if (Remaining < VarintLength || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadVarint();
            return true;
        }

        /// <summary>
        /// Try to read an unsigned Varint and return true if successful.
        /// </summary>
        /// <param name="value">The read Varint if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadUnsignedVarint(out ulong value)
        {
            value = default;
            if (Remaining < VarintLength || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadUnsignedVarint();
            return true;
        }

        /// <summary>
        /// Try to read a 7-bit encoded <see cref="int"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="int"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryRead7BitEncodedInt(out int value)
        {
            value = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            value = Read7BitEncodedInt();
            return true;
        }

        /// <summary>
        /// Try to read a 7-bit encoded <see cref="long"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="long"/> if successful, or a default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryRead7BitEncodedLong(out long value)
        {
            value = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            value = Read7BitEncodedLong();
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Vector2"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Vector2"/> if successful, or a default.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadVector2(out Vector2 value, Vector2Order order = Vector2Order.XY)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadVector2(order);
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Vector3"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Vector3"/> if successful, or a default.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadVector3(out Vector3 value, Vector3Order order = Vector3Order.XYZ)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadVector3(order);
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Vector4"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Vector4"/> if successful, or a default.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadVector4(out Vector4 value, Vector4Order order = Vector4Order.XYZW)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadVector4(order);
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Quaternion"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Quaternion"/> if successful, or a default.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadQuaternion(out Quaternion value, Vector4Order order = Vector4Order.XYZW)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadQuaternion(order);
            return true;
        }

        /// <summary>
        /// Try to read a <see cref="Color"/> and return true if successful.
        /// </summary>
        /// <param name="value">The read <see cref="Color"/> if successful, or a default.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadColor(out Color value, ColorOrder order = ColorOrder.ARGB)
        {
            value = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            value = ReadColor(order);
            return true;
        }

        /// <summary>
        /// Try to read a one <see cref="byte"/> <see cref="Enum"/> and return true if successful.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="result">The read <see cref="Enum"/> if successful, or default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadEnum8<TEnum>(out TEnum? result) where TEnum : Enum
        {
            result = default;
            if (Remaining < 1 || !SimpleBinaryStream.CanRead)
                return false;
            bool success = TryParseEnum(ReadByte(), out TEnum? parsed);
            result = parsed;
            return success;
        }

        /// <summary>
        /// Try to read a two <see cref="byte"/> <see cref="Enum"/> and return true if successful.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="result">The read <see cref="Enum"/> if successful, or default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadEnum16<TEnum>(out TEnum? result) where TEnum : Enum
        {
            result = default;
            if (Remaining < 2 || !SimpleBinaryStream.CanRead)
                return false;
            bool success = TryParseEnum(ReadUShort(), out TEnum? parsed);
            result = parsed;
            return success;
        }

        /// <summary>
        /// Try to read a four <see cref="byte"/> <see cref="Enum"/> and return true if successful.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="result">The read <see cref="Enum"/> if successful, or default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadEnum32<TEnum>(out TEnum? result) where TEnum : Enum
        {
            result = default;
            if (Remaining < 4 || !SimpleBinaryStream.CanRead)
                return false;
            bool success = TryParseEnum(ReadUInt(), out TEnum? parsed);
            result = parsed;
            return success;
        }

        /// <summary>
        /// Try to read an eight <see cref="byte"/> <see cref="Enum"/> and return true if successful.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <param name="result">The read <see cref="Enum"/> if successful, or default.</param>
        /// <returns>Whether or not reading was successful.</returns>
        public bool TryReadEnum64<TEnum>(out TEnum? result) where TEnum : Enum
        {
            result = default;
            if (Remaining < 8 || !SimpleBinaryStream.CanRead)
                return false;
            bool success = TryParseEnum(ReadULong(), out TEnum? parsed);
            result = parsed;
            return success;
        }
    }
}
