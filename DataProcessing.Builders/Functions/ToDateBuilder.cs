using DataProcessing.Functions;

namespace DataProcessing.Builders
{
    public class ToDateBuilder : FunctionBuilder<ToDate>,
        IFormatHolder
    {
        string IFormatHolder.Format { get; set; }

        public ToDateBuilder(string format)
        {
            ((IFormatHolder)this).Format = format;
        }

        public override void Initialize(ToDate function)
        {
            function.Format = ((IFormatHolder)this).Format;
        }
    }
}
