using System;

namespace SelectionSort
{
    public class SelectionSort
    {
       private int[] arr;
        private int upper;
        private int numElements;

        public SelectionSort(int size)
        {
            arr = new int[size];
            upper = size-1;
            numElements = 0;
        }

        public void Insert(int item) 
        {
            arr[numElements] = item;
            numElements++;
        }

        public void DisplayElements()
        {
            for(int i = 0; i <= upper; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public void Clear()
        {
            for(int i = 0; i <= upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;
        }

        public void SelectionSortSort()
        {
            int min, temp;
            for(int outer = 0; outer <= upper; outer++)
            {
                min = outer;
                for(int inner = outer + 1; inner <= upper; inner++)
                {
                    if(arr[inner] < arr[min])
                        min = inner;
                }
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
            }
        }
    }
}