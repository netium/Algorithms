using System;
namespace Algorithms.Collections
{
    public class FixSizeQueue<T>
    {
        T[] items;
        int head;
        int tail;

        public FixSizeQueue(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("The " + nameof(size) + " shall be greater than 0");
            
            items = new T[size + 1];
        }

        public int Capacity
        {
            get { return items.Length - 1; }   
        }

        public int Size
        {
            get { return (head + items.Length - tail) % items.Length; }
        }

        public void Enqueue(T item)
        {
            if ((head + 1) % items.Length == tail)
                throw new OverflowException();

            items[head] = item;
            head = (head + 1) % items.Length;
        }

        public T Dequeue()
        {
            if (tail == head)
                throw new OverflowException();

            var item = items[tail];
            items[tail] = default(T);
            tail = (tail + 1) % items.Length;

            return item;
        }
    }
}
