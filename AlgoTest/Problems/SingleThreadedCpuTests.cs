using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Problems.Tests
{
    [TestClass()]
    public class SingleThreadedCpuTests
    {
        [TestMethod()]
        public void GetOrderTest()
        {
            var sol = new SingleThreadedCpu();
            var input = new[] { new[] { 1, 2 }, new[] { 2, 4 }, new[] { 3, 2 }, new[] { 4, 1 } };
            var result = sol.GetOrder(input);
            ArrayHelper.PrintArray(result);
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(1, result[3]);
        }
    }
}