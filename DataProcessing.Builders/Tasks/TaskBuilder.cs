using DataProcessing.Tasks;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class TaskBuilder<T> : AbstractBuilder<T>,
        ITaskBuilder
        where T : ITask
    {
        ITask IBuilder<ITask>.Build()
        {
            return Build();
        }

        ITask IBuilder<ITask>.Create()
        {
            return Create();
        }

        void IBuilder<ITask>.Initialize(ITask obj)
        {
            Initialize((T)obj);
        }
    }
}