using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.ArrayAndString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.ArrayAndString.Tests
{
    [TestClass()]
    public class ArrayAndStringTests
    {
        [TestMethod]
        public void TwoSum_Test()
        {
            var input = new int[] { 2, 7, 11, 15 };
            var result = ArrayAndStrings.TwoSum(input, 9);


            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }
        [TestMethod]
        public void TwoSum_Test2()
        {
            var input = new int[] { 2, 7, 11, 15 };
            var result = ArrayAndStrings.TwoSum2(input, 9);


            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [TestMethod]
        public void LengthOfLongestSubstringTest_bf()
        {
            var s = "abcabcbb";
            var length = ArrayAndStrings.LengthOfLongestSubstring_Bruteforce(s);
            Assert.AreEqual(3, length);

            s = "dvdf";
            length = ArrayAndStrings.LengthOfLongestSubstring_Bruteforce(s);
            Assert.AreEqual(3, length);

            s = "pwwkew";
            length = ArrayAndStrings.LengthOfLongestSubstring_Bruteforce(s);
            Assert.AreEqual(3, length);
        }
        [TestMethod]
        public void LengthOfLongestSubstringTest_Op()
        {
            var s = "abcabcbb";
            var length = ArrayAndStrings.LengthOfLongestSubstring_Optimized(s);
            Assert.AreEqual(3, length);

            s = "dvdf";
            length = ArrayAndStrings.LengthOfLongestSubstring_Optimized(s);
            Assert.AreEqual(3, length);

            s = "pwwkew";
            length = ArrayAndStrings.LengthOfLongestSubstring_Optimized(s);
            Assert.AreEqual(3, length);
        }
        [TestMethod]
        public void LengthOfLongestSubstringTest_Op2()
        {
            var s = "abcabcbb";
            var length = ArrayAndStrings.LengthOfLongestSubstring_Optimized2(s);
            Assert.AreEqual(3, length);

            s = "dvdf";
            length = ArrayAndStrings.LengthOfLongestSubstring_Optimized2(s);
            Assert.AreEqual(3, length);

            s = "pwwkew";
            length = ArrayAndStrings.LengthOfLongestSubstring_Optimized2(s);
            Assert.AreEqual(3, length);
        }


        [TestMethod]
        public void StringToIntTest_bf()
        {
            var s = "23435";
            var result = ArrayAndStrings.StringToInt_bf(s);
            Assert.AreEqual(23435, result);

            s = "-91283472332";
            result = ArrayAndStrings.StringToInt_bf(s);
            Assert.AreEqual(-91283472332, result);
        }

        [TestMethod]
        public void StringToIntTest_bf2()
        {
            var s = "23435";
            var result = ArrayAndStrings.StringToInt_bf2(s);
            Assert.AreEqual(23435, result);

            s = "-91283472332";
            result = ArrayAndStrings.StringToInt_bf2(s);
            Assert.AreEqual(-91283472332, result);
        }

        [TestMethod()]
        public void MaxWaterAreaTest_bf()
        {
            /*
             * 9
               8    |                        |
               7    |                        |         |
               6    |    |                   |         |
               5    |    |         |         |         |
               4    |    |         |    |    |         |
               3    |    |         |    |    |    |    |
               2    |    |    |    |    |    |    |    |
               1 |  |    |    |    |    |    |    |    |
               0 1  2    3    4    5    6    7    8    9
             */
            var result = ArrayAndStrings.MaxWaterArea_bf(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });

            Assert.AreEqual(49, result);
        }

        [TestMethod()]
        public void MaxWaterArea_OpTest()
        {
            /*
             * 9
               8    |                        |
               7    |                        |         |
               6    |    |                   |         |
               5    |    |         |         |         |
               4    |    |         |    |    |         |
               3    |    |         |    |    |    |    |
               2    |    |    |    |    |    |    |    |
               1 |  |    |    |    |    |    |    |    |
               0 1  2    3    4    5    6    7    8    9
             */
            var result = 0;
            //result = ArrayAndStrings.MaxWaterArea_Op(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });

            //Assert.AreEqual(49, result);


            result = ArrayAndStrings.MaxWaterArea_Op(new int[] { 2, 3, 4, 5, 18, 17, 6 });

            Assert.AreEqual(17, result);
        }

        [TestMethod()]
        public void IntToRoman_Test()
        {
            /* 
             * Symbol       Value
                I             1
                V             5
                X             10
                L             50
                C             100
                D             500
                M             1000
             * 
            */

            var res = ArrayAndStrings.IntToRoman(58);
            Assert.AreEqual("LVIII", res);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            /* 
             * Symbol       Value
                I             1
                V             5
                X             10
                L             50
                C             100
                D             500
                M             1000
             * 
            */

            var res = ArrayAndStrings.RomanToInt("CMXCVIII");
            Assert.AreEqual(998, res);
        }

        [TestMethod()]
        public void ThreeSumTest_bf()
        {
            var res = ArrayAndStrings.ThreeSum_bf(new int[] { -1, 0, 1, 2, -1, -4 });
            Assert.AreEqual(2, res.Count);

            Assert.AreEqual(-1, res[0][0]);
            Assert.AreEqual(-1, res[0][1]);
            Assert.AreEqual(2, res[0][2]);

            Assert.AreEqual(-1, res[1][0]);
            Assert.AreEqual(0, res[1][1]);
            Assert.AreEqual(1, res[1][2]);
        }

        [TestMethod()]
        public void ThreeSum_OpTest()
        {
            var res = ArrayAndStrings.ThreeSum_Op(new int[] { -1, 0, 1, 2, -1, -4 });



            Assert.AreEqual(2, res.Count);

            Assert.AreEqual(-1, res[0][0]);
            Assert.AreEqual(-1, res[0][1]);
            Assert.AreEqual(2, res[0][2]);

            Assert.AreEqual(-1, res[1][0]);
            Assert.AreEqual(0, res[1][1]);
            Assert.AreEqual(1, res[1][2]);


            res = ArrayAndStrings.ThreeSum_Op(new int[] { -2, 0, 0, 2, 2 });


            Assert.AreEqual(1, res.Count);

            Assert.AreEqual(-2, res[0][0]);
            Assert.AreEqual(0, res[0][1]);
            Assert.AreEqual(2, res[0][2]);




        }

        [TestMethod()]
        public void FindTwoSumTest()
        {
            var res = ArrayAndStrings.FindTwoSums(new int[] { -1, 0, 1, 2, -1, -4, -3, 3 });
            Assert.AreEqual(2, res.Count);

            Assert.AreEqual(-1, res[1][0]);
            Assert.AreEqual(1, res[1][1]);

            Assert.AreEqual(-3, res[0][0]);
            Assert.AreEqual(3, res[0][1]);

        }

        [TestMethod()]
        public void ThreeSumClosestTest()
        {
            var res = ArrayAndStrings.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1);
            Assert.AreEqual(2, res);
        }

        [TestMethod()]
        public void StrStrTest_bf()
        {
            var res = -1;
            res = ArrayAndStrings.StrStr_bf("mississippi", "sippia");
            Assert.AreEqual(-1, res);

            res = ArrayAndStrings.StrStr_bf("mississippi", "issip");
            Assert.AreEqual(4, res);

            res = ArrayAndStrings.StrStr_bf("a", "a");
            Assert.AreEqual(0, res);

        }

        [TestMethod()]
        public void StrStrTest_op()
        {
            var res = -1;
            res = ArrayAndStrings.StrStr_op("mississippi", "sippia");
            Assert.AreEqual(-1, res);

            res = ArrayAndStrings.StrStr_op("mississippi", "issip");
            Assert.AreEqual(4, res);

            res = ArrayAndStrings.StrStr_op("a", "a");
            Assert.AreEqual(0, res);

        }
    }
}