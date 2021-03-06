﻿using System.Linq;

namespace DataProcessing.Conditions
{
    public class FieldIsNumeric : FieldCondition
    {
        internal override bool EvaluateValue(object value)
        {
            return value.ToString().All(char.IsDigit);
        }
    }
}
