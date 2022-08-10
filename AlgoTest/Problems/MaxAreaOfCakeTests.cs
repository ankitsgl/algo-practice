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
    public class MaxAreaOfCakeTests
    {
        [TestMethod()]
        public void MaxAreaTest()
        {
            var sol = new MaxAreaOfCake();
            var res = sol.MaxArea(5, 4, new[] { 1, 2, 4 }, new[] { 1, 3 });
            Assert.AreEqual(4, res);
        }
    }
}