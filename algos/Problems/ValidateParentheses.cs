global using System.Collections.Generic;
using System;

namespace algos.Problems;

public class ValidateParentheses
{

    public static bool Validate(string s)
    {
        
        if (string.IsNullOrEmpty(s)) // Save from Null Reference Exeption
        {
            return true;
        }

        var stack = new Stack<char>();

        foreach (var c in s.ToCharArray())
        {
            if (c == '}' || c == ']' || c == ')')
            {
                if (stack.Count == 0)
                    return false;

                var bracket = stack.Pop();

                // USING XOR operator 
                if (bracket == '(' ^ c == ')' ||
                    bracket == '[' ^ c == ']' ||
                    bracket == '{' ^ c == '}')
                {
                    return false;
                }
            }
            else if (c == '{' || c == '[' || c == '(')
            {
                stack.Push(c);
            }

        }

        return stack.Count == 0;
    }

    public int LongestValidParentheses(string s)
    {
        var longestCount = 0;

        var stack = new Stack<int>();
        stack.Push(-1);
        for(var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else if (s[i] == ')')
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    var currentLen = i - stack.Peek();
                    longestCount = Math.Max(currentLen, longestCount);
                }
            }

        }        

        return longestCount;
    }
}
