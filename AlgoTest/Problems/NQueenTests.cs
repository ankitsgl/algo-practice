using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Problems.Tests
{
    [TestClass()]
    public class NQueenTests
    {
        [TestMethod()]
        public void PlaceNQueenTest()
        {
            var sol = new NQueen();
            var res = sol.PlaceNQueen(4, 4);
            ArrayHelper.PrintArray(res);
        }
    }
}