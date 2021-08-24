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
    public class SelectionSortBenchmark_1k
    {
        private const int Size = 1000;
        SelectionSort.SelectionSort selectionSort = new SelectionSort.SelectionSort(Size);

        public SelectionSortBenchmark_1k()
        {
            Random rnd  = new Random(Size);
            for(int i = 0 ; i < Size; i++)
            {
                selectionSort.Insert((int)rnd.NextDouble() * Size);
            }
        }

        [Benchmark]
        public void Sort_1k()
        {
            selectionSort.SelectionSortSort();
        }
    }
}