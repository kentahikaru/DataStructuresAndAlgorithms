using ArrayStack;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ArrayStackBenchmark
{
    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [JsonExporterAttribute.Brief]
    public class ArrayStackBenchmark2
    {
        [Benchmark]
        public void ArrayStack2_10()
        {
            int size = 10;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_100()
        {
            int size = 100;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_1000()
        {
            int size = 1000;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_10000()
        {
            int size = 10000;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_100000()
        {
            int size = 100000;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_1000000()
        {
            int size = 1000000;
            FillAndTraverse(size);
        }

        [Benchmark]
        public void ArrayStack2_10000000()
        {
            int size = 10000000;
            FillAndTraverse(size);
        }

        private void FillAndTraverse(int size)
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(size);

            for(int i = 0; i <= size - 1; i++)
            {
                arrayStack.Push(i);
            }

            for(int i = 0; i <= size - 1; i++)
            {
                arrayStack.Pop();
            }
        }
    }
}