using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    public interface IFieldNamesHolder
    {
        /// <summary>
        /// The name of fields that participate in the condition
        /// </summary>
        IEnumerable<string> FieldNames { get; }
    }
}