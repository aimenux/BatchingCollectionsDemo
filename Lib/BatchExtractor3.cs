using System;
using System.Collections.Generic;

namespace Lib
{
    public class BatchExtractor3 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            var count = 0;
            TSource[] bucket = null;

            foreach (var item in items)
            {
                if (bucket == null)
                {
                    bucket = new TSource[batchSize];
                }

                bucket[count++] = item;

                if (count != batchSize)
                {
                    continue;
                }

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket == null || count <= 0)
            {
                yield break;
            }

            Array.Resize(ref bucket, count);
            yield return bucket;
        }
    }
}