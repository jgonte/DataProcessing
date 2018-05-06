using System;
using System.Collections.Generic;
using Utilities;

namespace DataProcessing.Conditions
{
    public abstract class SingleValuedFieldCondition : FieldCondition,
        ISingleValueHolder
    {
        public object Value { get; set; }

        public SingleValuedFieldCondition(ComparisonOperators @operator) : base(@operator)
        {
        }

        public override bool Evaluate(IDictionary<string, object> record)
        {
            if (!record.ContainsKey(FieldName))
            {
                throw new InvalidOperationException($"Field of name: {FieldName} does not exist in the record.");
            }

            var value = record[FieldName];

            return Compare(value);
        }

        internal abstract bool Compare(object value);
    }
}
