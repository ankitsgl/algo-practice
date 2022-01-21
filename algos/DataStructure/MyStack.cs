namespace algos.DataStructure
{
    using System;
    using System.Collections.Generic;

    public class MyStack<T>
    {
        IList<T> items { get; set; }

        public MyStack()
        {
            items = new List<T>();
        }

        public int Count { 
            get
            {
                return items.Count;
            }
        }
        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (items.Count == 0) throw new InvalidOperationException() ;

            return items[items.Count - 1];
        }
    }
}
