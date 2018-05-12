using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsLessThanOrEqual<T> : SingleValuedField<T>,
        IFieldIsLessThanOrEqual
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsLessThanOrEqual(Value);
        }
    }
}
