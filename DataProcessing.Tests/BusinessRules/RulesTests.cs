using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Tests
{
    [TestClass]
    public class RulesTests
    {
        [TestMethod]
        public void Rule_Is_Equal_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new FieldIsEqual<int>
                {
                    FieldName = "Age",
                    Value = 25
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Age must not be 25")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Age must not be 25", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual("Age", context.FieldNames.Single());

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual("Age", message.FieldNames.Single());

            Assert.AreEqual("Age must not be 25", message.Message);
        }

        [TestMethod]
        public void Rule_Is_Not_Equal_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new NotCondition
                {
                    Condition = new FieldIsEqual<int>
                    {
                        FieldName = "Age",
                        Value = 25
                    }
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Age must be 25")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Age", 24 }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Age must be 25", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual("Age", context.FieldNames.Single());

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual("Age", message.FieldNames.Single());

            Assert.AreEqual("Age must be 25", message.Message);
        }

        [TestMethod]
        public void Rule_Is_Numeric_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new FieldIsNumeric
                {
                    FieldName = "Age"
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Field is numeric")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Age", "01" }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Field is numeric", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual("Age", context.FieldNames.Single());

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual("Age", message.FieldNames.Single());

            Assert.AreEqual("Field is numeric", message.Message);
        }

        [TestMethod]
        public void Rule_In_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new FieldIsIn<string>
                {
                    FieldName = "Code",
                    Values = new List<string> { "01", "02", "03" }
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Field is in code")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Code", "02" }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Field is in code", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual("Code", context.FieldNames.Single());

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual("Code", message.FieldNames.Single());

            Assert.AreEqual("Field is in code", message.Message);
        }

        [TestMethod]
        public void Rules_With_And_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new AndCondition
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
                        }
                    }
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Error occurred!")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'M' },
                { "Age", 25 }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Error occurred!", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual(2, context.FieldNames.Count());

            Assert.AreEqual("Gender", context.FieldNames.ElementAt(0));

            Assert.AreEqual("Age", context.FieldNames.ElementAt(1));

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual(2, message.FieldNames.Count());

            Assert.AreEqual("Gender", message.FieldNames.ElementAt(0));

            Assert.AreEqual("Age", message.FieldNames.ElementAt(1));

            Assert.AreEqual("Error occurred!", message.Message);

        }

        [TestMethod]
        public void Business_Rules_With_Or_Test()
        {
            var messages = new List<RuleMessage>();

            var context = new RuleContext(messages, 1);

            var rule = new Rule
            {
                Condition = new OrCondition
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
                        }
                    }
                },
                Tasks = new List<ITask>
                {
                    new RuleMessageTask("Error occurred!")
                }
            };

            var record = new Dictionary<string, object>
            {
                { "Gender", 'F' },
                { "Age", 25 }
            };

            rule.Fire(context, record);

            Assert.AreEqual("Error occurred!", ((RuleMessageTask)rule.Tasks.Single()).Message);

            Assert.AreEqual(2, context.FieldNames.Count());

            Assert.AreEqual("Gender", context.FieldNames.ElementAt(0));

            Assert.AreEqual("Age", context.FieldNames.ElementAt(1));

            Assert.AreEqual(1, messages.Count);

            var message = messages.Single();

            Assert.AreEqual(1, message.Line);

            Assert.AreEqual(2, message.FieldNames.Count());

            Assert.AreEqual("Gender", message.FieldNames.ElementAt(0));

            Assert.AreEqual("Age", message.FieldNames.ElementAt(1));

            Assert.AreEqual("Error occurred!", message.Message);
        }
    }
}
