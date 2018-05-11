using DataProcessing.Conditions;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public class NotConditionBuilder : Builder<NotCondition>,
        IConditionBuilder,
        IConditionBuilderHolder
    {
        IConditionBuilder IConditionBuilderHolder.ConditionBuilder { get; set; }

        public override void Initialize(NotCondition condition)
        {
            condition.Condition = ((IConditionBuilderHolder)this).ConditionBuilder.Build();
        }

        ICondition IBuilder<ICondition>.Build()
        {
            return Build();
        }
    }
}
