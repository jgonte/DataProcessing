using System;
using System.Globalization;

namespace DataProcessing.Functions
{
    public class ToDate : IUnaryFunction<string, DateTime>,
        IFormatHolder
    {
        public string Format { get; set; }

        public DateTime Evaluate(string value)
        {
            return DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture);
        }

        public object Evaluate(object value)
        {
            return Evaluate((string)value);
        }
    }
}
