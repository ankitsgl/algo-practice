using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking
{
    public class Subsets
    {
        public List<List<int>> FindSubsets(int[] nums)
        {
            var result = new List<List<int>>();

            result.Add(new List<int>());

            foreach (var num in nums) 
            {
                var subSet = new List<List<int>>();
                foreach (var curr in result)
                {
                    subSet.Add(new List<int>(curr) { num });
                }
                foreach(var curr in subSet)
                    result.Add(curr);
            }
            return result;
        }

        public List<List<int>> FindSubsets_Op(int[] nums)
        {
            var result = new List<List<int>>();
            var k = 0;
            var n = nums.Length;

            void backtrack(int first, List<int> curr)
            {
                // if the combination is done
                if (curr.Count == k)
                {
                    result.Add(new List<int>(curr));
                    return;
                }
                for (int i = first; i < n; ++i)
                {
                    // add i into the current combination
                    curr.Add(nums[i]);
                    // use next integers to complete the combination
                    backtrack(i + 1, curr);
                    // backtrack
                    curr.RemoveAt(curr.Count - 1);
                }
            }


            for (k = 0; k < n+1; k++)
            {
                backtrack(0, new List<int>());
            }

            return result;
        }

    }
}
