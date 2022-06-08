using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Trees.Tests
{
    [TestClass()]
    public class BinarySearchTreePracticeTests
    {
        [TestMethod()]
        public void PrintTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(10);
            tree.Insert(50);
            tree.Insert(700);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(85);

            tree.Print();
        }
        [TestMethod()]
        public void Print_UnbalancedTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(80);
            tree.Insert(90);

            tree.Print();
        }

        [TestMethod()]
        public void LookupTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(10);
            tree.Insert(50);
            tree.Insert(700);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(85);

            tree.Print();
            var result = tree.Lookup(85);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 85);
        }

    }
}