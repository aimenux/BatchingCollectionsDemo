using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;
using Lib;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [MinColumn, MaxColumn]
    [Config(typeof(FilterConfig))]
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
        public BatchExtractor4 BatchExtractor4 { get; private set; }
        public BatchExtractor5 BatchExtractor5 { get; private set; }
        public BatchExtractor6 BatchExtractor6 { get; private set; }

        [GlobalSetup]
        public void Setup()
        {
            BatchExtractor1 = new BatchExtractor1();
            BatchExtractor2 = new BatchExtractor2();
            BatchExtractor3 = new BatchExtractor3();
            BatchExtractor4 = new BatchExtractor4();
            BatchExtractor5 = new BatchExtractor5();
            BatchExtractor6 = new BatchExtractor6();
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

        [Benchmark]
        public int BatchExtractor4Benchmark()
        {
            var batchs = BatchExtractor4.Batch(Items, BatchSize);
            return batchs.Count();
        }

        [Benchmark]
        public int BatchExtractor5Benchmark()
        {
            var batchs = BatchExtractor5.Batch(Items, BatchSize);
            return batchs.Count();
        }

        [Benchmark]
        public int BatchExtractor6Benchmark()
        {
            var batchs = BatchExtractor6.Batch(Items, BatchSize);
            return batchs.Count();
        }

        private class FilterConfig : ManualConfig
        {
            public FilterConfig()
            {
                AddFilter(new NameFilter(name => !name.Contains(nameof(BatchExtractor2Benchmark))));
            }
        }
    }
}