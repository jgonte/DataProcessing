using DataProcessing.Conditions;
using Utilities;

namespace DataProcessing.Tasks
{
    public class ErrorMessageTask : IIdentified<int>,
        IDescribed, 
        ITask
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ErrorMessage { get; set; }

        public void Execute()
        {
            ErrorMessage = "Error occurred!";
        }

        public void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
