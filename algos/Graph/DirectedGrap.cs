using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class DirectedGrap
{
    public HashSet<int> Nodes { get; set; }

    public IDictionary<int, HashSet<int>> Edges { get; set; }


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

    private enum VisitingStatus
    {
        UnVisited,
        Visiting,
        Visited,
    }

    public bool IsCircular()
    {
        PrintGraph();

        var visitingStatus = new Dictionary<int, VisitingStatus>();
        foreach (var node in Nodes)
        {
            visitingStatus.Add(node, VisitingStatus.UnVisited);
        }

        foreach (var node in Nodes)
        {

            if (IsCyclic_Dfs(visitingStatus, node))
                return true;
        }

        return false;
    }
    private bool IsCyclic_Dfs(Dictionary<int, VisitingStatus> visitingStatus, int node)
    {
        visitingStatus[node] = VisitingStatus.Visiting;
        foreach (var edge in Edges[node])
        {

            if (visitingStatus[edge] == VisitingStatus.Visiting)
                return true;

            if (visitingStatus[edge] != VisitingStatus.Visited)
            {

                if (IsCyclic_Dfs(visitingStatus, edge)) return true;
            }
        }

        visitingStatus[node] = VisitingStatus.Visited;
        return false;
    }

    public int[] TopologicalSort()
    {
        var list = new List<int>();

        var visitedStatus = new Dictionary<int, bool>();
        foreach (var node in Nodes)
        {
            visitedStatus.Add(node, false);
        }

        // Find if there is any circular dependency
        if (IsCircular()) return null;

        foreach (var node in Nodes)
        {
            if (!visitedStatus[node])
                TopologicalSort(node, list, visitedStatus);
        }

        return list.ToArray();
    }


    private void TopologicalSort(int node, List<int> list, Dictionary<int, bool> visitingStatus)
    {
        visitingStatus[node] = true;
        foreach (var edge in Edges[node])
        {
            if ( !visitingStatus[edge] )
                TopologicalSort(edge, list, visitingStatus);
        }
        list.Add(node);
    }
}