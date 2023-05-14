using System.Drawing;
using System.Numerics;
using System.Text;
using static SimpleStream.SimpleEnum;

namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Write an array of sbytes.
        /// </summary>
        /// <param name="values">The sbytes to write.</param>
        public void WriteSBytes(IList<sbyte> values)
        {
            foreach (sbyte value in values)
                WriteSByte(value);
        }

        /// <summary>
        /// Write an array of bytes.
        /// </summary>
        /// <param name="bytes">The bytes to write.</param>
        public void WriteBytes(byte[] bytes)
        {
            byte[] store = bytes;
            if (BigEndian) 
                Array.Reverse(store);
            Writer.Write(bytes);
        }

        /// <summary>
        /// Write an array of bytes.
        /// </summary>
        /// <param name="values">The bytes to write.</param>
        public void WriteBytes(IList<byte> values)
        {
            foreach (byte value in values)
                WriteByte(value);
        }

        /// <summary>
        /// Write an array of shorts.
        /// </summary>
        /// <param name="values">The shorts to write.</param>
        public void Write(IList<short> values)
        {
            WriteShorts(values);
        }

        /// <summary>
        /// Write an array of shorts.
        /// </summary>
        /// <param name="values">The shorts to write.</param>
        public void WriteShorts(IList<short> values)
        {
            foreach (var value in values)
                WriteShort(value);
        }

        /// <summary>
        /// Write an array of shorts.
        /// </summary>
        /// <param name="values">The ushorts to write.</param>
        public void WriteUShorts(IList<ushort> values)
        {
            foreach (var value in values)
                WriteUShort(value);
        }

        /// <summary>
        /// Write an array of ints.
        /// </summary>
        /// <param name="values">The ints to write.</param>
        public void WriteInts(IList<int> values)
        {
            foreach (var value in values)
                WriteInt(value);
        }

        /// <summary>
        /// Write an array of uints.
        /// </summary>
        /// <param name="values">The ints to write.</param>
        public void WriteUInts(IList<uint> values)
        {
            foreach (var value in values)
                WriteUInt(value);
        }

        /// <summary>
        /// Write an array of longs.
        /// </summary>
        /// <param name="values">The longs to write.</param>
        public void WriteLongs(IList<long> values)
        {
            foreach (var value in values)
                WriteLong(value);
        }

        /// <summary>
        /// Write an array of ulongs.
        /// </summary>
        /// <param name="values">The ulongs to write.</param>
        public void WriteULongs(IList<ulong> values)
        {
            foreach (var value in values)
                WriteULong(value);
        }

        /// <summary>
        /// Write an array of halfs.
        /// </summary>
        /// <param name="values">The halfs to write.</param>
        public void WriteHalfs(IList<Half> values)
        {
            foreach (var value in values)
                WriteHalf(value);
        }

        /// <summary>
        /// Write an array of floats.
        /// </summary>
        /// <param name="values">The floats to write.</param>
        public void WriteFloats(IList<float> values)
        {
            foreach (var value in values)
                WriteFloat(value);
        }

        /// <summary>
        /// Write an array of doubles.
        /// </summary>
        /// <param name="values">The doubles to write.</param>
        public void WriteDoubles(IList<double> values)
        {
            foreach (var value in values)
                WriteDouble(value);
        }

        /// <summary>
        /// Write an array of decimals.
        /// </summary>
        /// <param name="values">The decimals to write.</param>
        public void WriteDecimals(IList<decimal> values)
        {
            foreach (var value in values)
                WriteDecimal(value);
        }

        /// <summary>
        /// Write an array of varints.
        /// </summary>
        /// <param name="values">The values to write as varints.</param>
        public void WriteVarints(IList<long> values)
        {
            foreach (var value in values)
                WriteVarint(value);
        }

        /// <summary>
        /// Write an array of 7-bit encoded ints.
        /// </summary>
        /// <param name="values">The ints to write.</param>
        public void Write7BitEncodedInts(IList<int> values)
        {
            foreach (var value in values)
                Write7BitEncodedInt(value);
        }

        /// <summary>
        /// Write an array of 7-bit encoded longs.
        /// </summary>
        /// <param name="values">The longs to write.</param>
        public void Write7BitEncodedLongs(IList<long> values)
        {
            foreach (var value in values)
                Write7BitEncodedLong(value);
        }

        /// <summary>
        /// Write an array of bools.
        /// </summary>
        /// <param name="values">The bools to write.</param>
        public void WriteBools(IList<bool> values)
        {
            foreach (var value in values)
                WriteBool(value);
        }

        /// <summary>
        /// Write an array of chars.
        /// </summary>
        /// <param name="values">The chars to write.</param>
        public void WriteChars(IList<char> values)
        {
            foreach (var value in values)
                WriteChar(value);
        }

        /// <summary>
        /// Write an array of colors.
        /// </summary>
        /// <param name="values">The colors to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteColors(IList<Color> values, ColorOrder order = ColorOrder.ARGB)
        {
            foreach (var value in values)
                WriteColor(value, order);
        }

        /// <summary>
        /// Write an array of vector2s.
        /// </summary>
        /// <param name="values">The vector2s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector2s(IList<Vector2> values, Vector2Order order = Vector2Order.XY)
        {
            foreach (var value in values)
                WriteVector2(value, order);
        }  

        /// <summary>
        /// Write an array of vector3s.
        /// </summary>
        /// <param name="values">The vector3s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector3s(IList<Vector3> values, Vector3Order order = Vector3Order.XYZ)
        {
            foreach (var value in values)
                WriteVector3(value, order);
        }

        /// <summary>
        /// Write an array of vector4s.
        /// </summary>
        /// <param name="values">The vector4s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVector4s(IList<Vector4> values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteVector4(value, order);
        }

        /// <summary>
        /// Write an array of quaternions.
        /// </summary>
        /// <param name="values">The quaternions to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteQuaternions(IList<Quaternion> values, Vector4Order order = Vector4Order.XYZW)
        {
            foreach (var value in values)
                WriteQuaternion(value, order);
        }

        /// <summary>
        /// Write an ASCII string that has a null terminator.
        /// </summary>
        /// <param name="value">The string to write.</param>
        public void WriteString(string value)
        {
            WriteString(value, SimpleEncoding.ASCII, true);
        }

        /// <summary>
        /// Write an ASCII string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteString(string value, bool terminate = true)
        {
            WriteString(value, SimpleEncoding.ASCII, terminate);
        }

        /// <summary>
        /// Write a string with specified encoding and termination.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="encoding">The encoding of the string being written.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteString(string value, Encoding encoding, bool terminate = false)
        {
            if (terminate)
                value += '\0';
            byte[] bytes = encoding.GetBytes(value);
            Writer.Write(bytes);
        }

        /// <summary>
        /// Write an ASCII string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteASCII(string value, bool terminate = false)
        {
            WriteString(value, SimpleEncoding.ASCII, terminate);
        }

        /// <summary>
        /// Write a Japanese Shift-JIS string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteJapanese(string value, bool terminate = false)
        {
            WriteShiftJIS(value, terminate);
        }

        /// <summary>
        /// Write a fixed-size Japanese Shift-JIS string with a null terminator.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void WriteFixedJapanese(string value, int size, byte padding = 0)
        {
            WriteFixedShiftJIS(value, size, padding);
        }

        /// <summary>
        /// Write a Japanese Shift-JIS string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteShiftJIS(string value, bool terminate = false)
        {
            WriteString(value, SimpleEncoding.ShiftJIS, terminate);
        }

        /// <summary>
        /// Write a fixed-size Japanese Shift-JIS string with a null terminator.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void WriteFixedShiftJIS(string value, int size, byte padding = 0)
        {
            WriteFixedString(value, SimpleEncoding.ShiftJIS, size, padding);
        }

        /// <summary>
        /// Write a Japanese EUC-JP string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteEucJP(string value, bool terminate = false)
        {
            WriteString(value, SimpleEncoding.EucJP, terminate);
        }

        /// <summary>
        /// Write a Chinese simplified EUC-CN string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteEucCn(string value, bool terminate = false)
        {
            WriteString(value, SimpleEncoding.EucCN, terminate);
        }

        /// <summary>
        /// Write a Korean EUC-JP string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteEucKR(string value, bool terminate = false)
        {
            WriteString(value, SimpleEncoding.EucKR, terminate);
        }

        /// <summary>
        /// Write a UTF-16 string with a null terminator if specified.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void WriteUTF16(string value, bool terminate = false)
        {
            if (BigEndian)
                WriteString(value, SimpleEncoding.UTF16BE, terminate);
            else
                WriteString(value, SimpleEncoding.UTF16, terminate);
        }

        /// <summary>
        /// Write a null-terminated ACSII string in a fixed-size field.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void WriteFixedString(string value, int size, byte padding = 0)
        {
            byte[] fixstr = new byte[size];
            for (int i = 0; i < size; i++)
                fixstr[i] = padding;

            byte[] bytes = SimpleEncoding.ASCII.GetBytes(value + '\0');
            Array.Copy(bytes, fixstr, Math.Min(size, bytes.Length));
            Writer.Write(fixstr);
        }

        /// <summary>
        /// Write a null-terminated string in a fixed-size field with the specified encoding.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="encoding">The encoding to write the string in.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void WriteFixedString(string value, Encoding encoding, int size, byte padding = 0)
        {
            byte[] fixstr = new byte[size];
            for (int i = 0; i < size; i++)
                fixstr[i] = padding;

            byte[] bytes = encoding.GetBytes(value + '\0');
            Array.Copy(bytes, fixstr, Math.Min(size, bytes.Length));
            Writer.Write(fixstr);
        }

        /// <summary>
        /// Write a null-terminated UTF-16 string in a fixed-size field.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void WriteFixedStringWide(string value, int size, byte padding = 0)
        {
            byte[] fixstr = new byte[size];
            for (int i = 0; i < size; i++)
                fixstr[i] = padding;

            byte[] bytes;
            if (BigEndian)
                bytes = SimpleEncoding.UTF16BE.GetBytes(value + '\0');
            else
                bytes = SimpleEncoding.UTF16.GetBytes(value + '\0');
            Array.Copy(bytes, fixstr, Math.Min(size, bytes.Length));
            Writer.Write(fixstr);
        }

        /// <summary>
        /// Write an array of sbytes.
        /// </summary>
        /// <param name="values">The sbytes to write.</param>
        public void Write(IList<sbyte> values)
        {
            WriteSBytes(values);
        }

        /// <summary>
        /// Write an array of bytes.
        /// </summary>
        /// <param name="bytes">The bytes to write.</param>
        public void Write(byte[] bytes)
        {
            WriteBytes(bytes);
        }

        /// <summary>
        /// Write an array of bytes.
        /// </summary>
        /// <param name="values">The bytes to write.</param>
        public void Write(IList<byte> values)
        {
            WriteBytes(values);
        }

        /// <summary>
        /// Write an array of shorts.
        /// </summary>
        /// <param name="values">The ushorts to write.</param>
        public void Write(IList<ushort> values)
        {
            WriteUShorts(values);
        }

        /// <summary>
        /// Write an array of ints.
        /// </summary>
        /// <param name="values">The ints to write.</param>
        public void Write(IList<int> values)
        {
            WriteInts(values);
        }

        /// <summary>
        /// Write an array of uints.
        /// </summary>
        /// <param name="values">The ints to write.</param>
        public void Write(IList<uint> values)
        {
            WriteUInts(values);
        }

        /// <summary>
        /// Write an array of longs.
        /// </summary>
        /// <param name="values">The longs to write.</param>
        public void Write(IList<long> values)
        {
            WriteLongs(values);
        }

        /// <summary>
        /// Write an array of ulongs.
        /// </summary>
        /// <param name="values">The ulongs to write.</param>
        public void Write(IList<ulong> values)
        {
            WriteULongs(values);
        }

        /// <summary>
        /// Write an array of halfs.
        /// </summary>
        /// <param name="values">The halfs to write.</param>
        public void Write(IList<Half> values)
        {
            WriteHalfs(values);
        }

        /// <summary>
        /// Write an array of floats.
        /// </summary>
        /// <param name="values">The floats to write.</param>
        public void Write(IList<float> values)
        {
            WriteFloats(values);
        }

        /// <summary>
        /// Write an array of doubles.
        /// </summary>
        /// <param name="values">The doubles to write.</param>
        public void Write(IList<double> values)
        {
            WriteDoubles(values);
        }

        /// <summary>
        /// Write an array of decimals.
        /// </summary>
        /// <param name="values">The decimals to write.</param>
        public void Write(IList<decimal> values)
        {
            WriteDecimals(values);
        }

        /// <summary>
        /// Write an array of bools.
        /// </summary>
        /// <param name="values">The bools to write.</param>
        public void Write(IList<bool> values)
        {
            WriteBools(values);
        }

        /// <summary>
        /// Write an array of chars.
        /// </summary>
        /// <param name="values">The chars to write.</param>
        public void Write(IList<char> values)
        {
            WriteChars(values);
        }

        /// <summary>
        /// Write an array of colors.
        /// </summary>
        /// <param name="values">The colors to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void Write(IList<Color> values, ColorOrder order = ColorOrder.ARGB)
        {
            WriteColors(values, order);
        }

        /// <summary>
        /// Write an array of vector2s.
        /// </summary>
        /// <param name="values">The vector2s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void Write(IList<Vector2> values, Vector2Order order = Vector2Order.XY)
        {
            WriteVector2s(values, order);
        }

        /// <summary>
        /// Write an array of vector3s.
        /// </summary>
        /// <param name="values">The vector3s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void Write(IList<Vector3> values, Vector3Order order = Vector3Order.XYZ)
        {
            WriteVector3s(values, order);
        }

        /// <summary>
        /// Write an array of vector4s.
        /// </summary>
        /// <param name="values">The vector4s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void Write(IList<Vector4> values, Vector4Order order = Vector4Order.XYZW)
        {
            WriteVector4s(values, order);
        }

        /// <summary>
        /// Write an array of quaternions.
        /// </summary>
        /// <param name="values">The quaternions to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void Write(IList<Quaternion> values, Vector4Order order = Vector4Order.XYZW)
        {
            WriteQuaternions(values, order);
        }

        /// <summary>
        /// Write a string with specified encoding and termination.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="encoding">The encoding to write the string in.</param>
        /// <param name="terminate">Whether or not to add a null terminator to the written string.</param>
        public void Write(string value, Encoding encoding, bool terminate = false)
        {
            WriteString(value, encoding, terminate);
        }

        /// <summary>
        /// Write a fixed string with the specified encoding and size.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <param name="size">The size of the string to write.</param>
        /// <param name="encoding">The encoding to write the string in.</param>
        /// <param name="padding">The padding to add to the written string.</param>
        public void Write(string value, Encoding encoding, int size, byte padding = 0)
        {
            WriteFixedString(value, encoding, size, padding);
        }

        /// <summary>
        /// Write an array of vector2s.
        /// </summary>
        /// <param name="values">The vector2s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVectors(IList<Vector2> values, Vector2Order order = Vector2Order.XY)
        {
            WriteVector2s(values, order);
        }

        /// <summary>
        /// Write an array of vector3s.
        /// </summary>
        /// <param name="values">The vector3s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVectors(IList<Vector3> values, Vector3Order order = Vector3Order.XYZ)
        {
            WriteVector3s(values, order);
        }

        /// <summary>
        /// Write an array of vector4s.
        /// </summary>
        /// <param name="values">The vector4s to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVectors(IList<Vector4> values, Vector4Order order = Vector4Order.XYZW)
        {
            WriteVector4s(values, order);
        }

        /// <summary>
        /// Write an array of quaternions.
        /// </summary>
        /// <param name="values">The quaternions to write.</param>
        /// <param name="order">The order they should be written in.</param>
        public void WriteVectors(IList<Quaternion> values, Vector4Order order = Vector4Order.XYZW)
        {
            WriteQuaternions(values, order);
        }
    }
}