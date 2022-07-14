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
    public class TheMazeTests
    {
        [TestMethod()]
        public void HasPath_DfsTest()
        {
            var maze = new int[][] {
                    new[] { 0, 0, 1, 0, 0 },
                    new[] { 0, 0, 0, 0, 0 },
                    new[] { 0, 0, 0, 1, 0 },
                    new[] { 1, 1, 0, 1, 1 },
                    new[] { 0, 0, 0, 0, 0 }};
            var sol = new TheMaze();
            var result = sol.HasPath_Dfs(maze, new[] { 0, 4 }, new[] { 4, 4 });

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void HasPath_BfsTest()
        {
            var maze = new int[][] {
                    new[] { 0, 0, 1, 0, 0 },
                    new[] { 0, 0, 0, 0, 0 },
                    new[] { 0, 0, 0, 1, 0 },
                    new[] { 1, 1, 0, 1, 1 },
                    new[] { 0, 0, 0, 0, 0 }};
            var sol = new TheMaze();
            var result = sol.HasPath_Bfs(maze, new[] { 0, 4 }, new[] { 4, 4 });

            Assert.IsTrue(result);
        }
    }
}