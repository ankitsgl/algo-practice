using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Problems
{
    public static class MyStackPractice 
    {
        public static void Run()
        {
            Console.WriteLine("MyStack Stack Problem");
            var minStack = new MinStack();

            minStack.Push(0);
            minStack.Push(-2);            
            minStack.Push(-3);
            
            
            minStack.Pop();
            minStack.Pop();
            var m2 = minStack.GetMin();
        }
    }
    public class MinStack
    {        
        IList<int> stack { get; set; }
        Stack<int> minStack { get; set; }
        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new List<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            
            stack.Add(val);
            if (minStack.Count == 0) minStack.Push(val);
            else minStack.Push(Math.Min(val, minStack.Peek()));
        }

        public void Pop()
        {
            if (stack.Count == 0) throw new Exception("Stack is empty");

            stack.RemoveAt(stack.Count - 1);
            minStack.Pop();
        }

        public int Top()
        {
            if (stack.Count == 0) throw new Exception("Stack is empty");

            return stack[stack.Count - 1];
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

     
}
