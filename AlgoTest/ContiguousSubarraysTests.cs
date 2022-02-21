namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class ContiguousSubarraysTests
    {
        [TestMethod]
        public void Test()
        {
            var arayA = new int[] { 3, 4, 1, 6, 2 };
            

            var ag = new ReverseToMakeEqual();
            var result = ContiguousSubarrays.Find(arayA);
            
            Assert.IsTrue(result.Length == 5);
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 3);
            Assert.IsTrue(result[2] == 1);
            Assert.IsTrue(result[3] == 5);
            Assert.IsTrue(result[4] == 1);
        }

         
    }
}
