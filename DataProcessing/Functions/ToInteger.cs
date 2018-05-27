namespace DataProcessing.Functions
{
    public class ToInteger : IUnaryFunction<string, int>
    {
        public int Evaluate(string value)
        {
            return int.Parse(value);
        }

        public object Evaluate(object value)
        {
            return Evaluate((string)value);
        }
    }
}
