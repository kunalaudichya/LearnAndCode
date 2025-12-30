using System;
using System.Collections.Generic;

namespace Week2.Assignment2
{
    public static class InputReader
    {
        public static (long[] numbers, List<Query> queries) ReadInput()
        {
            var sizes = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int numberCount = sizes[0];
            int queryCount = sizes[1];

            long[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            List<Query> queries = new List<Query>();
            for (int i = 0; i < queryCount; i++)
            {
                var lr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                queries.Add(new Query(lr[0], lr[1]));
            }

            return (numbers, queries);
        }
    }
}
