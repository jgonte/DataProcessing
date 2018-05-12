using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Conditions
{
    public class AndCondition : CompositeCondition
    {
        public override bool Evaluate(IDictionary<string, object> record)
        {
            var result = Conditions.First().Evaluate(record);

            foreach (var condition in Conditions.Skip(1))
            {
                result = result && condition.Evaluate(record);
            }

            return result;
        }
    }
}
