using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public abstract class SingleValuedFieldConditionBuilder<T> : FieldConditionBuilder<T>,
        ISingleValueHolder
        where T : SingleValuedFieldCondition
    {
        object ISingleValueHolder.Value { get; set; }

        public override void Initialize(T condition)
        {
            base.Initialize(condition);

            condition.Value = ((ISingleValueHolder)this).Value;
        }

        //public FieldEqualsConditionBuilder IsEqual(object value)
        //{
        //    var builder = new FieldEqualsConditionBuilder();

        //    ((IComparisonOperatorHolder)builder).Operator = Utilities.ComparisonOperators.Equal;

        //    ((ISingleValueHolder)builder).Value = value;

        //    return builder;
        //}
    }
}
