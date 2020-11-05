using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Myframework.Libraries.Application.Extensions
{
    public static class IMemoryCacheExtensions
    {
        public static void Clear(this IMemoryCache memoryCache)
        {
            PropertyInfo prop = memoryCache.GetType().GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public);
            object innerCache = prop.GetValue(memoryCache);
            MethodInfo clearMethod = innerCache.GetType().GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public);
            clearMethod.Invoke(innerCache, null);
        }
    }
}