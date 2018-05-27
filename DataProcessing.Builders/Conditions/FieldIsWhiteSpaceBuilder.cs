using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsWhiteSpaceBuilder : FieldConditionBuilder<FieldIsWhiteSpace>
    {
        public override FieldIsWhiteSpace Create()
        {
            return new FieldIsWhiteSpace();
        }
    }
}
