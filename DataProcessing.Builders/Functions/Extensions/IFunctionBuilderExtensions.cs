namespace DataProcessing.Builders
{
    public static class IFunctionBuilderExtensions
    {
        public static SubstringBuilder Substring<T>(this T builder)
            where T : IFunctionBuilder
        {
            return new SubstringBuilder();
        }
    }
}
