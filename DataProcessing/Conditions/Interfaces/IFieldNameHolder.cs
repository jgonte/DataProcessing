using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessing.Conditions
{
    public interface IFieldNameHolder
    {
        /// <summary>
        /// The name of the field of the record to test the condition against (case sensitive)
        /// </summary>
        string FieldName { get; set; }
    }
}
