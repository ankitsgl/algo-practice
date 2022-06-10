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

    public TreeNode left;
    


    public TreeNode right;
    

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
            if (node.right != null)
            {
                Print(node.right, padding + 4);
            }
            if (padding > 0)
            {
                Console.Write(" ".PadLeft(padding));
            }
            if (node.right != null)
            {
                Console.Write("/\n");
                Console.Write(" ".PadLeft(padding));
            }
            Console.Write(node.Value.ToString() + "\n ");
            if (node.left != null)
            {
                Console.Write(" ".PadLeft(padding) + "\\\n");
                Print(node.left, padding + 4);
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
                    if (current.left == null)
                    {
                        current.left = new TreeNode(value);
                        break;
                    }
                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right= new TreeNode(value);
                        break;
                    }
                    current = current.right;
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
                current = current.right;
            else
                current = current.left;
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
            if (current.left != null)
                queue.Enqueue(current.left);

            if ( current.right != null)
                queue.Enqueue(current.right);
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
            if (current.left != null)
                stack.Push(current.left);

            if (current.right != null)
                stack.Push(current.right);
        }
    }

    public void PrintDfs_InOrder()
    {
        InOrderTraverse(Root);
    }

    private void InOrderTraverse(TreeNode node)
    {        
        if ( node.left != null)
            InOrderTraverse(node.left);

        Console.Write(node.Value + ", ");

        if (node.right != null)
            InOrderTraverse(node.right);        
    }

    public void PrintDfs_PreOrder()
    {
        PreOrderTraverse(Root);
    }

    private void PreOrderTraverse(TreeNode node)
    {
        Console.Write(node.Value + ", ");

        if (node.left != null)
            PreOrderTraverse(node.left);        

        if (node.right != null)
            PreOrderTraverse(node.right);
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


    #region Symmetric Tree    
    // Check if left tree is mirror of right side
    public bool IsSymmetric(TreeNode root)
    {
        return IsMirror(root, root);
    }

    public bool IsMirror(TreeNode node1, TreeNode node2)
    {
        if ( node1 == null && node2 == null) return true;

        if (node1 == null || node2 == null) return false;

        return node1.val == node2.val &&
            IsMirror(node1.left, node2.right) &&
            IsMirror(node1.right, node2.left);
    }
    #endregion

    #region Binary Tree Level Order Traversal
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();

        var queue= new Queue<TreeNode>();
                
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            var level = new List<int>();
            var queueLength = queue.Count;

            // Travel current level and add to result
            for (var i = 0; i < queueLength; i++)
            {
                var current = queue.Dequeue();
                if (current != null)
                {
                    level.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }
            if (level.Count > 0)
                result.Add(level); 
        }

        return result;
    }
    #endregion
}
