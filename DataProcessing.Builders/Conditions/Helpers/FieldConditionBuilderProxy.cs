using System;

namespace DataProcessing.Builders
{
    /// <summary>
    /// Helper to use fluent interfaces to construct a field builder
    /// </summary>
    public class FieldConditionBuilderProxy
    {
        private string _fieldName;

        public FieldConditionBuilderProxy(string fieldName)
        {
            _fieldName = fieldName;
        }

        #region Factory methods

        public FieldIsEqualBuilder<T> IsEqual<T>(T value) where T : IEquatable<T>
        {
            return new FieldIsEqualBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsNotEqualBuilder<T> IsNotEqual<T>(T value) where T : IEquatable<T>
        {
            return new FieldIsNotEqualBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsGreaterThanBuilder<T> IsGreaterThan<T>(T value) where T : IComparable<T>
        {
            return new FieldIsGreaterThanBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsGreaterThanOrEqualBuilder<T> IsGreaterThanOrEqual<T>(T value) where T : IComparable<T>
        {
            return new FieldIsGreaterThanOrEqualBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsLessThanBuilder<T> IsLessThan<T>(T value) where T : IComparable<T>
        {
            return new FieldIsLessThanBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsLessThanOrEqualBuilder<T> IsLessThanOrEqual<T>(T value) where T : IComparable<T>
        {
            return new FieldIsLessThanOrEqualBuilder<T>()
                .FieldName(_fieldName)
                .Value(value);
        }

        public FieldIsNumericBuilder IsNumeric()
        {
            return new FieldIsNumericBuilder()
                .FieldName(_fieldName);
        }

        public FieldIsZeroesBuilder IsZeroes()
        {
            return new FieldIsZeroesBuilder()
                .FieldName(_fieldName);
        }

        public FieldIsBetweenBuilder<T> IsBetween<T>(T minValue, T maxValue) where T : IComparable<T>
        {
            return new FieldIsBetweenBuilder<T>()
                .FieldName(_fieldName)
                .MinValue(minValue)
                .MaxValue(maxValue);
        }

        public FieldIsRegularExpressionMatchBuilder IsRegularExpressionMatch(string regularExpression)
        {
            return new FieldIsRegularExpressionMatchBuilder()
                .FieldName(_fieldName)
                .RegularExpression(regularExpression);
        }

        public FieldIsInBuilder<T> IsIn<T>(params T[] values)
        {
            return new FieldIsInBuilder<T>()
                .FieldName(_fieldName)
                .Values(values);
        }

        #endregion
    }
}