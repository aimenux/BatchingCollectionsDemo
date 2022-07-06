using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor2 : AbstractBatchExtractor
    {
        public override IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            for (var index = 0; index < items.Count(); index += batchSize)
            {
                var batch = items.Skip(index).Take(batchSize);
                yield return batch;
            }
        }
    }
}