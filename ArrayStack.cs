using System;

namespace ArrayStack
{
    public class ArrayStack<T> where T : class
    {
        private T[] stack ;
        private int stackSize;
        private int index;
        public ArrayStack(int size)
        {
            stack = T[size];
            stackSize = size;
        }

        public void Push(T element)
        {
            if(index < (stackSize - 1))
            {
                stack[index++] = element;
            }
            else
            {
                throw new Exception("Stack is full");
            }
        }

        public T Pop()
        {
            if(index > 0)
            {
                return stack[index--];
            }
            else
            {
                throw new Exception("Stack is empty");
            }
        }

        public void Clean()
        {
            for(int i = 0; i < stackSize - 1; i++)
            {
                stack[i] = null;
            }
            index = 0;
        }
    }
}