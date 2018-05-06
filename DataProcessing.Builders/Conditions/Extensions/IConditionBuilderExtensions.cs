using DataProcessing.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessing.Builders
{
    public static class IConditionBuilderExtensions
    {
        public static FieldConditionBuilderProxy Field<T>(this T builder, string name)
            where T : IConditionBuilder
        {
            return new FieldConditionBuilderProxy(name);
        }
    }
}
