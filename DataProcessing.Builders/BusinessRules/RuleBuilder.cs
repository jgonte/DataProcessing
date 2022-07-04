using DataProcessing.BusinessRules;
using DataProcessing.Tasks;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public class RuleBuilder : Builder<Rule>, 
        IConditionBuilderHolder,
        ITaskBuildersHolder
    {
        IConditionBuilder IConditionBuilderHolder.ConditionBuilder { get; set; }

        List<ITaskBuilder> ITaskBuildersHolder.TaskBuilders { get; set; } = new List<ITaskBuilder>();

        public override void Initialize(Rule rule)
        {
            rule.Condition = ((IConditionBuilderHolder)this).ConditionBuilder.Build();

            rule.Tasks = ((ITaskBuildersHolder)this).TaskBuilders.ToList(b => b.Build());
        }
    }
}
