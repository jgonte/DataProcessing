using DataProcessing.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class FunctionBuildersTests
    {
        [TestMethod]
        public void Substring_Builder_Test()
        {
            var builder = new SubstringBuilder(startIndex: 0, endIndex: 3);

            var function = builder.Build();

            Assert.AreEqual(0, function.StartIndex);

            Assert.AreEqual(3, function.EndIndex);
        }
    }
}
