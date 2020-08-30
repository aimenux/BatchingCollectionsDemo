﻿![.NET Core](https://github.com/aimenux/BatchLinqDemo/workflows/.NET%20Core/badge.svg)
# BatchLinqDemo
```
Batches an enumerable into sized buckets
```
> I m using 3 methods in order to batch an enumerable into slices. Method 3 is the best one according to benchmark tests.
>
>> **(1)** BatchExtractor1 : based on group-by operator
>
>> **(2)** BatchExtractor2 : based on yield operator & lists
>
>> **(3)** BatchExtractor3 : based on yield operator & arrays

**`Tools`** : vs19, net core 3.1