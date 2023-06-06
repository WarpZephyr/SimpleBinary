using System.Drawing;
using System.Numerics;

namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Fill a reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="typeName">The type name of the reservation.</param>
        /// <returns>The position the reservation was made at.</returns>
        /// <exception cref="ArgumentException">The key was not reserved.</exception>
        private long Fill(string name, string typeName)
        {
            name = $"{name}:{typeName}";
            if (!Reservations.TryGetValue(name, out long pos))
                throw new ArgumentException("Key is not reserved: " + name);

            Reservations.Remove(name);
            return pos;
        }

        /// <summary>
        /// Fill a reservation using the provided function.
        /// </summary>
        /// <typeparam name="T">The type the provided function writes.</typeparam>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="typename">The type name of the reservation.</param>
        /// <param name="write">A function used to write.</param>
        /// <param name="value">The value to write.</param>
        private void Fill<T>(string name, string typename, Action<T> write, T value)
        {
            StepIn(Fill(name, typename));
            write(value);
            StepOut();
        }

        public void FillByte(string name, byte value)
        {
            Fill(name, "byte", WriteByte, value);
        }

        public void FillSByte(string name, sbyte value)
        {
            Fill(name, "sbyte", WriteSByte, value);
        }

        public void FillShort(string name, short value)
        {
            Fill(name, "short", WriteShort, value);
        }

        public void FillUShort(string name, ushort value)
        {
            Fill(name, "ushort", WriteUShort, value);
        }

        public void FillInt(string name, int value)
        {
            Fill(name, "int", WriteInt, value);
        }

        public void FillUInt(string name, uint value)
        {
            Fill(name, "int", WriteUInt, value);
        }

        public void FillLong(string name, long value)
        {
            Fill(name, "long", WriteLong, value);
        }

        public void FillULong(string name, ulong value)
        {
            Fill(name, "ulong", WriteULong, value);
        }

        public void FillHalf(string name, Half value)
        {
            Fill(name, "Half", WriteHalf, value);
        }

        public void FillFloat(string name, float value)
        {
            Fill(name, "float", WriteFloat, value);
        }

        public void FillDouble(string name, double value)
        {
            Fill(name, "double", WriteDouble, value);
        }

        public void FillDecimal(string name, decimal value)
        {
            Fill(name, "decimal", WriteDecimal, value);
        }

        public void FillChar(string name, char value)
        {
            Fill(name, "char", WriteChar, value);
        }

        public void FillBool(string name, bool value)
        {
            Fill(name, "bool", WriteBool, value);
        }

        public void FillVarint(string name, long value)
        {
            Fill(name, $"Varint_{VarintLength}", WriteVarint, value);
        }

        public void FillColor(string name, Color value, SimpleEnum.ColorOrder order)
        {
            string orderstr = $"{(order.IsColor3() ? "Color3" : (order.IsColor4() ? "Color4" : throw new NotSupportedException($"The color order: {order} is not supported or does not exist.")))}";
            Fill(name, orderstr, (value) => WriteColor(value, order), value);
        }

        public void FillVector3(string name, Vector3 value, SimpleEnum.Vector3Order order)
        {
            Fill(name, "Vector3", (value) => WriteVector3(value, order), value);
        }

        public void FillVector4(string name, Vector4 value, SimpleEnum.Vector4Order order)
        {
            Fill(name, "Vector4", (value) => WriteVector4(value, order), value);
        }

        public void FillQuaternion(string name, Quaternion value, SimpleEnum.Vector4Order order)
        {
            Fill(name, "Quaternion", (value) => WriteQuaternion(value, order), value);
        }
    }
}
