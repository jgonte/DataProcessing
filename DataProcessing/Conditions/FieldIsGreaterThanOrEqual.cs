using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsGreaterThanOrEqual<T> : SingleValuedField<T>
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsGreaterThanOrEqual(Value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
