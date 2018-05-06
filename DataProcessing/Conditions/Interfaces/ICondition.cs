using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    public interface ICondition : 
        IIdentified<int>, 
        IDescribed
    {
        bool Evaluate(IDictionary<string, object> record);

        void Format(IFormatter formatter);
    }
}
