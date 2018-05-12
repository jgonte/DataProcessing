using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// Defines a generic condition
    /// </summary>
    public interface ICondition : IDescribed
    {
        // A composite condition might require several fields from a record
        bool Evaluate(IDictionary<string, object> record);
    }
}
