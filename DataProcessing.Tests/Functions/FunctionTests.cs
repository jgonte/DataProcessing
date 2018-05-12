using DataProcessing.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProcessing.Tests.Functions
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void Substring_Test()
        {
            var function = new Substring
            {
                StartIndex = 0,
                EndIndex = 3
            };

            var result = function.Evaluate("string");

            Assert.AreEqual("str", result);
        }
    }
}
