using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utilities;

namespace DataProcessing.Tasks
{
    /// <summary>
    /// Reads data from an Excel file
    /// </summary>
    public class ExcelReaderTask<T> : ITask,
        IExcelFileReader
        where T : new()
    {
        public string Description { get; set; }

        /// <summary>
        /// Full path to the Excel file
        /// </summary>
        public string FullPath { get; set; }

        public int WorksheetNumber { get; set; } = 1;

        public bool HasHeader { get; set; } = true;

        public Dictionary<int, string> ColumnIndexToPropertyMap { get; set; } = new Dictionary<int, string>();

        public List<T> Results { get; private set; } = new List<T>();

        public void Execute()
        {
            using (var package = new ExcelPackage(new FileInfo(FullPath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[WorksheetNumber];

                int rowCount = worksheet.Dimension.Rows;

                int ColCount = worksheet.Dimension.Columns;

                // Create a map from the index of the columns to the property of the type from the header if one is provided
                if (!ColumnIndexToPropertyMap.Any())
                {
                    if (HasHeader) // Populate the map from the header
                    {
                        for (int col = 1; col <= ColCount; ++col)
                        {
                            ColumnIndexToPropertyMap.Add(col, worksheet.Cells[1, col].Value.ToString());
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Without a header, a map from the column index to the property name needs to be provided.");
                    }
                }

                int startRow = HasHeader ? 2 : 1;

                var typeAccessor = typeof(T).GetTypeAccessor();

                for (int row = startRow; row <= rowCount; ++row)
                {
                    var item = new T();

                    for (int col = 1; col <= ColCount; ++col)
                    {
                        typeAccessor.SetValue(item, ColumnIndexToPropertyMap[col], worksheet.Cells[row, col].Value);
                    }

                    Results.Add(item);
                }
            }
        }
    }
}
