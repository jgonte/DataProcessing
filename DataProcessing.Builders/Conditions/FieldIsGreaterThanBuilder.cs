using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsGreaterThanBuilder<T> : SingleValuedFieldBuilder<FieldIsGreaterThan<T>, T>
        where T : IComparable<T>
    {
        public override FieldIsGreaterThan<T> Create()
        {
            return new FieldIsGreaterThan<T>();
        }
    }
}
