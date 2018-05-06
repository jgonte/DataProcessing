using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class ISingleValueHolderExtensions
    {
        /// <summary>
        /// Sets the value of the single value holder object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Value<T>(this T builder, object value)
            where T : ISingleValueHolder
        {
            builder.Value = value;

            return builder;
        }
    }
}
