namespace DataProcessing.Conditions
{
    /// <summary>
    /// Range valued field
    /// </summary>
    public abstract class RangeValuedField<T> : FieldCondition,
        IRangeValuesHolder<T>
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }
    }
}
