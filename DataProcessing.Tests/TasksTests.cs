using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProcessing.Tests.Tasks
{
    [TestClass]
    public class TasksTests
    {
        [TestMethod]
        public void ErrorMessageTask_Test()
        {
            var task = new ErrorMessageTask();

            task.Execute();

            Assert.AreEqual("Error occurred!", task.ErrorMessage);
        }
    }
}
