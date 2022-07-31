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

        //https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string/
        public int UniqueLetterString(string s)
        {
            //Count Unique Characters of All Substrings of a Given String
            // Continious
            Dictionary<char, List<int>> map = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    map[s[i]].Add(i);
                }
                else
                {
                    List<int> temp = new();
                    temp.Add(i);
                    map.Add(s[i], temp);
                }
            }

            int sum = 0;
            foreach (var list in map.Values)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int left = i == 0 ? list[i] + 1 : list[i] - list[i - 1];
                    int right = i == list.Count - 1 ? s.Length - list[i] : list[i + 1] - list[i];
                    sum += left * right;
                }
            }

            return sum;
        }
    }
}
