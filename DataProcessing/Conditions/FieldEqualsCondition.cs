using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldEqualsCondition : SingleValuedFieldCondition
    {
        public FieldEqualsCondition() : base(ComparisonOperators.Equal)
        {
        }

        internal override bool Compare(object value)
        {
            return Value.Equals(value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
