using DataProcessing.BusinessRules;

namespace DataProcessing.Tasks
{
    public interface IRuleContextHolder
    {
        /// <summary>
        /// The rule context passed to this task to enable validating the rule
        /// </summary>
        RuleContext RuleContext { get; set; }
    }
}
