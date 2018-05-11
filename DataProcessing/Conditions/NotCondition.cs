using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Conditions
{
    public class NotCondition : ICondition,
        IConditionHolder,
        IFieldNamesHolder
    {
        public string Description { get; set; }

        /// <summary>
        /// The condition to negate
        /// </summary>
        public ICondition Condition { get; set; }

        public IEnumerable<string> FieldNames => ((IFieldNamesHolder)Condition).FieldNames;

        public bool Evaluate(IDictionary<string, object> record)
        {
            return !(Condition.Evaluate(record));
        }

        public void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
