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
            SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe sma_ts = new SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe(5,new TimeSpan(0,0,1));

            var inputTask = Task.Run(async () => {
                Random rand = new Random();
                for(int i = 0; i < 60; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,300));
                    var value = rand.Next(1,10);
                    Console.WriteLine("Inserting value: " + value.ToString());
                    sma_ts.IncrementCurrentBucket(value);
                }
            });

            var outputTask = Task.Run( async () => {
                for(int i = 0; i < 25; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,1));
                    var value = sma_ts.GetLatestAverage();
                    Console.WriteLine("Reading value: " + value.ToString());
                }
            });

            Task.WaitAll(inputTask,outputTask);
        }
    }
}
