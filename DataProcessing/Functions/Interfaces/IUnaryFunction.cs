namespace DataProcessing.Functions
{
    public interface IUnaryFunction : IFunction
    {
        object Evaluate(object value);
    }

    public interface IUnaryFunction<TInput, TOutput> : IFunction, IUnaryFunction
    {
        TOutput Evaluate(TInput value);
    }
}
