using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.LinkedLists
{
    public class ListNode
    {
        public int val;      
        public ListNode next;
      
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
  }

    public class LinkedListProblems
    {
        #region Add to Numbers from Linked List
        public ListNode AddTwoNumbers_bf(ListNode l1, ListNode l2)
        {
            var carry = 0;

            ListNode result = new ListNode();
            ListNode current = result;

            while (l1 != null || l2 != null)
            {
                var sum = 0;
                if (l1 != null) {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                var val = (sum + carry) % 10;
                carry = (sum + carry) / 10;

                current.next = new ListNode(val);
                current = current.next;
            }
            if (carry > 0)
                current.next = new ListNode(carry);

            return result.next;
        }
        #endregion

        #region Merge to sorted Linked List
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var result = new ListNode();
            var current = result;
            while (list1 != null && list2 != null)
            {

                if (list1.val > list2.val)
                {
                    current.next = new ListNode(list2.val);
                    list2 = list2.next;
                }
                else
                {
                    current.next = new ListNode(list1.val);
                    list1 = list1.next;
                }

                current = current.next;
            }
            if (list1 != null) current.next = list1;
            if (list2 != null) current.next = list2;

            return result.next;
        }

        #endregion

        #region Reverse Linked List

        public ListNode ReverseLinkedList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;

            }
            return prev;
        }

        #endregion

        #region Reverse Nodes in k-Group

        public ListNode ReverseLinkedListUltilK(ListNode head, int k)
        {
            var dummy = new ListNode(next: head);
            ListNode prev = dummy;
            ListNode current = head;
            ListNode next = null;
            while (current != null && k > 0)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                k--;
            }
            dummy.next.next = current;
            head = prev;
            return head;
        }
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1) return head;
            ListNode dummy = new ListNode(next: head);

            ListNode groupPrev = dummy;
            ListNode prev = dummy;

            var count = 1;
            ListNode tail = null;
            while (head != null)
            {
                if ((count % k) == 1)
                {
                    groupPrev = prev;
                    tail = head;
                }
                prev = head;
                head = head.next;
                if ((count % k) == 0)
                {
                    prev = tail;
                    groupPrev.next = ReverseLinkedListUltilK(tail, k);
                    count = 0;
                }
                count++;

            }
            return dummy.next;
        }
        #endregion

        #region Merge k Sorted Lists
        

        public ListNode MergeKLists_Bf(ListNode[] lists)
        {
            /*
             * Merge two lists at a time since they are sorted.
             * */

            if (lists == null  || lists.Length == 0) return null;


            ListNode mergedList = lists[0];

            for (var i = 1; i < lists.Length; i++)
            {
                var list1 = mergedList;
                var list2 = lists[i];
                
                var twoMergedList = new ListNode();
                var current = twoMergedList;
                while (list1 != null && list2 != null)
                {

                    if (list1.val > list2.val)
                    {
                        current.next = new ListNode(list2.val);
                        list2 = list2.next;
                    }
                    else
                    {
                        current.next = new ListNode(list1.val);
                        list1 = list1.next;
                    }

                    current = current.next;
                }
                if (list1 != null) current.next = list1;
                if (list2 != null) current.next = list2;

                mergedList = twoMergedList.next;

            }

            return mergedList;

        }

        public ListNode MergeKLists_Op(ListNode[] lists)
        {
            /*
             * Find min of each head
             * Add min to new list
             * Move min index to next
             * */

            var dummy = new ListNode();
            var prev = dummy;

            while (true)
            {
                ListNode node = null;
                var minIndex = -1;
                for (var i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null) continue;

                    if (lists[i].val < (node?.val ?? int.MaxValue))
                    {
                        node = lists[i];
                        minIndex = i;
                    }
                }
                if (node == null) break;
                lists[minIndex] = lists[minIndex].next;
                prev.next = node;
                prev = node;
            }

            return dummy.next;
        }
        #endregion

        #region Find Circular List
        public bool IsCurcularLinkedList(ListNode head)
        {
            // Maintian slow and fast pointers
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow) return true;
            }
            return false;

        }
        #endregion
    }
}
