namespace SimpleStream
{
    public partial class SimpleWriter
    {
        /// <summary>
        /// Push a length reservation depending on the current VarintType onto a stack to be filled later.
        /// </summary>
        public void ReserveOffset()
        {
            Offsets.Add(VarintLength, Position);
            WritePattern(VarintLength, 0xFE);
        }

        /// <summary>
        /// Fill an offset reservation depending on the VarintType it was previously set to.
        /// </summary>
        public void FillOffset()
        {
            if (Offsets.Count == 0)
                throw new InvalidOperationException($"There are no offset reservations to fill.");

            var pair = Lengths.Last();
            long currentLength = VarintLength;
            SetVarintLength(pair.Key);

            long end = Position;
            StepIn(pair.Value);
            WriteVarint(end);
            StepOut();

            SetVarintLength(currentLength);
        }
    }
}
