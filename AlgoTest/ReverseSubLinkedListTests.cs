namespace AlgoTest
{
    using algos.DataStructure;
    using algos.Helpers;
    using algos.Problems;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ReverseSubLinkedListTests
    {
        [TestMethod]
        public void ReverseTest()
        {
            var head = new Node<int>(1,2,3,5,6,7,8);

            LinkedListHelpers.PrintLinedList(head);

            var newHead = ReverseSubLinkedList.Reverse(head);

            LinkedListHelpers.PrintLinedList(newHead);
            
        }

        [TestMethod]
        public void ReverseSubListTests()
        {
            var head = new Node<int>(1, 2, 4, 6, 9, 10, 12);

            LinkedListHelpers.PrintLinedList(head);

            var newHead = ReverseSubLinkedList.ReverseSubList(head, 4);

            LinkedListHelpers.PrintLinedList(newHead);

        }
        [TestMethod]
        public void ReverseSubList2Tests()
        {
            var head = new Node<int>(1, 2, 4, 6, 9, 10, 12);

            LinkedListHelpers.PrintLinedList(head);

            var newHead = ReverseSubLinkedList.ReverseSubList2(head, 4);

            LinkedListHelpers.PrintLinedList(newHead);

        }

        [TestMethod]
        public void ReverseEvenListTests()
        {
            var head = new Node<int>(1, 2, 4, 6, 9, 10, 12);

            LinkedListHelpers.PrintLinedList(head);

            var newHead = ReverseSubLinkedList.ReverseInMiddleEven(head);

            LinkedListHelpers.PrintLinedList(newHead);

        }
    }
}
