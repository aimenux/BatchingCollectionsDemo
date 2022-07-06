﻿using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class BatchExtractor3 : AbstractBatchExtractor
    {
        public override IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            return items
                .Where((x, i) => i % batchSize == 0)
                .Select((x, i) => items.Skip(i * batchSize).Take(batchSize));
        }
    }
}