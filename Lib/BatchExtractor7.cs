namespace Lib
{
    public class BatchExtractor7 : AbstractBatchExtractor
    {
        public override IEnumerable<IEnumerable<TSource>> Batch<TSource>(IEnumerable<TSource> items, int batchSize)
        {
            return items.Chunk(batchSize);
        }
    }
}