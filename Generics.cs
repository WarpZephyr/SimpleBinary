namespace SimpleBinary
{
    internal static class Generics
    {
        /// <summary>
        /// Perform an <see cref="Action{T}"/> on a <see cref="Array"/> of values.
        /// </summary>
        /// <typeparam name="T">The type of values being passed to the <see cref="Action{T}"/>.</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> to perform.</param>
        /// <param name="values">The <see cref="Array"/> of values to perform an <see cref="Action{T}"/> on.</param>
        internal static void PerformOnArray<T>(Action<T> action, T[] values)
        {
            foreach (T value in values)
                action(value);
        }

        /// <summary>
        /// Perform an <see cref="Action{T}"/> on a <see cref="List{T}"/> of values.
        /// </summary>
        /// <typeparam name="T">The type of values being passed to the <see cref="Action{T}"/>.</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> to perform.</param>
        /// <param name="values">The <see cref="List{T}"/> of values to perform an <see cref="Action{T}"/> on.</param>
        internal static void PerformOnList<T>(Action<T> action, List<T> values)
        {
            foreach (T value in values)
                action(value);
        }

        /// <summary>
        /// Perform an <see cref="Action{T}"/> on a <see cref="IList{T}"/> of values.
        /// </summary>
        /// <typeparam name="T">The type of values being passed to the <see cref="Action{T}"/>.</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> to perform.</param>
        /// <param name="values">The <see cref="IList{T}"/> of values to perform an <see cref="Action{T}"/> on.</param>
        internal static void PerformOnIList<T>(Action<T> action, IList<T> values)
        {
            foreach (T value in values)
                action(value);
        }

        /// <summary>
        /// Perform an <see cref="Action{T}"/> on a <see cref="IEnumerable{T}"/> of values.
        /// </summary>
        /// <typeparam name="T">The type of values being passed to the <see cref="Action{T}"/>.</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> to perform.</param>
        /// <param name="values">The <see cref="IEnumerable{T}"/> of values to perform on.</param>
        internal static void PerformOnIEnumerable<T>(Action<T> action, IEnumerable<T> values)
        {
            foreach (T value in values)
                action(value);
        }

        /// <summary>
        /// Perform a <see cref="Func{T[]}"/> and then optionally reverse the resulting <see cref="Array"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T[]}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T[]}"/> to perform.</param>
        /// <param name="reverse">Whether or not to reverse the resulting <see cref="Array"/>.</param>
        /// <returns>The resulting <see cref="Array"/>.</returns>
        internal static T[] PerformThenReverse<T>(Func<T[]> func, bool reverse)
        {
            T[] value = func();
            if (reverse)
                Array.Reverse(value);
            return value;
        }

        /// <summary>
        /// Perform a <see cref="Func{T}"/> the specified number of times then return the resulting <see cref="Array"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to perform.</param>
        /// <param name="count">The number of times to perform the <see cref="Func{T}"/>.</param>
        /// <returns>The resulting <see cref="Array"/>.</returns>
        internal static T[] RepeatIntoArray<T>(Func<T> func, int count)
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
                result[i] = func();
            return result;
        }

        /// <summary>
        /// Perform a <see cref="Func{T}"/> the specified number of times then return the resulting <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to perform.</param>
        /// <param name="count">The number of times to perform the <see cref="Func{T}"/>.</param>
        /// <returns>The resulting <see cref="List{T}"/>.</returns>
        internal static List<T> RepeatIntoList<T>(Func<T> func, int count)
        {
            List<T> result = new List<T>(count);
            for (int i = 0; i < count; i++)
                result[i] = func();
            return result;
        }

        /// <summary>
        /// Perform a <see cref="Func{T}"/> the specified number of times then return the resulting <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to perform.</param>
        /// <param name="count">The number of times to perform the <see cref="Func{T}"/>.</param>
        /// <returns>The resulting <see cref="IList{T}"/>.</returns>
        internal static IList<T> RepeatIntoIList<T>(Func<T> func, int count)
        {
            IList<T> result = new List<T>(count);
            for (int i = 0; i < count; i++)
                result[i] = func();
            return result;
        }

        /// <summary>
        /// Perform a <see cref="Func{T}"/> the specified number of times then return the resulting <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to perform.</param>
        /// <param name="count">The number of times to perform the <see cref="Func{T}"/>.</param>
        /// <returns>The resulting <see cref="IEnumerable{T}"/>.</returns>
        internal static IEnumerable<T> RepeatIntoIEnumerable<T>(Func<T> func, int count)
        {
            List<T> result = new List<T>(count);
            for (int i = 0; i < count; i++)
                result[i] = func();
            return result;
        }

        /// <summary>
        /// Perform a <see cref="Func{T}"/> the specified number of times then return the resulting <see cref="Stack{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of value being returned by the <see cref="Func{T}"/>.</typeparam>
        /// <param name="func">The <see cref="Func{T}"/> to perform.</param>
        /// <param name="count">The number of times to perform the <see cref="Func{T}"/>.</param>
        /// <returns>The resulting <see cref="Stack{T}"/>.</returns>
        internal static Stack<T> RepeatIntoStack<T>(Func<T> func, int count)
        {
            Stack<T> result = new(count);
            for (int i = 0; i < count; i++)
                result.Push(func());
            return result;
        }

        /// <summary>
        /// Convert a value to an <see cref="Enum"/> and throw if the value is not present in the <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <typeparam name="TValue">The type of the value to parse.</typeparam>
        /// <param name="value">The value to parse as the given <see cref="Enum"/>.</param>
        /// <returns>An <see cref="Enum"/> from the parsed value.</returns>
        /// <exception cref="ArgumentNullException">The provided value was null.</exception>
        /// <exception cref="InvalidDataException">The provided value was not present in the <see cref="Enum"/>.</exception>
        internal static TEnum ParseEnum<TEnum, TValue>(TValue value) where TEnum : Enum
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Provided value was null.");

            if (!Enum.IsDefined(typeof(TEnum), value))
                throw new InvalidDataException($"Provided value not present in enum: {value}");

            return (TEnum)(object)value;
        }

        /// <summary>
        /// Try to parse a value as the provided <see cref="Enum"/>, returning true if successful.
        /// </summary>
        /// <typeparam name="TEnum">The type of the <see cref="Enum"/>.</typeparam>
        /// <typeparam name="TValue">The type of the value to parse.</typeparam>
        /// <param name="value">The value to parse as the given <see cref="Enum"/>.</param>
        /// <param name="result">The resulting <see cref="Enum"/> from the parsed value, or default.</param>
        /// <returns>Whether or not the parsing was successful.</returns>
        internal static bool TryParseEnum<TEnum, TValue>(TValue value, out TEnum? result) where TEnum : Enum
        {
            result = default;
            if (value == null)
                return false;

            if (!Enum.IsDefined(typeof(TEnum), value))
                return false;

            result = (TEnum)(object)value;
            return true;
        }
    }
}
