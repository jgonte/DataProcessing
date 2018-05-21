using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsAlphaNumericBuilder : FieldConditionBuilder<FieldIsAlphaNumeric>
    {
        public override FieldIsAlphaNumeric Create()
        {
            return new FieldIsAlphaNumeric();
        }
    }
}
