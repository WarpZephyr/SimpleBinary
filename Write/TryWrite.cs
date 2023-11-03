using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Try to write an <see cref="sbyte"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteSByte(sbyte value)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteSByte(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="byte"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteByte(byte value)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteByte(value);
            return true;
        }

        /// <summary>
        /// Try to write an <see cref="short"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteShort(short value)
        {
            if (Remaining < 2 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteShort(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="ushort"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteUShort(ushort value)
        {
            if (Remaining < 2 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteUShort(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="int"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteInt(int value)
        {
            if (Remaining < 4 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteInt(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="uint"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteUInt(uint value)
        {
            if (Remaining < 4 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteUInt(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="long"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteLong(long value)
        {
            if (Remaining < 8 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteLong(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="ulong"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteULong(ulong value)
        {
            if (Remaining < 8 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteULong(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Half"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteHalf(Half value)
        {
            if (Remaining < 2 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteHalf(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="float"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteFloat(float value)
        {
            if (Remaining < 4 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteFloat(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="double"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteDouble(double value)
        {
            if (Remaining < 8 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteDouble(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="decimal"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteDecimal(decimal value)
        {
            if (Remaining < 16 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteDecimal(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="char"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteChar(char value)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteChar(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="bool"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteBool(bool value)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteBool(value);
            return true;
        }

        /// <summary>
        /// Try to write a Varint and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteVarint(long value)
        {
            if (Remaining < VarintLength || !SimpleBinaryStream.CanWrite)
                return false;
            WriteVarint(value);
            return true;
        }

        /// <summary>
        /// Try to write an unsigned Varint and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteUnsignedVarint(ulong value)
        {
            if (Remaining < VarintLength || !SimpleBinaryStream.CanWrite)
                return false;
            WriteUnsignedVarint(value);
            return true;
        }

        /// <summary>
        /// Try to write a 7-bit encoded <see cref="int"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWrite7BitEncodedInt(int value)
        {
            if (Remaining < 4 || !SimpleBinaryStream.CanWrite)
                return false;
            Write7BitEncodedInt(value);
            return true;
        }

        /// <summary>
        /// Try to write a 7-bit encoded <see cref="long"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWrite7BitEncodedLong(long value)
        {
            if (Remaining < 4 || !SimpleBinaryStream.CanWrite)
                return false;
            Write7BitEncodedLong(value);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Vector2"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteVector2(Vector2 value, Vector2Order order = Vector2Order.XY)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteVector2(value, order);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Vector3"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteVector3(Vector3 value, Vector3Order order = Vector3Order.XYZ)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteVector3(value, order);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Vector4"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteVector4(Vector4 value, Vector4Order order = Vector4Order.XYZW)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteVector4(value, order);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Quaternion"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteQuaternion(Quaternion value, Vector4Order order = Vector4Order.XYZW)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteQuaternion(value, order);
            return true;
        }

        /// <summary>
        /// Try to write a <see cref="Color"/> and return true if successful.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="order">The order that it should be written in.</param>
        /// <returns>Whether or not writing was successful.</returns>
        public bool TryWriteColor(Color value, ColorOrder order = ColorOrder.ARGB)
        {
            if (Remaining < 1 || !SimpleBinaryStream.CanWrite)
                return false;
            WriteColor(value, order);
            return true;
        }
    }
}
