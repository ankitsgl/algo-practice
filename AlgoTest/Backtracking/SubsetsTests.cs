using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Backtracking.Tests
{
    [TestClass()]
    public class SubsetsTests
    {
        Subsets sol = new Subsets();
        [TestMethod()]
        public void SubsetsTest()
        {
            var result = sol.FindSubsets(new int[] { 1, 2, 3 });
            ArrayHelper.PrintArray(result);
            Assert.AreEqual(8, result.Count);
        }

        [TestMethod()]
        public void Subsets_opTest()
        {
            var result = sol.FindSubsets_Op(new int[] { 1, 2, 3 });

            Assert.AreEqual(8, result.Count);
        }
    }
}