using System.Drawing;
using System.Numerics;
using System.Text;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleReader
    {
        /// <summary>
        /// Read an array of a type using the chosen function.
        /// </summary>
        /// <typeparam name="T">The type of data the chosen function returns.</typeparam>
        /// <param name="reads">The function itself.</param>
        /// <param name="reverse">Whether or not to reverse the array.</param>
        /// <returns>An array of the item of the type returned by the function.</returns>
        public static T[] Reads<T>(Func<T[]> reads, bool reverse = false)
        {
            T[] value = reads();
            if (reverse)
                Array.Reverse(value);
            return value;
        }

        /// <summary>
        /// Read an array of signed bytes.
        /// </summary>
        /// <param name="count">The number of signed bytes to read.</param>
        /// <returns>An array of signed bytes.</returns>
        /// <exception cref="InvalidOperationException">The requested number of signed bytes goes beyond the stream.</exception>
        public sbyte[] ReadSBytes(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            sbyte[] array = new sbyte[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadSByte();
            return array;
        }

        /// <summary>
        /// Read an array of unsigned bytes.
        /// </summary>
        /// <param name="count">The number of unsigned bytes to read.</param>
        /// <returns>An array of bytes.</returns>
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
        /// <param name="bytes">A byte array to read the bytes into.</param>
        /// <param name="position">The position or index in the array.</param>
        /// <param name="count">The number of bytes from the stream to read into the array.</param>
        /// <exception cref="InvalidOperationException">The requested number of bytes goes beyond the stream.</exception>
        public void ReadBytes(byte[] bytes, int position, int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            Reader.Read(bytes, position, count);
        }

        /// <summary>
        /// Read an array of shorts.
        /// </summary>
        /// <param name="count">The number of shorts to read.</param>
        /// <returns>An array of shorts.</returns>
        /// <exception cref="InvalidOperationException">The requested number of shorts goes beyond the stream.</exception>
        public short[] ReadShorts(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            short[] array = new short[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadShort();
            return array;
        }

        /// <summary>
        /// Read an array of ushorts.
        /// </summary>
        /// <param name="count">The number of ushorts to read.</param>
        /// <returns>An array of ushorts.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ushort goes beyond the stream.</exception>
        public ushort[] ReadUShorts(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            ushort[] array = new ushort[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadUShort();
            return array;
        }

        /// <summary>
        /// Read an array of ints.
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>An array of ints.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ints goes beyond the stream.</exception>
        public int[] ReadInts(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadInt();
            return array;
        }

        /// <summary>
        /// Read an array of uints.
        /// </summary>
        /// <param name="count">The number of uints to read.</param>
        /// <returns>An array of uints.</returns>
        /// <exception cref="InvalidOperationException">The requested number of uints goes beyond the stream.</exception>
        public uint[] ReadUInts(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            uint[] array = new uint[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadUInt();
            return array;
        }

        /// <summary>
        /// Read an array of longs.
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>An array of longs.</returns>
        /// <exception cref="InvalidOperationException">The requested number of longs goes beyond the stream.</exception>
        public long[] ReadLongs(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            long[] array = new long[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadLong();
            return array;
        }
        

        /// <summary>
        /// Read an array of ulongs.
        /// </summary>
        /// <param name="count">The number of ulongs to read.</param>
        /// <returns>An array of ulongs.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ulongs goes beyond the stream.</exception>
        public ulong[] ReadULongs(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            ulong[] array = new ulong[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadULong();
            return array;
        }

        /// <summary>
        /// Read an array of halfs.
        /// </summary>
        /// <param name="count">The number of halfs to read.</param>
        /// <returns>An array of floats.</returns>
        /// <exception cref="InvalidOperationException">The requested number of halfs goes beyond the stream.</exception>
        public Half[] ReadHalfs(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            Half[] array = new Half[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadHalf();
            return array;
        }

        /// <summary>
        /// Read an array of floats.
        /// </summary>
        /// <param name="count">The number of floats to read.</param>
        /// <returns>An array of floats.</returns>
        /// <exception cref="InvalidOperationException">The requested number of floats goes beyond the stream.</exception>
        public float[] ReadFloats(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            float[] array = new float[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadFloat();
            return array;
        }

        /// <summary>
        /// Read an array of doubles.
        /// </summary>
        /// <param name="count">The number of doubles to read.</param>
        /// <returns>An array of doubles.</returns>
        /// <exception cref="InvalidOperationException">The requested number of doubles goes beyond the stream.</exception>
        public double[] ReadDoubles(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadDouble();
            return array;
        }

        /// <summary>
        /// Read an array of decimals.
        /// </summary>
        /// <param name="count">The number of decimals to read.</param>
        /// <returns>An array of decimals.</returns>
        /// <exception cref="InvalidOperationException">The requested number of decimals goes beyond the stream.</exception>
        public decimal[] ReadDecimals(int count)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            decimal[] array = new decimal[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadDecimal();
            return array;
        }

        /// <summary>
        /// Read an array of booleans.
        /// </summary>
        /// <param name="count">The number of booleans to read.</param>
        /// <returns>An array of booleans.</returns>
        /// <exception cref="InvalidOperationException">The requested number of booleans goes beyond the end of the stream.</exception>
        public bool[] ReadBools(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            bool[] array = new bool[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadBool();
            return array;
        }

        /// <summary>
        /// Read an array of chars.
        /// </summary>
        /// <param name="count">The number of chars to read.</param>
        /// <returns>An array of chars.</returns>
        /// <exception cref="InvalidOperationException">The requested number of chars goes beyond the end of the stream.</exception>
        public char[] ReadChars(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            char[] array = new char[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadChar();
            return array;
        }

        /// <summary>
        /// Read an array of colors.
        /// </summary>
        /// <param name="count">The number of colors to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of colors.</returns>
        /// <exception cref="InvalidOperationException">The requested number of colors goes beyond the stream.</exception>
        /// <exception cref="NotImplementedException">The requested color order does not exist or is not supported.</exception>
        public Color[] ReadColors(int count, ColorOrder order = ColorOrder.ARGB)
        {
            switch (order)
            {
                case ColorOrder.RGB:
                case ColorOrder.BGR:
                case ColorOrder.RGBA:
                    if ((count * 3) > Remaining)
                        throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 3} bytes; Remaining: {Remaining} bytes.");
                    break;
                case ColorOrder.BGRA:
                case ColorOrder.ARGB:
                case ColorOrder.ABGR:
                    if ((count * 4) > Remaining)
                        throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
                    break;
                default:
                    throw new NotImplementedException($"The color order: {order}; Is not supported or does not exist.");
            }

            Color[] array = new Color[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadColor(order);
            return array;
        }

        /// <summary>
        /// Read an array of vector2s.
        /// </summary>
        /// <param name="count">The number of vector2s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of vector2s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector2s goes beyond the stream.</exception>
        public Vector2[] ReadVector2s(int count, Vector2Order order = Vector2Order.XY)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            Vector2[] array = new Vector2[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadVector2(order);
            return array;
        }

        /// <summary>
        /// Read an array of vector3s.
        /// </summary>
        /// <param name="count">The number of vector3s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of vector3s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector3s goes beyond the stream.</exception>
        public Vector3[] ReadVector3s(int count, Vector3Order order = Vector3Order.XYZ)
        {
            if ((count * 12) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 12} bytes; Remaining: {Remaining} bytes.");
            Vector3[] array = new Vector3[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadVector3(order);
            return array;
        }

        /// <summary>
        /// Read an array of vector4s.
        /// </summary>
        /// <param name="count">The number of vector4s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of vector4s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector4s goes beyond the stream.</exception>
        public Vector4[] ReadVector4s(int count, Vector4Order order = Vector4Order.XYZW)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            Vector4[] array = new Vector4[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadVector4(order);
            return array;
        }

        /// <summary>
        /// Read an array of quaternions.
        /// </summary>
        /// <param name="count">The number of quaternions to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>An array of quaternions.</returns>
        /// <exception cref="InvalidOperationException">The requested number of quaternions goes beyond the stream.</exception>
        public Quaternion[] ReadQuaternions(int count, Vector4Order order = Vector4Order.XYZW)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            Quaternion[] array = new Quaternion[count];
            for (int i = 0; i < count; i++)
                array[i] = ReadQuaternion(order);
            return array;
        }

        /// <summary>
        /// Read an ASCII string until a null terminator is found.
        /// </summary>
        public string ReadString()
        {
            return ReadString(SimpleEncoding.ASCII);
        }

        /// <summary>
        /// Read a string until a null terminator is found with the specified encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use for reading the string.</param>
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
        /// Read a fixed size ASCII string.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadFixedString(int length)
        {
            return ReadFixedString(SimpleEncoding.ASCII, length);
        }

        /// <summary>
        /// Read a fixed size string with the specified encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use for reading the string.</param>
        /// <param name="length">The length or size of the string.</param>
        public string ReadFixedString(Encoding encoding, int length)
        {
            if (length > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {length} bytes; Remaining: {Remaining} bytes.");
            return encoding.GetString(ReadBytes(length));
        }

        /// <summary>
        /// Reads an ASCII string until a null terminator is found.
        /// </summary>
        public string ReadASCII()
        {
            return ReadString(SimpleEncoding.ASCII);
        }

        /// <summary>
        /// Read a Japanese Shift-JIS string until a null terminator is found.
        /// </summary>
        public string ReadJapanese()
        {
            return ReadShiftJIS();
        }

        /// <summary>
        /// Read a Japanese Shift-JIS string until a null terminator is found.
        /// </summary>
        public string ReadShiftJIS()
        {
            return ReadString(SimpleEncoding.ShiftJIS);
        }

        /// <summary>
        /// Read a Japanese EUC-JP string until a null terminator is found.
        /// </summary>
        public string ReadEucJP()
        {
            return ReadString(SimpleEncoding.EucJP);
        }

        /// <summary>
        /// Read a Chinese Simplified EUC-CN string until a null terminator is found.
        /// </summary>
        public string ReadEucCn()
        {
            return ReadString(SimpleEncoding.EucCN);
        }

        /// <summary>
        /// Read a Korean EUC-KR string until a null terminator is found.
        /// </summary>
        public string ReadEucKR()
        {
            return ReadString(SimpleEncoding.EucKR);
        }

        /// <summary>
        /// Read a fixed size ASCII string until a null terminator is found.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadASCII(int length)
        {
            return ReadFixedString(SimpleEncoding.ASCII, length);
        }

        /// <summary>
        /// Read a fixed size Japanese Shift-JIS string until a null terminator is found.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadJapanese(int length)
        {
            return ReadShiftJIS(length);
        }

        /// <summary>
        /// Read a fixed size Japanese Shift-JIS string until a null terminator is found.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadShiftJIS(int length)
        {
            return ReadFixedString(SimpleEncoding.ShiftJIS, length);
        }

        /// <summary>
        /// Read a fixed size Chinese Simplified EUC-CN string until a null terminator is found.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadEucCn(int length)
        {
            return ReadFixedString(SimpleEncoding.EucCN, length);
        }

        /// <summary>
        /// Read a fixed size Korean EUC-KR string until a null terminator is found.
        /// </summary>
        /// <param name="length">The length or size of the string.</param>
        public string ReadEucKr(int length)
        {
            return ReadFixedString(SimpleEncoding.EucKR, length);
        }

        /// <summary>
        /// Read a list of signed bytes.
        /// </summary>
        /// <param name="count">The number of signed bytes to read.</param>
        /// <returns>A list of signed bytes.</returns>
        /// <exception cref="InvalidOperationException">The requested number of signed bytes goes beyond the stream.</exception>
        public List<sbyte> ReadSByteList(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            List<sbyte> list = new List<sbyte>();
            for (int i = 0; i < count; i++)
                list.Add(ReadSByte());
            return list;
        }

        /// <summary>
        /// Read a list of unsigned bytes.
        /// </summary>
        public List<byte> ReadByteList(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            List<byte> list = new List<byte>();
            for (int i = 0; i < count; i++)
                list.Add(ReadByte());
            return list;
        }

        /// <summary>
        /// Read a list of shorts.
        /// </summary>
        /// <param name="count">The number of shorts to read.</param>
        /// <returns>A list of shorts.</returns>
        /// <exception cref="InvalidOperationException">The requested number of shorts goes beyond the stream.</exception>
        public List<short> ReadShortList(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            var list = new List<short>();
            for (int i = 0; i < count; i++)
                list.Add(ReadShort());
            return list;
        }

        /// <summary>
        /// Read a list of ushorts.
        /// </summary>
        /// <param name="count">The number of ushorts to read.</param>
        /// <returns>A list of ushorts.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ushorts goes beyond the stream.</exception>
        public List<ushort> ReadUShortList(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            var list = new List<ushort>();
            for (int i = 0; i < count; i++)
                list.Add(ReadUShort());
            return list;
        }

        /// <summary>
        /// Read a list of ints.
        /// </summary>
        /// <param name="count">The number of ints to read.</param>
        /// <returns>A list of ints.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ints goes beyond the stream.</exception>
        public List<int> ReadIntList(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            var list = new List<int>();
            for (int i = 0; i < count; i++)
                list.Add(ReadInt());
            return list;
        }

        /// <summary>
        /// Read a list of uints.
        /// </summary>
        /// <param name="count">The number of uints to read.</param>
        /// <returns>A list of uints.</returns>
        /// <exception cref="InvalidOperationException">The requested number of uints goes beyond the stream.</exception>
        public List<uint> ReadUIntList(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            var list = new List<uint>();
            for (int i = 0; i < count; i++)
                list.Add(ReadUInt());
            return list;
        }

        /// <summary>
        /// Read a list of longs.
        /// </summary>
        /// <param name="count">The number of longs to read.</param>
        /// <returns>A list of longs.</returns>
        /// <exception cref="InvalidOperationException">The requested number of longs goes beyond the stream.</exception>
        public List<long> ReadLongList(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            var list = new List<long>();
            for (int i = 0; i < count; i++)
                list.Add(ReadLong());
            return list;
        }

        /// <summary>
        /// Read a list of ulongs.
        /// </summary>
        /// <param name="count">The number of ulongs to read.</param>
        /// <returns>A list of ulongs.</returns>
        /// <exception cref="InvalidOperationException">The requested number of ulongs goes beyond the stream.</exception>
        public List<ulong> ReadULongList(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            var list = new List<ulong>();
            for (int i = 0; i < count; i++)
                list.Add(ReadULong());
            return list;
        }

        /// <summary>
        /// Read a list of halfs.
        /// </summary>
        /// <param name="count">The number of halfs to read.</param>
        /// <returns>A list of floats.</returns>
        /// <exception cref="InvalidOperationException">The requested number of halfs goes beyond the stream.</exception>
        public List<Half> ReadHalfList(int count)
        {
            if ((count * 2) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 2} bytes; Remaining: {Remaining} bytes.");
            var list = new List<Half>();
            for (int i = 0; i < count; i++)
                list.Add(ReadHalf());
            return list;
        }

        /// <summary>
        /// Read a list of floats.
        /// </summary>
        /// <param name="count">The number of floats to read.</param>
        /// <returns>A list of floats.</returns>
        /// <exception cref="InvalidOperationException">The requested number of floats goes beyond the stream.</exception>
        public List<float> ReadFloatList(int count)
        {
            if ((count * 4) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
            var list = new List<float>();
            for (int i = 0; i < count; i++)
                list.Add(ReadFloat());
            return list;
        }

        /// <summary>
        /// Read a list of doubles.
        /// </summary>
        /// <param name="count">The number of doubles to read.</param>
        /// <returns>A list of doubles.</returns>
        /// <exception cref="InvalidOperationException">The requested number of doubles goes beyond the stream.</exception>
        public List<double> ReadDoubleList(int count)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            var list = new List<double>();
            for (int i = 0; i < count; i++)
                list.Add(ReadDouble());
            return list;
        }

        /// <summary>
        /// Read a list of decimals.
        /// </summary>
        /// <param name="count">The number of decimals to read.</param>
        /// <returns>A list of decimals.</returns>
        /// <exception cref="InvalidOperationException">The requested number of decimals goes beyond the stream.</exception>
        public List<decimal> ReadDecimalList(int count)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            var list = new List<decimal>();
            for (int i = 0; i < count; i++)
                list.Add(ReadDecimal());
            return list;
        }

        /// <summary>
        /// Read a list of booleans.
        /// </summary>
        /// <param name="count">The number of booleans to read.</param>
        /// <returns>A list of booleans.</returns>
        /// <exception cref="InvalidOperationException">The requested number of booleans goes beyond the end of the stream.</exception>
        public List<bool> ReadBoolList(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            var list = new List<bool>();
            for (int i = 0; i < count; i++)
                list.Add(ReadBool());
            return list;
        }

        /// <summary>
        /// Read a list of chars.
        /// </summary>
        /// <param name="count">The number of chars to read.</param>
        /// <returns>A list of chars.</returns>
        /// <exception cref="InvalidOperationException">The requested number of chars goes beyond the end of the stream.</exception>
        public List<char> ReadCharList(int count)
        {
            if (count > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count} bytes; Remaining: {Remaining} bytes.");
            var list = new List<char>();
            for (int i = 0; i < count; i++)
                list.Add(ReadChar());
            return list;
        }

        /// <summary>
        /// Read a list of colors.
        /// </summary>
        /// <param name="count">The number of colors to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of colors.</returns>
        /// <exception cref="InvalidOperationException">The requested number of colors goes beyond the stream.</exception>
        /// <exception cref="NotImplementedException">The requested color order does not exist or is not supported.</exception>
        public List<Color> ReadColorList(int count, ColorOrder order = ColorOrder.ARGB)
        {
            switch (order)
            {
                case ColorOrder.RGB:
                case ColorOrder.BGR:
                case ColorOrder.RGBA:
                    if ((count * 3) > Remaining)
                        throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 3} bytes; Remaining: {Remaining} bytes.");
                    break;
                case ColorOrder.BGRA:
                case ColorOrder.ARGB:
                case ColorOrder.ABGR:
                    if ((count * 4) > Remaining)
                        throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 4} bytes; Remaining: {Remaining} bytes.");
                    break;
                default:
                    throw new NotImplementedException($"The color order: {order}; Is not supported or does not exist.");
            }

            var list = new List<Color>();
            for (int i = 0; i < count; i++)
                list.Add(ReadColor(order));
            return list;
        }

        /// <summary>
        /// Read a list of vector2s.
        /// </summary>
        /// <param name="count">The number of vector2s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of vector2s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector2s goes beyond the stream.</exception>
        public List<Vector2> ReadVector2List(int count, Vector2Order order = Vector2Order.XY)
        {
            if ((count * 8) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 8} bytes; Remaining: {Remaining} bytes.");
            var list = new List<Vector2>();
            for (int i = 0; i < count; i++)
                list.Add(ReadVector2(order));
            return list;
        }

        /// <summary>
        /// Read a list of vector3s.
        /// </summary>
        /// <param name="count">The number of vector3s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of vector3s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector3s goes beyond the stream.</exception>
        public List<Vector3> ReadVector3List(int count, Vector3Order order = Vector3Order.XYZ)
        {
            if ((count * 12) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 12} bytes; Remaining: {Remaining} bytes.");
            var list = new List<Vector3>();
            for (int i = 0; i < count; i++)
                list.Add(ReadVector3(order));
            return list;
        }

        /// <summary>
        /// Read a list of vector4s.
        /// </summary>
        /// <param name="count">The number of vector4s to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of vector4s.</returns>
        /// <exception cref="InvalidOperationException">The requested number of vector4s goes beyond the stream.</exception>
        public List<Vector4> ReadVector4List(int count, Vector4Order order = Vector4Order.XYZW)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            var list = new List<Vector4>();
            for (int i = 0; i < count; i++)
                list.Add(ReadVector4(order));
            return list;
        }

        /// <summary>
        /// Read a list of quaternions.
        /// </summary>
        /// <param name="count">The number of quaternions to read.</param>
        /// <param name="order">The order they should be read in.</param>
        /// <returns>A list of quaternions.</returns>
        /// <exception cref="InvalidOperationException">The requested number of quaternions goes beyond the stream.</exception>
        public List<Quaternion> ReadQuaternionList(int count, Vector4Order order = Vector4Order.XYZW)
        {
            if ((count * 16) > Remaining)
                throw new InvalidOperationException($"Cannot read beyond the end of the stream; Requested: {count * 16} bytes; Remaining: {Remaining} bytes.");
            var list = new List<Quaternion>();
            for (int i = 0; i < count; i++)
                list.Add(ReadQuaternion(order));
            return list;
        }
    }
}