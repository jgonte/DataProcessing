using DataProcessing.Functions;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public class SubstringBuilder : Builder<Substring>,
        IFunctionBuilder,
        IStartEndIndexesHolder
    {
        int IStartEndIndexesHolder.StartIndex { get; set; }

        int? IStartEndIndexesHolder.EndIndex { get; set; }

        public override void Initialize(Substring function)
        {
            function.StartIndex = ((IStartEndIndexesHolder)this).StartIndex;

            function.EndIndex = ((IStartEndIndexesHolder)this).EndIndex;
        }

        IFunction IBuilder<IFunction>.Build()
        {
            return Build();
        }
    }
}
