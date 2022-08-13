using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems.Tests
{
    [TestClass()]
    public class SlowestKeyAlgoTests
    {
        [TestMethod()]
        public void SlowestKeyTest()
        {
            var algo = new SlowestKeyAlgo();
            var result = algo.SlowestKey(new int[] { 9, 29, 49, 50 }, "cbcd");
            Assert.AreEqual('c', result);
        }
    }
}