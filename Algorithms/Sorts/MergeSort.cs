using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    public static class MergeSort
    {
        private const int THRESHOLD = 15;

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

            T[] aux = new T[items.Count];
            Sort(items, aux, 0, items.Count, predictor);
        }

        private static void Sort<T>(IList<T> items, T[] aux, int low, int hi, Func<T, T, bool> less)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items) + " shall not be null");
            if (low < 0)
                throw new ArgumentOutOfRangeException(nameof(low) + " shall not less than 0");
            if (hi > items.Count)
                throw new ArgumentOutOfRangeException(nameof(hi) + " shall not greater than list length");
            if (hi < low)
                throw new ArgumentException(nameof(hi) + " shall not less than " + nameof(low));
            if (less == null)
                throw new ArgumentNullException(nameof(less) + " shall not be null");

            int dist = hi - low;
            if (dist <= 1)
                return;

            int mid = (hi - low) >> 1;

            Sort(items, aux, low, mid, less);
            Sort(items, aux, mid, hi, less);

            int first = low;
            int second = mid;
            for (int i = low; i < hi; i++) 
            {
                if (mid == hi) aux[i] = items[first++];
                else if (low == mid) aux[i] = items[second++];
                else if (!less(items[second], items[first])) aux[i] = items[first++];
                else aux[i] = items[second++];
            }
            for (int i = low; i < hi; i++)
                items[i] = aux[i];
        }
    }
}
