using DataProcessing.Conditions;
using Utilities;

namespace DataProcessing.Tasks
{
    /// <summary>
    /// Defines an executable task
    /// </summary>
    public interface ITask : IDescribed
    {
        void Execute();

        void Format(IFormatter formatter);
    }
}
