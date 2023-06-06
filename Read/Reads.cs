using System.Drawing;
using System.Numerics;
using System.Text;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
    {
        /// <summary>
        /// Read an array of the type <see cref="{T}" /> using the provided function.
        /// </summary>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <param name="read">The function to read with.</param>
        /// <param name="reverse">Whether or not to reverse the read array.</param>
        /// <returns>An array of the type <see cref="{T}" /></returns>
        public static T[] Read<T>(Func<T[]> read, bool reverse = false)
        {
            T[] value = read();
            if (reverse)
                Array.Reverse(value);
            return value;
        }

        /// <summary>
        /// Read an array of the type <see cref="{T}" /> using the provided function.
        /// </summary>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <param name="read">A function to read with.</param>
        /// <param name="count">The number of times to read.</param>
        /// <returns>An array of the type <see cref="{T}" /></returns>
        public static T[] ReadArray<T>(Func<T> read, int count)
        {
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
                array[i] = read();
            return array;
        }

        /// <summary>
        /// Read a <see cref="List{T}" /> of the type <see cref="{T}" /> using the provided function.
        /// </summary>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <param name="read">A function that returns the type <see cref="{T}" /> to read.</param>
        /// <param name="count">The number of times to read.</param>
        /// <returns>A <see cref="List{T}" /> of the type <see cref="{T}" />.</returns>
        public static List<T> ReadList<T>(Func<T> read, int count)
        {
            List<T> list = new(count);
            for (int i = 0; i < count; i++)
                list[i] = read();
            return list;
        }

        /// <summary>
        /// Read a <see cref="Stack{T}" /> of the type <see cref="{T}" /> using the provided function.
        /// </summary>
        /// <typeparam name="T">The type to read.</typeparam>
        /// <param name="read">A function that returns the type <see cref="{T}" /> to read.</param>
        /// <param name="count">The number of times to read.</param>
        /// <returns>A <see cref="Stack{T}" /> of the type <see cref="{T}" />.</returns>
        public static Stack<T> ReadStack<T>(Func<T> read, int count)
        {
            Stack<T> stack = new(count);
            for (int i = 0; i < count; i++)
                stack.Push(read());
            return stack;
        }

        /// <summary>
        /// Read an array of <see cref="sbyte" />
        /// </summary>
        /// <param name="count">The number of sbytes to read.</param>
        /// <returns>An array of <see cref="sbyte" /></returns>
        public sbyte[] ReadSBytes(int count)
        {
            return ReadArray(ReadSByte, count);
        }

        /// <summary>
        /// Read an array of <see cref="byte" />
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>An array of <see cref="byte" /></returns>
        /// <exception cref="InvalidOperationException">The requested number of bytes goes beyond the stream.</exception>
        public byte[] ReadBytes(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            return Reader.ReadBytes(count);
        }

        /// <summary>
        /// Read the specified number of bytes from the stream into the buffer starting at the specified position.
        /// </summary>
        /// <param name="bytes">A <see cref="byte" /> array to read the bytes into.</param>
        /// <param name="position">The position or index in the array to start from.</param>
        /// <param name="count">The number of bytes from the stream to read into the array.</param>
        /// <exception cref="InvalidOperationException">The requested number of bytes goes beyond the stream.</exception>
        public void ReadBytes(byte[] bytes, int position, int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            Reader.Read(bytes, position, count);
        }

        /// <summary>
        /// Read an array of <see cref="short" />
        /// </summary>
        /// <param name="count">The number of shorts to read.</param>
        /// <returns>An array of <see cref="short" /></returns>
        public short[] ReadShorts(int count)
        {
            return ReadArray(ReadShort, count);
        }

        /// <summary>
        /// Read an array of <see cref="ushort" />
        /// </summary>
        /// <param name="count">The number of ushorts to read.</param>
        /// <returns>An array of <see cref="ushort" /></returns>
        public ushort[] ReadUShorts(int count)
        {
            return ReadArray(ReadUShort, count);
        }

        /// <summary>
        /// Read an array of <see cref="int" />
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>An array of <see cref="int" /></returns>
        public int[] ReadInts(int count)
        {
            return ReadArray(ReadInt, count);
        }

        /// <summary>
        /// Read an array of <see cref="uint" />
        /// </summary>
        /// <param name="count">The number of uints to read.</param>
        /// <returns>An array of <see cref="uint" /></returns>
        public uint[] ReadUInts(int count)
        {
            return ReadArray(ReadUInt, count);
        }

        /// <summary>
        /// Read an array of <see cref="long" />
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>An array of <see cref="long" /></returns>
        public long[] ReadLongs(int count)
        {
            return ReadArray(ReadLong, count);
        }


        /// <summary>
        /// Read an array of <see cref="ulong" />
        /// </summary>
        /// <param name="count">The number of ulongs to read.</param>
        /// <returns>An array of <see cref="ulong" /></returns>
        public ulong[] ReadULongs(int count)
        {
            return ReadArray(ReadULong, count);
        }

        /// <summary>
        /// Read an array of <see cref="Half" />
        /// </summary>
        /// <param name="count">The number of Halfs to read.</param>
        /// <returns>An array of <see cref="Half" /></returns>
        public Half[] ReadHalfs(int count)
        {
            return ReadArray(ReadHalf, count);
        }

        /// <summary>
        /// Read an array of <see cref="float" />
        /// </summary>
        /// <param name="count">The number of floats to read.</param>
        /// <returns>An array of <see cref="float" /></returns>
        public float[] ReadFloats(int count)
        {
            return ReadArray(ReadFloat, count);
        }

        /// <summary>
        /// Read an array of <see cref="double" />
        /// </summary>
        /// <param name="count">The number of doubles to read.</param>
        /// <returns>An array of <see cref="double" /></returns>
        public double[] ReadDoubles(int count)
        {
            return ReadArray(ReadDouble, count);
        }

        /// <summary>
        /// Read an array of <see cref="decimal" />
        /// </summary>
        /// <param name="count">The number of decimals to read.</param>
        /// <returns>An array of <see cref="decimal" /></returns>
        public decimal[] ReadDecimals(int count)
        {
            return ReadArray(ReadDecimal, count);
        }

        /// <summary>
        /// Read an array of Varints depending on the set VarintType.
        /// </summary>
        /// <param name="count">The number of Varints to read.</param>
        /// <returns>An array of <see cref="long" /></returns>
        public long[] ReadVarints(int count)
        {
            return ReadArray(ReadVarint, count);
        }

        /// <summary>
        /// Read an array of 7-bit encoded ints.
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>An array of <see cref="int" /></returns>
        public int[] Read7BitEncodedInts(int count)
        {
            return ReadArray(Read7BitEncodedInt, count);
        }

        /// <summary>
        /// Read an array of 7-bit encoded longs.
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>An array of <see cref="long" /></returns>
        public long[] Read7BitEncodedLongs(int count)
        {
            return ReadArray(Read7BitEncodedLong, count);
        }

        /// <summary>
        /// Read an array of <see cref="bool" />
        /// </summary>
        /// <param name="count">The number of bools to read.</param>
        /// <returns>An array of <see cref="bool" />.</returns>
        public bool[] ReadBools(int count)
        {
            return ReadArray(ReadBool, count);
        }

        /// <summary>
        /// Read an array of <see cref="char" />
        /// </summary>
        /// <param name="count">The number of chars to read.</param>
        /// <returns>An array of <see cref="char" /></returns>
        public char[] ReadChars(int count)
        {
            return ReadArray(ReadChar, count);
        }

        /// <summary>
        /// Read an array of <see cref="Color" />
        /// </summary>
        /// <param name="count">The number of Colors to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of <see cref="Color" /></returns>
        public Color[] ReadColors(int count, ColorOrder order = ColorOrder.ARGB)
        {
            return ReadArray(() => ReadColor(order), count);
        }

        /// <summary>
        /// Read an array of <see cref="Vector2" />
        /// </summary>
        /// <param name="count">The number of Vector2s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of <see cref="Vector2" /></returns>
        public Vector2[] ReadVector2s(int count, Vector2Order order = Vector2Order.XY)
        {
            return ReadArray(() => ReadVector2(order), count);
        }

        /// <summary>
        /// Read an array of <see cref="Vector3" />
        /// </summary>
        /// <param name="count">The number of Vector3s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of <see cref="Vector3" /></returns>
        public Vector3[] ReadVector3s(int count, Vector3Order order = Vector3Order.XYZ)
        {
            return ReadArray(() => ReadVector3(order), count);
        }

        /// <summary>
        /// Read an array of <see cref="Vector4" />
        /// </summary>
        /// <param name="count">The number of Vector4s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of <see cref="Vector4" /></returns>
        public Vector4[] ReadVector4s(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return ReadArray(() => ReadVector4(order), count);
        }

        /// <summary>
        /// Read an array of <see cref="Quaternion" />
        /// </summary>
        /// <param name="count">The number of Quaternions to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of <see cref="Quaternion" /></returns>
        public Quaternion[] ReadQuaternions(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return ReadArray(() => ReadQuaternion(order), count);
        }

        /// <summary>
        /// Read a <see cref="string" /> until a null-terminator is found with the specified <see cref="Encoding" />
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadString(Encoding encoding)
        {
            var bytes = new List<byte>();
            byte value = ReadByte();
            while (value != 0)
            {
                bytes.Add(value);
                value = ReadByte();
            }
            return encoding.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Read a fixed-size <see cref="string" /> with the specified <see cref="Encoding" />
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the <see cref="string" /></param>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadString(Encoding encoding, int length)
        {
            if (length > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {length} bytes; Remaining: {Remaining} bytes.");
            return encoding.GetString(ReadBytes(length));
        }

        /// <summary>
        /// Read an array of null-terminated strings using the specified <see cref="Encoding" />
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the strings.</param>
        /// <param name="count">The number of strings to read.</param>
        /// <returns>An array of <see cref="string" /></returns>
        public string[] ReadStrings(Encoding encoding, int count)
        {
            return ReadArray(() => ReadString(encoding), count);
        }

        /// <summary>
        /// Read an array of fixed-size strings.
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding" /> of the strings.</param>
        /// <param name="count">The number of strings to read.</param>
        /// <param name="length">The length of each <see cref="string" /></param>
        /// <returns>An array of <see cref="string" /></returns>
        public string[] ReadStrings(Encoding encoding, int count, int length)
        {
            return ReadArray(() => ReadString(encoding, length), count);
        }

        /// <summary>
        /// Read an ASCII <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadString()
        {
            return ReadString(SimpleEncoding.ASCII);
        }

        /// <summary>
        /// Read a fixed-size ASCII <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadString(int length)
        {
            return ReadString(SimpleEncoding.ASCII, length);
        }

        /// <summary>
        /// Read an ASCII <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadASCII()
        {
            return ReadString(SimpleEncoding.ASCII);
        }

        /// <summary>
        /// Read a Japanese Shift-JIS <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadShiftJIS()
        {
            return ReadString(SimpleEncoding.ShiftJIS);
        }

        /// <summary>
        /// Read a Japanese EUC-JP <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadEucJP()
        {
            return ReadString(SimpleEncoding.EucJP);
        }

        /// <summary>
        /// Read a Chinese Simplified EUC-CN <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadEucCn()
        {
            return ReadString(SimpleEncoding.EucCN);
        }

        /// <summary>
        /// Read a Korean EUC-KR <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadEucKR()
        {
            return ReadString(SimpleEncoding.EucKR);
        }

        /// <summary>
        /// Read a fixed-size ASCII <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadASCII(int length)
        {
            return ReadString(SimpleEncoding.ASCII, length);
        }

        /// <summary>
        /// Read a fixed-size Japanese Shift-JIS <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadShiftJIS(int length)
        {
            return ReadString(SimpleEncoding.ShiftJIS, length);
        }

        /// <summary>
        /// Read a fixed-size Chinese Simplified EUC-CN <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadEucCn(int length)
        {
            return ReadString(SimpleEncoding.EucCN, length);
        }

        /// <summary>
        /// Read a fixed-size Korean EUC-KR <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadEucKr(int length)
        {
            return ReadString(SimpleEncoding.EucKR, length);
        }

        /// <summary>
        /// Read a Japanese Shift-JIS <see cref="string" /> until a null-terminator is found.
        /// </summary>
        /// <returns>A <see cref="string" /></returns>
        public string ReadJapanese()
        {
            return ReadShiftJIS();
        }

        /// <summary>
        /// Read a fixed-size Japanese Shift-JIS <see cref="string" />
        /// </summary>
        /// <param name="length">The length of the <see cref="string" /></param>
        /// <returns>A <see cref="string" /></returns>
        public string ReadJapanese(int length)
        {
            return ReadShiftJIS(length);
        }

        /// <summary>
        /// Read a list of <see cref="sbyte" />
        /// </summary>
        /// <param name="count">The number of sbytes to read.</param>
        /// <returns>A list of <see cref="sbyte" /></returns>
        public List<sbyte> ReadSByteList(int count)
        {
            return ReadList(ReadSByte, count);
        }

        /// <summary>
        /// Read a list of <see cref="byte" />
        /// </summary>
        /// <returns>A list of <see cref="byte" /></returns>
        public List<byte> ReadByteList(int count)
        {
            return ReadList(ReadByte, count);
        }

        /// <summary>
        /// Read a list of <see cref="short" />
        /// </summary>
        /// <param name="count">The number of shorts to read.</param>
        /// <returns>A list of <see cref="short" /></returns>
        public List<short> ReadShortList(int count)
        {
            return ReadList(ReadShort, count);
        }

        /// <summary>
        /// Read a list of <see cref="ushort" />
        /// </summary>
        /// <param name="count">The number of ushorts to read.</param>
        /// <returns>A list of <see cref="ushort" /></returns>
        public List<ushort> ReadUShortList(int count)
        {
            return ReadList(ReadUShort, count);
        }

        /// <summary>
        /// Read a list of <see cref="int" />
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>A list of <see cref="int" /></returns>
        public List<int> ReadIntList(int count)
        {
            return ReadList(ReadInt, count);
        }

        /// <summary>
        /// Read a list of <see cref="uint" />
        /// </summary>
        /// <param name="count">The number of uints to read.</param>
        /// <returns>A list of <see cref="uint" /></returns>
        public List<uint> ReadUIntList(int count)
        {
            return ReadList(ReadUInt, count);
        }

        /// <summary>
        /// Read a list of <see cref="long" />
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>A list of <see cref="long" /></returns>
        public List<long> ReadLongList(int count)
        {
            return ReadList(ReadLong, count);
        }

        /// <summary>
        /// Read a list of <see cref="ulong" />
        /// </summary>
        /// <param name="count">The number of ulongs to read.</param>
        /// <returns>A list of <see cref="ulong" /></returns>
        public List<ulong> ReadULongList(int count)
        {
            return ReadList(ReadULong, count);
        }

        /// <summary>
        /// Read a list of <see cref="Half" />
        /// </summary>
        /// <param name="count">The number of Halfs to read.</param>
        /// <returns>A list of <see cref="Half" /></returns>
        public List<Half> ReadHalfList(int count)
        {
            return ReadList(ReadHalf, count);
        }

        /// <summary>
        /// Read a list of <see cref="float" />
        /// </summary>
        /// <param name="count">The number of floats to read.</param>
        /// <returns>A list of <see cref="float" /></returns>
        public List<float> ReadFloatList(int count)
        {
            return ReadList(ReadFloat, count);
        }

        /// <summary>
        /// Read a list of <see cref="double" />
        /// </summary>
        /// <param name="count">The number of doubles to read.</param>
        /// <returns>A list of <see cref="double" /></returns>
        public List<double> ReadDoubleList(int count)
        {
            return ReadList(ReadDouble, count);
        }

        /// <summary>
        /// Read a list of <see cref="decimal" />
        /// </summary>
        /// <param name="count">The number of decimals to read.</param>
        /// <returns>A list of <see cref="decimal" /></returns>
        public List<decimal> ReadDecimalList(int count)
        {
            return ReadList(ReadDecimal, count);
        }

        /// <summary>
        /// Read a list of Varints.
        /// </summary>
        /// <param name="count">The number of Varints to read.</param>
        /// <returns>A list of <see cref="long" /></returns>
        public List<long> ReadVarintList(int count)
        {
            return ReadList(ReadVarint, count);
        }

        /// <summary>
        /// Read a list of 7-bit encoded ints.
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>A list of <see cref="int" /></returns>
        public List<int> Read7BitEncodedIntList(int count)
        {
            return ReadList(Read7BitEncodedInt, count);
        }

        /// <summary>
        /// Read a list of 7-bit encoded longs.
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>A list of <see cref="long" /></returns>
        public List<long> Read7BitEncodedLongList(int count)
        {
            return ReadList(Read7BitEncodedLong, count);
        }

        /// <summary>
        /// Read a list of <see cref="bool" />
        /// </summary>
        /// <param name="count">The number of bools to read.</param>
        /// <returns>A list of <see cref="bool" /></returns>
        public List<bool> ReadBoolList(int count)
        {
            return ReadList(ReadBool, count);
        }

        /// <summary>
        /// Read a list of <see cref="char" />
        /// </summary>
        /// <param name="count">The number of chars to read.</param>
        /// <returns>A list of <see cref="char" /></returns>
        public List<char> ReadCharList(int count)
        {
            return ReadList(ReadChar, count);
        }

        /// <summary>
        /// Read a list of <see cref="Color" />
        /// </summary>
        /// <param name="count">The number of Colors to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of <see cref="Color" /></returns>
        public List<Color> ReadColorList(int count, ColorOrder order = ColorOrder.ARGB)
        {
            return ReadList(() => ReadColor(order), count);
        }

        /// <summary>
        /// Read a list of <see cref="Vector2" />
        /// </summary>
        /// <param name="count">The number of Vector2s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of <see cref="Vector2" /></returns>
        public List<Vector2> ReadVector2List(int count, Vector2Order order = Vector2Order.XY)
        {
            return ReadList(() => ReadVector2(order), count);
        }

        /// <summary>
        /// Read a list of <see cref="Vector3" />
        /// </summary>
        /// <param name="count">The number of Vector3s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of <see cref="Vector3" /></returns>
        public List<Vector3> ReadVector3List(int count, Vector3Order order = Vector3Order.XYZ)
        {
            return ReadList(() => ReadVector3(order), count);
        }

        /// <summary>
        /// Read a list of <see cref="Vector4" />
        /// </summary>
        /// <param name="count">The number of Vector4s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of <see cref="Vector4" /></returns>
        public List<Vector4> ReadVector4List(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return ReadList(() => ReadVector4(order), count);
        }

        /// <summary>
        /// Read a list of <see cref="Quaternion" />
        /// </summary>
        /// <param name="count">The number of Quaternions to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of <see cref="Quaternion" /></returns>
        public List<Quaternion> ReadQuaternionList(int count, Vector4Order order = Vector4Order.XYZW)
        {
            return ReadList(() => ReadQuaternion(order), count);
        }

        /// <summary>
        /// Read a list of null-terminated strings.
        /// </summary>
        /// <param name="encoding">The encoding of the strings.</param>
        /// <param name="count">The number of strings to read.</param>
        /// <returns>A list of <see cref="string" /></returns>
        public List<string> ReadStringList(Encoding encoding, int count)
        {
            return ReadList(() => ReadString(encoding), count);
        }

        /// <summary>
        /// Read a list of fixed-size strings.
        /// </summary>
        /// <param name="encoding">The encoding of the strings.</param>
        /// <param name="count">The number of strings to read.</param>
        /// <param name="length">The length of each string.</param>
        /// <returns>A list of <see cref="string" /></returns>
        public List<string> ReadStringList(Encoding encoding, int count, int length)
        {
            return ReadList(() => ReadString(encoding, length), count);
        }
    }
}