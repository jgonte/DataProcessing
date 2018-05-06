namespace DataProcessing.Builders
{
    public static class ITaskBuilderExtensions
    {
        #region Factory methods

        public static ErrorMessageTaskBuilder ErrorMessage<T>(this T builder)
            where T : ITaskBuilder
        {
            return new ErrorMessageTaskBuilder();
        }

        #endregion
    }
}
