using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;
public class Permutations
{
    public List<List<int>> GetPermutations(List<int> nums)
    {
        var res = new List<List<int>>();



        if (nums.Count == 0) return new List<List<int>>();
        if (nums.Count == 1)
            return new List<List<int>> { new List<int>(nums) };


        void backtrack(List<int> perm, int[] used)
        {
            if (perm.Count == nums.Count)
            {
                res.Add(new List<int>(perm));
                return;
            }
            for (var i = 0; i < nums.Count; i++)
            {
                if (used[i] != 1)
                {
                    used[i] = 1;
                    perm.Add(nums[i]);
                    backtrack(perm, used);

                    used[i] = 0;
                    perm.RemoveAt(perm.Count - 1);
                }
            }
        };

        backtrack(new List<int>(), new int[nums.Count]);
        return res;
    }
}

