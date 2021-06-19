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
            int[] inputNumbers = new int[] {9,7,4,2,3,8,6,3,4,8,8,9,2,5,9,8,5,5,5,4,2,5,6,4,7,6,6,5,7,6,6,1,2,3,3,5,8,8,4,4,3,9,4,3,7,9,9,1,6,9};
            double[] sma = new double[] {0,6.6,10.8,14.6,19,18.8,18.8,18,17.8,16.4,14.8,17,16.8,17,17.2,16.8,12,8.8,5,1.8,0,0,0,0,0};
            SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe sma_ts = new SimpleMovingAverage_ThreadSafe.SimpleMovingAverage_ThreadSafe(5,new TimeSpan(0,0,0,0,100));
            Task[] tasks = new Task[2];
            tasks[0] = Task.Run(async () => {
                Random rand = new Random();
                for(int i = 0; i < inputNumbers.Length; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,30));
                    var value = inputNumbers[i];
                    //Console.WriteLine("Inserting value: " + value.ToString());
                    sma_ts.IncrementCurrentBucket(value);
                }
            });

            tasks[1] = Task.Run( async () => {
                for(int i = 0; i < 25; i++)
                {
                    await Task.Delay(new TimeSpan(0,0,0,0,100));
                    var value = sma_ts.GetLatestAverage();
                    // Console.WriteLine(sma[i].ToString() + " " + value.ToString());
                    Assert.AreEqual(sma[i], value);

                }
            });

            Task.WaitAll(tasks);
        }
    }
}
