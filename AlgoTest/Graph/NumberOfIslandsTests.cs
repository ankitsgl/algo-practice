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
    public class NumberOfIslandsTests
    {
        [TestMethod()]
        public void NumIslandsTest()
        {
            var input = new []{
                new[] { '1', '1', '0', '0', '0' },
                new[] { '1', '1', '0', '0', '0' },
                new[] { '0', '0', '1', '0', '0'},
                new[] { '0', '0', '0', '1', '1' },
            };

            Helpers.ArrayHelper.PrintArray(input);
            var sol = new NumberOfIslands();
            var res = sol.NumIslands(input);
            Assert.AreEqual(3, res);
        }

        [TestMethod()]
        public void NumIslandsTest2()
        {
            var input = new[]{
                new[] { '1','1','1','1','0'},
                new[] { '1','1','0','1','0'},
                new[] { '1','1','0','0','0'},
                new[] { '0','0','0','0','0'},
            };

            Helpers.ArrayHelper.PrintArray(input);
            var sol = new NumberOfIslands();
            var res = sol.NumIslands(input);
            Assert.AreEqual(1, res);
        }

        [TestMethod()]
        public void NumIslands_DfsTest()
        {
            var input = new[]{
                new[] { '1', '1', '0', '0', '0' },
                new[] { '1', '1', '0', '0', '0' },
                new[] { '0', '0', '1', '0', '0'},
                new[] { '0', '0', '0', '1', '1' },
            };

            Helpers.ArrayHelper.PrintArray(input);
            var sol = new NumberOfIslands();
            var res = sol.NumIslands_UsingDfs(input);
            Assert.AreEqual(3, res);
        }

    }
}