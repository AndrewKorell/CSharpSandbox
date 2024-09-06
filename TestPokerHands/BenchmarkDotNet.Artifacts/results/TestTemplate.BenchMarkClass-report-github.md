```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
Intel Core i3-8145U CPU 2.10GHz (Whiskey Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.401
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  Job-PTXDQV : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

IterationCount=4  LaunchCount=10  WarmupCount=0  

```
| Method | Mean     | Error     | StdDev    |
|------- |---------:|----------:|----------:|
| Foo    | 523.4 ns |  49.61 ns |  86.88 ns |
| Bar    | 906.3 ns | 173.43 ns | 308.27 ns |
