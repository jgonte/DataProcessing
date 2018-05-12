using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Conditions
{
    public abstract class MultipleValuedField<T> : FieldCondition,
        IMultipleValuesHolder<T>
    {
        public List<T> Values { get; set; }

        public List<object> GetValues() => Values.Cast<object>().ToList();
    }
}
