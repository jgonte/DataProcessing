using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsGreaterThanOrEqual<T> : SingleValuedField<T>,
        IFieldIsGreaterThanOrEqual
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsGreaterThanOrEqual(Value);
        }
    }
}
