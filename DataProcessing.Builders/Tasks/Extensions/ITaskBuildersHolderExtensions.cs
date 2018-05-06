﻿using DataProcessing.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessing.Builders
{
    public static class ITaskBuildersHolderExtensions
    {
        public static T Tasks<T>(this T builder, params ITaskBuilder[] builders)
            where T : ITaskBuildersHolder
        {
            builder.TaskBuilders.AddRange(builders);

            return builder;
        }

        public static T Tasks<T>(this T builder, params Func<ITaskBuilder, ITaskBuilder>[] factories)
            where T : ITaskBuildersHolder
        {
            return Tasks(builder, factories.Select(f => f(null)).ToArray());
        }
    }
}
