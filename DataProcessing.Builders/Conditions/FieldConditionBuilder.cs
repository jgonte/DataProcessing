using DataProcessing.Conditions;
using DataProcessing.Functions;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class FieldConditionBuilder<T> : AbstractBuilder<T>,
        IFieldConditionBuilder,
        IUnaryFunctionHolder
        where  T : FieldCondition
    {
        string IDescribed.Description { get; set; }

        string IFieldNameHolder.FieldName { get; set; }

        IUnaryFunction IUnaryFunctionHolder.InputSource { get; set; }

        public override void Initialize(T condition)
        {
            condition.Description = ((IDescribed)this).Description;

            condition.FieldName = ((IFieldNameHolder)this).FieldName;

            condition.InputSource = ((IUnaryFunctionHolder)this).InputSource;
        }

        ICondition IBuilder<ICondition>.Build()
        {
            return Build();
        }
    }
}
