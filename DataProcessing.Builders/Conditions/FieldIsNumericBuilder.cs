using System;
using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public class FieldIsNumericBuilder : FieldConditionBuilder<FieldIsNumeric>
    {
        public override FieldIsNumeric Create()
        {
            return new FieldIsNumeric();
        }

    }
}
