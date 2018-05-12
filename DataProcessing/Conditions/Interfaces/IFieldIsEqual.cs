namespace DataProcessing.Conditions
{
    /// <summary>
    /// Marker interface to discriminate a condition regardless the type T of its value
    /// </summary>
    public interface IFieldIsEqual : IFieldNameHolder, ISingleValueHolder
    {
    }
}