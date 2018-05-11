using DataProcessing.Conditions;
using Utilities;

namespace DataProcessing.Builders
{
    public interface IFieldConditionBuilder : IConditionBuilder,
        IDescribed,
        IFieldNameHolder
    {
    }
}