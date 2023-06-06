using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Reserve an array to fill later with the provided function.
        /// </summary>
        /// <param name="reserve">A function that does individual reservations</param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        private void ReserveArray(Action<string> reserve, string name, long count)
        {
            for (int i = 0; i < count; i++)
                reserve($"{name}_{i}");
        }

        /// <summary>
        /// Reserve multiple sbytes to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of sbytes to reserve.</param>
        public void ReserveSBytes(string name, long count)
        {
            ReserveArray(ReserveSByte, name, count);
        }

        /// <summary>
        /// Reserve multiple bytes to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of bytes to reserve.</param>
        public void ReserveBytes(string name, long count)
        {
            ReserveArray(ReserveByte, name, count);
        }

        /// <summary>
        /// Reserve multiple shorts to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of shorts to reserve.</param>
        public void ReserveShorts(string name, long count)
        {
            ReserveArray(ReserveShort, name, count);
        }

        /// <summary>
        /// Reserve multiple ushorts to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of ushorts to reserve.</param>
        public void ReserveUShorts(string name, long count)
        {
            ReserveArray(ReserveUShort, name, count);
        }

        /// <summary>
        /// Reserve multiple ints to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of ints to reserve.</param>
        public void ReserveInts(string name, long count)
        {
            ReserveArray(ReserveInt, name, count);
        }

        /// <summary>
        /// Reserve multiple uints to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of uints to reserve.</param>
        public void ReserveUInts(string name, long count)
        {
            ReserveArray(ReserveUInt, name, count);
        }

        /// <summary>
        /// Reserve multiple longs to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of longs to reserve.</param>
        public void ReserveLongs(string name, long count)
        {
            ReserveArray(ReserveLong, name, count);
        }

        /// <summary>
        /// Reserve multiple ulongs to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of ulongs to reserve.</param>
        public void ReserveULongs(string name, long count)
        {
            ReserveArray(ReserveULong, name, count);
        }

        /// <summary>
        /// Reserve multiple Halfs to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of Halfs to reserve.</param>
        public void ReserveHalfs(string name, long count)
        {
            ReserveArray(ReserveHalf, name, count);
        }

        /// <summary>
        /// Reserve multiple floats to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of floats to reserve.</param>
        public void ReserveFloats(string name, long count)
        {
            ReserveArray(ReserveFloat, name, count);
        }

        /// <summary>
        /// Reserve multiple doubles to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of doubles to reserve.</param>
        public void ReserveDoubles(string name, long count)
        {
            ReserveArray(ReserveDouble, name, count);
        }

        /// <summary>
        /// Reserve multiple decimals to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of decimals to reserve.</param>
        public void ReserveDecimals(string name, long count)
        {
            ReserveArray(ReserveDecimal, name, count);
        }

        /// <summary>
        /// Reserve multiple chars to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of chars to reserve.</param>
        public void ReserveChars(string name, long count)
        {
            ReserveArray(ReserveChar, name, count);
        }

        /// <summary>
        /// Reserve multiple bools to fill later by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of bools to reserve.</param>
        public void ReserveBools(string name, long count)
        {
            ReserveArray(ReserveBool, name, count);
        }

        /// <summary>
        /// Reserve multiple Varints to fill later depending on the current VarintLength by adding "_index" to the reservation.
        /// </summary>
        /// <param name="name">The name to reservation.</param>
        /// <param name="count">The number of Varints to reserve.</param>
        public void ReserveVarints(string name, long count)
        {
            ReserveArray(ReserveVarint, name, count);
        }
    }
}
