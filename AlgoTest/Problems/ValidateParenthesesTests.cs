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
    public class ValidateParenthesesTests
    {
        [TestMethod()]
        public void LongestValidParenthesesTest()
        {
            var sol = new ValidateParentheses();
            var result = sol.LongestValidParentheses("(()");
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void LongestValidParenthesesTest2()
        {
            var sol = new ValidateParentheses();
            var result = sol.LongestValidParentheses(")()())");
            Assert.AreEqual(4, result);
        }
    }
}