using algos.DataStructure;
using algos.LinkedLists;
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
        public static void PrintLinkedList(string prefix, ListNode head)
        {
            var current = head;
            Console.Write(prefix + " : ");
            while (current != null)
            {
                Console.Write($"{current.val } -> ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static ListNode ArrayToListNode(int[] array)
        {
            ListNode prev = null;
            ListNode head = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                head = new ListNode();
                head.val = array[i];
                head.next = prev;
                prev = head;
            }
            return head;
        }
    }
}
