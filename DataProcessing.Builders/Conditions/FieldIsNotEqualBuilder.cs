using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsNotEqualBuilder<T> : SingleValuedFieldBuilder<FieldIsNotEqual<T>, T>
        where T : IEquatable<T>
    {
        public override FieldIsNotEqual<T> Create()
        {
            return new FieldIsNotEqual<T>();
        }
    }
}
