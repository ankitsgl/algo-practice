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
    public class StrongPasswordCheckerAlgoTests
    {
        [TestMethod()]
        public void StrongPasswordCheckerTest()
        {
            var sol = new StrongPasswordCheckerAlgo();
            var result = sol.StrongPasswordChecker("a");
            Assert.AreEqual(5, result);
        }
    }
}