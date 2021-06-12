using System;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] stack;
        private int stackSize;
        private int index;
        public ArrayStack(int size)
        {
            stack = new T[size];
            stackSize = size;
            index = -1;
        }

        public void Push(T element)
        {
            if(index <= (stackSize - 1))
            {
                stack[++index] = element;
            }
            else
            {
                throw new Exception("Stack is full");
            }
        }

        public T Pop()
        {
            if(index > -1)
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
                stack[i] = default;
            }
            index = 0;
        }
    }
}