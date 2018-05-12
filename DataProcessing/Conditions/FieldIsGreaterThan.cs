using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsGreaterThan<T> : SingleValuedField<T>,
        IFieldIsGreaterThan
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsGreaterThan(Value);
        }
    }
}
