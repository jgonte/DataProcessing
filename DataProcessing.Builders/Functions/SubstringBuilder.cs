using DataProcessing.Functions;

namespace DataProcessing.Builders
{
    public class SubstringBuilder : FunctionBuilder<Substring>,
        IStartEndIndexesHolder
    {
        int IStartEndIndexesHolder.StartIndex { get; set; }

        int? IStartEndIndexesHolder.EndIndex { get; set; }

        public SubstringBuilder(int startIndex, int? endIndex)
        {
            ((IStartEndIndexesHolder)this).StartIndex = startIndex;

            ((IStartEndIndexesHolder)this).EndIndex = endIndex;
        }

        public override void Initialize(Substring function)
        {
            function.StartIndex = ((IStartEndIndexesHolder)this).StartIndex;

            function.EndIndex = ((IStartEndIndexesHolder)this).EndIndex;
        }
    }
}
