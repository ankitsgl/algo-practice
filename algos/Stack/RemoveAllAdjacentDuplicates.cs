using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Stack
{
    public class RemoveAllAdjacentDuplicates
    {
        private class Item
        {
            public char Char { get; set; }
            public int Count{ get; set; }

            public Item(char chr, int count = 1)
            {
                Char = chr;
                Count = 1;

            }
        }
        public string Remove(string data, int count)
        {
            var stack = new Stack<Item>();
            foreach (var c in data)
            {
                if (stack.Count > 0 && stack.Peek().Char == c)                
                    stack.Peek().Count++;
                else
                    stack.Push(new Item(c));

                if (stack.Peek().Count == count)
                    stack.Pop();

            }
            var sb = new StringBuilder();
            while (stack.Count > 0)
            {
                var item = stack.Pop();                
                    sb.Insert(0, new string(item.Char, item.Count));
            }

            return sb.ToString();
        }
    }
}
