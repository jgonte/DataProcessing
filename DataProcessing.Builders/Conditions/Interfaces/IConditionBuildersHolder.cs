using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public interface IConditionBuildersHolder
    {
        List<IConditionBuilder> ConditionBuilders { get; set; }
    }
}