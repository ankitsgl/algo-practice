﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Sort.Tests
{
    [TestClass()]
    public class SelectionSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            var algo = new SelectionSort();
            var input = new[] { 3, 6, 2, 5, 1, 7, 9, 8 };
            var result = algo.Sort(input);
            var expected = new[] { 3, 6, 2, 5, 1, 7, 9, 8 };
            Array.Sort(expected);

            ArrayHelper.PrintArray(input, "Input: ");
            ArrayHelper.PrintArray(expected, "Expected: ");
            ArrayHelper.PrintArray(result, "Result: ");

            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Length, result.Length);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}