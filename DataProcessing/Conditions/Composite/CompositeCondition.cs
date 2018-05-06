using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    public abstract class CompositeCondition : ICondition, 
        IConditionsHolder,
        ILogicalOperatorHolder
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public LogicalOperators Operator { get; set; }

        public IEnumerable<ICondition> Conditions { get; set; }

        public CompositeCondition(LogicalOperators @operator)
        {
            Operator = @operator;
        }

        public abstract bool Evaluate(IDictionary<string, object> record);

        public abstract void Format(IFormatter formatter);
    }
}
