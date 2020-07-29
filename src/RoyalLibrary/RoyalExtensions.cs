using System;
using System.Collections.Generic;
using ByteDecoder.Common.GuardClauses;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class RoyalExtensions
  {
    /// <summary>
    /// Deferred execution returning a LINQ sequence of elements, after applying the selector on each sequence element
    /// </summary>
    /// <typeparam name="TInput">Element type</typeparam>
    /// <typeparam name="TResult">Result data type</typeparam>
    /// <param name="source">Input LINQ sequence</param>
    /// <param name="element">Applied action to transform each collection element</param>
    /// <returns></returns>
    public static IEnumerable<TResult> Map<TInput, TResult>(this IEnumerable<TInput> source, Func<TInput, TResult> element)
    {
      Guard.Break.IfArgumentIsNull(source, nameof(source));
      Guard.Break.IfArgumentIsNull(element, nameof(element));

      foreach(var item in source)
      {
        yield return element(item);
      }
    }

    /// <summary>
    /// Returns the element with the Max property value, based on the selector of IComparable type
    /// in the sequence of elements
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static TElement MaxElement<TElement, TData>(this IEnumerable<TElement> source,
      Func<TElement, TData> selector) where TData : IComparable<TData>
    {
      Guard.Break.IfArgumentIsNull(source, nameof(source));
      Guard.Break.IfArgumentIsNull(selector, nameof(selector));

      var firstElement = true;
      var result = default(TElement);
      var maxValue = default(TData);

      foreach(var element in source)
      {
        var candidate = selector(element);
        if(!firstElement && (candidate.CompareTo(maxValue) <= 0)) continue;
        firstElement = false;
        maxValue = candidate;
        result = element;
      }
      return result;
    }
  }
}
