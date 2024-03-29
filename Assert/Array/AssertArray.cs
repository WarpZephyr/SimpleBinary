﻿namespace SimpleBinary
{
    public partial class SimpleBinaryReader
    {
        /// <summary>
        /// Assert that length number of bytes will match the provided value, throwing if not.
        /// </summary>
        /// <param name="length">The number of bytes to assert matches the provided value.</param>
        /// <param name="value">The value all bytes read should match.</param>
        /// <returns>A <see cref="byte" /> array should they all match.</returns>
        /// <exception cref="InvalidDataException">One of the bytes did not match.</exception>
        public byte[] AssertPattern(int length, byte value)
        {
            byte[] bytes = ReadBytes(length);
            for (int i = 0; i < length; i++)
                if (bytes[i] != value)
                    throw new InvalidDataException($"Value: {bytes[i]}; Did not match the pattern value: {value}; Ending Position: 0x{Position:X} ({Position})");
            return bytes;
        }

        /// <summary>
        /// Assert each value in an array of values are equal to at least one of the provided options.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="values">The values to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public T[] AssertArray<T>(T[] values, params T[] options) where T : IEquatable<T>
        {
            foreach (T value in values)
                Assert(value, options);
            return values;
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="byte" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public byte[] AssertBytes(int count, params byte[] options)
        {
            return AssertArray(ReadBytes(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="sbyte" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public sbyte[] AssertSBytes(int count, params sbyte[] options)
        {
            return AssertArray(ReadSBytes(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="short" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public short[] AssertShorts(int count, params short[] options)
        {
            return AssertArray(ReadShorts(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="ushort" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public ushort[] AssertUShorts(int count, params ushort[] options)
        {
            return AssertArray(ReadUShorts(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="int" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public int[] AssertInts(int count, params int[] options)
        {
            return AssertArray(ReadInts(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="uint" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public uint[] AssertUInts(int count, params uint[] options)
        {
            return AssertArray(ReadUInts(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="long" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public long[] AssertLongs(int count, params long[] options)
        {
            return AssertArray(ReadLongs(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="ulong" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public ulong[] AssertULongs(int count, params ulong[] options)
        {
            return AssertArray(ReadULongs(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="Half" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public Half[] AssertHalfs(int count, params Half[] options)
        {
            return AssertArray(ReadHalfs(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="float" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public float[] AssertFloats(int count, params float[] options)
        {
            return AssertArray(ReadFloats(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="double" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public double[] AssertDoubles(int count, params double[] options)
        {
            return AssertArray(ReadDoubles(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="decimal" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public decimal[] AssertDecimals(int count, params decimal[] options)
        {
            return AssertArray(ReadDecimals(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="char" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public char[] AssertChars(int count, params char[] options)
        {
            return AssertArray(ReadChars(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="bool" /> with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public bool[] AssertBools(int count, params bool[] options)
        {
            return AssertArray(ReadBools(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of Varints with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public long[] AssertVarints(int count, params long[] options)
        {
            return AssertArray(ReadVarints(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of unsigned Varints with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public ulong[] AssertUnsignedVarints(int count, params ulong[] options)
        {
            return AssertArray(ReadUnsignedVarints(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="int"/>, each 7-bit encoded, with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public int[] Assert7BitEncodedInts(int count, params int[] options)
        {
            return AssertArray(Read7BitEncodedInts(count), options);
        }

        /// <summary>
        /// Assert an <see cref="Array"/> of <see cref="long"/>, each 7-bit encoded, with provided options, throwing if no match is found.
        /// </summary>
        /// <param name="count">The amount to assert.</param>
        /// <param name="options">A list of possible options the read values should be.</param>
        /// <returns>The read values.</returns>
        public long[] Assert7BitEncodedLongs(int count, params long[] options)
        {
            return AssertArray(Read7BitEncodedLongs(count), options);
        }
    }
}