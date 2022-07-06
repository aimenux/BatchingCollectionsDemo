using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Lib;
using NUnit.Framework;

namespace Tests
{
    public class BatchExtractorTests
    {
        [Test, TestCaseSource(nameof(GetTestParameters))]
        public void Should_Split_Items_Into_Valid_Batchs(IBatchExtractor extractor, int itemsSize, int batchSize, int expectedBatchsCount)
        {
            // arrange
            var items = Enumerable.Range(0, itemsSize);

            // act
            var batchs = extractor.Batch(items, batchSize).ToList();

            // assert
            batchs.Should().NotBeNullOrEmpty().And.HaveCount(expectedBatchsCount);
            batchs.SelectMany(x => x).Should().BeEquivalentTo(items);
            for (var index = 0; index < expectedBatchsCount; index++)
            {
                var batch = batchs.ElementAt(index).ToList();
                batch.Should().HaveCount(batchSize);
                batch.Should().OnlyHaveUniqueItems();
            }
        }

        private static IEnumerable<object[]> GetTestParameters()
        {
            yield return new object[] { new BatchExtractor1(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor1(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor1(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor2(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor2(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor2(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor3(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor3(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor3(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor4(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor4(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor4(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor5(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor5(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor5(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor6(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor6(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor6(), 1000, 10, 100 };

            yield return new object[] { new BatchExtractor7(), 10, 10, 1 };
            yield return new object[] { new BatchExtractor7(), 100, 10, 10 };
            yield return new object[] { new BatchExtractor7(), 1000, 10, 100 };
        }
    }
}