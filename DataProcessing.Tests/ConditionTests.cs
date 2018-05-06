using DataProcessing.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataProcessing.Tests.Conditions
{
    [TestClass]
    public class ConditionTests
    {
        [TestMethod]
        public void FieldEqualsCondition_Equals_Test()
        {
            var condition = new FieldEqualsCondition
            {
                FieldName = "Age",
                Value = 25
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            Assert.IsTrue(condition.Evaluate(record));
        }

        [TestMethod]
        public void FieldEqualsCondition_Not_Equals_Test()
        {
            var condition = new FieldEqualsCondition
            {
                FieldName = "Age",
                Value = 25
            };

            var record = new Dictionary<string, object>
            {
                { "Age", "25" }
            };

            Assert.IsFalse(condition.Evaluate(record));
        }

        [TestMethod]
        public void FieldEqualsCondition_Equals_With_And_Test()
        {
            var condition = new AndCondition
            {
                Conditions = new List<ICondition>
                {
                    new FieldEqualsCondition
                    {
                        FieldName = "Gender",
                        Value = 'M'
                    },
                    new FieldEqualsCondition
                    {
                        FieldName = "Age",
                        Value = 25
                    },
                    new FieldEqualsCondition
                    {
                        FieldName = "Name",
                        Value = "David"
                    }
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'M' },
                { "Age", 25 },
                { "Name", "David" }
            };

            Assert.IsTrue(condition.Evaluate(record));
        }

        [TestMethod]
        public void FieldEqualsCondition_Equals_With_And_Combined_With_Or_Test()
        {
            var condition = new AndCondition
            {
                Conditions = new List<ICondition>
                {
                    new OrCondition
                    {
                        Conditions = new List<ICondition>
                        {
                            new FieldEqualsCondition
                            {
                                FieldName = "Gender",
                                Value = 'F'
                            },
                            new FieldEqualsCondition
                            {
                                FieldName = "Age",
                                Value = 25
                            }
                        }
                    },
                    new OrCondition
                    {
                        Conditions = new List<ICondition>
                        {
                            new FieldEqualsCondition
                            {
                                FieldName = "Gender",
                                Value = 'M'
                            },
                            new FieldEqualsCondition
                            {
                                FieldName = "Name",
                                Value = "David"
                            }
                        }
                    }
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'M' },
                { "Age", 25 },
                { "Name", "David" }
            };

            Assert.IsTrue(condition.Evaluate(record));
        }
    }
}
