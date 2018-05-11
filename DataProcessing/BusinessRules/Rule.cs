using DataProcessing.Conditions;
using DataProcessing.Tasks;
using System.Collections.Generic;
using System.Linq;
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

        public void Fire(RuleContext context, Dictionary<string, object> record)
        {
            if (!IsActive)
            {
                return;
            }

            if (Condition.Evaluate(record))
            {
                if (Condition is IFieldNamesHolder)
                {
                    context.FieldNames = new HashSet<string>(((IFieldNamesHolder)Condition).FieldNames);
                }

                foreach (var task in Tasks.Where(t => t is IRuleContextHolder))
                {
                    ((IRuleContextHolder)task).RuleContext = context;

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
