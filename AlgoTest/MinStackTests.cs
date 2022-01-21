namespace AlgoTest
{
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class MinStackTests
    {
        [TestMethod]
        public void Test()
        {
            
            var minStack = new MinStack();

            minStack.Push(0);
            minStack.Push(-2);
            minStack.Push(-3);
            
            Assert.AreEqual(-3, minStack.Top());

            minStack.Pop();
            minStack.Pop();
            var m2 = minStack.GetMin();

            Assert.AreEqual(0, minStack.Top());
            Assert.AreEqual(0, m2);
        }
    }
}
