using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Stack.Tests
{
    [TestClass()]
    public class RemoveAllAdjacentDuplicatesTests
    {
        [TestMethod()]
        public void RemoveTest()
        {
            var sol = new RemoveAllAdjacentDuplicates();
            var res = sol.Remove("deeedbbcccbdaa", 3);
            Assert.AreEqual("aa", res);
        }
    }
}