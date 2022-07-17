namespace AlgoTest
{
    using algos.Helpers;
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class QuickPad
    {
        [TestMethod]
        public void PermutationPad()
        {
            var input = (new[] { 1, 2, 3 }).ToList();

            var result = new List<List<int>>();

            var used = new int[input.Count];
            void backtrack(List<int> items)
            {
                ArrayHelper.PrintArray(items, "Per :");
                if (items.Count == input.Count)
                {
                    result.Add(new List<int>(items));
                    return;
                }

                foreach (var i in Enumerable.Range(0, input.Count))
                {
                    if (used[i] != 1)
                    {
                        items.Add(input[i]);
                        used[i] = 1;
                        backtrack(items);
                        used[i] = 0;
                        items.RemoveAt(items.Count - 1);
                    }
                }
            }
            
            backtrack(new List<int>());


            ArrayHelper.PrintArray(result);


        }
    }
}
