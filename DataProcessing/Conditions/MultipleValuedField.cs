using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    public abstract class MultipleValuedField<T> : FieldCondition,
        IMultipleValuesHolder<T>
    {
        public List<T> Values { get; set; }
    }
}
