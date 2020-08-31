using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor5 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            var batch = new List<TSource>();

            foreach (var item in items)
            {
                batch.Add(item);
                if (batch.Count != batchSize)
                {
                    continue;
                }

                yield return batch;
                batch = new List<TSource>();
            }

            if (!batch.Any())
            {
                yield break;
            }

            batch.TrimExcess();
            yield return batch;
        }
    }
}