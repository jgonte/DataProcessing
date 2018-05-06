using System;
using System.Linq;

namespace DataProcessing.Builders
{
    public static class IConditionBuildersHolderExtensions
    {
        public static T Conditions<T>(this T builder, params IConditionBuilder[] builders)
            where T : IConditionBuildersHolder
        {
            builder.ConditionBuilders.AddRange(builders);

            return builder;
        }

        public static T Conditions<T>(this T builder, params Func<IConditionBuilder, IConditionBuilder>[] factories)
            where T : IConditionBuildersHolder
        {
            return Conditions(builder, factories.Select(f => f(null)).ToArray());
        }
    }
}
