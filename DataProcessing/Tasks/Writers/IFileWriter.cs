namespace DataProcessing.Builders
{
    public interface IFileWriter
    {
        /// <summary>
        /// Full path to the file
        /// </summary>
        string FullPath { get; set; }
    }
}