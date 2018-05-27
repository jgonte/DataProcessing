using System.Linq;

namespace DataProcessing.Conditions
{
    public class FieldIsWhiteSpace : FieldCondition
    {
        internal override bool EvaluateValue(object value)
        {
            return value.ToString().All(char.IsWhiteSpace);
        }
    }
}
