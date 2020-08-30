using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Lib;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [MinColumn, MaxColumn]
    public class Benchmarks
    {
        [Params(1000000)]
        public int ItemsSize { get; set; }

        [Params(100, 1000)]
        public int BatchSize { get; set; }

        public IEnumerable<string> Items { get; private set; }

        public BatchExtractor1 BatchExtractor1 { get; private set; }
        public BatchExtractor2 BatchExtractor2 { get; private set; }
        public BatchExtractor3 BatchExtractor3 { get; private set; }

        [GlobalSetup]
        public void Setup()
        {
            BatchExtractor1 = new BatchExtractor1();
            BatchExtractor2 = new BatchExtractor2();
            BatchExtractor3 = new BatchExtractor3();
            Items = RandomGenerator.RandomStrings(ItemsSize);
        }


        [Benchmark]
        public int BatchExtractor1Benchmark()
        {
            var batchs = BatchExtractor1.Batch(Items, BatchSize);
            return batchs.Count();
        }

        [Benchmark]
        public int BatchExtractor2Benchmark()
        {
            var batchs = BatchExtractor2.Batch(Items, BatchSize);
            return batchs.Count();
        }

        [Benchmark]
        public int BatchExtractor3Benchmark()
        {
            var batchs = BatchExtractor3.Batch(Items, BatchSize);
            return batchs.Count();
        }
    }
}