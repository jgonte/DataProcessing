using Utilities;

namespace DataProcessing.Conditions
{
    public interface IComparisonOperatorHolder
    {
        ComparisonOperators Operator { get; set; }
    }
}
