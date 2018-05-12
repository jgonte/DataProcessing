using System.Text.RegularExpressions;

namespace DataProcessing.Conditions
{
    public class FieldIsRegularExpressionMatch : SingleValuedField<string>,
        IRegularExpressionHolder
    {
        public string RegularExpression { get; set; }

        internal override bool EvaluateValue(object value)
        {
            return Regex.IsMatch(value.ToString(), RegularExpression);
        }
    }
}
