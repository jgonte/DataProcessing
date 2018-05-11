using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public abstract class RangeValuedFieldBuilder<T> : FieldConditionBuilder<T>,
        IRangeValuesHolder<T>
        where T : RangeValuedField<T>
    {
        T IRangeValuesHolder<T>.MinValue { get; set; }

        T IRangeValuesHolder<T>.MaxValue { get; set; }

        public override void Initialize(T condition)
        {
            base.Initialize(condition);

            condition.MinValue = ((IRangeValuesHolder<T>)this).MinValue;

            condition.MaxValue = ((IRangeValuesHolder<T>)this).MaxValue;
        }
    }
}
