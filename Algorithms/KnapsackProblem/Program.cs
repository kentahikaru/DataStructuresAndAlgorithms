using System;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 16;
            int[] size = new int[] { 3,4,7,8,9};
            int[] values = new int[] { 4,5, 10, 11,13};
            int[] totval = new int[capacity];
            int[] best = new int[capacity];
            int n = values.Length;

            for(int j = 0; j <= n-1; j++)
            {
                for(int i = 0; i <= capacity; i++)
                {
                    if(i >= size[j])
                    {
                        if(totval[i] < (totval[i-size[j]] + values[j]))
                        {
                            totval[i] = totval[i-size[j]] + values[j];
                            best[i] = j;
                        }
                    }
                }
            }

            Console.WriteLine("The maximum value is: " + totval[capacity]);
        }
    }
}
