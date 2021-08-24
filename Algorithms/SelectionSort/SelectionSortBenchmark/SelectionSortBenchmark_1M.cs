using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SelectionSort;

namespace SelectionSortBenchmark
{
    [AsciiDocExporter]
    [CsvExporter]
    [CsvMeasurementsExporter]
    [HtmlExporter]
    [PlainExporter]
    [JsonExporterAttribute.Brief]
    public class SelectionSortBenchmark_1M
    {
        private const int Size = 1_000_000;
        SelectionSort.SelectionSort selectionSort = new SelectionSort.SelectionSort(Size);

        public SelectionSortBenchmark_1M()
        {
            Random rnd  = new Random(Size);
            for(int i = 0 ; i < Size; i++)
            {
                selectionSort.Insert((int)rnd.NextDouble() * Size);
            }
        }

        [Benchmark]
        public void Sort_1M()
        {
            selectionSort.SelectionSortSort();
        }
    }
}