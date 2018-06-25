using DataProcessing.BusinessRules;
using DataProcessing.Tasks;
using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public class ExcelReaderTaskBuilder<T> : TaskBuilder<ExcelReaderTask<T>>,
        IRuleContextHolder,
        IExcelFileReader
        where T : new()
    {
        public RuleContext RuleContext { get; set; }

        public string FullPath { get; set; }

        public int WorksheetNumber { get; set; } = 1;

        public bool HasHeader { get; set; }

        public Dictionary<int, string> ColumnIndexToPropertyMap { get; set; }

        public override ExcelReaderTask<T> Create()
        {
            return new ExcelReaderTask<T>();
        }

        public override void Initialize(ExcelReaderTask<T> reader)
        {
            base.Initialize(reader);

            reader.FullPath = FullPath;

            reader.WorksheetNumber = WorksheetNumber;

            reader.HasHeader = HasHeader;

            reader.ColumnIndexToPropertyMap = ColumnIndexToPropertyMap;
        }
    }
}
