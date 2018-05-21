using DataProcessing.Functions;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public abstract class FunctionBuilder<T> : AbstractBuilder<T>,
        IFunctionBuilder
        where T : IFunction, new()
    {
        public override T Create()
        {
            return new T();
        }

        IFunction IBuilder<IFunction>.Build()
        {
            return Build();
        }
    }
}
