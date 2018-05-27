namespace DataProcessing.Builders
{
    public static class IFunctionBuilderExtensions
    {
        public static SubstringBuilder Substring<T>(this T builder, int startIndex = 0, int? endIndex = null)
            where T : IFunctionBuilder
        {
            return new SubstringBuilder(startIndex, endIndex);
        }

        public static ToDateBuilder ToDate<T>(this T builder, string format)
            where T : IFunctionBuilder
        {
            return new ToDateBuilder(format);
        }

        public static ToIntegerBuilder ToInteger<T>(this T builder)
            where T : IFunctionBuilder
        {
            return new ToIntegerBuilder();
        }
    }
}
