using System.Drawing;
using System.Numerics;

namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Make a reservation with a name, type name, and length of how many bytes to reserve.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        /// <param name="typename">The name of the type of the reservation.</param>
        /// <param name="length">The length of the reservation in bytes.</param>
        /// <exception cref="ArgumentException">The reservation already exists.</exception>
        private void Reserve(string name, string typename, long length)
        {
            name = $"{name}:{typename}";
            if (Reservations.ContainsKey(name))
                throw new ArgumentException("Key already reserved: " + name);

            Reservations[name] = Position;
            WritePattern(length, 0xFE);
        }

        /// <summary>
        /// Reserve an <see cref="sbyte" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveSByte(string name)
        {
            Reserve(name, "sbyte", 1);
        }

        /// <summary>
        /// Reserve a <see cref="byte" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveByte(string name)
        {
            Reserve(name, "byte", 1);
        }

        /// <summary>
        /// Reserve a <see cref="short" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveShort(string name)
        {
            Reserve(name, "short", 2);
        }

        /// <summary>
        /// Reserve a <see cref="ushort" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveUShort(string name)
        {
            Reserve(name, "ushort", 2);
        }

        /// <summary>
        /// Reserve an <see cref="int" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveInt(string name)
        {
            Reserve(name, "int", 4);
        }

        /// <summary>
        /// Reserve a <see cref="uint" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveUInt(string name)
        {
            Reserve(name, "uint", 4);
        }

        /// <summary>
        /// Reserve a <see cref="long" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveLong(string name)
        {
            Reserve(name, "long", 8);
        }

        /// <summary>
        /// Reserve a <see cref="ulong" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveULong(string name)
        {
            Reserve(name, "ulong", 8);
        }

        /// <summary>
        /// Reserve a <see cref="Half" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveHalf(string name)
        {
            Reserve(name, "Half", 2);
        }

        /// <summary>
        /// Reserve a <see cref="float" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveFloat(string name)
        {
            Reserve(name, "float", 4);
        }

        /// <summary>
        /// Reserve a <see cref="double" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveDouble(string name)
        {
            Reserve(name, "double", 8);
        }

        /// <summary>
        /// Reserve a <see cref="decimal" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveDecimal(string name)
        {
            Reserve(name, "decimal", 16);
        }

        /// <summary>
        /// Reserve a <see cref="char" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveChar(string name)
        {
            Reserve(name, "char", 1);
        }

        /// <summary>
        /// Reserve a <see cref="bool" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveBool(string name)
        {
            Reserve(name, "bool", 1);
        }

        /// <summary>
        /// Reserve a Varint to fill later depending on the current VarintLength.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveVarint(string name)
        {
            Reserve(name, $"Varint_{VarintLength}", VarintLength);
        }

        /// <summary>
        /// Reserve a <see cref="Color" /> that does not use Alpha to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveColor3(string name)
        {
            Reserve(name, "Color3", 3);
        }

        /// <summary>
        /// Reserve a <see cref="Color" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveColor4(string name)
        {
            Reserve(name, "Color4", 4);
        }

        /// <summary>
        /// Reserve a <see cref="Vector2" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveVector2(string name)
        {
            Reserve(name, "Vector2", 8);
        }

        /// <summary>
        /// Reserve a <see cref="Vector3" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveVector3(string name)
        {
            Reserve(name, "Vector3", 12);
        }

        /// <summary>
        /// Reserve a <see cref="Vector4" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveVector4(string name)
        {
            Reserve(name, "Vector4", 16);
        }

        /// <summary>
        /// Reserve a <see cref="Quaternion" /> to fill later.
        /// </summary>
        /// <param name="name">The name of the reservation.</param>
        public void ReserveQuaternion(string name)
        {
            Reserve(name, "Quaternion", 16);
        }
    }
}
