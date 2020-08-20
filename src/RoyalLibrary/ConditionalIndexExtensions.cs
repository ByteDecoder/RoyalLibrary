using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.Common.GuardClauses;

namespace ByteDecoder.RoyalLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConditionalIndexExtensions
    {
        /// <summary>
        /// Get top n index from a sequence based on a predicate. Not deferred execution LINQ query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="topIndexes"></param>
        /// <returns></returns>
        public static IEnumerable<int> TopIndexes<T>(this IEnumerable<T> source, Func<T, bool> predicate, int topIndexes)
        {
            Guard.Break.IfArgumentIsNull(source, nameof(source));
            Guard.Break.IfArgumentIsNull(predicate, nameof(predicate));

            return source.Select((value, index) => new { value, index })
                         .Where(x => predicate(x.value))
                         .Select(x => x.index)
                         .Take(topIndexes);
        }
    }
}
