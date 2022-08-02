using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.DataStructure;

public class DLinkedListNode<K, V>
{
    public K Key{ get; set; }
    public V Value { get; set; }

    public DLinkedListNode()
    {   
    }
    public DLinkedListNode(K key, V val)
    {
        Key = key;
        Value = val;
    }
    public DLinkedListNode<K,V> Prev { get; set; }
    public DLinkedListNode<K, V> Next { get; set; }
}

public class DLinkedList<K, V>
{
    private DLinkedListNode<K, V> Head { get; set; }
    private DLinkedListNode<K, V> Tail { get; set; }

    public DLinkedList()        
    {
        Head = new DLinkedListNode<K, V>();
        Tail = new DLinkedListNode<K, V>();
        Head.Next = Tail;
        Tail.Prev = Head;
    }
    public DLinkedListNode<K, V> AddFirst(K key, V val)
    {
        var node = new DLinkedListNode<K, V>(key, val);
        return AddFirst(node);
    }
    public DLinkedListNode<K, V> AddFirst(DLinkedListNode<K, V> node)
    {
        var first = Head.Next;
        node.Next = first;
        first.Prev = node;
        node.Prev = Head;
        Head.Next = node;
        return node;
    }
    
    public DLinkedListNode<K, V> AddLast(K key, V val)
    {
        var node = new DLinkedListNode<K, V>(key, val);
        return AddLast(node);
    }

    public DLinkedListNode<K, V> AddLast(DLinkedListNode<K, V> node)
    {
        var last = Tail.Prev;
        last.Next = node;
        node.Prev = last;
        node.Next = Tail;
        Tail.Prev = node;

        return node;
    }

    public void RemoveFirst()
    {
        Head.Next = Head.Next.Next;
        Head.Next.Prev = Head;
    }


    public void RemoveNode(DLinkedListNode<K, V> node)
    {
        var prev = node.Prev;
        var next = node.Next;
        prev.Next = next;
        next.Prev = prev;
    }
    public void MoveToHear(DLinkedListNode<K, V> node)
    {
        RemoveNode(node);
        AddFirst(node);
    }

    public void RemoveLast()
    {
        if ( Tail.Prev != Head)
            RemoveNode(Tail.Prev);
    }
}


