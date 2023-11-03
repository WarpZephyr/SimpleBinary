using System.Drawing;
using System.Numerics;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
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
            SimpleBinaryStream.StepIn(Fill(name, typename));
            write(value);
            SimpleBinaryStream.StepOut();
        }

        /// <summary>
        /// Fill a <see cref="byte" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillByte(string name, byte value)
        {
            Fill(name, "byte", WriteByte, value);
        }

        /// <summary>
        /// Fill an <see cref="sbyte" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillSByte(string name, sbyte value)
        {
            Fill(name, "sbyte", WriteSByte, value);
        }

        /// <summary>
        /// Fill a <see cref="short" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillShort(string name, short value)
        {
            Fill(name, "short", WriteShort, value);
        }

        /// <summary>
        /// Fill a <see cref="ushort" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillUShort(string name, ushort value)
        {
            Fill(name, "ushort", WriteUShort, value);
        }

        /// <summary>
        /// Fill an <see cref="int" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillInt(string name, int value)
        {
            Fill(name, "int", WriteInt, value);
        }

        /// <summary>
        /// Fill a <see cref="uint" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillUInt(string name, uint value)
        {
            Fill(name, "int", WriteUInt, value);
        }

        /// <summary>
        /// Fill a <see cref="long" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillLong(string name, long value)
        {
            Fill(name, "long", WriteLong, value);
        }

        /// <summary>
        /// Fill a <see cref="ulong" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillULong(string name, ulong value)
        {
            Fill(name, "ulong", WriteULong, value);
        }

        /// <summary>
        /// Fill a <see cref="Half" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillHalf(string name, Half value)
        {
            Fill(name, "Half", WriteHalf, value);
        }

        /// <summary>
        /// Fill a <see cref="float" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillFloat(string name, float value)
        {
            Fill(name, "float", WriteFloat, value);
        }

        /// <summary>
        /// Fill a <see cref="double" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillDouble(string name, double value)
        {
            Fill(name, "double", WriteDouble, value);
        }

        /// <summary>
        /// Fill a <see cref="decimal" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillDecimal(string name, decimal value)
        {
            Fill(name, "decimal", WriteDecimal, value);
        }

        /// <summary>
        /// Fill a <see cref="char" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillChar(string name, char value)
        {
            Fill(name, "char", WriteChar, value);
        }

        /// <summary>
        /// Fill a <see cref="bool" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillBool(string name, bool value)
        {
            Fill(name, "bool", WriteBool, value);
        }

        /// <summary>
        /// Fill a Varint reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillVarint(string name, long value)
        {
            Fill(name, $"Varint_{VarintLength}", WriteVarint, value);
        }

        /// <summary>
        /// Fill an unsigned Varint reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillUnsignedVarint(string name, ulong value)
        {
            Fill(name, $"Unsigned_Varint_{VarintLength}", WriteUnsignedVarint, value);
        }

        /// <summary>
        /// Fill a <see cref="Vector2" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillVector2(string name, Vector2 value, SimpleBinaryEnum.Vector2Order order)
        {
            Fill(name, "Vector2", (value) => WriteVector2(value, order), value);
        }

        /// <summary>
        /// Fill a <see cref="Vector3" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillVector3(string name, Vector3 value, SimpleBinaryEnum.Vector3Order order)
        {
            Fill(name, "Vector3", (value) => WriteVector3(value, order), value);
        }

        /// <summary>
        /// Fill a <see cref="Vector4" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillVector4(string name, Vector4 value, SimpleBinaryEnum.Vector4Order order)
        {
            Fill(name, "Vector4", (value) => WriteVector4(value, order), value);
        }

        /// <summary>
        /// Fill a <see cref="Quaternion" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillQuaternion(string name, Quaternion value, SimpleBinaryEnum.Vector4Order order)
        {
            Fill(name, "Quaternion", (value) => WriteQuaternion(value, order), value);
        }

        /// <summary>
        /// Fill a <see cref="Color" /> reservation.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="value">The value to fill at the reservation.</param>
        public void FillColor(string name, Color value, SimpleBinaryEnum.ColorOrder order)
        {
            string orderstr = $"{(order.IsColor3() ? "Color3" : (order.IsColor4() ? "Color4" : throw new NotSupportedException($"The color order: {order} is not supported or does not exist.")))}";
            Fill(name, orderstr, (value) => WriteColor(value, order), value);
        }
    }
}
