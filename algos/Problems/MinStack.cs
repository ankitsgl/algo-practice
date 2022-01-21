namespace algos.Problems
{
    using algos.DataStructure;
    using System;
    using System.Collections.Generic;

     
    public class MinStack
    {        
        MyStack<int> stack { get; set; }
        MyStack<int> minStack { get; set; }
        
        public MinStack()
        {
            stack = new MyStack<int>();
            minStack = new MyStack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0) minStack.Push(val);
            else minStack.Push(Math.Min(val, minStack.Peek()));
        }

        public void Pop()
        {
            if (stack.Count == 0) throw new Exception("Stack is empty");

            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

     
}
