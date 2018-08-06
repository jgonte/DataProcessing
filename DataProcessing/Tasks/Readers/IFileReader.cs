namespace DataProcessing.Tasks
{
    public interface IFileReader
    {
        /// <summary>
        /// Full path to the file
        /// </summary>
        string FullPath { get; set; }
    }
}