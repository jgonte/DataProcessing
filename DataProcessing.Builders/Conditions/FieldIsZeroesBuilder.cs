using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsZeroesBuilder : FieldConditionBuilder<FieldIsZeroes>
    {
        public override FieldIsZeroes Create()
        {
            return new FieldIsZeroes();
        }
    }
}
