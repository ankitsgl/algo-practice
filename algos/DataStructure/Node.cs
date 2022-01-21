using System;
using System.Collections.Generic;
using System.Text;

namespace algos.DataStructure
{
    public class Node
    {
        public int Data { get; set; }

        public IList<Node> Childs { get; set; }
    }
}
