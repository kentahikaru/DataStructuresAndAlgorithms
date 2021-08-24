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
    public class SelectionSortBenchmark_10k
    {
        private const int Size = 10000;
        SelectionSort.SelectionSort selectionSort = new SelectionSort.SelectionSort(Size);

        public SelectionSortBenchmark_10k()
        {
            Random rnd  = new Random(Size);
            for(int i = 0 ; i < Size; i++)
            {
                selectionSort.Insert((int)rnd.NextDouble() * Size);
            }
        }

        [Benchmark]
        public void Sort_10k()
        {
            selectionSort.SelectionSortSort();
        }
    }
}