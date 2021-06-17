using System;
using System.Threading;
using System.Threading.Tasks;


namespace SimpleMovingAverage_ThreadSafe
{
    // Tracks the number of events occurring in a given period of time (1 second).
    public class SimpleMovingAverage_ThreadSafe : IDisposable
    {
        private readonly int _k;
        private readonly TimeSpan _bucketDuration;
        private readonly int[] _values;

        private readonly TaskCompletionSource<bool> _processExit = new TaskCompletionSource<bool>();

        private int _index = 0;
        private long _sum = 0;
        private int _currentBucketValue = 0;

        public SimpleMovingAverage_ThreadSafe(int k, TimeSpan bucketDuration)
        {
            if( k <= 0)
                throw new ArgumentOutOfRangeException(nameof(k), "Must be greater than 0");

            _k = k;
            _bucketDuration = bucketDuration;
            _values = new int[k];

            // start the background update task
            Task.Run(UpdateBucketTaskLoopAsync)
                .ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
        }

        public void IncrementCurrentBucket(int count)
        {
            // Note, can cause overflows°
            Interlocked.Add(ref _currentBucketValue, count);
        }

        public double GetLatestAverage()
        {
            var sum = Interlocked.Read(ref _sum);
            return ((double)sum) / _k;
        }

        private void UpdateBucket()
        {
            int previousBucketValue = _values[_index];
            int newBucketValue = Interlocked.Exchange(ref _currentBucketValue, 0);

            long newSum = _sum - previousBucketValue + newBucketValue;
            Interlocked.Exchange(ref _sum, newSum);

            _values[_index] = newBucketValue;
            _index = (_index + 1) % _k;
        }

        private async Task UpdateBucketTaskLoopAsync()
        {
            while(true)
            {
                if(_processExit.Task.IsCompleted)
                {
                    return;
                }

                UpdateBucket();

                await Task
                    .WhenAny(Task.Delay(_bucketDuration), _processExit.Task)
                    .ConfigureAwait(false);
            }
        }

        public void CancelUpdates()
        {
            _processExit.TrySetResult(true);
        }

        public void Dispose() => CancelUpdates();
    }
}
