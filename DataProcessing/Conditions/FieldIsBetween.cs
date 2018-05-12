using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsBetween<T> : RangeValuedField<T>
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsBetween(MinValue, MaxValue);
        }
    }
}
