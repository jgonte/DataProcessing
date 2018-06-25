using System.Collections.Generic;

namespace DataProcessing.Tasks
{
    public interface IExcelFileReader : IFileReader
    {
        int WorksheetNumber { get; set; }

        bool HasHeader { get; set; }

        Dictionary<int, string> ColumnIndexToPropertyMap { get; set; }
    }
}
