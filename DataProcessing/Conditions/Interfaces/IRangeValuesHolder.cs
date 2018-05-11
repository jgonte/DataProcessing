namespace DataProcessing.Conditions
{
    public interface IRangeValuesHolder<T>
    {
        T MinValue { get; set; }

        T MaxValue { get; set; }
    }
}