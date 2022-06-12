using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Helpers;
public class GraphHelper
{
    public static void PrintGraph<T>(HashSet<T> Nodes, IDictionary<T, HashSet<T>> Edges)
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

    public static void PrintGraph<T>(IList<T> Nodes, IDictionary<T, HashSet<T>> Edges)
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

    public static void PrintGraphWithPattern(IList<string> Nodes, IDictionary<string, HashSet<string>> Edges)         
    {
        foreach (var vertex in Nodes)
        {
            foreach (var chr in vertex)
            {
                var pattern = vertex.Replace(chr, '*');
                Console.Write(pattern + " : --> ");
                if (Edges.ContainsKey(pattern))
                {
                    foreach (var edge in Edges[pattern])
                    {
                        Console.Write($" {edge}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

