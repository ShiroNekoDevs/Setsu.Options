namespace Setsu.Options
{
    /// <summary>
    /// A class for commonly used methods related to the <see cref="Option{T}"/> type.
    /// </summary>
    public static class OptionExtensions
    {
        /// <summary>
        /// Converts a value to an <see cref="Option{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>An <see cref="Option{T}"/> with <see cref="Option{T}.HasValue"/> <see langword="true"/> if the value is not null, or <see langword="false"/> if the value is null.</returns>
        public static Option<T> AsOption<T>(this T? value) where T: notnull
        {
            return value == null ? default : new(value);
        }
    }
}
