using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsGreaterThan<T> : SingleValuedField<T>
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsGreaterThan(Value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
