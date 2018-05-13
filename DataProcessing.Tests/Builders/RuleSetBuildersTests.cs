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
    public class RuleSetBuildersTests
    {
        [TestMethod]
        public void RuleSet_Builder_Test()
        {
            var builder = new RuleSetBuilder()
                .Rules(
                    r => r.If(
                        c => c.Field("Age").IsNotEqual(18)
                    )
                    .Then(
                        a => a.Message("Age must be greater or equal to 18")
                    )
                );

            var ruleSet = builder.Build();

            Assert.IsInstanceOfType(ruleSet, typeof(RuleSet));

            var rule = ruleSet.Rules.Single();

            var condition = (FieldIsNotEqual<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be greater or equal to 18", task.Message);
        }
    }
}
