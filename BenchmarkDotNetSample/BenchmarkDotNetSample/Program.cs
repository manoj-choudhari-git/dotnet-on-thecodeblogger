// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchmarkDotNetSample;
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

var summary = BenchmarkRunner.Run<StringCompareUtil>();

sw.Stop();
Console.WriteLine("=================================================================");
Console.WriteLine($"Total Elapsed Milliseconds: {sw.ElapsedMilliseconds}");
Console.WriteLine("=================================================================");



//sw.Start();
//var summaries = BenchmarkRunner.Run<MyBenchmarks>();


//Console.WriteLine("=================================================================");
//Console.WriteLine($"Total Elapsed Milliseconds: {sw.ElapsedMilliseconds}");
//Console.WriteLine("=================================================================");

