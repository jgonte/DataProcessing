using DataProcessing.Conditions;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class FieldConditionBuilder<T> : AbstractBuilder<T>,
        IConditionBuilder,
        IDescribed,
        IFieldNameHolder,
        IComparisonOperatorHolder
        where  T : FieldCondition
    {
        string IDescribed.Description { get; set; }

        string IFieldNameHolder.FieldName { get; set; }

        ComparisonOperators IComparisonOperatorHolder.Operator { get; set; }

        public override void Initialize(T condition)
        {
            condition.Description = ((IDescribed)this).Description;

            condition.FieldName = ((IFieldNameHolder)this).FieldName;

            condition.Operator = ((IComparisonOperatorHolder)this).Operator;
        }

        ICondition IBuilder<ICondition>.Build()
        {
            return Build();
        }
    }
}
