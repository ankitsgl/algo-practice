using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

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

        [TestMethod]
        public void PrintTreeAllMethods()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4)
            .Insert(2).Insert(15).Insert(14).Insert(170);

            tree.Print();

            Console.WriteLine();
            Console.Write("BFS : ");
            tree.PrintBfs_UsingQueue();
            Console.WriteLine();
            Console.Write("DFS PreOrder : ");
            tree.PrintDfs_PreOrder();

            Console.WriteLine();
            Console.Write("DFS InOrder : ");
            tree.PrintDfs_InOrder();
            
            Console.WriteLine();
            Console.Write("DFS PostOrder : ");
            tree.PrintDfs_PostOrder();
        }

        [TestMethod]
        public void SerializeTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4)
            .Insert(2).Insert(15).Insert(14).Insert(170);
            tree.Print();
            Console.WriteLine();
            var result = tree.Serialize();
            Console.WriteLine($"Result : {result}");
        }

        [TestMethod]
        public void DrSerializeTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Insert(9)
            .Insert(4)
            .Insert(2).Insert(15).Insert(14).Insert(170);
            tree.Print();

            Console.WriteLine();
            var input = tree.Serialize();
            Console.WriteLine($"Input : {input}");


            var result = tree.DeSerialize(input);
            tree.Root = result;
            tree.Print();
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
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsValidBSTTest2()
        {
            var tree = new BinarySearchTreePractice();

            tree.Root = new TreeNode(5)
            {
                left = new TreeNode(1),
                right = new TreeNode(7)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(9)
                }
            };


            var result = tree.IsValidBST();
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsSymmetricTest()
        {
            var tree = new BinarySearchTreePractice();

            tree.Root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }

            };

            tree.PrintDfs_InOrder();
            Console.WriteLine();

            var result = tree.IsSymmetric(tree.Root);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void LevelOrderTest()
        {
            var tree = new BinarySearchTreePractice();


            tree.Root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }

            };

            var result = tree.LevelOrder(tree.Root);

            Assert.IsNotNull(result);
            foreach (var item in result)
            {
                Console.Write("[");

                item.ToList().ForEach(x => Console.Write(x + ", "));

                Console.Write("],");
            }
        }

        [TestMethod()]
        public void MaxPathSumTest()
        {
            var tree = new BinarySearchTreePractice();


            tree.Root = new TreeNode(-10)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }

            };

            var result = tree.MaxPathSum(tree.Root);

            Assert.AreEqual(42, result);
             
        }

        [TestMethod()]
        public void PrintLeftViewTest()
        {
            var tree = new BinarySearchTreePractice();
            tree.Root = new TreeNode(5)
            {
                left = new TreeNode(2),
                right = new TreeNode(4)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(9)
                    {
                        left = new TreeNode(8)
                    }
                }

            };
            tree.Print();

            var result = tree.PrintLeftView(tree.Root);


            ArrayHelper.PrintArray(result);
        }

        [TestMethod()]
        public void PrintRightViewTest()
        {
            var tree = new BinarySearchTreePractice();
            tree.Root = new TreeNode(5)
            {
                left = new TreeNode(2),
                right = new TreeNode(4)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(9)
                    {
                        left = new TreeNode(8)
                    }
                }

            };
            tree.Print();

            var result = tree.PrintRightView(tree.Root);


            ArrayHelper.PrintArray(result);

            
        }
    }
}