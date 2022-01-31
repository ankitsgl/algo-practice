using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class MergeIntervals
    {
        public int[,] Merge(int[,] intervals)
        {
            var result = new int[intervals.Length, 2];
            var mergedCount = 0;
            for (var index = 0; index < intervals.GetLength(0) - 1; index++)
            {
                if (intervals[index, 1] > intervals[index + 1, 0])
                {
                    //Merge them
                    result[mergedCount, 0] = intervals[index, 0];
                    result[mergedCount, 1] = intervals[index + 1, 1];
                    index++;
                }
                else
                {
                    result[mergedCount, 0] = intervals[index, 0];
                    result[mergedCount, 1] = intervals[index, 1];
                }
                mergedCount++;
            }

            return Resize(result, mergedCount);
        }

        public int[,] MergeUsingArray(int[,] intervals)
        {
            var pairs = new List<Pair>();
            
            pairs.Add(new Pair
            {
                Start = intervals[0, 0],
                End = intervals[0, 1]
            });

            for (var index = 1; index < intervals.GetLength(0); index++)
            {
                var lastPair = pairs.Last();
                if (lastPair.End > intervals[index, 0])
                {
                    lastPair.End = intervals[index, 1];
                }
                else
                {
                    pairs.Add(new Pair
                    {
                        Start = intervals[index, 0],
                        End = intervals[index, 1]
                    });
                }
            }

            var result = new int[pairs.Count, 2];
            
            for(int i = 0; i < pairs.Count; i++)
            {
                result[i, 0] = pairs[i].Start;
                result[i, 1] = pairs[i].End;
            }

            return result;
        }

        public int[][] MergeUsing2DArray(int[][] intervals)
        {
            Array.Sort(intervals, (x, y)=> x[0] - y[0]);
            var pairs = new List<int[]>();
                        
            int[] currentPair = intervals[0];
            pairs.Add(currentPair);
            for (var index = 1; index < intervals.GetLength(0); index++)
            {
                if (currentPair[1] >= intervals[index][0])
                {
                    currentPair[1] = Math.Max(currentPair[1], intervals[index][1]);
                }
                else
                {
                    currentPair = intervals[index];
                    pairs.Add(currentPair);
                }
            }
            return pairs.ToArray();
        }

        private int[,] Resize(int[,] array, int size)
        {
            var result = new int[size, 2];
            for (var index = 0; index < size; index++)
            {
                result[index, 0] = array[index, 0];
                result[index, 1] = array[index, 1];
            }
            return result;
        }
    }
    public class Pair
    {
        public int Start { get; set; }
        public int End { get; set; }

        
    }
}
