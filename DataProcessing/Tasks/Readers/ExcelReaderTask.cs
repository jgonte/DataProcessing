using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcessing.Tasks
{
    /// <summary>
    /// Reads data from an Excel file using ADO.NET
    /// </summary>
    public class ExcelReaderTask : ITask
    {
        public string Description { get; set; }

        /// <summary>
        /// Full path to the Excel file
        /// </summary>
        public string FullPath { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
