using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class AndConditionBuilder : CompositeConditionBuilder<AndCondition>
    {
        public override AndCondition Create()
        {
            return new AndCondition();
        }
    }
}
