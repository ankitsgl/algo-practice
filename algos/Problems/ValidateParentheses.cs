using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace algos
{
    public class ValidateParentheses
    {
        public static void Run()
        {
            var data = "ankit { sdf } fdf[ df] dfdfd( dfdf)";

            Console.WriteLine($"Validating: {data}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Result: {Validate(data)}");
        }

        private static bool Validate(string s)
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
    }
}
