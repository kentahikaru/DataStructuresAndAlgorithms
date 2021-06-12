using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ArrayStackBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
