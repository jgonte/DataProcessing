using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    public interface ICondition : IDescribed
    {
        bool Evaluate(IDictionary<string, object> record);

        void Format(IFormatter formatter);
    }
}
