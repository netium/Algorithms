using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmUnitTests
{
    [TestClass]
    public class SelectSortTests
    {
        [TestMethod]
        public void TestSelectSort()
        {
            const int N = 100;
            int[] items = new int[N];

            Random rand = new Random();

            for (int i = 0; i < N; i++)
            {
                items[i] = rand.Next();
            }

            Algorithms.Sorts.SelectSort.Sort(items);

            for (int i = 0; i < N - 1; i++)
            {
                Assert.IsTrue(items[i] <= items[i + 1]);
            }
        }
    }
}
