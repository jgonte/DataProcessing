﻿using DataProcessing.Conditions;
using DataProcessing.Functions;

namespace DataProcessing.Builders
{
    public abstract class SingleValuedFieldBuilder<T, V> : FieldConditionBuilder<T>,
        ISingleValueHolder<V>
        where T : SingleValuedField<V>
    {
        V ISingleValueHolder<V>.Value { get; set; }

        public override void Initialize(T condition)
        {
            base.Initialize(condition);

            condition.Value = ((ISingleValueHolder<V>)this).Value;
        }

        object ISingleValueHolder.GetValue() => ((ISingleValueHolder<V>)this).Value;
    }
}
