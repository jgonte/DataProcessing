using DataProcessing.Tasks;

namespace DataProcessing.Builders
{
    public class ErrorMessageTaskBuilder : TaskBuilder<ErrorMessageTask>
    {
        public override ErrorMessageTask Create()
        {
            return new ErrorMessageTask();
        }

        public override void Initialize(ErrorMessageTask task)
        {
            task.ErrorMessage = "kuku";
        }
    }
}