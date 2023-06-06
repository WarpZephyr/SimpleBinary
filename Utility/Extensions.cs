using System.Numerics;

namespace SimpleStream
{
    public static class Extensions
    {
        /// <summary>
        /// Get a bit from a byte.
        /// </summary>
        /// <param name="b">The byte.</param>
        /// <param name="bitNumber">The bit to get.</param>
        /// <returns>A bool indicating whether or not the bit is set to 0 or 1.</returns>
        public static bool GetBit(this byte b, int bitNumber)
        {
            return ((b >> bitNumber) & 1) != 0;
        }

        /// <summary>
        /// Convert an array of the specified type to a single string.
        /// </summary>
        /// <typeparam name="T">The type of the items in the array.</typeparam>
        /// <param name="array">The array of the specified type.</param>
        /// <returns>A string.</returns>
        public static string ArrayToString<T>(this T[] array)
        {
            string str = "";
            foreach (var item in array)
                str += $"{item?.ToString()} | ";
            return str[..^3];
        }

        /// <summary>
        /// Convert a <see cref="Vector4" /> into a <see cref="Quaternion" />
        /// </summary>
        /// <param name="vector">A <see cref="Vector4" /> </param>
        /// <returns>A <see cref="Quaternion" /></returns>
        public static Quaternion ToQuaternion(this Vector4 vector)
        {
            return new Quaternion(vector.X, vector.Y, vector.Z, vector.W);
        }

        /// <summary>
        /// Convert a <see cref="Quaternion" /> into a <see cref="Vector4" />
        /// </summary>
        /// <param name="qut">A <see cref="Quaternion" /> </param>
        /// <returns>A <see cref="Vector4" /></returns>
        public static Vector4 ToVector4(this Quaternion qut)
        {
            return new Vector4(qut.X, qut.Y, qut.Z, qut.W);
        }
    }
}