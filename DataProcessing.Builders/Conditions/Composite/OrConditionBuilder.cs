using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class OrConditionBuilder : CompositeConditionBuilder<OrCondition>
    {
        public override OrCondition Create()
        {
            return new OrCondition();
        }
    }
}
