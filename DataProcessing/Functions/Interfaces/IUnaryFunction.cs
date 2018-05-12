namespace DataProcessing.Functions
{
    public interface IUnaryFunction : IFunction
    {
        object Evaluate(object value);
    }

    public interface IUnaryFunction<T> : IFunction, IUnaryFunction
    {
        T Evaluate(T value);
    }
}
