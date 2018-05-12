using System;

namespace DataProcessing.Conditions
{
    public class FieldIsEqual<T> : SingleValuedField<T>,
        IFieldIsEqual
        where T : IEquatable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).Equals(Value);
        }
    }
}
