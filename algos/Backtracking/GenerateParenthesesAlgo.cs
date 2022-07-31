using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking;

public class GenerateParenthesesAlgo
{
    //https://www.youtube.com/watch?v=s9fokUqJ76A
    //https://leetcode.com/problems/generate-parentheses/
    public IList<string> GenerateParenthesis(int n)
    {
        List<String> ans = new();

        void backtrack(List<String> ans, StringBuilder cur, int open, int close, int max)
        {
            Console.WriteLine(cur.ToString()) ;
            if (cur.Length == max * 2)
            {
                ans.Add(cur.ToString());
                return;
            }

            if (open < max)
            {
                cur.Append("(");
                backtrack(ans, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }
            if (close < open)
            {
                cur.Append(")");
                backtrack(ans, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }

        backtrack(ans, new StringBuilder(), 0, 0, n);
        return ans;
    }
}
