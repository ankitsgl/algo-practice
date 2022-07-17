using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph.Tests
{
    [TestClass()]
    public class MinimumKnightMovesTests
    {
        [TestMethod()]
        public void FindMinMoveTest()
        {
            var sol = new MinimumKnightMoves();
            var result = sol.FindMinMove(new[] { 0, 0 }, new[] { 5, 5 });
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void FindMinMove2Test()
        {
            var sol = new MinimumKnightMoves();
            var result = sol.FindMinMove(5, 5);
            Assert.AreEqual(4, result);
        }
    }
}