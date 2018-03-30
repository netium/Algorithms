using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    public static class InsertSort
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

            for (int i = 1; i < items.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (less(items[j], items[j - 1]))
                    {
                        T tmp = items[j];
                        items[j] = items[j - 1];
                        items[j - 1] = tmp;
                    }
                    else
                        break;
                }
            }
        }
    }
}
