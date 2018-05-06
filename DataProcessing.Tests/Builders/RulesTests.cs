using DataProcessing.Builders;
using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Utilities;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class RulesTests
    {
        [TestMethod]
        public void Simple_Rule_Builder_Test()
        {
            var builder = new RuleBuilder()
                .Condition(
                    c => c.Field("Gender").IsEqual('M')
                )
                .Tasks(
                    a => a.ErrorMessage()
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldEqualsCondition)rule.Condition;

            Assert.AreEqual("Gender", condition.FieldName);

            Assert.AreEqual(ComparisonOperators.Equal, condition.Operator);

            Assert.AreEqual('M', condition.Value);

            var task = (ErrorMessageTask)rule.Tasks.Single();

            Assert.AreEqual("kuku", task.ErrorMessage);

        }
    }
}
