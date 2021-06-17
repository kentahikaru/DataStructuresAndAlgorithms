using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleMovingAverage_ThreadSafe;

namespace SimpleMovingAverage_ThreadSafeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe sma_ts = new SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe(5,new TimeSpan(0,0,1));
            Task[] tasks = new Task[2];
            tasks[0] = Task.Run(async () => {
                Random rand = new Random();
                for(int i = 0; i < 60; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,300));
                    sma_ts.IncrementCurrentBucket(rand.Next(1,10));
                }
            });

            tasks[1] = Task.Run( async () => {
                for(int i = 0; i < 25; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,1));
                    Console.WriteLine(sma_ts.GetLatestAverage());
                }
            });

            Task.WaitAll(tasks);
        }
    }
}
