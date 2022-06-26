using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Backtracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking.Tests
{
    [TestClass()]
    public class WordSearchTests
    {
        WordSearch sol = new WordSearch();
        [TestMethod()]
        public void ExistTest()
        {
            var board = new char[][] { 
                new []{ 'A', 'B', 'C', 'E' },
                new []{ 'S', 'F', 'C', 'S' },
                new []{ 'A', 'D', 'E', 'E' },
            };
            var result = sol.Exist(board, "ABCCED");
            Assert.IsTrue(result);
        }
    }
}