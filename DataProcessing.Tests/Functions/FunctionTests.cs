using DataProcessing.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void ToDate_Test()
        {
            var function = new ToDate
            {
                Format = "MMddyyyy",
            };

            var result = function.Evaluate("09011995");

            Assert.AreEqual(new DateTime(1995, 9, 1), result);
        }

        [TestMethod]
        public void ToInteger_Test()
        {
            var function = new ToInteger();

            var result = function.Evaluate("01");

            Assert.AreEqual(1, result);
        }
    }
}
