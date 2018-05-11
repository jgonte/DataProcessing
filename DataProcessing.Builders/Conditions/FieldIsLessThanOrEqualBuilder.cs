using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsLessThanOrEqualBuilder<T> : SingleValuedFieldBuilder<FieldIsLessThanOrEqual<T>, T>
        where T : IComparable<T>
    {
        public override FieldIsLessThanOrEqual<T> Create()
        {
            return new FieldIsLessThanOrEqual<T>();
        }
    }
}