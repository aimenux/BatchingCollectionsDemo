﻿![.NET Core](https://github.com/aimenux/BatchLinqDemo/workflows/.NET%20Core/badge.svg)
# BatchLinqDemo
```
Batches an enumerable into sized buckets
```
> I m using 3 implementations in order to batch an enumerable into slices. `Implementation 3` is the best one according to benchmark tests.
>
>> **(1)** BatchExtractor1 : based on group-by operator
>>
>> **(2)** BatchExtractor2 : based on yield operator & lists
>>
>> **(3)** BatchExtractor3 : based on yield operator & arrays

**`Tools`** : vs19, net core 3.1


```
|                   Method | ItemsSize | BatchSize |     Mean |    Error |   StdDev |      Min |      Max |      Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|------------------------- |---------- |---------- |---------:|---------:|---------:|---------:|---------:|-----------:|-----------:|----------:|----------:|
| BatchExtractor1Benchmark |   1000000 |       100 | 593.7 ms | 11.66 ms | 10.90 ms | 582.4 ms | 620.0 ms | 41000.0000 | 12000.0000 | 3000.0000 | 236.23 MB |
| BatchExtractor2Benchmark |   1000000 |       100 | 266.3 ms |  2.26 ms |  2.00 ms | 263.5 ms | 270.7 ms | 45000.0000 |  1500.0000 |         - | 204.01 MB |
| BatchExtractor3Benchmark |   1000000 |       100 | 261.5 ms |  2.22 ms |  2.07 ms | 258.8 ms | 264.2 ms | 42500.0000 |  1500.0000 |         - | 190.96 MB |
| BatchExtractor1Benchmark |   1000000 |      1000 | 580.5 ms | 11.52 ms | 14.57 ms | 560.3 ms | 612.7 ms | 40000.0000 | 12000.0000 | 3000.0000 | 229.62 MB |
| BatchExtractor2Benchmark |   1000000 |      1000 | 269.1 ms |  2.13 ms |  1.99 ms | 266.8 ms | 272.7 ms | 44000.0000 |  1000.0000 |         - | 198.94 MB |
| BatchExtractor3Benchmark |   1000000 |      1000 | 270.6 ms |  1.15 ms |  1.07 ms | 268.1 ms | 272.1 ms | 42000.0000 |  1000.0000 |         - | 190.76 MB |