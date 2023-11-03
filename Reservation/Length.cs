using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Push a length reservation depending on the current <see cref="VarintLengthType"/> onto a <see cref="Stack{T}"/> to be filled later.
        /// </summary>
        public void ReserveLength()
        {
            Lengths.Push(KeyValuePair.Create(VarintLength, Position));
            WritePattern(VarintLength, 0xFE);
        }

        /// <summary>
        /// Fill a length reservation depending on the <see cref="VarintLengthType"/> it was previously set to.
        /// </summary>
        public void FillLength()
        {
            if (Lengths.Count == 0)
                throw new InvalidOperationException($"There are no length reservations to fill.");

            var pair = Lengths.Pop();
            long currentLength = VarintLength;
            SetVarintLength(pair.Key);

            long start = pair.Value;
            long end = Position;
            SimpleBinaryStream.StepIn(start);
            WriteVarint(end - start);
            SimpleBinaryStream.StepOut();

            SetVarintLength(currentLength);
        }
    }
}
