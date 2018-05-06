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

        public FieldEqualsConditionBuilder IsEqual(object value)
        {
            return new FieldEqualsConditionBuilder()
                .FieldName(_fieldName)
                .Value(value);
        } 

        #endregion
    }
}