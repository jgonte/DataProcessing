using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    public interface IConditionsHolder
    {
        List<ICondition> Conditions { get; set; }
    }
}