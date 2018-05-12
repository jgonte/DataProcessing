using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// To allow the retrieval of the values as a list of objects regardless of the generic implementation
    /// </summary>
    public interface IMultipleValuesHolder
    {
        List<object> GetValues();
    }

    public interface IMultipleValuesHolder<T> : IMultipleValuesHolder
    {
        List<T> Values { get; set; }
    }
}
