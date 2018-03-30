using System;
using Algorithms.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmUnitTests
{
    [TestClass]
    public class FixSizeStackUnitTests
    {
        [TestMethod]
        public void TestPush()
        {
            var stack = new FixSizeStack<int>(10);
            stack.Push(10);
            Assert.AreEqual(stack.Size, 1);
        }

        [TestMethod]
        public void TestPop()
        {
            var stack = new FixSizeStack<int>(10);
            stack.Push(10);
            int n = stack.Pop();
            Assert.AreEqual(10, n);
            Assert.AreEqual(stack.Size, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestPushOverflow()
        {
            var stack = new FixSizeStack<int>(1);
            stack.Push(10);
            stack.Push(9);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestPopEmptyStack()
        {
            var stack = new FixSizeStack<int>(1);
            stack.Pop();
        }
    }
}
