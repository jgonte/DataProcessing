using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldEqualsConditionBuilder : SingleValuedFieldConditionBuilder<FieldEqualsCondition>
    {
        public override FieldEqualsCondition Create()
        {
            return new FieldEqualsCondition();
        }
    }
}
