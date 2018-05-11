namespace DataProcessing.Conditions
{
    public class FieldIsIn<T> : MultipleValuedField<T>
    {
        internal override bool EvaluateValue(object value)
        {
            return Values.Contains((T)value);
        }

        public override void Format(IFormatter formatter)
        {
            formatter.Format(this);
        }
    }
}
