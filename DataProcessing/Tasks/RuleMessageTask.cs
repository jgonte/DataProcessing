using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using System.Linq;

namespace DataProcessing.Tasks
{
    /// <summary>
    /// Task that outputs a message on execution of a rule
    /// </summary>
    public class RuleMessageTask : ITask,
        IRuleContextHolder
    {
        public RuleMessageTask(string message)
        {
            Message = message;
        }

        public string Description { get; set; }

        /// <summary>
        /// The message to be output when the evaluation of a condition of a rule is true
        /// </summary>
        public string Message { get; set; }

        public RuleContext RuleContext { get; set; }

        public void Execute()
        {
            RuleContext.Messages.Add(new RuleMessage
            {
                Line = RuleContext.Line,
                FieldNames = RuleContext.FieldNames?.ToArray(),
                Message = Message
            });
        }

        public void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
