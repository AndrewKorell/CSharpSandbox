```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
Intel Core i3-8145U CPU 2.10GHz (Whiskey Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.401
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-DZACBK : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

IterationCount=4  LaunchCount=10  WarmupCount=0  

```
| Method    | Mean       | Error     | StdDev     | Median     |
|---------- |-----------:|----------:|-----------:|-----------:|
| MeasureA1 |  52.033 ms | 5.5942 ms |  9.9436 ms |  52.979 ms |
| MeasureA2 | 124.778 ms | 7.4461 ms | 12.8442 ms | 130.452 ms |
| MeasureB1 |  13.010 ms | 1.3581 ms |  2.3061 ms |  13.425 ms |
| MeasureB2 |   8.220 ms | 0.9020 ms |  1.5797 ms |   7.768 ms |
| MeasureC1 |   4.130 ms | 0.5224 ms |  0.9010 ms |   3.868 ms |
| MeasureC2 |   4.899 ms | 0.7402 ms |  1.3156 ms |   4.748 ms |
