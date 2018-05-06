using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public interface IRuleBuildersHolder
    {
        List<RuleBuilder> RuleBuilders { get; set; }
    }
}