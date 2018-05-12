namespace DataProcessing.Functions
{
    public class Substring : IUnaryFunction<string>,
        IStartEndIndexesHolder
    {
        public int StartIndex { get; set; }

        public int? EndIndex { get; set; }

        public object Evaluate(object value)
        {
            return Evaluate((string)value);
        }

        public string Evaluate(string value)
        {
            return EndIndex.HasValue ?
                value.Substring(StartIndex, EndIndex.Value - StartIndex)
                : value.Substring(StartIndex);
        }
    }
}
