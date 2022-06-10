using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Trees;

public class TreeNode
{
    public int Value;
    public int val{ get { return Value; } }

    public TreeNode Left;
    public TreeNode left { get { return Left; } }


    public TreeNode Right;
    public TreeNode right { get { return Right; } }

    public TreeNode(int value)
    {
        this.Value = value;        
    }
}

public class BinarySearchTreePractice
{
    public TreeNode Root = null;

    public void Print()
    {
        Print(Root, 4);
    }

    private void Print(TreeNode node, int padding)
    {
        if (node != null)
        {
            if (node.Right != null)
            {
                Print(node.Right, padding + 4);
            }
            if (padding > 0)
            {
                Console.Write(" ".PadLeft(padding));
            }
            if (node.Right != null)
            {
                Console.Write("/\n");
                Console.Write(" ".PadLeft(padding));
            }
            Console.Write(node.Value.ToString() + "\n ");
            if (node.Left != null)
            {
                Console.Write(" ".PadLeft(padding) + "\\\n");
                Print(node.Left, padding + 4);
            }
        }
    }

    public BinarySearchTreePractice Insert(int value)
    {
        if (Root == null) Root = new TreeNode(value);
        else
        {
            // Insert at related location;
            var parent = Root;
            TreeNode current = parent;

            while (true)
            {
                parent = current;
                if (current.Value > value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode(value);
                        break;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right= new TreeNode(value);
                        break;
                    }
                    current = current.Right;
                }                
            }
        }

        return this;
    }

    public TreeNode Lookup(int value)
    {
        var current = Root;

        while (current != null)
        {   
            if (current.Value == value)
                return current;
            else if (value > current.Value)
                current = current.Right;
            else
                current = current.Left;
        }

        return null;
    }


    public void PrintBfs_UsingQueue()
    {
        var queue = new Queue<TreeNode>();

        var current = Root;

        queue.Enqueue(current);
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            
            Console.Write(current.Value + ", ");
            if (current.Left != null)
                queue.Enqueue(current.Left);

            if ( current.Right != null)
                queue.Enqueue(current.Right);
        }
    }
    public void Print_UsingStack()
    {
        var stack = new Stack<TreeNode>();

        var current = Root;

        stack.Push(current);
        while (stack.Count > 0)
        {
            current = stack.Pop();

            Console.Write(current.Value + ", ");
            if (current.Left != null)
                stack.Push(current.Left);

            if (current.Right != null)
                stack.Push(current.Right);
        }
    }

    public void PrintDfs_InOrder()
    {
        InOrderTraverse(Root);
    }

    private void InOrderTraverse(TreeNode node)
    {        
        if ( node.Left != null)
            InOrderTraverse(node.Left);

        Console.Write(node.Value + ", ");

        if (node.Right != null)
            InOrderTraverse(node.Right);        
    }

    public void PrintDfs_PreOrder()
    {
        PreOrderTraverse(Root);
    }

    private void PreOrderTraverse(TreeNode node)
    {
        Console.Write(node.Value + ", ");

        if (node.Left != null)
            PreOrderTraverse(node.Left);        

        if (node.Right != null)
            PreOrderTraverse(node.Right);
    }

    public void PrintDfs_PostOrder()
    {
        PostOrderTraverse(Root);
    }

    private void PostOrderTraverse(TreeNode node)
    {
        if (node.left != null)
            PostOrderTraverse(node.left);        

        if (node.right != null)
            PostOrderTraverse(node.right);

        Console.Write(node.Value + ", ");
    }

    public bool IsValidBST()
    {
        return ValidateBst(Root);
    }

    public bool ValidateBst(TreeNode root)
    {
        return ValidateBst(root, null, null);
        // Solve using Left and Right boundary 
    }
    private bool ValidateBst(TreeNode node, TreeNode left, TreeNode right)
    {
        if (node == null)  return true;

        if (left!= null && left.val >= node.val) 
            return false;
        if (right != null && right.val <= node.val)
            return false;

        return ValidateBst(node.left, left, node)
            && ValidateBst(node.right, node, right);
    }

    

}
