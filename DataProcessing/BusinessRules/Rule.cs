using DataProcessing.Conditions;
using DataProcessing.Tasks;
using System.Collections.Generic;
using Utilities;

namespace DataProcessing.BusinessRules
{
    /// <summary>
    /// Represents a business rule
    /// </summary>
    public class Rule : NamedObject<int>, 
        IConditionHolder,
        ITasksHolder, 
        IActive, 
        IOrdered
    {
        public ICondition Condition { get; set; }

        /// <summary>
        /// The tasks to be fired when the condition evaluates to true
        /// </summary>
        public IEnumerable<ITask> Tasks { get; set; }

        public bool IsActive { get; set; } = true;

        public int Order { get; set; }

        public RuleSet OwnerRuleSet { get; set; }

        public void Fire(Dictionary<string, object> record)
        {
            if (!IsActive)
            {
                return;
            }

            if (Condition.Evaluate(record))
            {
                foreach (var task in Tasks)
                {
                    task.Execute();
                }
            }
        }

        public void Format(IFormatter formatter)
        {
            Condition.Format(formatter);

            foreach (var task in Tasks)
            {
                task.Format(formatter);
            }
        }
    }
}
