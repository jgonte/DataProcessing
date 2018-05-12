namespace DataProcessing.Conditions
{
    public class FieldIsIn<T> : MultipleValuedField<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return Values.Contains((T)value);
        }
    }
}
