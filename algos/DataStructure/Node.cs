namespace algos.DataStructure
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node()
        {

        }

        public Node(params T[] data)
        {
            var current = this;
            var previous = current;
            foreach (T item in data)
            {
                current.Data = item;
                previous = current;
                current.Next = new Node<T>();
                
                current = current.Next;
            }
            previous.Next = null;
        }
    }
}
