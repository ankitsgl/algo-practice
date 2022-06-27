using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.CombinationSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.CombinationSearch.Tests
{
    [TestClass()]
    public class CombinationSearchProblemTests
    {
        [TestMethod()]
        public void CombinationSumTest()
        {
            var sol = new CombinationSearchProblem();

            var result = sol.CombinationSum(new[] { 2, 3, 6, 7 }, 7);
            ArrayHelper.PrintArray(result);
            Assert.AreEqual(2, result.Count);
        }
    }
}