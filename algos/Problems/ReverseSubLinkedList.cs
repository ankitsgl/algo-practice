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

        public static Node<int> ReverseInMiddleEven(Node<int> head)
        {
            var newHead = head;
            var current = head;
            
            while (current != null)
            {
                if (current.Data % 2 !=0 )
                {
                    // Move Next
                    current = current.Next;
                }
                else 
                {
                    var next = current.Next;
                    var start = current;

                    while (true)
                    {
                        if (current.Next.Data % 2 == 0)
                        {
                            next = next.Next;
                            current.Next = current;

                            //Reverse
                        }
                        else
                        {
                            break;
                        }
                    }
                    var end = current;
                    
                    
                }
                
                       
            }
            return null;
        }
    }
}
