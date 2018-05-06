using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace DataProcessing.Conditions
{
    public class AndCondition : CompositeCondition
    {
        public AndCondition() : base(LogicalOperators.And)
        {
        }

        public override bool Evaluate(IDictionary<string, object> record)
        {
            var result = Conditions.First().Evaluate(record);

            foreach (var condition in Conditions.Skip(1))
            {
                result = result && condition.Evaluate(record);
            }

            return result;
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
