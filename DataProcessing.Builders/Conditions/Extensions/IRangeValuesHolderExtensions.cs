using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class IRangeValuesHolderExtensions
    {
        public static T MinValue<T, K>(this T builder, K value)
            where T : IRangeValuesHolder<K>
        {
            builder.MinValue = value;

            return builder;
        }

        public static T MaxValue<T, K>(this T builder, K value)
            where T : IRangeValuesHolder<K>
        {
            builder.MaxValue = value;

            return builder;
        }
    }
}
