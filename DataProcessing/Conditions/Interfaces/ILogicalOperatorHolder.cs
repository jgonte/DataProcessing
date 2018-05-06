using Utilities;

namespace DataProcessing.Conditions
{
    public interface ILogicalOperatorHolder
    {
        LogicalOperators Operator { get; set; }
    }
}