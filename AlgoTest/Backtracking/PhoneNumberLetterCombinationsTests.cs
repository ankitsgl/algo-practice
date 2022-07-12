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
    public class PhoneNumberLetterCombinationsTests
    {
        [TestMethod()]
        public void LetterCombinationsTest()
        {
            var sol = new PhoneNumberLetterCombinations();
            var result = sol.LetterCombinations("23");
            var expected = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };

            Assert.AreEqual(expected.Length, result.Count);

            ArrayHelper.PrintArray(expected, "Expected: ");
            ArrayHelper.PrintArray(result, "Result: ");
        }

        [TestMethod()]
        public void LetterCombinationsTest2()
        {
            var sol = new PhoneNumberLetterCombinations();
            var result = sol.LetterCombinations("234");
            var expected = new[] { "adg", "adh", "adi", "aeg", "aeh", "aei", "afg", "afh", "afi", "bdg", "bdh", "bdi", "beg", "beh", "bei", "bfg", "bfh", "bfi", "cdg", "cdh", "cdi", "ceg", "ceh", "cei", "cfg", "cfh", "cfi" };

            ArrayHelper.PrintArray(expected, "Expected: ");
            ArrayHelper.PrintArray(result, "Result: ");

            Assert.AreEqual(expected.Length, result.Count);
        }

        [TestMethod()]
        public void LetterCombinationsWordsTest()
        {
            var sol = new PhoneNumberLetterCombinations();
            var result = sol.LetterCombinationsWords("228");
            var expected = new[] { "bat", "cat"};

            Assert.AreEqual(expected.Length, result.Count);

            ArrayHelper.PrintArray(expected, "Expected: ");
            ArrayHelper.PrintArray(result, "Result: ");
        }
    }
}