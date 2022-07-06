using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor1 : AbstractBatchExtractor
    {
        public override IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            return items
                .Select((item, index) => new { item, index })
                .GroupBy(x => x.index / batchSize)
                .Select(g => g.Select(x => x.item));
        }
    }
}