using ArrayStack;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ArrayStackBenchmark
{
    public class ArrayStackBenchmark
    {
        [Benchmark]
        public void ArrayStack_10()
        {
            int size = 10;
            ArrayStack.ArrayStack<int> arrayStack = new ArrayStack.ArrayStack<int>(size);

            for(int i = 0; i <= size - 1; i++)
            {
                arrayStack.Push(i);
            }

            for(int i = 0; i <= size - 1; i++)
            {
                arrayStack.Pop();
            }
        }

        [Benchmark]
        public void ArrayStack_100()
        {
            int size = 100;
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

        [Benchmark]
        public void ArrayStack_1000()
        {
            int size = 1000;
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

                [Benchmark]
        public void ArrayStack_10000()
        {
            int size = 10000;
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

                [Benchmark]
        public void ArrayStack_100000()
        {
            int size = 100000;
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

                [Benchmark]
        public void ArrayStack_1000000()
        {
            int size = 1000000;
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

                [Benchmark]
        public void ArrayStack_10000000()
        {
            int size = 10000000;
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