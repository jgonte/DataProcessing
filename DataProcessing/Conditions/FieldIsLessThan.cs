using System;
using Utilities;

namespace DataProcessing.Conditions
{
    public class FieldIsLessThan<T> : SingleValuedField<T>,
        IFieldIsLessThan
        where T : IComparable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).IsLessThan(Value);
        }
    }
}
