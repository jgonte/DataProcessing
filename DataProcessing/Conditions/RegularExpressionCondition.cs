using System.Text.RegularExpressions;

namespace DataProcessing.Conditions
{
    public class RegularExpressionCondition : SingleValuedField<string>,
        IRegularExpressionHolder
    {
        public string RegularExpression { get; set; }

        internal override bool EvaluateValue(object value)
        {
            return Regex.IsMatch(value.ToString(), RegularExpression);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
