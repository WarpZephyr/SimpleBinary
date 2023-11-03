using static SimpleBinary.SimpleBinaryEnum;

namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Push a length reservation depending on the current <see cref="VarintLengthType"/> onto a <see cref="Stack{T}"/> to be filled later.
        /// </summary>
        public void ReserveOffset()
        {
            Offsets.Push(KeyValuePair.Create(VarintLength, Position));
            WritePattern(VarintLength, 0xFE);
        }

        /// <summary>
        /// Fill an offset reservation depending on the <see cref="VarintLengthType"/> it was previously set to.
        /// </summary>
        public void FillOffset()
        {
            if (Offsets.Count == 0)
                throw new InvalidOperationException($"There are no offset reservations to fill.");

            var pair = Lengths.Pop();
            long currentLength = VarintLength;
            SetVarintLength(pair.Key);

            long end = Position;
            SimpleBinaryStream.StepIn(pair.Value);
            WriteVarint(end);
            SimpleBinaryStream.StepOut();

            SetVarintLength(currentLength);
        }
    }
}
