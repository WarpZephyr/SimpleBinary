using System.Drawing;
using System.Numerics;
using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Assert that a value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <typeparam name="T">The type of the value and options being asserted.</typeparam>
        /// <param name="value">The value to assert is equal to at least one of the options.</param>
        /// <param name="options">The options that should have at least one option matching the read value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        /// <exception cref="InvalidDataException">None of the provided options matched the provided value.</exception>
        public T Assert<T>(T value, params T[] options) where T : IEquatable<T>
        {
            foreach (var option in options)
                if (value.Equals(option))
                    return value;

            throw new InvalidDataException($"Read {typeof(T).Name}: {value} | Expected: {string.Join(",", options)} | Ending Position: 0x{Position:X} ({Position})");
        }

        /// <summary>
        /// Assert the next read <see cref="sbyte"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public sbyte AssertSByte(params sbyte[] options)
        {
            return Assert(ReadSByte(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="byte"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public byte AssertByte(params byte[] options)
        {
            return Assert(ReadByte(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="short"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public short AssertShort(params short[] options)
        {
            return Assert(ReadShort(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="ushort"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public ushort AssertUShort(params ushort[] options)
        {
            return Assert(ReadUShort(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="int"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public int AssertInt(params int[] options)
        {
            return Assert(ReadInt(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="uint"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public uint AssertUInt(params uint[] options)
        {
            return Assert(ReadUInt(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="long"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public long AssertLong(params long[] options)
        {
            return Assert(ReadLong(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="ulong"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public ulong AssertULong(params ulong[] options)
        {
            return Assert(ReadULong(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Half"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Half AssertHalf(params Half[] options)
        {
            return Assert(ReadHalf(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="float"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public float AssertFloat(params float[] options)
        {
            return Assert(ReadFloat(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="double"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public double AssertDouble(params double[] options)
        {
            return Assert(ReadDouble(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="decimal"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public decimal AssertDecimal(params decimal[] options)
        {
            return Assert(ReadDecimal(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="char"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public char AssertChar(params char[] options)
        {
            return Assert(ReadChar(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="bool"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public bool AssertBool(params bool[] options)
        {
            return Assert(ReadBool(), options);
        }

        /// <summary>
        /// Assert the next read Varint is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public long AssertVarint(params long[] options)
        {
            return Assert(ReadVarint(), options);
        }

        /// <summary>
        /// Assert the next read unsigned Varint is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public ulong AssertUnsignedVarint(params ulong[] options)
        {
            return Assert(ReadUnsignedVarint(), options);
        }

        /// <summary>
        /// Assert the next read 7-bit encoded <see cref="int"> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public int Assert7bitEncodedInt(params int[] options)
        {
            return Assert(Read7BitEncodedInt(), options);
        }

        /// <summary>
        /// Assert the next read 7-bit encoded <see cref="long"> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public long Assert7bitEncodedLong(params long[] options)
        {
            return Assert(Read7BitEncodedLong(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Vector2"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Vector2 AssertVector2(params Vector2[] options)
        {
            return Assert(ReadVector2(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Vector3"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Vector3 AssertVector3(params Vector3[] options)
        {
            return Assert(ReadVector3(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Vector4"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Vector4 AssertVector4(params Vector4[] options)
        {
            return Assert(ReadVector4(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Quaternion"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Quaternion AssertQuaternion(params Quaternion[] options)
        {
            return Assert(ReadQuaternion(), options);
        }

        /// <summary>
        /// Assert the next read <see cref="Color"/> is equal to one of the provided values.
        /// </summary>
        /// <param name="options">A list of possible options the read value should be.</param>
        /// <returns>The read value.</returns>
        public Color AssertColor(ColorOrder order = ColorOrder.ARGB, params Color[] options)
        {
            return Assert(ReadColor(order), options);
        }
    }
}