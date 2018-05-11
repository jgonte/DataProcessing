using System.Collections.Generic;
using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public abstract class MultipleValuedFieldBuilder<T, V> : FieldConditionBuilder<T>,
        IMultipleValuesHolder<V>
        where T : MultipleValuedField<V>
    {
        List<V> IMultipleValuesHolder<V>.Values { get; set; } = new List<V>();

        public override void Initialize(T condition)
        {
            base.Initialize(condition);

            condition.Values = ((IMultipleValuesHolder<V>)this).Values;
        }
    }
}
