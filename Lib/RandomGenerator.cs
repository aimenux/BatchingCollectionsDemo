using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class RandomGenerator
    {
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public static IEnumerable<string> RandomStrings(int size)
        {
            return Enumerable.Range(0, size).Select(x => RandomString());
        }

        public static string RandomString(int length = 10)
        {
            const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
