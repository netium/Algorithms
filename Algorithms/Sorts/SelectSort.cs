using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    public static class SelectSort
    {
        public static void Sort<T>(IList<T> items) where T : IComparable<T>
        {
            Sort(items, (item1, item2) => item1.CompareTo(item2) < 0);
        }

        public static void Sort<T>(IList<T> items, IComparer<T> comparer)
        {
            Sort(items, (item1, item2) => comparer.Compare(item1, item2) < 0);
        }

        public static void Sort<T>(IList<T> items, Func<T, T, bool> predictor)
        {
            if (items == null)
                throw new ArgumentNullException("Parameter " + nameof(items) + " cannot be null");
            if (predictor == null)
                throw new ArgumentNullException("Parameter " + nameof(items) + " cannot be null");

            var less = predictor;

            for (int i = 0; i < items.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (less(items[j], items[minIndex]))
                        minIndex = j;
                }
                T tmp = items[i];
                items[i] = items[minIndex];
                items[minIndex] = tmp;
            }
        }
    }
}
