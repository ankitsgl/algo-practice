using algos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Helpers
{
    public static class LinkedListHelpers
    {
        public static void PrintLinedList<T>(Node<T> head)
        {
            var current = head;
            while (current != null)
            {
                Console.Write($"{current.Data.ToString()} -> ");
                current = current.Next;
            }
            Console.WriteLine(); 
        }
    }
}
