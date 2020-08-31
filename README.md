﻿![.NET Core](https://github.com/aimenux/BatchLinqDemo/workflows/.NET%20Core/badge.svg)
# BatchLinqDemo
```
Batches an enumerable into sized chunks
```
> I m using multiple implementations in order to batch an enumerable into chunks. `Last implementation` is the best one (perf/memory) according to benchmark tests.
>
>> **(1)** `BatchExtractor 1 & 2` : based on group-by operator
>>
>> **(2)** `BatchExtractor 3` : based on take/skip operators
>>
>> **(3)** `BatchExtractor 4 & 5` : based on yield operator

**`Tools`** : vs19, net core 3.1


```
|                   Method | ItemsSize | BatchSize |       Mean |    Error |    StdDev |     Median |      Min |        Max |      Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|------------------------- |---------- |---------- |-----------:|---------:|----------:|-----------:|---------:|-----------:|-----------:|-----------:|----------:|----------:|
| BatchExtractor1Benchmark |   1000000 |       100 | 1,477.3 ms | 81.25 ms | 238.29 ms | 1,561.2 ms | 627.6 ms | 1,745.1 ms | 41000.0000 | 12000.0000 | 3000.0000 | 236.23 MB |
| BatchExtractor2Benchmark |   1000000 |       100 | 1,404.7 ms | 77.40 ms | 227.01 ms | 1,480.5 ms | 635.5 ms | 1,596.7 ms | 35000.0000 | 12000.0000 | 3000.0000 | 208.15 MB |
| BatchExtractor3Benchmark |   1000000 |       100 |   755.3 ms | 16.19 ms |  46.96 ms |   767.9 ms | 486.7 ms |   803.7 ms | 45000.0000 |  1000.0000 |         - | 204.01 MB |
| BatchExtractor4Benchmark |   1000000 |       100 |   769.2 ms | 15.35 ms |  28.83 ms |   775.0 ms | 642.7 ms |   793.8 ms | 45000.0000 |  1000.0000 |         - | 204.01 MB |
| BatchExtractor5Benchmark |   1000000 |       100 |   545.7 ms | 70.82 ms | 208.81 ms |   632.4 ms | 261.6 ms |   791.6 ms | 42000.0000 |  1000.0000 |         - | 190.96 MB |
| BatchExtractor1Benchmark |   1000000 |      1000 | 1,337.8 ms | 68.03 ms | 200.60 ms | 1,394.3 ms | 778.4 ms | 1,679.0 ms | 40000.0000 | 12000.0000 | 3000.0000 | 229.62 MB |
| BatchExtractor2Benchmark |   1000000 |      1000 | 1,313.8 ms | 73.46 ms | 216.58 ms | 1,363.6 ms | 649.6 ms | 1,649.1 ms | 35000.0000 | 11000.0000 | 3000.0000 | 199.04 MB |
| BatchExtractor3Benchmark |   1000000 |      1000 |   667.9 ms | 32.17 ms |  94.87 ms |   679.2 ms | 333.0 ms |   849.9 ms | 44000.0000 |  1000.0000 |         - | 198.94 MB |
| BatchExtractor4Benchmark |   1000000 |      1000 |   640.9 ms | 41.33 ms | 121.87 ms |   669.6 ms | 329.6 ms |   797.5 ms | 44000.0000 |  1000.0000 |         - | 198.94 MB |
| BatchExtractor5Benchmark |   1000000 |      1000 |   605.6 ms | 39.97 ms | 117.86 ms |   628.1 ms | 358.0 ms |   849.0 ms | 42000.0000 |  1000.0000 |         - | 190.76 MB |
