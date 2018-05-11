using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsLessThan<T> : SingleValuedField<T>
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsLessThan(Value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
