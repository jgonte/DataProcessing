namespace DataProcessing.Builders
{
    public static class ITaskBuilderExtensions
    {
        #region Factory methods

        public static RuleMessageTaskBuilder Message<T>(this T builder, string message)
            where T : ITaskBuilder
        {
            return new RuleMessageTaskBuilder(message);
        }

        #endregion
    }
}
