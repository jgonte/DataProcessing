using DataProcessing.Conditions;
using System;

namespace DataProcessing.Builders
{
    public class FieldIsEqualBuilder<T> : SingleValuedFieldBuilder<FieldIsEqual<T>, T>
        where T : IEquatable<T>
    {
        public override FieldIsEqual<T> Create()
        {
            return new FieldIsEqual<T>();
        }
    }
}
