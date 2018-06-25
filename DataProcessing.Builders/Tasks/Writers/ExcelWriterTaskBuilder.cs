using DataProcessing.BusinessRules;
using DataProcessing.Tasks;
using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public class ExcelWriterTaskBuilder<T> : TaskBuilder<ExcelWriterTask<T>>,
        IRuleContextHolder,
        IExcelFileWriter<T>
    {
        public RuleContext RuleContext { get; set; }

        public string FullPath { get; set; }

        public string WorksheetName { get; set; } = "Sheet1";

        public bool OuputHeader { get; set; } = true;

        public Dictionary<int, string> ColumnIndexToHeaderTitleMap { get; set; }

        public Dictionary<string, int> PropertyToColumnIndexMap { get; set; }

        public List<T> Records { get; set; }

        public override ExcelWriterTask<T> Create()
        {
            return new ExcelWriterTask<T>();
        }

        public override void Initialize(ExcelWriterTask<T> writer)
        {
            base.Initialize(writer);

            writer.FullPath = FullPath;

            writer.WorksheetName = WorksheetName;

            writer.OuputHeader = OuputHeader;

            writer.ColumnIndexToHeaderTitleMap = ColumnIndexToHeaderTitleMap;

            writer.PropertyToColumnIndexMap = PropertyToColumnIndexMap;

            writer.Records = Records;
        }
    }
}
