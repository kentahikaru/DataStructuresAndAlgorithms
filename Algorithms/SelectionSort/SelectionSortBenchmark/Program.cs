using System;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Exporters;
using SelectionSortBenchmark;

namespace SelectionSortBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly, null, args);
            var summary = BenchmarkRunner.Run<SelectionSortBenchmark_1k>();
            summary = BenchmarkRunner.Run<SelectionSortBenchmark_10k>();
            summary = BenchmarkRunner.Run<SelectionSortBenchmark_100k>();
            summary = BenchmarkRunner.Run<SelectionSortBenchmark_1M>();
        }
    }
}
