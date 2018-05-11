using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class RegularExpressionConditionBuilder : SingleValuedFieldBuilder<RegularExpressionCondition, string>,
        IRegularExpressionHolder
    {
        string IRegularExpressionHolder.RegularExpression { get; set; }

        public override RegularExpressionCondition Create()
        {
            return new RegularExpressionCondition();
        }

        public override void Initialize(RegularExpressionCondition condition)
        {
            base.Initialize(condition);

            condition.RegularExpression = ((IRegularExpressionHolder)this).RegularExpression;
        }
    }
}
