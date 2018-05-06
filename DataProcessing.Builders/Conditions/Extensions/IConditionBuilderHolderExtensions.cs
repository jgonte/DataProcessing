using System;

namespace DataProcessing.Builders
{
    public static class IConditionBuilderHolderExtensions
    {
        public static T Condition<T>(this T builder, IConditionBuilder b)
            where T : IConditionBuilderHolder
        {
            builder.ConditionBuilder = b;

            return builder;
        }

        public static T Condition<T>(this T builder, Func<IConditionBuilder, IConditionBuilder> factory)
            where T : IConditionBuilderHolder
        {
            return Condition(builder, factory(null));
        }
    }
}
