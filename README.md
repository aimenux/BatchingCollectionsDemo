﻿![.NET Core](https://github.com/aimenux/BatchLinqDemo/workflows/.NET%20Core/badge.svg)
# BatchLinqDemo
```
Batches an enumerable into sized chunks
```
> I m using multiple implementations in order to batch an enumerable into chunks.
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
|                   Method | ItemsSize | BatchSize |     Mean |    Error |   StdDev |      Min |      Max |      Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|------------------------- |---------- |---------- |---------:|---------:|---------:|---------:|---------:|-----------:|-----------:|----------:|----------:|
| BatchExtractor1Benchmark |   1000000 |       100 | 625.8 ms |  7.91 ms |  6.18 ms | 617.3 ms | 637.6 ms | 41000.0000 | 12000.0000 | 3000.0000 | 236.23 MB |
| BatchExtractor3Benchmark |   1000000 |       100 | 285.3 ms |  3.44 ms |  2.87 ms | 282.2 ms | 292.4 ms | 41000.0000 |          - |         - | 184.02 MB |
| BatchExtractor4Benchmark |   1000000 |       100 | 280.5 ms |  1.71 ms |  1.33 ms | 278.7 ms | 283.6 ms | 42000.0000 |  1000.0000 |         - | 191.27 MB |
| BatchExtractor5Benchmark |   1000000 |       100 | 280.5 ms |  5.37 ms |  6.39 ms | 273.8 ms | 294.1 ms | 45000.0000 |  1000.0000 |         - | 204.01 MB |
| BatchExtractor6Benchmark |   1000000 |       100 | 280.4 ms |  4.70 ms |  4.17 ms | 276.1 ms | 290.4 ms | 42500.0000 |  1500.0000 |         - | 190.96 MB |
| BatchExtractor1Benchmark |   1000000 |      1000 | 654.1 ms | 12.07 ms | 25.45 ms | 602.9 ms | 711.3 ms | 40000.0000 | 12000.0000 | 3000.0000 | 229.62 MB |
| BatchExtractor3Benchmark |   1000000 |      1000 | 284.5 ms |  2.97 ms |  2.32 ms | 279.6 ms | 287.3 ms | 40000.0000 |          - |         - |  183.2 MB |
| BatchExtractor4Benchmark |   1000000 |      1000 | 282.9 ms |  1.39 ms |  1.23 ms | 281.3 ms | 285.3 ms | 42000.0000 |  1000.0000 |         - | 190.79 MB |
| BatchExtractor5Benchmark |   1000000 |      1000 | 292.5 ms |  5.33 ms |  9.48 ms | 281.7 ms | 324.4 ms | 44000.0000 |  1000.0000 |         - | 198.94 MB |
| BatchExtractor6Benchmark |   1000000 |      1000 | 294.0 ms |  5.63 ms |  7.51 ms | 285.4 ms | 310.3 ms | 42000.0000 |  1000.0000 |         - | 190.76 MB |
