using algos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class ReverseSubLinkedList
    {
        public static Node<int> Reverse(Node<int> head)
        {
            var current = head;
            Node<int> previous = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }

        public static Node<int> ReverseSubList(Node<int> head, int start)
        {
            var newHead = head;
            var current = head;
            var index = 0;
            if (start == 1)
            {
                return Reverse(head);
            }
            while (current != null)
            {
                index++;
                if (index<start-1)
                {
                    // Move Next
                    current = current.Next;
                }
                else
                {
                    var curr = current;
                    var revese = Reverse(current.Next);
                    curr.Next = revese;
                    break;
                }
            }
            return newHead;
        }

        public static Node<int> ReverseInMiddleEven(Node<int> head, Node<int> prev = null)
        {
            // Base case
            if (head == null)
                return null;

            Node<int> temp = null;
            var current = head;
            // Reversing nodes until curr node's value
            // turn odd or Linked list is fully traversed
            while (current != null && current.Data % 2 == 0)
            {
                temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }

            // If elements were reversed then head
            // pointer needs to be changed
            if (current != head)
            {
                head.Next = current;
                head.Next = ReverseInMiddleEven(current);
                return prev;
            }
            else // Simply iterate over the odd value nodes
            {
                head.Next = ReverseInMiddleEven(head.Next, head);                
                return head;
            }                 
        }
    }
}
