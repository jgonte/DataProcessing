using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class IRegularExpressionHolderExtensions
    {
        public static T RegularExpression<T>(this T builder, string regularExpression)
            where T : IRegularExpressionHolder
        {
            builder.RegularExpression = regularExpression;

            return builder;
        }
    }
}
