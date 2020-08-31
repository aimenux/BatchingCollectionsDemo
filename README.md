﻿![.NET Core](https://github.com/aimenux/BatchLinqDemo/workflows/.NET%20Core/badge.svg)
# BatchLinqDemo
```
Batches an enumerable into sized chunks
```
> I m using multiple implementations in order to batch an enumerable into chunks. `Last implementation` is the best one (perf/memory) according to benchmark tests.
>
>> **(1)** `BatchExtractor 1` : based on group-by operator
>>
>> **(2)** `BatchExtractor 2 & 3` : based on take/skip operators
>>
>> **(3)** `BatchExtractor 4` : based on enumerators
>>
>> **(4)** `BatchExtractor 5 & 6` : based on yield operator

**`Tools`** : vs19, net core 3.1

```
|                   Method | ItemsSize | BatchSize |      Mean |     Error |    StdDev |    Median |      Min |       Max |    Gen 0 |    Gen 1 | Gen 2 | Allocated |
|------------------------- |---------- |---------- |----------:|----------:|----------:|----------:|---------:|----------:|---------:|---------:|------:|----------:|
| BatchExtractor1Benchmark |     10000 |       100 |  8.282 ms | 0.9221 ms | 2.7187 ms |  9.882 ms | 3.385 ms | 11.230 ms | 398.4375 | 199.2188 |     - |   2.36 MB |
| BatchExtractor3Benchmark |     10000 |       100 |  7.644 ms | 0.0817 ms | 0.0802 ms |  7.648 ms | 7.528 ms |  7.821 ms | 406.2500 |        - |     - |   1.84 MB |
| BatchExtractor4Benchmark |     10000 |       100 |  7.476 ms | 0.1481 ms | 0.4028 ms |  7.601 ms | 5.752 ms |  7.980 ms | 421.8750 |  23.4375 |     - |   1.91 MB |
| BatchExtractor5Benchmark |     10000 |       100 |  8.273 ms | 0.1649 ms | 0.4344 ms |  8.434 ms | 6.240 ms |  9.174 ms | 453.1250 |  15.6250 |     - |   2.04 MB |
| BatchExtractor6Benchmark |     10000 |       100 |  7.940 ms | 0.0863 ms | 0.0721 ms |  7.931 ms | 7.788 ms |  8.071 ms | 421.8750 |  15.6250 |     - |   1.91 MB |
| BatchExtractor1Benchmark |     10000 |      1000 | 10.047 ms | 0.1950 ms | 0.3205 ms | 10.111 ms | 8.843 ms | 10.429 ms | 390.6250 | 187.5000 |     - |    2.3 MB |
| BatchExtractor3Benchmark |     10000 |      1000 |  7.920 ms | 0.1228 ms | 0.1149 ms |  7.904 ms | 7.806 ms |  8.167 ms | 406.2500 |        - |     - |   1.83 MB |
| BatchExtractor4Benchmark |     10000 |      1000 |  8.184 ms | 0.1636 ms | 0.2069 ms |  8.240 ms | 7.580 ms |  8.421 ms | 421.8750 | 125.0000 |     - |   1.91 MB |
| BatchExtractor5Benchmark |     10000 |      1000 |  3.172 ms | 0.0638 ms | 0.1693 ms |  3.129 ms | 2.940 ms |  3.656 ms | 437.5000 | 140.6250 |     - |   1.99 MB |
| BatchExtractor6Benchmark |     10000 |      1000 |  7.317 ms | 0.5710 ms | 1.6747 ms |  8.002 ms | 3.028 ms |  9.215 ms | 421.8750 |  89.8438 |     - |   1.91 MB |