using DataProcessing.Tasks;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public interface ITaskBuilder : IBuilder<ITask>, 
        IDescribed
    {
    }
}