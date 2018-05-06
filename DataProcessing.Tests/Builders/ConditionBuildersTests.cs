using DataProcessing.Builders;
using DataProcessing.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Utilities;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class ConditionBuildersTests
    {
        [TestMethod]
        public void FieldEqualsConditionBuilder_Test()
        {
            var builder = new FieldEqualsConditionBuilder()
                .FieldName("Age")
                .Value(25);

            var condition = builder.Build();

            Assert.IsInstanceOfType(condition, typeof(FieldEqualsCondition));

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(ComparisonOperators.Equal, condition.Operator);

            Assert.AreEqual(25, condition.Value);
        }

        [TestMethod]
        public void AndConditionBuilder_Test()
        {
            var builder = new AndConditionBuilder()
                .Conditions(
                    new FieldEqualsConditionBuilder()
                        .FieldName("Gender")
                        .Value('M'),
                    new FieldEqualsConditionBuilder()
                        .FieldName("Age")
                        .Value(25),
                    new FieldEqualsConditionBuilder()
                        .FieldName("Name")
                        .Value("David")
                );

            var condition = builder.Build();

            Assert.IsInstanceOfType(condition, typeof(AndCondition));

            Assert.AreEqual(3, condition.Conditions.Count());

            var itemCondition = (FieldEqualsCondition)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", itemCondition.FieldName);

            Assert.AreEqual(ComparisonOperators.Equal, itemCondition.Operator);

            Assert.AreEqual('M', itemCondition.Value);
        }

        [TestMethod]
        public void AndConditionBuilder_With_Factories_Test()
        {
            var builder = new AndConditionBuilder()
                .Conditions(
                    c => c.Field("Gender").IsEqual('M'),
                    c => c.Field("Age").IsEqual(25),
                    c => c.Field("Name").IsEqual("David")
                );

            var condition = builder.Build();

            Assert.IsInstanceOfType(condition, typeof(AndCondition));

            Assert.AreEqual(3, condition.Conditions.Count());

            var itemCondition = (FieldEqualsCondition)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", itemCondition.FieldName);

            Assert.AreEqual(ComparisonOperators.Equal, itemCondition.Operator);

            Assert.AreEqual('M', itemCondition.Value);
        }
    }
}
