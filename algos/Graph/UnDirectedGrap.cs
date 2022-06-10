using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class UnDirectedGrap
{
    public HashSet<int> Nodes { get; set; }

    public IDictionary<int, HashSet<int>> Edges { get; set;}


    public UnDirectedGrap()
    {
        Nodes = new HashSet<int>();

        Edges = new Dictionary<int, HashSet<int>>();
    }

    public UnDirectedGrap AddVertex(int vertex)
    {
        if (!Nodes.Contains(vertex))
        {
            Nodes.Add(vertex);
            Edges.Add(vertex, new HashSet<int>());
        }

        return this;
    }

    public UnDirectedGrap AddEdge(int node1, int node2)
    {
        if (!Edges[node1].Contains(node2))        
            Edges[node1].Add(node2);
        

        if (!Edges[node2].Contains(node1))        
            Edges[node2].Add(node1);
        

        return this;
    }

    public void PrintGraph()
    {
        foreach (var vertex in Nodes)
        {
            Console.Write(vertex + " : --> ");
            if (Edges.ContainsKey(vertex))
            {
                foreach (var edge in Edges[vertex])
                {
                    Console.Write($" {edge}");
                }
            }
            Console.WriteLine();
        }
    }

}