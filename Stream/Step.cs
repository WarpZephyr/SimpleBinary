namespace SimpleStream
{
    public partial class SimplerStream
    {
        /// <summary>
        /// Step into the specified position.
        /// </summary>
        /// <param name="position">The position to step into.</param>
        public void StepIn(long position)
        {
            SetPosition(position);
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
            SetPosition(Steps.Pop());
        }

        /// <summary>
        /// Step out of all the previously stepped in positions, stepping out of the first stepped in position. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The stream was already all the way stepped out.</exception>
        public void StepOutAll()
        {
            if (Steps.Count == 0)
                throw new InvalidOperationException("The stream is already all the way stepped out.");

            while (Steps.Count > 1)
                Steps.Pop();
            SetPosition(Steps.Pop());
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
            SetPosition(Steps.Pop());
        }

        /// <summary>
        /// Clear all existing steps without changing position.
        /// </summary>
        public void ClearSteps()
        {
            Steps.Clear();
        }
    }

    public partial class SimpleReader
    {
        /// <summary>
        /// Step into the specified position.
        /// </summary>
        /// <param name="position">The position to step into.</param>
        public void StepIn(long position)
        {
            SimplerStream.StepIn(position);
        }

        /// <summary>
        /// Step back out of the last stepped in position.
        /// </summary>
        public void StepOut()
        {
            SimplerStream.StepOut();
        }

        /// <summary>
        /// Step out of all the previously stepped in positions, stepping out of the first stepped in position. 
        /// </summary>
        public void StepOutAll()
        {
            SimplerStream.StepOutAll();
        }

        /// <summary>
        /// Step out the specified number of times.
        /// </summary>
        /// <param name="count">The number of times to step out.</param>
        public void StepOut(long count)
        {
            SimplerStream.StepOut(count);
        }

        /// <summary>
        /// Clear all existing steps without changing position.
        /// </summary>
        public void ClearSteps()
        {
            SimplerStream.ClearSteps();
        }
    }

    public partial class SimpleWriter
    {
        /// <summary>
        /// Step into the specified position.
        /// </summary>
        /// <param name="position">The position to step into.</param>
        public void StepIn(long position)
        {
            SimplerStream.StepIn(position);
        }

        /// <summary>
        /// Step back out of the last stepped in position.
        /// </summary>
        public void StepOut()
        {
            SimplerStream.StepOut();
        }

        /// <summary>
        /// Step out of all the previously stepped in positions, stepping out of the first stepped in position. 
        /// </summary>
        public void StepOutAll()
        {
            SimplerStream.StepOutAll();
        }

        /// <summary>
        /// Step out the specified number of times.
        /// </summary>
        /// <param name="count">The number of times to step out.</param>
        public void StepOut(long count)
        {
            SimplerStream.StepOut(count);
        }

        /// <summary>
        /// Clear all existing steps without changing position.
        /// </summary>
        public void ClearSteps()
        {
            SimplerStream.ClearSteps();
        }
    }
}
