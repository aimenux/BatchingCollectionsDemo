using System.Linq;
using FluentAssertions;
using Lib;
using NUnit.Framework;

namespace Tests
{
    public class BatchExtractor2Tests
    {
        [TestCase(10, 1, 10)]
        [TestCase(10, 10, 1)]
        [TestCase(100, 10, 10)]
        [TestCase(1000, 10, 100)]
        public void Should_Split_Items_Into_Valid_Chunks(int itemsSize, int batchSize, int expectedChunksCount)
        {
            // arrange
            var extractor = new BatchExtractor2();
            var items = Enumerable.Range(0, itemsSize);

            // act
            var chunks = extractor.Batch(items, batchSize);

            // assert
            chunks.Should().NotBeNullOrEmpty().And.HaveCount(expectedChunksCount);
        }
    }
}