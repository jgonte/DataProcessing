using DataProcessing.Builders;
using DataProcessing.BusinessRules;
using DataProcessing.Conditions;
using DataProcessing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class RuleBuildersTests
    {
        [TestMethod]
        public void Rule_Is_Equal_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Gender").IsEqual('M')
                )
                .Then(
                    a => a.Message("An error has occurred")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsEqual<char>)rule.Condition;

            Assert.AreEqual("Gender", condition.FieldName);

            Assert.AreEqual('M', condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("An error has occurred", task.Message);
        }

        [TestMethod]
        public void Rule_Is_Not_Equal_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsNotEqual(18)
                )
                .Then(
                    a => a.Message("Age must be 18")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsNotEqual<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be 18", task.Message);
        }

        [TestMethod]
        public void Rule_Is_Greater_Than_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsGreaterThan(18)
                )
                .Then(
                    a => a.Message("Age must be less or equal 18")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsGreaterThan<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be less or equal 18", task.Message);
        }

        [TestMethod]
        public void Rule_Is_Greater_Than_Or_Equal_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsGreaterThanOrEqual(18)
                )
                .Then(
                    a => a.Message("Age must be less than 18")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsGreaterThanOrEqual<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be less than 18", task.Message);
        }

        [TestMethod]
        public void Rule_Is_Less_Than_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsLessThan(18)
                )
                .Then(
                    a => a.Message("Age must be greater or equal 18")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsLessThan<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be greater or equal 18", task.Message);
        }

        [TestMethod]
        public void Rule_Is_Less_Than_Or_Equal_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsLessThanOrEqual(18)
                )
                .Then(
                    a => a.Message("Age must be greater than 18")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsLessThanOrEqual<int>)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(18, condition.Value);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age must be greater than 18", task.Message);
        }

        [TestMethod]
        public void Rule_IsNumeric_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsNumeric()
                )
                .Then(
                    a => a.Message("Age is numeric")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsNumeric)rule.Condition;

            Assert.AreEqual("Age", condition.FieldName);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Age is numeric", task.Message);
        }

        [TestMethod]
        public void Rule_IsZeroes_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Code").IsZeroes()
                )
                .Then(
                    a => a.Message("Code is all zeroes")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsZeroes)rule.Condition;

            Assert.AreEqual("Code", condition.FieldName);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Code is all zeroes", task.Message);
        }

        [TestMethod]
        public void Rule_Regular_Expression_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Email").IsRegularExpressionMatch(@"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$")
                )
                .Then(
                    a => a.Message("Email is correct")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsRegularExpressionMatch)rule.Condition;

            Assert.AreEqual("Email", condition.FieldName);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Email is correct", task.Message);
        }

        [TestMethod]
        public void Rule_In_Condition_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Code").IsIn("01", "02", "03")
                )
                .Then(
                    a => a.Message("Code is in one of those")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (FieldIsIn<string>)rule.Condition;

            Assert.AreEqual("Code", condition.FieldName);

            var values = condition.Values;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual("01", values.ElementAt(0));

            Assert.AreEqual("02", values.ElementAt(1));

            Assert.AreEqual("03", values.ElementAt(2));

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Code is in one of those", task.Message);
        }

        [TestMethod]
        public void Rule_Composite_With_IsNumeric_And_IsBetween_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    c => c.Field("Age").IsNumeric()
                        .And(
                            c.Field("Age").IsBetween("01", "62")
                                .Or(
                                    c.Field("Age").IsBetween("67", "90")
                                )
                        )
                )
                .Then(
                    a => a.Message("Incorrect age range")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (AndCondition)rule.Condition;

            var andLeftCondition = (FieldIsNumeric)condition.Conditions.First();

            Assert.AreEqual("Age", andLeftCondition.FieldName);

            var andRightCondition = (OrCondition)condition.Conditions.Last();

            var orLeftCondition = (FieldIsBetween<string>)andRightCondition.Conditions.First();

            Assert.AreEqual("Age", orLeftCondition.FieldName);

            Assert.AreEqual("01", orLeftCondition.MinValue);

            Assert.AreEqual("62", orLeftCondition.MaxValue);

            var orRightCondition = (FieldIsBetween<string>)andRightCondition.Conditions.Last();

            Assert.AreEqual("Age", orRightCondition.FieldName);

            Assert.AreEqual("67", orRightCondition.MinValue);

            Assert.AreEqual("90", orRightCondition.MaxValue);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Incorrect age range", task.Message);
        }

        [TestMethod]
        public void Rule_Composite_With_Not_IsNumeric_And_IsBetween_Builder_Test()
        {
            var builder = new RuleBuilder()
                .If(
                    n => n.Not(
                        c =>c.Field("Age").IsNumeric()
                            .And(
                                c.Field("Age").IsBetween("01", "62")
                                    .Or(
                                        c.Field("Age").IsBetween("67", "90")
                                    )
                            )
                    )
                )
                .Then(
                    a => a.Message("Incorrect age range")
                );

            var rule = builder.Build();

            Assert.IsInstanceOfType(rule, typeof(Rule));

            var condition = (NotCondition)rule.Condition;

            var innerCondition = (AndCondition)condition.Condition;

            var andLeftCondition = (FieldIsNumeric)innerCondition.Conditions.First();

            Assert.AreEqual("Age", andLeftCondition.FieldName);

            var andRightCondition = (OrCondition)innerCondition.Conditions.Last();

            var orLeftCondition = (FieldIsBetween<string>)andRightCondition.Conditions.First();

            Assert.AreEqual("Age", orLeftCondition.FieldName);

            Assert.AreEqual("01", orLeftCondition.MinValue);

            Assert.AreEqual("62", orLeftCondition.MaxValue);

            var orRightCondition = (FieldIsBetween<string>)andRightCondition.Conditions.Last();

            Assert.AreEqual("Age", orRightCondition.FieldName);

            Assert.AreEqual("67", orRightCondition.MinValue);

            Assert.AreEqual("90", orRightCondition.MaxValue);

            var task = (RuleMessageTask)rule.Tasks.Single();

            Assert.AreEqual("Incorrect age range", task.Message);
        }
    }
}
