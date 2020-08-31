using System;
using System.Collections.Generic;

namespace Lib
{
    public class BatchExtractor6 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            var count = 0;
            TSource[] batch = null;

            foreach (var item in items)
            {
                if (batch == null)
                {
                    batch = new TSource[batchSize];
                }

                batch[count++] = item;

                if (count != batchSize)
                {
                    continue;
                }

                yield return batch;

                batch = null;
                count = 0;
            }

            if (batch == null || count <= 0)
            {
                yield break;
            }

            Array.Resize(ref batch, count);
            yield return batch;
        }
    }
}