using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.LinkedLists.Tests
{
    [TestClass()]
    public class LinkedListProblemsTests
    {
        LinkedListProblems sol = new LinkedListProblems();

        [TestMethod()]
        public void AddTwoNumbersTest_bf()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 9, 9, 9, 9, 9, 9, 9 });

            var list2 = LinkedListHelpers.ArrayToListNode(new int[] { 9, 9, 9, 9 });

            var result = sol.AddTwoNumbers_bf(list1, list2);
            Assert.IsNotNull(result);

            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 });

            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void AddTwoNumbersTest2_bf()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 2, 4, 9 });

            var list2 = LinkedListHelpers.ArrayToListNode(new int[] { 5, 6, 4, 9 });

            var result = sol.AddTwoNumbers_bf(list1, list2);
            Assert.IsNotNull(result);

            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 7, 0, 4, 0, 1 });

            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void MergeTwoSortedLinkedListTest()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 2, 4 });

            var list2 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 3, 4 });

            var result = sol.MergeTwoLists(list1, list2);
            Assert.IsNotNull(result);

            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 1, 1, 2, 3, 4, 4 });

            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }


        [TestMethod()]
        public void ReverseLinkedListTest()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 2, 3, 4, 5 });
            LinkedListHelpers.PrintLinkedList("Input   ", list1);

            var result = sol.ReverseLinkedList(list1);

            Assert.IsNotNull(result);
            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 5, 4, 3, 2, 1 });
            LinkedListHelpers.PrintLinkedList("Expected", expectedList);

            LinkedListHelpers.PrintLinkedList("Actual  ", result);
            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void ReverseLinkedListUntilKTest()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 2, 3, 4, 5 });
            LinkedListHelpers.PrintLinkedList("Input   ", list1);

            var result = sol.ReverseLinkedListUltilK(list1, 3);

            Assert.IsNotNull(result);
            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 3, 2, 1, 4, 5 });
            LinkedListHelpers.PrintLinkedList("Expected", expectedList);

            LinkedListHelpers.PrintLinkedList("Actual  ", result);
            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void ReverseKGroupTest()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 2, 3, 4, 5 });
            LinkedListHelpers.PrintLinkedList("Input   ", list1);

            var result = sol.ReverseKGroup(list1, 2);

            Assert.IsNotNull(result);
            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 2, 1, 4, 3, 5 });
            LinkedListHelpers.PrintLinkedList("Expected", expectedList);

            LinkedListHelpers.PrintLinkedList("Actual  ", result);
            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void MergeKListsTest_Bf()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 4, 5 });
            var list2 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 3, 4 });
            var list3 = LinkedListHelpers.ArrayToListNode(new int[] { 2, 6 });


            var result = sol.MergeKLists_Bf(new[] { list1, list2, list3 });

            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });

            LinkedListHelpers.PrintLinkedList("Expected", expectedList);

            LinkedListHelpers.PrintLinkedList("Actual  ", result);
            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }

        [TestMethod()]
        public void MergeKListsTest_Op()
        {
            var list1 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 4, 5 });
            var list2 = LinkedListHelpers.ArrayToListNode(new int[] { 1, 3, 4 });
            var list3 = LinkedListHelpers.ArrayToListNode(new int[] { 2, 6 });


            var result = sol.MergeKLists_Op(new[] { list1, list2, list3 });

            var expectedList = LinkedListHelpers.ArrayToListNode(new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });

            LinkedListHelpers.PrintLinkedList("Expected", expectedList);

            LinkedListHelpers.PrintLinkedList("Actual  ", result);
            while (expectedList != null)
            {
                Assert.AreEqual(expectedList.val, result.val);
                expectedList = expectedList.next;
                result = result.next;
            }
        }
        

        [TestMethod()]
        public void IsCurcularLinkedListTest()
        {
            var list = LinkedListHelpers.ArrayToListNode(new int[] { 1, 4, 5 });
            var result = sol.IsCurcularLinkedList(list);
            Assert.IsFalse(result);

            // Make is circular
            list.next.next.next = list.next;
            result = sol.IsCurcularLinkedList(list);
            Assert.IsTrue(result);
        }
    }
}