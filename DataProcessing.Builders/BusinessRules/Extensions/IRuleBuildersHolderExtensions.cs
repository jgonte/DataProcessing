using System;
using System.Linq;

namespace DataProcessing.Builders
{
    public static class IRuleBuildersHolderExtensions
    {
        public static T Rules<T>(this T builder, params RuleBuilder[] builders)
            where T : IRuleBuildersHolder
        {
            builder.RuleBuilders.AddRange(builders);

            return builder;
        }

        public static T Rules<T>(this T builder, params Action<RuleBuilder>[] configures)
            where T : IRuleBuildersHolder
        {
            return Rules(builder, 
                configures
                    .Select(configure => 
                    {
                        var b = new RuleBuilder();

                        configure(b);

                        return b;
                    })
                    .ToArray()
            );
        }
    }
}
