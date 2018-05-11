using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// Condition that has a field name
    /// </summary>
    public abstract class FieldCondition : ICondition,
        IFieldNamesHolder,
        IFieldNameHolder
    {
        public string Description { get; set; }

        public string FieldName { get; set; }

        public IEnumerable<string> FieldNames => Enumerable.Repeat(FieldName, 1);

        public virtual bool Evaluate(IDictionary<string, object> record)
        {
            if (!record.ContainsKey(FieldName))
            {
                throw new InvalidOperationException($"Field of name: {FieldName} does not exist in the record.");
            }

            var value = record[FieldName];

            return EvaluateValue(value);
        }

        internal abstract bool EvaluateValue(object value);

        public abstract void Format(IFormatter formatter);
    }
}
