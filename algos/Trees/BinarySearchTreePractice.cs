using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Trees;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        this.Value = value;        
    }
}

public class BinarySearchTreePractice
{
    private TreeNode Root = null;

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

    public void Insert(int value)
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
}
