using DataProcessing.Functions;

namespace DataProcessing.Builders
{
    public static class IStartEndIndexesHolderExtensions
    {
        public static T StartIndex<T>(this T builder, int startIndex)
            where T : IStartEndIndexesHolder
        {
            builder.StartIndex = startIndex;

            return builder;
        }

        public static T EndIndex<T>(this T builder, int endIndex)
            where T : IStartEndIndexesHolder
        {
            builder.EndIndex = endIndex;

            return builder;
        }
    }
}
