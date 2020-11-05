﻿using System.Collections.Generic;

namespace Myframework.Libraries.Common.Extensions
{
    public static class ICollectionExtension
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (T item in items) collection.Add(item);
        }
    }
}
