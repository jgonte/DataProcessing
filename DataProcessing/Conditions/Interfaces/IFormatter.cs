using DataProcessing.Tasks;

namespace DataProcessing.Conditions
{
    public interface IFormatter
    {
        void Format(AndCondition andCondition);

        void Format(OrCondition orCondition);

        void Format(FieldEqualsCondition fieldEqualsCondition);
        void Format(ErrorMessageTask errorMessageTask);
    }
}