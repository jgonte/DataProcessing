using System;

namespace DataProcessing.Conditions
{
    public class FieldIsEqual<T> : SingleValuedField<T>
        where T : IEquatable<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return ((T)value).Equals(Value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
