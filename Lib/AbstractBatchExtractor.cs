using System.Collections.Generic;

namespace Lib
{
    public abstract class AbstractBatchExtractor : IBatchExtractor
    {
        public string Name => GetType().Name;

        public abstract IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize);
    }
}