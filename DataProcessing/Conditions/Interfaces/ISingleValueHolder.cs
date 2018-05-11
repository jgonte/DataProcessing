namespace DataProcessing.Conditions
{
    /// <summary>
    /// Defines an object that holds a single value
    /// </summary>
    public interface ISingleValueHolder<T>
    {
        /// <summary>
        /// The value that the object holds
        /// </summary>
        T Value { get; set; }
    }
}
