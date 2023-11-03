namespace SimpleBinary
{
    public partial class SimpleBinaryWriter
    {
        /// <summary>
        /// Push a length reservation depending on the current VarintType onto a stack to be filled later.
        /// </summary>
        public void ReserveLength()
        {
            Lengths.Add(VarintLength, Position);
            WritePattern(VarintLength, 0xFE);
        }

        /// <summary>
        /// Fill a length reservation depending on the VarintType it was previously set to.
        /// </summary>
        public void FillLength()
        {
            if (Lengths.Count == 0)
                throw new InvalidOperationException($"There are no length reservations to fill.");

            var pair = Lengths.Last();
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
