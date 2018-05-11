using DataProcessing.BusinessRules;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Tests.Tasks
{
    [TestClass]
    public class TasksTests
    {
        [TestMethod]
        public void RuleMessageTask_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var task = new RuleMessageTask("Error occurred!");

            task.RuleContext = context;

            task.Execute();

            Assert.AreEqual("Error occurred!", task.Message);

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.IsNull(message.FieldNames);

            Assert.AreEqual("Error occurred!", message.Message);
        }
    }
}
