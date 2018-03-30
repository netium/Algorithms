using System;
using System.Collections.Generic;
using Algorithms.Collections;

namespace Algorithms.Sorts
{
    public static class HeapSort
    {
        public static void Sort<T>(IList<T> items) where T : IComparable<T>
        {
            Sort(items, (item1, item2) => item1.CompareTo(item2) < 0);
        }

        public static void Sort<T>(IList<T> items, IComparer<T> comparer) where T : IComparable<T>
        {
            Sort(items, (item1, item2) => comparer.Compare(item1, item2) < 0);
        }

        public static void Sort<T>(IList<T> items, Func<T, T, bool> predictor) where T : IComparable<T>
        {
            if (items == null)
                throw new ArgumentNullException("Parameter " + nameof(items) + " cannot be null");
            if (predictor == null)
                throw new ArgumentNullException("Parameter " + nameof(items) + " cannot be null");

            var queue = new PriorityQueue<T>(predictor);
            foreach (var item in items)
                queue.Enqueue(item);

            for (int i = 0; i < items.Count; i++)
                items[i] = queue.Dequeue();
        }
    }
}
