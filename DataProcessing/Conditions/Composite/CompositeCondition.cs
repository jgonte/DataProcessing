using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Conditions
{
    public abstract class CompositeCondition : ICondition,
        IFieldNamesHolder, 
        IConditionsHolder
    {
        public string Description { get; set; }

        public List<ICondition> Conditions { get; set; }

        public IEnumerable<string> FieldNames => Conditions
            .Where(c => c is IFieldNamesHolder)
            .Cast<IFieldNamesHolder>()
            .SelectMany(c => c.FieldNames);

        public abstract bool Evaluate(IDictionary<string, object> record);
    }
}
