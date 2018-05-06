using DataProcessing.Conditions;

namespace DataProcessing.Builders
{
    public static class IFieldNameHolderExtensions
    {
        /// <summary>
        /// Sets the name of the field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T FieldName<T>(this T builder, string name)
            where T : IFieldNameHolder
        {
            builder.FieldName = name;

            return builder;
        }
    }
}
