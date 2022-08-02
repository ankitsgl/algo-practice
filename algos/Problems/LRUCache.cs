using System;

namespace algos.Problems;

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
//https://leetcode.com/problems/lru-cache/
public class LRUCache
{
    private int Capacity { get; set; }
    private int Count { get; set; }

    private DLinkedList<int, int> accessOrder;
    private Dictionary<int, DLinkedListNode<int, int>> Cache;

    

    public LRUCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity can't be negative.");
        Capacity = capacity;
        accessOrder = new DLinkedList<int, int>();
        Cache = new Dictionary<int, DLinkedListNode<int, int>>();
    }

    public int Get(int key)
    {
        if (Cache.ContainsKey(key))
        {
            var data = Cache[key];
            accessOrder.MoveToHead(data);            
            return data.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (!Cache.ContainsKey(key))
        {
            var node = new DLinkedListNode<int, int>(key, value);
            Cache[key] = node;
            accessOrder.AddFirst(node);
            Count++;
            if (Count > Capacity)
            {
                var deletedNode = accessOrder.RemoveLast();
                Cache.Remove(deletedNode.Key);
                Count--;
            }
        }
        else
        {
            Cache[key].Value = value;
            accessOrder.MoveToHead(Cache[key]);
        }        
    }
}

#region DLinkedList
public class DLinkedListNode<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }

    public DLinkedListNode()
    {
    }
    public DLinkedListNode(K key, V val)
    {
        Key = key;
        Value = val;
    }
    public DLinkedListNode<K, V> Prev { get; set; }
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
    public DLinkedListNode<K, V> AddFirst(DLinkedListNode<K, V> node)
    {
        var first = Head.Next;
        node.Next = first;
        first.Prev = node;
        node.Prev = Head;
        Head.Next = node;
        return node;
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
        var first = Head.Next;
        Head.Next = first.Next;
        first.Next.Prev = Head;
    }


    public void RemoveNode(DLinkedListNode<K, V> node)
    {
        var prev = node.Prev;
        var next = node.Next;
        prev.Next = next;
        next.Prev = prev;
    }
    public void MoveToHead(DLinkedListNode<K, V> node)
    {
        RemoveNode(node);
        AddFirst(node);
    }

    public DLinkedListNode<K, V> RemoveLast()
    {
        DLinkedListNode<K, V> deleted = null;
        if (Tail.Prev != Head)
        {
            deleted = Tail.Prev;
            RemoveNode(Tail.Prev);
        }
        return deleted;
    }
}

#endregion

