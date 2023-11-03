namespace SimpleBinary
{
    public partial class SimpleBinaryStream
    {
        /// <summary>
        /// Step into the current position.
        /// </summary>
        public void StepIn()
        {
            Steps.Push(Position);
        }

        /// <summary>
        /// Step into the specified position.
        /// </summary>
        /// <param name="position">The position to step into.</param>
        public void StepIn(long position)
        {
            Position = position;
            Steps.Push(position);
        }

        /// <summary>
        /// Step back out of the last stepped in position.
        /// </summary>
        /// <exception cref="InvalidOperationException">The stream was already all the way stepped out.</exception>
        public void StepOut()
        {
            if (Steps.Count == 0)
                throw new InvalidOperationException("The stream is already all the way stepped out.");
            Position = Steps.Pop();
        }

        /// <summary>
        /// Step out the specified number of times.
        /// </summary>
        /// <param name="count">The number of times to step out.</param>
        /// <exception cref="InvalidOperationException">The number of times to step out exceeds the number of steps.</exception>
        public void StepOut(long count)
        {
            if (count > Steps.Count)
                throw new InvalidOperationException("The specified count to step out by is greater than the existing number of steps.");

            while (Steps.Count > Steps.Count - count - 1)
                Steps.Pop();
            Position = Steps.Pop();
        }

        /// <summary>
        /// Step out of all the previously stepped in positions. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The stream was already all the way stepped out.</exception>
        public void StepOutAll()
        {
            if (Steps.Count == 0)
                throw new InvalidOperationException("The stream is already all the way stepped out.");

            while (Steps.Count > 1)
                Steps.Pop();
            Position = Steps.Pop();
        }

        /// <summary>
        /// Clear all existing steps without changing position.
        /// </summary>
        public void ClearSteps()
        {
            Steps.Clear();
        }
    }
}
