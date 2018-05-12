using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataProcessing.Builders;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class FunctionBuildersTests
    {
        [TestMethod]
        public void Substring_Builder_Test()
        {
            var builder = new SubstringBuilder()
                .StartIndex(0)
                .EndIndex(3);

            var function = builder.Build();

            Assert.AreEqual(0, function.StartIndex);

            Assert.AreEqual(3, function.EndIndex);
        }
    }
}
