using System;

namespace DataProcessing.Builders
{
    public static class IConditionBuilderExtensions
    {
        public static FieldConditionBuilderProxy Field<T>(this T builder, string name)
            where T : IConditionBuilder
        {
            return new FieldConditionBuilderProxy(name);
        }

        public static NotConditionBuilder Not<T>(this T builder, IConditionBuilder conditionBuilder)
            where T : IConditionBuilder
        {
            return new NotConditionBuilder()
                .Condition(conditionBuilder);
        }

        public static NotConditionBuilder Not<T>(this T builder, Func<IConditionBuilder, IConditionBuilder> factory)
            where T : IConditionBuilder
        {
            return new NotConditionBuilder()
                .Condition(factory);
        }
    }
}
