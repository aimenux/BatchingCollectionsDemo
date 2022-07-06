using System.Collections.Generic;

namespace Lib
{
    public interface IBatchExtractor
    {
        string Name { get; }

        IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize);
    }
}
