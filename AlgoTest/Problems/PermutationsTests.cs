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
    public class PermutationsTests
    {
        [TestMethod()]
        public void GetPermutationsTest()
        {
            var sol = new Permutations();

            var res = sol.GetPermutations(new List<int> { 1, 2, 3 });

            ArrayHelper.PrintArray(res);
            Assert.IsNotNull(res);
            Assert.AreEqual(6, res.Count);
        }
    }
}