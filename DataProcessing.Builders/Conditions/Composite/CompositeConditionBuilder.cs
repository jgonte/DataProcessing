using DataProcessing.Conditions;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class CompositeConditionBuilder<T> : AbstractBuilder<T>,
        IConditionBuilder,
        IDescribed,
        IConditionBuildersHolder
        where T : CompositeCondition
    {
        string IDescribed.Description { get; set; }

        List<IConditionBuilder> IConditionBuildersHolder.ConditionBuilders { get; set; } = new List<IConditionBuilder>();

        public override void Initialize(T condition)
        {
            condition.Description = ((IDescribed)this).Description;

            condition.Conditions = ((IConditionBuildersHolder)this).ConditionBuilders.SelectToList(b => b.Build());
        }

        ICondition IBuilder<ICondition>.Build()
        {
            return Build();
        }
    }
}
