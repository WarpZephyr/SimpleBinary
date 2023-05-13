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
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        /// <exception cref="InvalidDataException">None of the provided options matched the provided value.</exception>
        public T Assert<T>(T value, params T[] options) where T : IEquatable<T>
        {
            foreach (var option in options)
                if (value.Equals(option))
                    return value;

            throw new InvalidDataException($"Value: {value} of type: {typeof(T).FullName}; Did not match any of the selected options: {options.ArrayToString()}. Ending Position: 0x{Position:X} ({Position})");
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public sbyte AssertSByte(params sbyte[] options)
        {
            return Assert(ReadSByte(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public byte AssertByte(params byte[] options)
        {
            return Assert(ReadByte(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public short AssertShort(params short[] options)
        {
            return Assert(ReadShort(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public ushort AssertUShort(params ushort[] options)
        {
            return Assert(ReadUShort(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public int AssertInt(params int[] options)
        {
            return Assert(ReadInt(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public uint AssertUInt(params uint[] options)
        {
            return Assert(ReadUInt(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public long AssertLong(params long[] options)
        {
            return Assert(ReadLong(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public ulong AssertULong(params ulong[] options)
        {
            return Assert(ReadULong(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Half AssertHalf(params Half[] options)
        {
            return Assert(ReadHalf(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public float AssertFloat(params float[] options)
        {
            return Assert(ReadFloat(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public double AssertDouble(params double[] options)
        {
            return Assert(ReadDouble(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public decimal AssertDecimal(params decimal[] options)
        {
            return Assert(ReadDecimal(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Vector2 AssertVector2(params Vector2[] options)
        {
            return Assert(ReadVector2(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Vector3 AssertVector3(params Vector3[] options)
        {
            return Assert(ReadVector3(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Vector4 AssertVector4(params Vector4[] options)
        {
            return Assert(ReadVector4(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Quaternion AssertQuaternion(params Quaternion[] options)
        {
            return Assert(ReadQuaternion(), options);
        }

        /// <summary>
        /// Assert that the next read value equals at least one of the options in a list of provided options, throwing if not.
        /// </summary>
        /// <param name="options">The options that should have at least one option matching the provided value.</param>
        /// <returns>The value if it matched one of the provided options.</returns>
        public Color AssertColor(ColorOrder order = ColorOrder.ARGB, params Color[] options)
        {
            return Assert(ReadColor(order), options);
        }
    }
}