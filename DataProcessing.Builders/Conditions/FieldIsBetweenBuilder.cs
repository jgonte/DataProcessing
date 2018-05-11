using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsBetweenBuilder<T> : FieldConditionBuilder<FieldIsBetween<T>>,
        IRangeValuesHolder<T>
         where T : IComparable<T>
    {
        T IRangeValuesHolder<T>.MinValue { get; set; }

        T IRangeValuesHolder<T>.MaxValue { get; set; }

        public override FieldIsBetween<T> Create()
        {
            return new FieldIsBetween<T>();
        }

        public override void Initialize(FieldIsBetween<T> condition)
        {
            base.Initialize(condition);

            condition.MinValue = ((IRangeValuesHolder<T>)this).MinValue;

            condition.MaxValue = ((IRangeValuesHolder<T>)this).MaxValue;
        }
    }
}