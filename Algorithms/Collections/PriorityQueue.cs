using System;
using System.Collections.Generic;

namespace Algorithms.Collections
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> items = new List<T>();
        private Func<T, T, bool> less;

        public int Size
        {
            get { return items.Count; }
        }

        public PriorityQueue()
        {
            less = delegate(T item1, T item2) 
            {
                return item1.CompareTo(item2) < 0;
            };
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("Parameter " + nameof(comparer) + " cannot be null.");
            
            less = delegate (T item1, T item2)
            {
                return comparer.Compare(item1, item2) < 0;
            };
        }

        public PriorityQueue(Func<T, T, bool> predictor)
        {
            if (predictor == null)
                throw new ArgumentNullException("Parameter " + nameof(predictor) + " cannot be null.");

            less = predictor;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
            Upgrade(items.Count - 1);
        }

        public T Dequeue()
        {
            if (items.Count == 0)
                throw new OverflowException();

            var item = items[0];
            items[0] = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            if (items.Count > 0)
                Degrade(0);

            return item;
        }

        private void Upgrade(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new IndexOutOfRangeException();
            
            while (index > 0)
            {
                int parent = (index - 1) >> 1;
                if (less(items[parent], items[index]))
                    break;
                T tmp = items[index];
                items[index] = items[parent];
                items[parent] = tmp;
                index = parent;
            }
        }

        private void Degrade(int index)
        {
            if (index < 0 || index >= items.Count)
                throw new IndexOutOfRangeException("index of " + index.ToString() + " is out of the range");

            while (true)
            {
                int left = (index << 1) + 1;
                int right = (index << 1) + 2;
                int min = right < items.Count ?
                                       (less(items[left], items[right]) ? left : right) :
                                       (left < items.Count ? left : -1);
                if (min < 0)
                    break;

                if (less(items[index], items[min]))
                    break;
                
                T tmp = items[index];
                items[index] = items[min];
                items[min] = tmp;
                index = min;
            }
        }
    }
}
