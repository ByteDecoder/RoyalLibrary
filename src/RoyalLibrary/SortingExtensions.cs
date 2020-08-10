using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteDecoder.Common.GuardClauses;

namespace ByteDecoder.RoyalLibrary
{
    /// <summary>
    /// Advanced sorting for collections
    /// </summary>
    public static class SortingExtensions
    {
        /// <summary>
        /// returns a new sorted ICollection 
        /// </summary>
        /// <param name="source"></param>
        /// <returns>An Enumerable sorted collection by LastName</returns>
        public static async Task<ICollection<string>> SortByLastNameAsync(this IEnumerable<string> source)
        {
            Guard.Break.IfArgumentIsNull(source, nameof(source));

            var enumerable = source as string[] ?? source.ToArray();
            var rowsCount = enumerable.Count();

            if (rowsCount == 0) return (ICollection<string>)source;

            byte lastSpaceIndex;
            string firstName, lastName;
            var orderedList = new SortedList<string, string>() { Capacity = rowsCount };

            await Task.Run(() =>
            {
                foreach (var item in enumerable)
                {
                    var spaces = item.Count(char.IsWhiteSpace);
                    lastSpaceIndex = (byte)item.IndexOfNth(' ', spaces - 1);

                    firstName = item.Substring(0, lastSpaceIndex);
                    var lastNameLength = item.Length - firstName.Length;
                    lastName = item.Substring(lastSpaceIndex, lastNameLength);

                    orderedList.Add(lastName, firstName);
                }
            });

            return orderedList.AsParallel().AsOrdered()
              .Select((fullName) => fullName.Value + fullName.Key).ToList();
        }

        /// <summary>
        /// returns a new sorted ICollection 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns>An Enumerable sorted collection by LastName</returns>
        public static async Task<ICollection<string>> SortByLastNameAsync(this IEnumerable<string> source, Action<string> action)
        {
            var sortedList = await source.SortByLastNameAsync();

            sortedList.AsParallel()
                      .AsOrdered()
                      .ForEach(action);

            return sortedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <param name="nth"></param>
        /// <returns></returns>
        private static int IndexOfNth(this string str, char value, int nth)
        {
            if (nth < 0)
                throw new ArgumentException($"Negative index found {nameof(nth)} has negative value, it must start at 0");

            var offset = str.IndexOf(value);
            for (var i = 0; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
        }
    }
}