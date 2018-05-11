using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Tests.BusinessRules
{
    [TestClass]
    public class RuleSetsTests
    {
        [TestMethod]
        public void RuleSet_Single_Record_Test()
        {
            var ruleSet = new RuleSet
            {
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Condition = new FieldIsNotEqual<int>
                        {
                            FieldName = "Age",
                            Value = 25
                        },
                        Tasks = new List<ITask>
                        {
                            new RuleMessageTask("Age must be 25")
                        }
                    }
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            ruleSet.Fire(record, 1);

            Assert.AreEqual(0, ruleSet.Messages.Count);
        }

        [TestMethod]
        public void RuleSet_Multiple_Records_Test()
        {
            var ruleSet = new RuleSet
            {
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Condition = new FieldIsNotEqual<int>
                        {
                            FieldName = "Age",
                            Value = 25
                        },
                        Tasks = new List<ITask>
                        {
                            new RuleMessageTask("Age must be 25")
                        }
                    }
                }
            };

            var records = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "Age", 25 }
                },
                new Dictionary<string, object>
                {
                    { "Age", 52 }
                }
            };

            ruleSet.Fire(records);

            Assert.AreEqual(1, ruleSet.Messages.Count);

            var message = ruleSet.Messages.Single();

            Assert.AreEqual(2, message.Line);

            Assert.AreEqual("Age", message.FieldNames.Single());

            Assert.AreEqual("Age must be 25", message.Message);
        }
    }
}
