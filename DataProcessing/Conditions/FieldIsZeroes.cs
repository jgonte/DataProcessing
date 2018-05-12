using System.Linq;

namespace DataProcessing.Conditions
{
    public class FieldIsZeroes : FieldCondition
    {
        internal override bool EvaluateValue(object value)
        {
            return value.ToString().All(c => c == '0');
        }
    }
}
