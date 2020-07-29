using ByteDecoder.Common.GuardClauses;
using System.Linq;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class PagingExtensions
  {
    /// <summary>
    /// Generic Page query object
    /// </summary>
    /// <param name="query">Sequence source</param>
    /// <param name="pageNumZeroStart">Starting page number offset. Zero is the first page</param>
    /// <param name="pageSize">Page size</param>
    /// <typeparam name="T">Type of the source</typeparam>
    /// <returns></returns>
    public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
    {
      Guard.Break.IfArgumentIsNull(query, nameof(query));
      Guard.Break.IfArgumentOutOfRange(() => pageSize == 0, nameof(pageSize), "pageSize cannot be zero.");

      if(pageNumZeroStart != 0)
        query = query.Skip(pageNumZeroStart * pageSize);

      return query.Take(pageSize);
    }
  }
}
