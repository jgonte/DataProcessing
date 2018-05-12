using System;

namespace DataProcessing.Conditions
{
    public class FieldIsNotEqual<T> : SingleValuedField<T>
        where T :IEquatable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return !Value.Equals((T)value);
        }
    }
}
