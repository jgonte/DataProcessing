using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Tests
{
    [TestClass]
    public class BusinessRulesTests
    {
        [TestMethod]
        public void Simple_Business_Rule_Test()
        {
            var rule = new Rule
            {
                Condition = new FieldEqualsCondition
                {
                    FieldName = "Age",
                    Value = 25
                },
                Tasks = new List<ITask>
                {
                    new ErrorMessageTask()
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            rule.Fire(record);

            Assert.AreEqual("Error occurred!", ((ErrorMessageTask)rule.Tasks.Single()).ErrorMessage);
        }

        [TestMethod]
        public void Simple_Business_Rules_With_And_Test()
        {
            var rule = new Rule
            {
                Condition = new AndCondition
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
                        }
                    }
                },
                Tasks = new List<ITask>
                {
                    new ErrorMessageTask()
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'M' },
                { "Age", 25 }
            };

            rule.Fire(record);

            Assert.AreEqual("Error occurred!", ((ErrorMessageTask)rule.Tasks.Single()).ErrorMessage);
        }

        [TestMethod]
        public void Simple_Business_Rules_With_Or_Test()
        {
            var rule = new Rule
            {
                Condition = new OrCondition
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
                        }
                    }
                },
                Tasks = new List<ITask>
                {
                    new ErrorMessageTask()
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'F' },
                { "Age", 25 }
            };

            rule.Fire(record);

            Assert.AreEqual("Error occurred!", ((ErrorMessageTask)rule.Tasks.Single()).ErrorMessage);
        }
    }
}
