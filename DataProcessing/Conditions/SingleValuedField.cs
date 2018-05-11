namespace DataProcessing.Conditions
{
    /// <summary>
    /// Single valued field
    /// </summary>
    public abstract class SingleValuedField<T> : FieldCondition,
        ISingleValueHolder<T>
    {
        public T Value { get; set; }
    }
}
