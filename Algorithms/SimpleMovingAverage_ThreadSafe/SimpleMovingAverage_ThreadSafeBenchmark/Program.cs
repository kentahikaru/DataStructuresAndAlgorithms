using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleMovingAverage_ThreadSafe;

namespace SimpleMovingAverage_ThreadSafeBenchmark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe sma_ts = new SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe(5,new TimeSpan(0,0,0,0,100));
            int[] inputNumbers = new int[] {9,7,4,2,3,8,6,3,4,8,8,9,2,5,9,8,5,5,5,4,2,5,6,4,7,6,6,5,7,6,6,1,2,3,3,5,8,8,4,4,3,9,4,3,7,9,9,1,6,9};
            var inputTask = Task.Run(async () => {
                Random rand = new Random();
                for(int i = 0; i < inputNumbers.Length; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,30));
                    //var value = rand.Next(1,10);
                    var value = inputNumbers[i];
                    //Console.WriteLine("Inserting value: " + value.ToString());
                    sma_ts.IncrementCurrentBucket(value);
                }
            });

            var outputTask = Task.Run( async () => {
                for(int i = 0; i < 25; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,100));
                    var value = sma_ts.GetLatestAverage();
                    //Console.WriteLine("Reading value: " + value.ToString());
                    Console.Write(value.ToString() + ",");
                }
            });

            Task.WaitAll(inputTask,outputTask);
        }
    }
}
