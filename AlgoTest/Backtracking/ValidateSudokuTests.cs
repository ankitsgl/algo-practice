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
    public class ValidateSudokuTests
    {
        [TestMethod()]
        public void IsValidSudokuTest()
        {
            var board = new char[][]
            {
                 new[]{ '5','3','.','.','7','.','.','.','.'}
                ,new[] { '6','.','.','1','9','5','.','.','.'}
                ,new[] { '.','9','8','.','.','.','.','6','.'}
                ,new[] { '8','.','.','.','6','.','.','.','3'}
                ,new[] { '4','.','.','8','.','3','.','.','1'}
                ,new[] { '7','.','.','.','2','.','.','.','6'}
                ,new[] { '.','6','.','.','.','.','2','8','.'}
                ,new[] { '.','.','.','4','1','9','.','.','5'}
                ,new[] { '.','.','.','.','8','.','.','7','9'}
            };

            var sol = new ValidateSudoku();
            ArrayHelper.PrintArray(board);
            var result = sol.IsValidSudoku(board);

            Assert.IsTrue(result);

        }
    }
}