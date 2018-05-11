using DataProcessing.Tasks;

namespace DataProcessing.Builders
{
    public class RuleMessageTaskBuilder : TaskBuilder<RuleMessageTask>
    {
        private string _message;

        public RuleMessageTaskBuilder(string message)
        {
            _message = message;
        }

        public override RuleMessageTask Create()
        {
            return new RuleMessageTask(_message);
        }

        public override void Initialize(RuleMessageTask task)
        {
            task.Message = _message;
        }
    }
}