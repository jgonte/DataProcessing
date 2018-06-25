using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utilities;

namespace DataProcessing.Tasks
{
    public class ExcelWriterTask<T> : ITask
    {
        public string Description { get; set; }

        /// <summary>
        /// Full path to the Excel file
        /// </summary>
        public string FullPath { get; set; }

        public string WorksheetName { get; set; } = "Sheet1";

        public bool OuputHeader { get; set; } = true;

        public Dictionary<int, string> ColumnIndexToHeaderTitleMap { get; set; }

        public Dictionary<string, int> PropertyToColumnIndexMap { get; set; }

        public List<T> Records { get; set; }

        public void Execute()
        {
            if (PropertyToColumnIndexMap?.Any() == false)
            {
                throw new InvalidOperationException("PropertyToColumnIndexMap must be provided");
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(FullPath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(WorksheetName);

                var typeAccessor = typeof(T).GetTypeAccessor();

                var row = 1;

                if (OuputHeader)
                {
                    foreach (var propertyAccessor in typeAccessor.PropertyAccessors)
                    {
                        var propertyName = propertyAccessor.Value.PropertyName;

                        var col = PropertyToColumnIndexMap[propertyName];

                        var propertyTitle = ColumnIndexToHeaderTitleMap?.ContainsKey(col) == true ?
                            ColumnIndexToHeaderTitleMap[col] :
                            propertyName;

                        worksheet.Cells[row, col].Value = propertyTitle;
                    }

                    ++row;
                }

                foreach (var record in Records)
                {
                    foreach (var propertyAccessor in typeAccessor.PropertyAccessors)
                    {
                        var propertyName = propertyAccessor.Value.PropertyName;

                        var col = PropertyToColumnIndexMap[propertyName];

                        worksheet.Cells[row, col].Value = propertyAccessor.Value.GetValue(record).ToString();
                    }

                    row++;
                }

                package.Save();
            }
        }
    }
}
