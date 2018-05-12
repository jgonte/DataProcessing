using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsRegularExpressionMatchBuilder : SingleValuedFieldBuilder<FieldIsRegularExpressionMatch, string>,
        IRegularExpressionHolder
    {
        string IRegularExpressionHolder.RegularExpression { get; set; }

        public override FieldIsRegularExpressionMatch Create()
        {
            return new FieldIsRegularExpressionMatch();
        }

        public override void Initialize(FieldIsRegularExpressionMatch condition)
        {
            base.Initialize(condition);

            condition.RegularExpression = ((IRegularExpressionHolder)this).RegularExpression;
        }
    }
}
