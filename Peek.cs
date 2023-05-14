using System.Drawing;
using System.Numerics;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
    {
        /// <summary>
        /// Peek dynamically using the chosen read function without advancing the stream.
        /// </summary>
        /// <typeparam name="T">The type of data the chosen function returns.</typeparam>
        /// <param name="read">The function itself.</param>
        /// <returns>An item of the type returned by the function.</returns>
        /// <exception cref="NullReferenceException">The value returned by the function was null.</exception>
        public T Peek<T>(Func<T> read)
        {
            return Get(read, Position);
        }

        /// <summary>
        /// See what the next signed byte is without advancing the stream.
        /// </summary>
        /// <returns>An sbyte.</returns>
        public sbyte PeekSByte()
        {
            return Peek(ReadSByte);
        }

        /// <summary>
        /// See what the next byte is without advancing the stream.
        /// </summary>
        /// <returns>A byte.</returns>
        public byte PeekByte()
        {
            return Peek(ReadByte);
        }

        /// <summary>
        /// See what the next short is without advancing the stream.
        /// </summary>
        /// <returns>A short.</returns>
        public short PeekShort()
        {
            return Peek(ReadShort);
        }

        /// <summary>
        /// See what the next ushort is without advancing the stream.
        /// </summary>
        /// <returns>A ushort.</returns>
        public ushort PeekUShort()
        {
            return Peek(ReadUShort);
        }

        /// <summary>
        /// See what the next int is without advancing the stream.
        /// </summary>
        /// <returns>An int.</returns>
        public int PeekInt()
        {
            return Peek(ReadInt);
        }

        /// <summary>
        /// See what the next uint is without advancing the stream.
        /// </summary>
        /// <returns>A uint.</returns>
        public uint PeekUInt()
        {
            return Peek(ReadUInt);
        }

        /// <summary>
        /// See what the next long is without advancing the stream.
        /// </summary>
        /// <returns>A long.</returns>
        public long PeekLong()
        {
            return Peek(ReadLong);
        }

        /// <summary>
        /// See what the next ulong is without advancing the stream.
        /// </summary>
        /// <returns>A ulong.</returns>
        public ulong PeekULong()
        {
            return Peek(ReadULong);
        }

        /// <summary>
        /// See what the next half is without advancing the stream.
        /// </summary>
        /// <returns>A half.</returns>
        public Half PeekHalf()
        {
            return Peek(ReadHalf);
        }

        /// <summary>
        /// See what the next float is without advancing the stream.
        /// </summary>
        /// <returns>A float.</returns>
        public float PeekFloat()
        {
            return Peek(ReadFloat);
        }

        /// <summary>
        /// See what the next double is without advancing the stream.
        /// </summary>
        /// <returns>A double.</returns>
        public double PeekDouble()
        {
            return Peek(ReadDouble);
        }

        /// <summary>
        /// See what the next decimal is without advancing the stream.
        /// </summary>
        /// <returns>A decimal.</returns>
        public decimal PeekDecimal()
        {
            return Peek(ReadDecimal);
        }

        /// <summary>
        /// See what the varint is without advancing the stream.
        /// </summary>
        /// <returns>A long.</returns>
        public long PeekVarint()
        {
            return Peek(ReadVarint);
        }

        /// <summary>
        /// See what the next 7-bit encoded int is without advancing the stream.
        /// </summary>
        /// <returns>An int.</returns>
        public int Peek7BitEncodedInt()
        {
            return Peek(Read7BitEncodedInt);
        }

        /// <summary>
        /// See what the next 7-bit encoded long is without advancing the stream.
        /// </summary>
        /// <returns>A long.</returns>
        public long Peek7BitEncodedLong()
        {
            return Peek(Read7BitEncodedLong);
        }

        /// <summary>
        /// See what the next vector2 is without advancing the stream.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector2.</returns>
        public Vector2 PeekVector2(Vector2Order order = Vector2Order.XY)
        {
            return Peek(() => ReadVector2(order));
        }

        /// <summary>
        /// See what the next vector3 is without advancing the stream.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector3.</returns>
        public Vector3 PeekVector3(Vector3Order order = Vector3Order.XYZ)
        {
            return Peek(() => ReadVector3(order));
        }

        /// <summary>
        /// See what the next vector4 is without advancing the stream.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A vector4.</returns>
        public Vector4 PeekVector4(Vector4Order order = Vector4Order.XYZW)
        {
            return Peek(() => ReadVector4(order));
        }

        /// <summary>
        /// See what the next quaternion is without advancing the stream.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A quaternion.</returns>
        public Quaternion PeekQuaternion(Vector4Order order = Vector4Order.XYZW)
        {
            return Peek(() => ReadQuaternion(order));
        }

        /// <summary>
        /// See what the next color is without advancing the stream.
        /// </summary>
        /// <param name="order">The order that it should be read in.</param>
        /// <returns>A color.</returns>
        public Color PeekColor(ColorOrder order = ColorOrder.ARGB)
        {
            return Peek(() => ReadColor(order));
        }
    }
}