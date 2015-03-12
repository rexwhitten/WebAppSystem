using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace WebAppSystem.Common
{
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> SelectIf<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source.Any())
            {
                return source.Select(selector);
            }

            return new List<TResult>();
        }
    }
}
