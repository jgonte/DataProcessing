using DataProcessing.Conditions;

namespace DataProcessing.Tasks
{
    /// <summary>
    /// Defines an executable task
    /// </summary>
    public interface ITask
    {
        void Execute();

        void Format(IFormatter formatter);
    }
}
