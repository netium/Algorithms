using System;
using Algorithms.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmUnitTests
{
    [TestClass]
    public class FixSizeQueueTests
    {
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestDequeueEmpty()
        {
            var queue = new FixSizeQueue<int>(1);
            queue.Dequeue();
        }

        [TestMethod]
        public void TestEnqueueDequeue()
        {
            var queue = new FixSizeQueue<int>(1);
            queue.Enqueue(10);
            var v = queue.Dequeue();
            Assert.AreEqual(v, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestEnqueueFull()
        {
            var queue = new FixSizeQueue<int>(1);
            queue.Enqueue(10);
            queue.Enqueue(1);
        }

        [TestMethod]
        public void TestItemOrder()
        {
            var queue = new FixSizeQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            var item = queue.Dequeue();
            Assert.AreEqual(item, 1);
            item = queue.Dequeue();
            Assert.AreEqual(item, 2);
        }

        [TestMethod]
        public void TestMixedOperationOrder()
        {
            var queue = new FixSizeQueue<int>(5);
            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 4; i++) {
                var item = queue.Dequeue();
                Assert.AreEqual(item, i);
            }

            for (int i = 0; i < 4; i++) {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 4; i++) {
                var item = queue.Dequeue();
                Assert.AreEqual(item, i);
            }
        }
    }
}
