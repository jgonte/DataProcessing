using System.Collections.Generic;

namespace DataProcessing.Conditions
{
    public interface IMultipleValuesHolder<T>
    {
        List<T> Values { get; set; }
    }
}
