using System.Drawing;
using System.Numerics;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
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

            throw new InvalidDataException($"Value: {value} of type: {typeof(T).FullName}; Did not match any of the selected options: {options.ArrayToString()}; Ending Position: 0x{Position:X} ({Position})");
        }

        /// <summary>
        /// Assert that the next read sbyte equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read sbyte.</param>
        /// <returns>The sbyte if it matched one of the provided options.</returns>
        public sbyte AssertSByte(params sbyte[] options)
        {
            return Assert(ReadSByte(), options);
        }

        /// <summary>
        /// Assert that the next read byte equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read byte.</param>
        /// <returns>The byte if it matched one of the provided options.</returns>
        public byte AssertByte(params byte[] options)
        {
            return Assert(ReadByte(), options);
        }

        /// <summary>
        /// Assert that the next read short equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read short.</param>
        /// <returns>The short if it matched one of the provided options.</returns>
        public short AssertShort(params short[] options)
        {
            return Assert(ReadShort(), options);
        }

        /// <summary>
        /// Assert that the next read ushort equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read ushort.</param>
        /// <returns>The ushort if it matched one of the provided options.</returns>
        public ushort AssertUShort(params ushort[] options)
        {
            return Assert(ReadUShort(), options);
        }

        /// <summary>
        /// Assert that the next read int equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read int.</param>
        /// <returns>The int if it matched one of the provided options.</returns>
        public int AssertInt(params int[] options)
        {
            return Assert(ReadInt(), options);
        }

        /// <summary>
        /// Assert that the next read uint equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read uint.</param>
        /// <returns>The uint if it matched one of the provided options.</returns>
        public uint AssertUInt(params uint[] options)
        {
            return Assert(ReadUInt(), options);
        }

        /// <summary>
        /// Assert that the next read long equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read long.</param>
        /// <returns>The long if it matched one of the provided options.</returns>
        public long AssertLong(params long[] options)
        {
            return Assert(ReadLong(), options);
        }

        /// <summary>
        /// Assert that the next read ulong equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read ulong.</param>
        /// <returns>The ulong if it matched one of the provided options.</returns>
        public ulong AssertULong(params ulong[] options)
        {
            return Assert(ReadULong(), options);
        }

        /// <summary>
        /// Assert that the next read half equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read half.</param>
        /// <returns>The half if it matched one of the provided options.</returns>
        public Half AssertHalf(params Half[] options)
        {
            return Assert(ReadHalf(), options);
        }

        /// <summary>
        /// Assert that the next read float equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read float.</param>
        /// <returns>The float if it matched one of the provided options.</returns>
        public float AssertFloat(params float[] options)
        {
            return Assert(ReadFloat(), options);
        }

        /// <summary>
        /// Assert that the next read double equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read double.</param>
        /// <returns>The double if it matched one of the provided options.</returns>
        public double AssertDouble(params double[] options)
        {
            return Assert(ReadDouble(), options);
        }

        /// <summary>
        /// Assert that the next read decimal equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read decimal.</param>
        /// <returns>The decimal if it matched one of the provided options.</returns>
        public decimal AssertDecimal(params decimal[] options)
        {
            return Assert(ReadDecimal(), options);
        }

        /// <summary>
        /// Assert that the next read varint equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read varint.</param>
        /// <returns>The varint as a long if it matched one of the provided options.</returns>
        public long AssertVarint(params long[] options)
        {
            return Assert(ReadVarint(), options);
        }

        /// <summary>
        /// Assert that the next read 7-bit encoded int equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read int.</param>
        /// <returns>An int if it matched one of the provided options.</returns>
        public int Assert7bitEncodedInt(params int[] options)
        {
            return Assert(Read7BitEncodedInt(), options);
        }

        /// <summary>
        /// Assert that the next read 7-bit encoded long equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read long.</param>
        /// <returns>A long if it matched one of the provided options.</returns>
        public long Assert7bitEncodedLong(params long[] options)
        {
            return Assert(Read7BitEncodedLong(), options);
        }

        /// <summary>
        /// Assert that the next read vector2 equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read vector2.</param>
        /// <returns>The vector2 if it matched one of the provided options.</returns>
        public Vector2 AssertVector2(params Vector2[] options)
        {
            return Assert(ReadVector2(), options);
        }

        /// <summary>
        /// Assert that the next read vector3 equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read vector3.</param>
        /// <returns>The vector3 if it matched one of the provided options.</returns>
        public Vector3 AssertVector3(params Vector3[] options)
        {
            return Assert(ReadVector3(), options);
        }

        /// <summary>
        /// Assert that the next read vector4 equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read vector4.</param>
        /// <returns>The vector4 if it matched one of the provided options.</returns>
        public Vector4 AssertVector4(params Vector4[] options)
        {
            return Assert(ReadVector4(), options);
        }

        /// <summary>
        /// Assert that the next read quaternion equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read quaternion.</param>
        /// <returns>The quaternion if it matched one of the provided options.</returns>
        public Quaternion AssertQuaternion(params Quaternion[] options)
        {
            return Assert(ReadQuaternion(), options);
        }

        /// <summary>
        /// Assert that the next read color equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the read color.</param>
        /// <returns>The color if it matched one of the provided options.</returns>
        public Color AssertColor(ColorOrder order = ColorOrder.ARGB, params Color[] options)
        {
            return Assert(ReadColor(order), options);
        }
    }
}