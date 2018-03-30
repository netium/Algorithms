using System;
namespace Algorithms.Collections
{
    public class FixSizeStack<T>
    {
        private readonly T[] _items;
        private int index = 0;

        public FixSizeStack(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("The " + nameof(size) + " shall be greater than 0");

            _items = new T[size];
        }

        public void Push(T item) {
            if (index >= _items.Length)
                throw new OverflowException();

            _items[index++] = item;
        }

        public T Pop() 
        {
            if (index <= 0)
                throw new OverflowException();

            T item = _items[--index];
            _items[index] = default(T);
            return item;
        }

        public int Size 
        {
            get { return index; }
        }

        public int Capacity 
        {
            get { return _items.Length; }
        }
    }
}
