using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class IMultipleValueHolderExtensions
    {
        /// <summary>
        /// Sets the values of the multiple values holder object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="builder"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T Values<T, V>(this T builder, params V[] values)
            where T : IMultipleValuesHolder<V>
        {
            builder.Values.AddRange(values);

            return builder;
        }
    }
}
