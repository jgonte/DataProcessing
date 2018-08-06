using DataProcessing.Tasks;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class TaskBuilder<T> : AbstractBuilder<T>,
        ITaskBuilder
        where T : ITask
    {
        public string Description { get; set; }

        ITask IBuilder<ITask>.Build()
        {
            return Build();
        }

        public override void Initialize(T obj)
        {
            obj.Description = Description;
        }
    }
}