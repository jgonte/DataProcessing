using DataProcessing.Conditions;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class CompositeConditionBuilder<T> : AbstractBuilder<T>,
        IDescribed,
        ILogicalOperatorHolder,
        IConditionBuildersHolder
        where T : CompositeCondition
    {
        string IDescribed.Description { get; set; }

        LogicalOperators ILogicalOperatorHolder.Operator { get; set; }

        List<IConditionBuilder> IConditionBuildersHolder.ConditionBuilders { get; set; } = new List<IConditionBuilder>();

        public override void Initialize(T condition)
        {
            condition.Description = ((IDescribed)this).Description;

            condition.Operator = ((ILogicalOperatorHolder)this).Operator;

            condition.Conditions = ((IConditionBuildersHolder)this).ConditionBuilders.Select(b => b.Build());
        }
    }
}
