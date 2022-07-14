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
    public class IsRobotBoundedAlgoTests
    {
        [TestMethod()]
        public void IsRobotBoundedTest()
        {
            var sol = new IsRobotBoundedAlgo();
            var result = sol.IsRobotBounded("GGLLGG");
            Assert.IsTrue(result);
        }
    }
}