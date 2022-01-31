namespace AlgoTest
{    
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class MergeIntervalsTests
    {
        [TestMethod]
        public void Test()
        {
            var mergeIntervals = new MergeIntervals();

            var data = new int[,] { { 1, 3 }, { 2, 4 }, { 5, 7 }, { 6, 8 } };

            var result = mergeIntervals.Merge(data);
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual(1, result[0,0]);
            Assert.AreEqual(4, result[0, 1]);
        }

        [TestMethod]
        public void TestArray()
        {
            var mergeIntervals = new MergeIntervals();

            var data = new int[,] { { 1, 4 }, { 2, 5 },{4,6 }, { 7, 9 }, { 8, 10 } };

            var result = mergeIntervals.MergeUsingArray(data);
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Length);
            //Assert.AreEqual(1, result[0, 0]);
            //Assert.AreEqual(4, result[0, 1]);
        }

        [TestMethod]
        public void Test2DArray()
        {
            var mergeIntervals = new MergeIntervals();

            //var data = new int[,] { { 1, 4 }, { 2, 5 }, { 4, 6 }, { 7, 9 }, { 8, 10 } };
            var data = new List<int[]>();
            data.Add(new int[2] { 1, 4 });
            data.Add(new int[2] { 2, 5 });
            data.Add(new int[2] { 4, 6 });
            data.Add(new int[2] { 7, 9 });
            data.Add(new int[2] { 8, 10 });

            var result = mergeIntervals.MergeUsing2DArray(data.ToArray());
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            //Assert.AreEqual(1, result[0, 0]);
            //Assert.AreEqual(4, result[0, 1]);
            
        }

        [TestMethod]
        public void Test2DArray2()
        {
            var mergeIntervals = new MergeIntervals();

            //var data = new int[,] { { 1, 4 }, { 2, 5 }, { 4, 6 }, { 7, 9 }, { 8, 10 } };
            var data = new List<int[]>();
            data.Add(new int[2] { 1, 4 });
            data.Add(new int[2] { 4, 5 });
            

            var result = mergeIntervals.MergeUsing2DArray(data.ToArray());
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            //Assert.AreEqual(1, result[0, 0]);
            //Assert.AreEqual(4, result[0, 1]);

        }

        [TestMethod]
        public void Test2DArray3()
        {
            var mergeIntervals = new MergeIntervals();

            //var data = new int[,] { { 1, 4 }, { 2, 5 }, { 4, 6 }, { 7, 9 }, { 8, 10 } };
            var data = new List<int[]>();
            data.Add(new int[2] { 4, 5 });
            data.Add(new int[2] { 1, 4 });


            var result = mergeIntervals.MergeUsing2DArray(data.ToArray());
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            //Assert.AreEqual(1, result[0, 0]);
            //Assert.AreEqual(4, result[0, 1]);

        }

        [TestMethod]
        public void Test2DArray4()
        {
            var mergeIntervals = new MergeIntervals();

            var data = new List<int[]>();
            data.Add(new int[2] { 1, 4 });
            data.Add(new int[2] { 2, 3 });


            var result = mergeIntervals.MergeUsing2DArray(data.ToArray());
            Print(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(4, result[0][1]);

        }


        private void Print(int[,] intervals)
        {
            for (var index = 0; index < intervals.GetLength(0) ; index++)
            {
                Console.WriteLine($"[{intervals[index,0]},{intervals[index,1]}]");
            }
        }

        private void Print(int[][] intervals)
        {
            for (var index = 0; index < intervals.Length; index++)
            {
                Console.WriteLine($"[{intervals[index][0]},{intervals[index][1]}]");
            }
        }
    }
}
