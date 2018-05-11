namespace DataProcessing.Builders
{
    public static class IFieldConditionBuilderExtensions
    {
        public static AndConditionBuilder And(this IConditionBuilder builder, IConditionBuilder rightBuilder)
        {
            var b = new AndConditionBuilder();

            ((IConditionBuildersHolder)b).ConditionBuilders.Add(builder);

            ((IConditionBuildersHolder)b).ConditionBuilders.Add(rightBuilder);

            return b;
        }

        public static AndConditionBuilder And(this AndConditionBuilder builder, IConditionBuilder rightBuilder)
        {
            if (rightBuilder is AndConditionBuilder) // Merge the condition builders
            {
                builder.Conditions(
                    ((IConditionBuildersHolder)rightBuilder).ConditionBuilders.ToArray()
                );
            }
            else
            {
                builder.Conditions(rightBuilder);
            }

            return builder;
        }

        public static AndConditionBuilder And(this IConditionBuilder builder, AndConditionBuilder rightBuilder)
        {
            rightBuilder.PrependConditions(builder);

            return rightBuilder;
        }

        public static OrConditionBuilder Or(this IConditionBuilder builder, IConditionBuilder rightBuilder)
        {
            var b = new OrConditionBuilder();

            ((IConditionBuildersHolder)b).ConditionBuilders.Add(builder);

            ((IConditionBuildersHolder)b).ConditionBuilders.Add(rightBuilder);

            return b;
        }

        public static OrConditionBuilder Or(this OrConditionBuilder builder, IConditionBuilder rightBuilder)
        {
            if (rightBuilder is OrConditionBuilder) // Merge the condition builders
            {
                builder.Conditions(
                    ((IConditionBuildersHolder)rightBuilder).ConditionBuilders.ToArray()
                );
            }
            else
            {
                builder.Conditions(rightBuilder);
            }

            return builder;
        }

        public static OrConditionBuilder Or(this IConditionBuilder builder, OrConditionBuilder rightBuilder)
        {
            rightBuilder.PrependConditions(builder);

            return rightBuilder;
        }
    }
}
