using DataProcessing.Functions;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// To allow the retrieval of the value as an object regardless of the generic implementation
    /// </summary>
    public interface ISingleValueHolder
    {
        object GetValue();
    }

    /// <summary>
    /// Defines an object that holds a single value
    /// </summary>
    public interface ISingleValueHolder<T> : ISingleValueHolder
    {
        /// <summary>
        /// The value that the condition holds
        /// </summary>
        T Value { get; set; }
    }
}
