using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Get a <see cref="List{T}"/> of values using the chosen <see cref="Func{T}"/> and return to the previous position.
        /// </summary>
        /// <typeparam name="T">The type of the values the <see cref="Func{T}"/> returns.</typeparam>
        /// <param name="read">The <see cref="Func{T}"/> for a reading.</param>
        /// <param name="position">The position to get values at.</param>
        /// <returns>The values returned by the <see cref="Func{T}"/>.</returns>
        private List<T> GetList<T>(Func<List<T>> read, long position)
        {
            SimpleBinaryStream.StepIn(position);
            List<T> values = read();
            SimpleBinaryStream.StepOut();
            return values;
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="sbyte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="sbyte"/>.</returns>
        public List<sbyte> GetSByteList(long position, int count)
        {
            return GetList(() => ReadSByteList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="byte"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="byte"/>.</returns>
        public List<byte> GetByteList(long position, int count)
        {
            return GetList(() => ReadByteList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="short"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="short"/>.</returns>
        public List<short> GetShortList(long position, int count)
        {
            return GetList(() => ReadShortList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="ushort"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="ushort"/>.</returns>
        public List<ushort> GetUShortList(long position, int count)
        {
            return GetList(() => ReadUShortList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="int"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="int"/>.</returns>
        public List<int> GetIntList(long position, int count)
        {
            return GetList(() => ReadIntList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="uint"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="uint"/>.</returns>
        public List<uint> GetUIntList(long position, int count)
        {
            return GetList(() => ReadUIntList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="long"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="long"/>.</returns>
        public List<long> GetLongList(long position, int count)
        {
            return GetList(() => ReadLongList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="ulong"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="ulong"/>.</returns>
        public List<ulong> GetULongList(long position, int count)
        {
            return GetList(() => ReadULongList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Half"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Half"/>.</returns>
        public List<Half> GetHalfList(long position, int count)
        {
            return GetList(() => ReadHalfList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="float"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="float"/>.</returns>
        public List<float> GetFloatList(long position, int count)
        {
            return GetList(() => ReadFloatList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="double"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="double"/>.</returns>
        public List<double> GetDoubleList(long position, int count)
        {
            return GetList(() => ReadDoubleList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="decimal"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="decimal"/>.</returns>
        public List<decimal> GetDecimalList(long position, int count)
        {
            return GetList(() => ReadDecimalList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="char"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="char"/>.</returns>
        public List<char> GetCharList(long position, int count)
        {
            return GetList(() => ReadCharList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="bool"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="bool"/>.</returns>
        public List<bool> GetBoolList(long position, int count)
        {
            return GetList(() => ReadBoolList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of Varints at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="long"/>.</returns>
        public List<long> GetVarintList(long position, int count)
        {
            return GetList(() => ReadVarintList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of unsigned Variants at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="ulong"/>.</returns>
        public List<ulong> GetUnsignedVarintList(long position, int count)
        {
            return GetList(() => ReadUnsignedVarintList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="int"/>, each 7-bit encoded, at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="int"/>.</returns>
        public List<int> Get7BitEncodedIntList(long position, int count)
        {
            return GetList(() => Read7BitEncodedIntList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="long"/>, each 7-bit encoded, at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="long"/>.</returns>
        public List<long> Get7BitEncodedLongList(long position, int count)
        {
            return GetList(() => Read7BitEncodedLongList(count), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Vector2"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Vector2"/>.</returns>
        public List<Vector2> GetVector2List(long position, int count, Vector2Order order)
        {
            return GetList(() => ReadVector2List(count, order), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Vector3"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Vector3"/>.</returns>
        public List<Vector3> GetVector3List(long position, int count, Vector3Order order)
        {
            return GetList(() => ReadVector3List(count, order), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Vector4"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Vector4"/>.</returns>
        public List<Vector4> GetVector4List(long position, int count, Vector4Order order)
        {
            return GetList(() => ReadVector4List(count, order), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Quaternion"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Quaternion"/>.</returns>
        public List<Quaternion> GetQuaternionList(long position, int count, Vector4Order order)
        {
            return GetList(() => ReadQuaternionList(count, order), position);
        }

        /// <summary>
        /// Get a <see cref="List{T}"/> of <see cref="Color"/> at the specified position.
        /// </summary>
        /// <param name="position">The position to get values at.</param>
        /// <param name="count">The amount to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Color"/>.</returns>
        public List<Color> GetColorList(long position, int count, ColorOrder order)
        {
            return GetList(() => ReadColorList(count, order), position);
        }
    }
}
