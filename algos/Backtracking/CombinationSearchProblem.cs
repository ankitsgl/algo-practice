using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.CombinationSearch
{
    public class CombinationSearchProblem
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> results = new List<IList<int>>();

            void backtrack(int remain,
                LinkedList<int> comb,
                int start)
            {
                if (remain == 0)
                {
                    // make a deep copy of the current combination
                    results.Add(new List<int>(comb));
                    return;
                }
                else if (remain < 0)
                {
                    // exceed the scope, stop exploration.
                    return;
                }

                for (int i = start; i < candidates.Length; ++i)
                {
                    // add the number into the combination
                    comb.AddLast(candidates[i]);                    
                    backtrack(remain - candidates[i], comb, i);
                    // backtrack, remove the number from the combination
                    comb.RemoveLast();
                }
            }

            backtrack(target, new LinkedList<int>(), 0);


            return results;
        }

    }
}
