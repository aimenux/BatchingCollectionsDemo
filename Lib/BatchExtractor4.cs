using System.Collections.Generic;

namespace Lib
{
    public class BatchExtractor4 : IBatchExtractor
    {
        public string Name => GetType().Name;

        public IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            using(var enumerator = items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return Batch(enumerator, batchSize);
                }
            }
        }

        private static IEnumerable<TSource> Batch<TSource>(IEnumerator<TSource> enumerator, int batchSize)
        {
            var index = 0;
            var batch = new List<TSource>(batchSize);
            
            while(true)
            {
                batch.Add(enumerator.Current);

                index++;
                if (index == batchSize)
                {
                    break;
                }

                if (!enumerator.MoveNext())
                {
                    break;
                }
            }

            return batch;
        }
    }
}