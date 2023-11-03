using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Get an <see cref="Array"/> of values using the chosen <see cref="Func{T}"/> and return to the previous position.
        /// </summary>
        /// <typeparam name="T">The type of the values the <see cref="Func{T}"/> returns.</typeparam>
        /// <param name="read">The <see cref="Func{T}"/> for a reading.</param>
        /// <param name="position">The position to get values at.</param>
        /// <returns>The values returned by the <see cref="Func{T}"/>.</returns>
        private T[] GetArray<T>(Func<T[]> read, long position)
        {
            SimpleBinaryStream.StepIn(position);
            T[] values = read();
            SimpleBinaryStream.StepOut();
            return values;
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="sbyte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="sbyte"/>.</returns>
        public sbyte[] GetSBytes(long position, int count)
        {
            return GetArray(() => ReadSBytes(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="byte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="byte"/>.</returns>
        public byte[] GetBytes(long position, int count)
        {
            return GetArray(() => ReadBytes(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="short"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="short"/>.</returns>
        public short[] GetShorts(long position, int count)
        {
            return GetArray(() => ReadShorts(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="ushort"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ushort"/>.</returns>
        public ushort[] GetUShorts(long position, int count)
        {
            return GetArray(() => ReadUShorts(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="int"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="int"/>.</returns>
        public int[] GetInts(long position, int count)
        {
            return GetArray(() => ReadInts(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="uint"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="uint"/>.</returns>
        public uint[] GetUInts(long position, int count)
        {
            return GetArray(() => ReadUInts(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="long"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long"/>.</returns>
        public long[] GetLongs(long position, int count)
        {
            return GetArray(() => ReadLongs(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="ulong"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ulong"/>.</returns>
        public ulong[] GetULongs(long position, int count)
        {
            return GetArray(() => ReadULongs(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Half"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Half"/>.</returns>
        public Half[] GetHalfs(long position, int count)
        {
            return GetArray(() => ReadHalfs(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="float"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="float"/>.</returns>
        public float[] GetFloats(long position, int count)
        {
            return GetArray(() => ReadFloats(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="double"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="double"/>.</returns>
        public double[] GetDoubles(long position, int count)
        {
            return GetArray(() => ReadDoubles(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="decimal"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="decimal"/>.</returns>
        public decimal[] GetDecimals(long position, int count)
        {
            return GetArray(() => ReadDecimals(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="char"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="char"/>.</returns>
        public char[] GetChars(long position, int count)
        {
            return GetArray(() => ReadChars(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="bool"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="bool"/>.</returns>
        public bool[] GetBools(long position, int count)
        {
            return GetArray(() => ReadBools(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of Varints at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long"/>.</returns>
        public long[] GetVarints(long position, int count)
        {
            return GetArray(() => ReadVarints(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of unsigned Variants at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="ulong"/>.</returns>
        public ulong[] GetUnsignedVarints(long position, int count)
        {
            return GetArray(() => ReadUnsignedVarints(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="int"/>, each 7-bit encoded, at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="int"/>.</returns>
        public int[] Get7BitEncodedInts(long position, int count)
        {
            return GetArray(() => Read7BitEncodedInts(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="long"/>, each 7-bit encoded, at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="Array"/> of <see cref="long"/>.</returns>
        public long[] Get7BitEncodedLongs(long position, int count)
        {
            return GetArray(() => Read7BitEncodedLongs(count), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Vector2"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector2"/>.</returns>
        public Vector2[] GetVector2s(long position, int count, Vector2Order order)
        {
            return GetArray(() => ReadVector2s(count, order), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Vector3"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector3"/>.</returns>
        public Vector3[] GetVector3s(long position, int count, Vector3Order order)
        {
            return GetArray(() => ReadVector3s(count, order), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Vector4"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Vector4"/>.</returns>
        public Vector4[] GetVector4s(long position, int count, Vector4Order order)
        {
            return GetArray(() => ReadVector4s(count, order), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Quaternion"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Quaternion"/>.</returns>
        public Quaternion[] GetQuaternions(long position, int count, Vector4Order order)
        {
            return GetArray(() => ReadQuaternions(count, order), position);
        }

        /// <summary>
        /// Get an <see cref="Array"/> of <see cref="Color"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="Array"/> of <see cref="Color"/>.</returns>
        public Color[] GetColors(long position, int count, ColorOrder order)
        {
            return GetArray(() => ReadColors(count, order), position);
        }
    }
}
