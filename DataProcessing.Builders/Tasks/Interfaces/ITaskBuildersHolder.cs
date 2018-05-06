using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public interface ITaskBuildersHolder
    {
        List<ITaskBuilder> TaskBuilders { get; set; }
    }
}