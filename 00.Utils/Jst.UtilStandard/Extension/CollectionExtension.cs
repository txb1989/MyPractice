using System;
using System.Collections.Generic;
using System.Linq;

namespace Jst.UtilStandard.Extension
{
    /// <summary>
    /// 集合扩展方法
    /// </summary>
    public static class CollectionExtension
    {
      
        /// <summary>
        /// 根据约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="equalExpression"></param>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> source,Func<T,bool> equalExpression)
        {
           return source.Count(item => equalExpression(item)) >0;
        }

        /// <summary>
        /// 集合是否为空或者null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !IsNotEmpty(source);
        }

       /// <summary>
       /// 判断集合是否非空
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="source"></param>
       /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Count() > 0;
        }

        /// <summary>
        /// 遍历集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void Foreach<T>(this IEnumerable<T> source,Action<T> action)
        {
            if (source.IsNotEmpty())
            {
                foreach(var item in source)
                {
                    action(item);
                }
            }
        }

    }
}
