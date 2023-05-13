using System.Drawing;
using System.Numerics;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
    {
        /// <summary>
        /// Get a value dynamically using the chosen read function and return to the previous position.
        /// </summary>
        /// <typeparam name="T">The type of data the chosen function returns.</typeparam>
        /// <param name="read">The function itself.</param>
        /// <param name="position">The position at which to get the value.</param>
        /// <returns>An item of the type returned by the function.</returns>
        public T Get<T>(Func<T> read, long position)
        {
            StepIn(position);
            T value = Read(read);
            StepOut();
            return value;
        }

        /// <summary>
        /// Get a signed byte at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed byte.</returns>
        public sbyte GetSByte(long position)
        {
            return Get(ReadSByte, position);
        }

        /// <summary>
        /// Get a byte at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>An unsigned byte.</returns>
        public byte GetByte(long position)
        {
            return Get(ReadByte, position);
        }

        /// <summary>
        /// Get a short at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed short.</returns>
        public short GetShort(long position)
        {
            return Get(ReadShort, position);
        }

        /// <summary>
        /// Get a unsigned short at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A unsigned short.</returns>
        public ushort GetUShort(long position)
        {
            return Get(ReadUShort, position);
        }

        /// <summary>
        /// Get a int at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed integer.</returns>
        public int GetInt(long position)
        {
            return Get(ReadInt, position);
        }

        /// <summary>
        /// Get a unsigned int at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>An unsigned integer.</returns>
        public uint GetUInt(long position)
        {
            return Get(ReadUInt, position);
        }

        /// <summary>
        /// Get a long at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed long.</returns>
        public long GetLong(long position)
        {
            return Get(ReadLong, position);
        }

        /// <summary>
        /// Get a unsigned long at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>An unsigned long.</returns>
        public ulong GetULong(long position)
        {
            return Get(ReadULong, position);
        }

        /// <summary>
        /// Get a half at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A half-precision floating point decimal number.</returns>
        public Half GetHalf(long position)
        {
            return Get(ReadHalf, position);
        }

        /// <summary>
        /// Get a float at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A floating point decimal number.</returns>
        public float GetFloat(long position)
        {
            return Get(ReadFloat, position);
        }

        /// <summary>
        /// Get a double at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A double-precision floating point decimal number.</returns>
        public double GetDouble(long position)
        {
            return Get(ReadDouble, position);
        }

        /// <summary>
        /// Get a decimal at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A decimal floating point number.</returns>
        public decimal GetDecimal(long position)
        {
            return Get(ReadDecimal, position);
        }

        /// <summary>
        /// Get a varint at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed integer.</returns>
        public int GetVarint(long position)
        {
            return Get(ReadVarint, position);
        }

        /// <summary>
        /// Get a varint long at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <returns>A signed long.</returns>
        public long GetCompressedLong(long position)
        {
            return Get(ReadVarintLong, position);
        }

        /// <summary>
        /// Get a vector2 at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector2.</returns>
        public Vector2 GetVector2(long position, Vector2Order order = Vector2Order.XY)
        {
            return Get(() => ReadVector2(order), position);
        }

        /// <summary>
        /// Get a vector3 at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector3.</returns>
        public Vector3 GetVector3(long position, Vector3Order order = Vector3Order.XYZ)
        {
            return Get(() => ReadVector3(order), position);
        }

        /// <summary>
        /// Get a vector4 at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector4.</returns>
        public Vector4 GetVector4(long position, Vector4Order order = Vector4Order.XYZW)
        {
            return Get(() => ReadVector4(order), position);
        }

        /// <summary>
        /// Get a quaternion at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A quaternion.</returns>
        public Quaternion GetQuaternion(long position, Vector4Order order = Vector4Order.XYZW)
        {
            return Get(() => ReadQuaternion(order), position);
        }

        /// <summary>
        /// Get a color at the specified position and return.
        /// </summary>
        /// <param name="position">The position from which to get the value.</param>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A color.</returns>
        public Color GetColor(long position, ColorOrder order = ColorOrder.ARGB)
        {
            return Get(() => ReadColor(order), position);
        }
    }
}