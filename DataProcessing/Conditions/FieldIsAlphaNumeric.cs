using System.Linq;

namespace DataProcessing.Conditions
{
    public class FieldIsAlphaNumeric : FieldCondition
    {
        internal override bool EvaluateValue(object value)
        {
            return value.ToString().All(char.IsLetterOrDigit);
        }
    }
}
