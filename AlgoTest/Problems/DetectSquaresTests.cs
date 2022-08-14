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
    public class DetectSquaresTests
    {
        [TestMethod()]
        public void DetectSquaresTest()
        {
            var detectSquares = new DetectSquares();
            detectSquares.Add(new[] { 3, 10 });
            detectSquares.Add(new[] { 11, 2});
            detectSquares.Add(new[] { 3, 2});

            var count = detectSquares.Count(new[] { 11, 10 });
            Assert.AreEqual(1, count);
            
            count = detectSquares.Count(new[] { 14, 8 });
            Assert.AreEqual(0, count);

            detectSquares.Add(new[] { 11, 2 });

            count = detectSquares.Count(new[] { 11, 10 });
            Assert.AreEqual(2, count);
        }
    }
}