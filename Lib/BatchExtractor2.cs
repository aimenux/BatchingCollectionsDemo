using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor2 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            var index = 0;
            var chunks = from item in items
                group item by index++ % batchSize into chunk
                select chunk.AsEnumerable();
            return chunks;
        }
    }
}