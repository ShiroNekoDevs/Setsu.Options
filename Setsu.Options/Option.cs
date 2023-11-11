using System;

namespace Setsu.Options
{
    /// <summary>
    /// A simple option type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public readonly struct Option<T> where T: notnull
    {
        private readonly T? _value;
        /// <summary>
        /// Indicates whether or not the current option has a value.
        /// </summary>
        public readonly bool HasValue;
        /// <summary>
        /// Gets the inner value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if <see cref="HasValue"/> is <see langword="false"/>.</exception>
        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new System.InvalidOperationException("Cannot access the value of an Option without value.");
                return _value!;
            }
        }

        /// <summary>
        /// Creates an option with the specified value.
        /// <para>If you want to convert a nullable type to an option, see <see cref="OptionExtensions.AsOption{T}"/>.</para>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Thrown if the value parameter is null.</exception>
        public Option(T value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            HasValue = true;
        }
        /// <summary>
        /// Creates an option without value.
        /// </summary>
        public Option()
        {
            _value = default;
            HasValue = false;
        }

        /// <summary>
        /// Converts this option to a nullable value.
        /// </summary>
        /// <returns></returns>
        public T? AsNullable()
        {
            return _value;
        }

        /// <summary>
        /// Converts this option to a string.
        /// </summary>
        /// <returns>'Some: {<see cref="Value"/>.ToString()}' if the option has a value, or 'None' when not.</returns>
        public override string ToString()
        {
            return HasValue ? $"Some: {_value}" : "None";
        }
    }
}
