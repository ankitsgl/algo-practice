using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class SingleThreadedCpu
    {
        //https://leetcode.com/problems/single-threaded-cpu/
        //https://www.youtube.com/watch?v=RR1n-d4oYqE
        public int[] GetOrder(int[][] tasks)
        {
            int len = tasks.Length;
            int[] result = new int[len];

            int[][] jobs = new int[len][];
            for (int i = 0; i < len; i++)
            {
                jobs[i] = new int[3] { tasks[i][0], tasks[i][1], i };
            }

            Array.Sort(jobs, (a, b) => a[0] - b[0]);

            PriorityQueue<int[], int[]> pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[1] == b[1] ? a[2] - b[2] : a[1] - b[1]));

            int idx = 0, k = 0, time = 0;

            while (pq.Count != 0 || idx < len)
            {
                if (pq.Count == 0)
                {
                    // Start at smallest time in given list initially then go for max
                    time = Math.Max(time, jobs[idx][0]);
                }

                // Add to queue untill current time is greater then time
                while (idx < len && time >= jobs[idx][0])
                {
                    pq.Enqueue(jobs[idx], jobs[idx]);
                    idx++;
                }

                int[] curr = pq.Dequeue();
                time += curr[1];
                result[k++] = curr[2];
            }

            return result;


        }

        
    }
}
