using System.Collections.Generic;

namespace DataProcessing.Builders
{
    public interface IExcelFileWriter<T> : IFileWriter
    {
        string WorksheetName { get; set; }

        bool OuputHeader { get; set; }

        Dictionary<int, string> ColumnIndexToHeaderTitleMap { get; set; }

        Dictionary<string, int> PropertyToColumnIndexMap { get; set; }

        List<T> Records { get; set; }
    }
}