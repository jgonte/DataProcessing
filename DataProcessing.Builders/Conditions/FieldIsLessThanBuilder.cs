using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsLessThanBuilder<T> : SingleValuedFieldBuilder<FieldIsLessThan<T>, T>
        where T : IComparable<T>
    {
        public override FieldIsLessThan<T> Create()
        {
            return new FieldIsLessThan<T>();
        }
    }
}