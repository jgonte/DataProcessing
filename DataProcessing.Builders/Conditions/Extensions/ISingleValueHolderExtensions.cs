using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class ISingleValueHolderExtensions
    {
        /// <summary>
        /// Sets the value of the single value holder object
        /// </summary>
        /// <typeparam name="T">Builder type</typeparam>
        /// <typeparam name="V">Value type</typeparam>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Value<T, V>(this T builder, V value)
            where T : ISingleValueHolder<V>
        {
            builder.Value = value;

            return builder;
        }
    }
}
