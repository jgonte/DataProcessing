using DataProcessing.Builders;
using DataProcessing.Conditions;
using DataProcessing.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class ConditionBuildersTests
    {
        [TestMethod]
        public void Field_Is_Equal_Builder_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c => c.Field("Age").IsEqual(25);

            var condition = (FieldIsEqual<int>)factory(null).Build();

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(25, condition.Value);
        }

        public void Field_Is_Greater_Than_Builder_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c => c.Field("Age").IsGreaterThan(25);

            var condition = (FieldIsGreaterThan<int>)factory(null).Build();

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(25, condition.Value);
        }

        public void Field_Is_Greater_Than_Or_Equal_Builder_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c => c.Field("Age").IsGreaterThanOrEqual(25);

            var condition = (FieldIsGreaterThan<int>)factory(null).Build();

            Assert.AreEqual("Age", condition.FieldName);

            Assert.AreEqual(25, condition.Value);
        }

        [TestMethod]
        public void Not_Field_Is_Equal_Builder_Test()
        {
            var builder = new NotConditionBuilder()
                .Condition(
                    c => c.Field("Age").IsEqual(25)
                );

            var condition = builder.Build();

            var innerCondition = (FieldIsEqual<int>)condition.Condition;

            Assert.AreEqual("Age", innerCondition.FieldName);

            Assert.AreEqual(25, innerCondition.Value);
        }

        [TestMethod]
        public void Field_Is_Numeric_Builder_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c => c.Field("Age").IsNumeric();

            var condition = (FieldIsNumeric)factory(null).Build();

            Assert.AreEqual("Age", condition.FieldName);
        }

        [TestMethod]
        public void Field_Is_Numeric_Builder_With_Substring_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c => c.Field("Age").IsNumeric()
                .InputSource(
                    f => f.Substring().StartIndex(2).EndIndex(3)
                );

            var condition = (FieldIsNumeric)factory(null).Build();

            Assert.AreEqual("Age", condition.FieldName);

            var function = (Substring)condition.InputSource;

            Assert.AreEqual(2, function.StartIndex);

            Assert.AreEqual(3, function.EndIndex);
        }

        [TestMethod]
        public void And_Condition_Builder_Using_Conditions_Method_Test()
        {
            var builder = new AndConditionBuilder()
                .Conditions(
                    c => c.Field("Gender").IsEqual('M'),
                    c => c.Field("Age").IsEqual(25),
                    c => c.Field("Name").IsEqual("David")
                );

            var condition = builder.Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void And_Condition_Builder_Using_Fluent_Methods_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').And(
                    c.Field("Age").IsEqual(25)
                )
                .And(
                    c.Field("Name").IsEqual("David")
                );

            var condition = (AndCondition)factory(null).Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void And_Condition_Builder_Using_Fluent_Methods_Equivalent_With_Above_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').And(
                    c.Field("Age").IsEqual(25).And(
                        c.Field("Name").IsEqual("David")
                    )
                );

            var condition = (AndCondition)factory(null).Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void Or_Condition_Builder_Using_Conditions_Method_Test()
        {
            var builder = new OrConditionBuilder()
                .Conditions(
                    c => c.Field("Gender").IsEqual('M'),
                    c => c.Field("Age").IsEqual(25),
                    c => c.Field("Name").IsEqual("David")
                );

            var condition = builder.Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void Or_Condition_Builder_Using_Fluent_Methods_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').Or(
                    c.Field("Age").IsEqual(25)
                )
                .Or(
                    c.Field("Name").IsEqual("David")
                );

            var condition = (OrCondition)factory(null).Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void Or_Condition_Builder_Using_Fluent_Methods_Equivalent_With_Above_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').Or(
                    c.Field("Age").IsEqual(25).Or(
                        c.Field("Name").IsEqual("David")
                    )
                );

            var condition = (OrCondition)factory(null).Build();

            Assert.AreEqual(3, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var intCondition = (FieldIsEqual<int>)condition.Conditions.ElementAt(1);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)condition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void Combined_And_Or_Condition_Builders_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').And(
                    c.Field("Age").IsEqual(25).Or(
                        c.Field("Name").IsEqual("David")
                    )
                );

            var condition = (AndCondition)factory(null).Build();

            Assert.AreEqual(2, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var orCondition = (OrCondition)condition.Conditions.ElementAt(1);

            var intCondition = (FieldIsEqual<int>)orCondition.Conditions.ElementAt(0);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)orCondition.Conditions.ElementAt(1);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }

        [TestMethod]
        public void Combined_And_Or_Condition_Builders_Test2()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').Or(
                    c.Field("Gender").IsEqual('F')).And(
                    c.Field("Age").IsEqual(25).Or(
                        c.Field("Name").IsEqual("David").Or(
                            c.Field("Name").IsEqual("Kevon")
                        )
                    )
                );

            var condition = (AndCondition)factory(null).Build();

            Assert.AreEqual(2, condition.Conditions.Count());

            var orCondition = (OrCondition)condition.Conditions.ElementAt(0);

            Assert.AreEqual(2, orCondition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)orCondition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            charCondition = (FieldIsEqual<char>)orCondition.Conditions.ElementAt(1);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('F', charCondition.Value);

            orCondition = (OrCondition)condition.Conditions.ElementAt(1);

            Assert.AreEqual(3, orCondition.Conditions.Count());

            var intCondition = (FieldIsEqual<int>)orCondition.Conditions.ElementAt(0);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)orCondition.Conditions.ElementAt(1);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);

            stringCondition = (FieldIsEqual<string>)orCondition.Conditions.ElementAt(2);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("Kevon", stringCondition.Value);
        }

        [TestMethod]
        public void Combined_Or_And_Condition_Builders_Test()
        {
            Func<IConditionBuilder, IConditionBuilder> factory = c =>
                c.Field("Gender").IsEqual('M').Or(
                    c.Field("Age").IsEqual(25).And(
                        c.Field("Name").IsEqual("David")
                    )
                );

            var condition = (OrCondition)factory(null).Build();

            Assert.AreEqual(2, condition.Conditions.Count());

            var charCondition = (FieldIsEqual<char>)condition.Conditions.ElementAt(0);

            Assert.AreEqual("Gender", charCondition.FieldName);

            Assert.AreEqual('M', charCondition.Value);

            var orCondition = (AndCondition)condition.Conditions.ElementAt(1);

            var intCondition = (FieldIsEqual<int>)orCondition.Conditions.ElementAt(0);

            Assert.AreEqual("Age", intCondition.FieldName);

            Assert.AreEqual(25, intCondition.Value);

            var stringCondition = (FieldIsEqual<string>)orCondition.Conditions.ElementAt(1);

            Assert.AreEqual("Name", stringCondition.FieldName);

            Assert.AreEqual("David", stringCondition.Value);
        }
    }
}
