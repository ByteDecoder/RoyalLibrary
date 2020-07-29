using ByteDecoder.Common.GuardClauses;
using System.Collections.Generic;
using System.IO;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class StreamReaderExtensions
  {
    /// <summary>
    /// Deferred execution for an StreamReader source
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<string> Lines(this StreamReader source)
    {
      Guard.Break.IfArgumentIsNull(source, nameof(source));

      string line;

      while ((line = source.ReadLine()) != null)
        yield return line;
    }
  }
}