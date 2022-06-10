﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            tree.Insert(20)
            .Insert(30).Insert(10).Insert(50)
            .Insert(700).Insert(15).Insert(25)
            .Insert(85);

            tree.Print();
            var result = tree.Lookup(85);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Value, 85);
        }

        [TestMethod()]
        public void PrintBreathFirstSearchTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4).Insert(20).Insert(1)
            .Insert(6).Insert(15).Insert(170);

            tree.Print();
            Console.WriteLine("-----------------------------------------");
            tree.PrintBfs_UsingQueue();
        }

        [TestMethod()]
        public void Prin_UsingStackTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4).Insert(20).Insert(1)
            .Insert(6).Insert(15).Insert(170);

            tree.Print();
            Console.WriteLine("-----------------------------------------");
            tree.Print_UsingStack();
        }

        [TestMethod()]
        public void PrintDfs_InOrderTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4).Insert(20).Insert(1)
            .Insert(6).Insert(15).Insert(170);

            tree.Print();
            Console.WriteLine("-----------------------------------------");
            tree.PrintDfs_InOrder();
        }
        [TestMethod()]
        public void PrintDfs_PreOrderTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4).Insert(20).Insert(1)
            .Insert(6).Insert(15).Insert(170);

            tree.Print();
            Console.WriteLine("-----------------------------------------");
            tree.PrintDfs_PreOrder();
        }
        [TestMethod()]
        public void PrintDfs_PostOrderTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4).Insert(20).Insert(1)
            .Insert(6).Insert(15).Insert(170);

            tree.Print();
            Console.WriteLine("-----------------------------------------");
            tree.PrintDfs_PostOrder();
        }

        [TestMethod()]
        public void IsValidBSTTest()
        {
            var tree = new BinarySearchTreePractice();
            tree.Insert(2147483647);
            var result = tree.IsValidBST();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsValidBSTTest2()
        {
            var tree = new BinarySearchTreePractice();

            tree.Root = new TreeNode(5)
            {
                Left = new TreeNode(1),
                Right = new TreeNode(7)
                {
                    Left = new TreeNode(3),
                    Right = new TreeNode(9)
                }
            };
            

            var result = tree.IsValidBST();
            Assert.IsFalse(result);
        }
    }
}