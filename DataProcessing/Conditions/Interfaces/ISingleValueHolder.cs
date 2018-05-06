namespace DataProcessing.Conditions
{
    /// <summary>
    /// Defines an object that holds a single value
    /// </summary>
    public interface ISingleValueHolder
    {
        /// <summary>
        /// The value that the object holds
        /// </summary>
        object Value { get; set; }
    }
}
