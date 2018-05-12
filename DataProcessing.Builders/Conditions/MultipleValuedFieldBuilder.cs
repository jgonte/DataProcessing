using System.Collections.Generic;
using DataProcessing.Conditions;
using System.Linq;

namespace DataProcessing.Builders
{
    public abstract class MultipleValuedFieldBuilder<T, V> : FieldConditionBuilder<T>,
        IMultipleValuesHolder<V>
        where T : MultipleValuedField<V>
    {
        List<V> IMultipleValuesHolder<V>.Values { get; set; } = new List<V>();

        List<object> IMultipleValuesHolder.GetValues() => ((IMultipleValuesHolder<V>)this).Values.Cast<object>().ToList();

        public override void Initialize(T condition)
        {
            base.Initialize(condition);

            condition.Values = ((IMultipleValuesHolder<V>)this).Values;
        }
    }
}
