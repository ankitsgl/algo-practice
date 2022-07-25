using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoTest.Hashmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.Hashmap.Tests
{
    [TestClass()]
    public class TopKFrequentElementsTests
    {
        [TestMethod()]
        public void TopKFrequentTest()
        {
            var input = new int[] { 1,1,1,2,2,3};
            var sol = new TopKFrequentElements();
            var result = sol.TopKFrequent(input, 2);
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(2));
        }
    }
}