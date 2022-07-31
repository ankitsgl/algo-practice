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
    public class GenerateParenthesesAlgoTests
    {
        [TestMethod()]
        public void GenerateParenthesisTest()
        {
            var sol = new GenerateParenthesesAlgo();
            var result = sol.GenerateParenthesis(3);
            ArrayHelper.PrintArray(result);
            Assert.AreEqual(5, result.Count);

        }
    }
}