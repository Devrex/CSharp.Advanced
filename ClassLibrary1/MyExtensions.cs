using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClassLibrary1
{
    public static class MyExtensions
    {
        /// <summary>
        /// first argument is the object we are extending
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsBig(this Circle c)
        {
            return c.Radius > 10;
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> items, Expression<Func<T, bool>> expression)
        {

            //EF LINQ provider would analyze the expression tree and try to translate to SQL

            var predicate = expression.Compile();



            foreach (var item in items)
            {
                if (predicate.Invoke(item)) yield return item;
            }
        }
    }
}
