using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    public abstract class FieldCondition : ICondition, 
        IFieldNameHolder, 
        IComparisonOperatorHolder
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string FieldName { get; set; }

        public ComparisonOperators Operator { get; set; }

        public FieldCondition(ComparisonOperators @operator)
        {
            Operator = @operator;
        }

        public abstract bool Evaluate(IDictionary<string, object> record);

        public abstract void Format(IFormatter formatter);
    }
}
