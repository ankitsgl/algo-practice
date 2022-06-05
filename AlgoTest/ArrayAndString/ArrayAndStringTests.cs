﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.ArrayAndString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.ArrayAndString.Tests
{
    [TestClass()]
    public class ArrayAndStringTests
    {
        ArrayAndStrings sol = new ArrayAndStrings();

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
        [TestMethod()]
        public void RotateImageTest()
        {
            var array = new int[4][];
            array[0] = new int[] { 5, 1, 9, 11 };
            array[1] = new int[] { 2, 4, 8, 10 };
            array[2] = new int[] { 13, 3, 6, 7 };
            array[3] = new int[] { 15, 14, 12, 16 };

            ArrayHelper.PrintArray(array);
            ArrayAndStrings.RotateImage(array);
            Console.WriteLine("Actual ----------------");
            ArrayHelper.PrintArray(array);


            var expectedArray = new int[4][];
            expectedArray[0] = new int[] { 15, 13, 2, 5 };
            expectedArray[1] = new int[] { 14, 3, 4, 1 };
            expectedArray[2] = new int[] { 12, 6, 8, 9 };
            expectedArray[3] = new int[] { 16, 7, 10, 11 };
            Console.WriteLine("Expected ---------------");
            ArrayHelper.PrintArray(expectedArray);

            Assert.IsTrue(ArrayHelper.AreEqual(array, expectedArray));
        }

        [TestMethod()]
        public void GroupAnagramsTest_bf()
        {
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var res = ArrayAndStrings.GroupAnagrams_bf(strs);

            Assert.AreEqual(3, res.Count);
            Assert.AreEqual("eat", res[0][0]);
            Assert.AreEqual(2, res[1].Count);


            Assert.AreEqual(1, res[2].Count);

        }

        [TestMethod()]
        public void GroupAnagramsTest_op()
        {
            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var res = ArrayAndStrings.GroupAnagrams_op(strs);

            Assert.AreEqual(3, res.Count);
            Assert.AreEqual("eat", res[0][0]);
            Assert.AreEqual(2, res[1].Count);


            Assert.AreEqual(1, res[2].Count);

            strs = new string[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" };
            res = ArrayAndStrings.GroupAnagrams_op(strs);
            Assert.AreEqual(10, res.Count);
        }

        [TestMethod()]
        public void MinWindowSubString_bfTest()
        {
            var res = ArrayAndStrings.MinWindowSubstring_bf("ADOBECODEBANC", "ABC");

            Assert.AreEqual("BANC", res);
        }

        [TestMethod()]
        public void CompareVersionTest()
        {
            var res = ArrayAndStrings.CompareVersion("1.01", "1.001");
            Assert.AreEqual(0, res);
        }

        [TestMethod()]
        public void ProductExceptSelfTest_bf()
        {
            var res = ArrayAndStrings.ProductExceptSelf_bf(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(4, res.Length);

            Assert.AreEqual(24, res[0]);
            Assert.AreEqual(12, res[1]);
            Assert.AreEqual(8, res[2]);
            Assert.AreEqual(6, res[3]);
        }

        [TestMethod()]
        public void ProductExceptSelfTest_op()
        {
            var res = ArrayAndStrings.ProductExceptSelf_op(new int[] { 1, 2, 3, 4 });
            Assert.AreEqual(4, res.Length);

            Assert.AreEqual(24, res[0]);
            Assert.AreEqual(12, res[1]);
            Assert.AreEqual(8, res[2]);
            Assert.AreEqual(6, res[3]);
        }

        [TestMethod()]
        public void MissingNumberTest()
        {
            var result = ArrayAndStrings.MissingNumber(new int[] { 3, 0, 1 });

            Assert.AreEqual(2, result);

        }

        [TestMethod()]
        public void NumberToWordsTest()
        {
            var result = ArrayAndStrings.NumberToWords(12345);

            Assert.AreEqual("Twelve Thousand Three Hundred Forty Five", result);
        }

        [TestMethod()]
        public void NumberToWordsTest_op2()
        {
            var result = ArrayAndStrings.NumberToWords_Op2(130);

            Assert.AreEqual("One Hundred Thirty", result);
        }

        [TestMethod()]
        public void FirstUniqCharTest()
        {
            var result = ArrayAndStrings.FirstUniqChar("loveleetcode");

            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void MostCommonWordTest()
        {
            var result = sol.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", 
                new string[]{ "hit"});

            Assert.AreEqual("ball", result);
        }

        [TestMethod()]
        public void MostCommonWordTest2()
        {
            var result = sol.MostCommonWord("j. t? T. z! R, v, F' x! L; l! W. M; S. y? r! " +
"n; O. q; I? h; w. t; y; X? y, p. k! k, h, J, r" +
"? w! U! V; j' u; R! z. s. T' k. P? M' I' j! y. P, T! e; X. w? M! Y, X" +
"; G; d, X? S' F, K? V, r' v, v, D, w, K! S? Q! N. n. V. v. t? t' x! u. j" +
"; m; n! F, V' Y! h; c! V, v, X' X' t? n; N' r; x. W' P? W; p' q, S' X, J; R. x; " +
"z; z! G, U; m. P; o. P! Y; I, I' l' J? h; Q; s? U, q, x. J, T! o. z, N, L; u, w! u, S. Y! " +
"V; S? y' E! O; p' X, w. p' M, h! R; t? K? Y' z? T? w; u. q' R, q, T. R? I. R! t, X, s? u; z. u," +
" Y, n' U; m; p? g' P? y' v, o? K? R. Q? I! c, X, x. r' u! m' y. t. W; x! K? B. v; m, k; k' x; Z! U! " +
" p. U? Q, t, u' E' n? S' w. y; W, x? r. p! Y? q, Y. t, Z' V, S. q; W. Z, z? x! k, I. n; x? z; V? s! g, U; E" +
" ' m! Z? y' x? V! t, F. Z? Y' S! z, Y' T? x? v? o! l; d; G' L. L, Z? q. w' r? U! E, H. C, Q! O? w! s? w' D. R, Y?" +
" u. w, N. Z? h. M? o, B, g, Z! t! l, W? z, o? z, q! O? u, N; o' o? V; S! z; q! q. o, t! q! w! Z? " +
" Z? w, F? O' N' U' p? r' J' L; S. M; g' V. i, P, v, v, f; W? L, y! i' z; L? w. v, s! P?",
                new string[] { "m", "q", "e", "l", "c", "i", "z", "j", "g", "t", "w", "v", "h", "p", "d", "b", "a", "r", "x", "n" });

            Assert.AreEqual("y", result);
        }

        [TestMethod()]
        public void MostCommonWord_Imp2Test()
        {
            var result = sol.MostCommonWord_Imp2("Bob hit a ball, the hit BALL flew far after it was hit.",
                new string[] { "hit" });

            Assert.AreEqual("ball", result);
        }

        [TestMethod()]
        public void MostCommonWord_Imp2Test2()
        {
            var result = sol.MostCommonWord_Imp2("j. t? T. z! R, v, F' x! L; l! W. M; S. y? r! " +
"n; O. q; I? h; w. t; y; X? y, p. k! k, h, J, r" +
"? w! U! V; j' u; R! z. s. T' k. P? M' I' j! y. P, T! e; X. w? M! Y, X" +
"; G; d, X? S' F, K? V, r' v, v, D, w, K! S? Q! N. n. V. v. t? t' x! u. j" +
"; m; n! F, V' Y! h; c! V, v, X' X' t? n; N' r; x. W' P? W; p' q, S' X, J; R. x; " +
"z; z! G, U; m. P; o. P! Y; I, I' l' J? h; Q; s? U, q, x. J, T! o. z, N, L; u, w! u, S. Y! " +
"V; S? y' E! O; p' X, w. p' M, h! R; t? K? Y' z? T? w; u. q' R, q, T. R? I. R! t, X, s? u; z. u," +
" Y, n' U; m; p? g' P? y' v, o? K? R. Q? I! c, X, x. r' u! m' y. t. W; x! K? B. v; m, k; k' x; Z! U! " +
" p. U? Q, t, u' E' n? S' w. y; W, x? r. p! Y? q, Y. t, Z' V, S. q; W. Z, z? x! k, I. n; x? z; V? s! g, U; E" +
" ' m! Z? y' x? V! t, F. Z? Y' S! z, Y' T? x? v? o! l; d; G' L. L, Z? q. w' r? U! E, H. C, Q! O? w! s? w' D. R, Y?" +
" u. w, N. Z? h. M? o, B, g, Z! t! l, W? z, o? z, q! O? u, N; o' o? V; S! z; q! q. o, t! q! w! Z? " +
" Z? w, F? O' N' U' p? r' J' L; S. M; g' V. i, P, v, v, f; W? L, y! i' z; L? w. v, s! P?",
                new string[] { "m", "q", "e", "l", "c", "i", "z", "j", "g", "t", "w", "v", "h", "p", "d", "b", "a", "r", "x", "n" });

            Assert.AreEqual("y", result);
        }
    }
}