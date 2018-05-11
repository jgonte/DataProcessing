using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsGreaterThanOrEqualBuilder<T> : SingleValuedFieldBuilder<FieldIsGreaterThanOrEqual<T>, T>
        where T : IComparable<T>
    {
        public override FieldIsGreaterThanOrEqual<T> Create()
        {
            return new FieldIsGreaterThanOrEqual<T>();
        }
    }
}