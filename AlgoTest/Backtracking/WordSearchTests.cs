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

        [TestMethod()]
        public void FindWordsTest()
        {
            var board = new char[][] {
                new [] {'o','a','a','n'},
                new [] {'e','t','a','e'},
                new [] {'i','h','k','r'},
                new [] {'i','f','l','v'}
            };
            var result = sol.FindWords(board, new[] { "oath", "pea", "eat", "rain" });
            Assert.AreEqual(2, result.Count);

            ArrayHelper.PrintArray(result);

            Assert.IsTrue(result.Contains("eat"));
            Assert.IsTrue(result.Contains("oath"));
        }
    }
}