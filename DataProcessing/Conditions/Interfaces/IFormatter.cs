using DataProcessing.Tasks;
using System;

namespace DataProcessing.Conditions
{
    public interface IFormatter
    {
        #region Conditions

        void Format<T>(FieldIsEqual<T> condition) where T : IEquatable<T>;

        void Format<T>(FieldIsNotEqual<T> condition) where T : IEquatable<T>;

        void Format(FieldIsNumeric condition);

        void Format<T>(FieldIsBetween<T> condition) where T : IComparable<T>;

        void Format<T>(FieldIsIn<T> condition);

        void Format<T>(FieldIsLessThanOrEqual<T> condition) where T : IComparable<T>;

        void Format(RegularExpressionCondition condition);

        void Format<T>(FieldIsLessThan<T> condition) where T : IComparable<T>;

        void Format<T>(FieldIsGreaterThanOrEqual<T> condition) where T : IComparable<T>;

        void Format<T>(FieldIsGreaterThan<T> condition) where T : IComparable<T>;

        void Format(AndCondition condition);

        void Format(OrCondition condition);

        void Format(NotCondition condition);

        #endregion

        #region Tasks

        void Format(RuleMessageTask errorMessageTask);

        #endregion
    }
}