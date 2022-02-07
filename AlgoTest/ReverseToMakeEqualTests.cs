namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class ReverseToMakeEqualTests
    {
        [TestMethod]
        public void Test()
        {
            var arayA = new int[] { 1, 3, 2, 4 };
            var arayB = new int[] { 1, 2, 3, 4 };

            var ag = new ReverseToMakeEqual();

            var result = ag.Check(arayA, arayB);
            
            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void Test2()
        {
            var arayA = new int[] { 1, 4, 2, 3 };
            var arayB = new int[] { 1, 2, 3, 4 };

            var ag = new ReverseToMakeEqual();

            var result = ag.Check(arayA, arayB);

            Assert.IsFalse(result);
        }
    }
}
