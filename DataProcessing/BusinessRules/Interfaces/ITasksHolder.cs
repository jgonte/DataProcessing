using DataProcessing.Tasks;
using System.Collections.Generic;

namespace DataProcessing.BusinessRules
{
    /// <summary>
    /// Defines an object that holds tasks
    /// </summary>
    public interface ITasksHolder
    {
        /// <summary>
        /// The tasks held by the object
        /// </summary>
        IEnumerable<ITask> Tasks { get; set; }
    }
}
