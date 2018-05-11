using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsInBuilder<T> : MultipleValuedFieldBuilder<FieldIsIn<T>, T>
    {
        public override FieldIsIn<T> Create()
        {
            return new FieldIsIn<T>();
        }
    }
}
