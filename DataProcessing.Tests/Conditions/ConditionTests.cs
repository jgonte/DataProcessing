using DataProcessing.Conditions;
using DataProcessing.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataProcessing.Tests.Conditions
{
    [TestClass]
    public class ConditionTests
    {
        [TestMethod]
        public void Field_Is_Equal_Test()
        {
            var condition = new FieldIsEqual<int>
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
        public void Field_Is_Equal_With_Not_Equals_Test()
        {
            var condition = new FieldIsEqual<int>
            {
                FieldName = "Age",
                Value = 25
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 24 }
            };

            Assert.IsFalse(condition.Evaluate(record));
        }

        [TestMethod]
        public void And_Conditions_With_Fields_Is_Equal_Test()
        {
            var condition = new AndCondition
            {
                Conditions = new List<ICondition>
                {
                    new FieldIsEqual<char>
                    {
                        FieldName = "Gender",
                        Value = 'M'
                    },
                    new FieldIsEqual<int>
                    {
                        FieldName = "Age",
                        Value = 25
                    },
                    new FieldIsEqual<string>
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
        public void And_Combined_With_Or_Conditions_Test()
        {
            var condition = new AndCondition
            {
                Conditions = new List<ICondition>
                {
                    new OrCondition
                    {
                        Conditions = new List<ICondition>
                        {
                            new FieldIsEqual<char>
                            {
                                FieldName = "Gender",
                                Value = 'F'
                            },
                            new FieldIsEqual<int>
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
                            new FieldIsEqual<char>
                            {
                                FieldName = "Gender",
                                Value = 'M'
                            },
                            new FieldIsEqual<string>
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

        [TestMethod]
        public void Field_Is_Numeric_With_Substring_Test()
        {
            var condition = new FieldIsNumeric
            {
                FieldName = "Identifier",
                InputSource = new Substring
                {
                    StartIndex = 0,
                    EndIndex = 3
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Identifier", "123Z" }
            };

            Assert.IsTrue(condition.Evaluate(record));
        }

        [TestMethod]
        public void Field_Is_Zeroes_With_Substring_Test()
        {
            var condition = new FieldIsZeroes
            {
                FieldName = "Code",
                InputSource = new Substring
                {
                    StartIndex = 0,
                    EndIndex = 3
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Code", "000Z" }
            };

            Assert.IsTrue(condition.Evaluate(record));
        }
    }
}
