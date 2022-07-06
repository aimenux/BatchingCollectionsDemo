﻿![.NET Core](https://github.com/aimenux/BatchingCollectionsDemo/workflows/.NET%20Core/badge.svg)
# BatchingCollectionsDemo
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
>>
>> **(5)** `BatchExtractor 7` : based on chunk extension

**`Tools`** : vs22, net core 6.0

```
|                   Method | ItemsSize | BatchSize |       Mean |    Error |   StdDev |     Median |        Min |        Max |       Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|------------------------- |---------- |---------- |-----------:|---------:|---------:|-----------:|-----------:|-----------:|------------:|-----------:|----------:|----------:|
| BatchExtractor1Benchmark |   1000000 |       100 |   730.7 ms | 14.49 ms | 25.38 ms |   727.6 ms |   692.3 ms |   785.3 ms |  41000.0000 | 12000.0000 | 3000.0000 |    236 MB |
| BatchExtractor3Benchmark |   1000000 |       100 |   257.3 ms |  4.21 ms |  5.32 ms |   257.1 ms |   249.6 ms |   268.9 ms |  46000.0000 |          - |         - |    184 MB |
| BatchExtractor4Benchmark |   1000000 |       100 |   257.4 ms |  3.96 ms |  3.51 ms |   256.1 ms |   253.5 ms |   265.9 ms |  47500.0000 |          - |         - |    191 MB |
| BatchExtractor5Benchmark |   1000000 |       100 |   285.5 ms |  8.30 ms | 23.94 ms |   278.0 ms |   253.3 ms |   346.5 ms |  51000.0000 |          - |         - |    204 MB |
| BatchExtractor6Benchmark |   1000000 |       100 |   278.0 ms |  5.52 ms | 14.84 ms |   276.0 ms |   254.3 ms |   316.1 ms |  47000.0000 |          - |         - |    191 MB |
| BatchExtractor7Benchmark |   1000000 |       100 |   275.9 ms |  8.88 ms | 26.04 ms |   265.6 ms |   248.5 ms |   346.1 ms |  47500.0000 |          - |         - |    191 MB |
| BatchExtractor1Benchmark |   1000000 |      1000 |   707.7 ms | 13.58 ms | 26.81 ms |   705.9 ms |   660.5 ms |   784.6 ms |  40000.0000 | 12000.0000 | 3000.0000 |    230 MB |
| BatchExtractor3Benchmark |   1000000 |      1000 |   253.4 ms |  5.01 ms |  8.24 ms |   251.0 ms |   238.3 ms |   275.8 ms |  45500.0000 |          - |         - |    183 MB |
| BatchExtractor4Benchmark |   1000000 |      1000 |   283.7 ms |  5.67 ms | 12.80 ms |   283.1 ms |   257.9 ms |   306.2 ms |  47000.0000 | 11000.0000 |         - |    191 MB |
| BatchExtractor5Benchmark |   1000000 |      1000 |   290.0 ms |  5.75 ms | 16.30 ms |   287.7 ms |   263.5 ms |   336.4 ms |  49000.0000 | 12000.0000 |         - |    199 MB |
| BatchExtractor6Benchmark |   1000000 |      1000 |   280.0 ms |  5.54 ms | 13.48 ms |   278.5 ms |   258.4 ms |   313.1 ms |  47000.0000 | 11000.0000 |         - |    191 MB |
| BatchExtractor7Benchmark |   1000000 |      1000 |   287.3 ms |  5.68 ms | 13.16 ms |   286.5 ms |   257.9 ms |   316.4 ms |  47000.0000 | 11000.0000 |         - |    191 MB |
| BatchExtractor1Benchmark |   2000000 |       100 | 1,482.5 ms | 26.83 ms | 43.33 ms | 1,485.9 ms | 1,414.7 ms | 1,573.9 ms |  81000.0000 | 23000.0000 | 4000.0000 |    472 MB |
| BatchExtractor3Benchmark |   2000000 |       100 |   513.9 ms |  8.53 ms | 15.60 ms |   510.1 ms |   494.8 ms |   557.2 ms |  92000.0000 |          - |         - |    368 MB |
| BatchExtractor4Benchmark |   2000000 |       100 |   514.6 ms |  9.85 ms |  9.21 ms |   513.2 ms |   500.2 ms |   534.4 ms |  95000.0000 |          - |         - |    383 MB |
| BatchExtractor5Benchmark |   2000000 |       100 |   539.9 ms | 10.73 ms | 23.10 ms |   533.5 ms |   510.6 ms |   597.0 ms | 102000.0000 |          - |         - |    408 MB |
| BatchExtractor6Benchmark |   2000000 |       100 |   543.2 ms | 12.66 ms | 36.93 ms |   529.9 ms |   497.4 ms |   654.2 ms |  95000.0000 |          - |         - |    382 MB |
| BatchExtractor7Benchmark |   2000000 |       100 |   518.6 ms |  8.82 ms | 19.00 ms |   510.1 ms |   494.8 ms |   573.9 ms |  95000.0000 |          - |         - |    382 MB |
| BatchExtractor1Benchmark |   2000000 |      1000 | 1,399.9 ms | 27.40 ms | 35.62 ms | 1,401.0 ms | 1,335.5 ms | 1,487.5 ms |  80000.0000 | 22000.0000 | 4000.0000 |    459 MB |
| BatchExtractor3Benchmark |   2000000 |      1000 |   518.0 ms |  9.54 ms | 22.68 ms |   511.1 ms |   487.0 ms |   578.9 ms |  91000.0000 |          - |         - |    366 MB |
| BatchExtractor4Benchmark |   2000000 |      1000 |   537.5 ms | 10.62 ms | 16.53 ms |   533.0 ms |   515.7 ms |   578.6 ms |  95000.0000 | 23000.0000 |         - |    382 MB |
| BatchExtractor5Benchmark |   2000000 |      1000 |   540.2 ms |  9.94 ms | 19.39 ms |   535.1 ms |   512.5 ms |   602.6 ms |  99000.0000 | 24000.0000 |         - |    398 MB |
| BatchExtractor6Benchmark |   2000000 |      1000 |   537.7 ms | 10.71 ms | 23.29 ms |   528.0 ms |   506.0 ms |   603.3 ms |  95000.0000 | 23000.0000 |         - |    382 MB |
| BatchExtractor7Benchmark |   2000000 |      1000 |   532.8 ms | 10.46 ms | 19.39 ms |   527.9 ms |   507.6 ms |   604.7 ms |  95000.0000 | 23000.0000 |         - |    382 MB |
```
