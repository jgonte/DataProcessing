using DataProcessing.Functions;
using System;

namespace DataProcessing.Builders
{
    public static class IUnaryFunctionHolderExtensions
    {
        public static T InputFilter<T>(this T builder, IUnaryFunction unaryFunction)
            where T : IUnaryFunctionHolder
        {
            builder.InputSource = unaryFunction;

            return builder;
        }

        public static T InputFilter<T>(this T builder, Func<IFunctionBuilder, IFunctionBuilder> factory)
            where T : IUnaryFunctionHolder
        {
            var function = (IUnaryFunction)factory(null).Build();

            return InputFilter(builder, function);
        }
    }
}
