using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    public interface IConditionsHolder
    {
        IEnumerable<ICondition> Conditions { get; set; }
    }
}