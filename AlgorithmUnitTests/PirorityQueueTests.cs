using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Collections;

namespace AlgorithmUnitTests
{
    [TestClass]
    public class PirorityQueueTests
    {
        [TestMethod]
        public void testOrder()
        {
            var queue = new PriorityQueue<int>();
            queue.Enqueue(2);
            queue.Enqueue(1);
            int item = queue.Dequeue();
            Assert.AreEqual(item, 1);
            queue.Enqueue(4);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);

        }
    }
}
