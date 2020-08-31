using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor2 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            for (var index = 0; index < items.Count(); index+= batchSize)
            {
                var batch = items.Skip(index).Take(batchSize);
                yield return batch;
            }
        }
    }
}