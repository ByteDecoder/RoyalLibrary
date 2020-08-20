using System;
using ByteDecoder.Common.GuardClauses;

namespace ByteDecoder.RoyalLibrary
{
    /// <summary>
    /// Times LINQ query operators allow to execute a block n times defined by the integer number source
    /// </summary>
    public static class TimesExtensions
    {
        /// <summary>
        /// Executes n times a code block
        /// </summary>
        /// <param name="source">number of iterations</param>
        /// <param name="action">Action delegate type to execute on each iteration</param>
        public static void Times(this int source, Action action)
        {
            Guard.Break.IfArgumentIsNull(action, nameof(action));

            for (var i = 0; i < source; i++)
            {
                action();
            }
        }

        /// <summary>
        /// Executes n times an Action delegate without returning anything 
        /// </summary>
        /// <param name="source">number of iterations</param>
        /// <param name="action">Action delegate type to execute on each iteration + current iteration number</param>
        public static void Times(this int source, Action<int> action)
        {
            Guard.Break.IfArgumentIsNull(action, nameof(action));

            for (var i = 0; i < source; i++)
            {
                action(i);
            }
        }
    }
}