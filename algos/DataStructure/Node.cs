namespace algos.DataStructure
{
    using System.Collections.Generic;

    public class Node
    {
        public int Data { get; set; }

        public IList<Node> Childs { get; set; }
    }
}
