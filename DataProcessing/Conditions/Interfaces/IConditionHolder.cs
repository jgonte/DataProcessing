using DataProcessing.Conditions;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// Defines an object that holds a condition
    /// </summary>
    public interface IConditionHolder
    {
        ICondition Condition { get; set; }
    }
}
