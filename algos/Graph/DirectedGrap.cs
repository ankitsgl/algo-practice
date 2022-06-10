using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class DirectedGrap
{
    public HashSet<int> Nodes { get; set; }

    public IDictionary<int, HashSet<int>> Edges { get; set;}


    public DirectedGrap()
    {
        Nodes = new HashSet<int>();

        Edges = new Dictionary<int, HashSet<int>>();
    }

    public DirectedGrap AddVertex(int vertex)
    {
        if (!Nodes.Contains(vertex))
        {
            Nodes.Add(vertex);
            Edges.Add(vertex, new HashSet<int>());
        }

        return this;
    }

    public DirectedGrap AddEdge(int start, int end)
    {
        if (!Edges[start].Contains(end))
        {
            Edges[start].Add(end);
        }

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