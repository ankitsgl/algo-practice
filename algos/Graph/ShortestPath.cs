﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class ShortestPath
{
    // Dijkstras Algo
    //https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/

    int minDistance(int[] dist,
                bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < 9; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }


    public int[] Dijkstra(int[,] graph, int source)
    {
        var nodeCount = graph.GetLength(0);
        // Assumption : Graph is 9 x 9
        var dist = new int[nodeCount];
        var sptSet = new bool[nodeCount];

        foreach (var i in Enumerable.Range(0, dist.Length))
        {
            dist[i] = int.MaxValue;  // Initialzie it with max distance 
            sptSet[i] = false;
        }

        dist[source] = 0;  // Set 0 Distance to self

        for (var count = 0; count < graph.GetLength(0) - 1; count++)
        {
            int u = minDistance(dist, sptSet);
            sptSet[u] = true;

            for (int v = 0; v < nodeCount; v++)

                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller
                // than current value of dist[v]
                if (!sptSet[v] 
                    && graph[u, v] != 0 
                    && dist[u] != int.MaxValue 
                    && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];

        }

        return dist;
    }


    // Worht to Read: https://betterprogramming.pub/5-ways-to-find-the-shortest-path-in-a-graph-88cfefd0030f

    public int[] DijkstraMy(int[,] graph, int source)
    {
        // Assumption source is zero
        var nodeCount = graph.GetLength(0);
        var distSource = new int[nodeCount];
        var consumSet = new bool[nodeCount];
        foreach (var i in Enumerable.Range(0, nodeCount))
        {
            distSource[i] = int.MaxValue;  // Initialzie it with max distance 
            consumSet[i] = false;
        }

        distSource[source] = 0;

        int minDistanceNode()
        {
            var min = int.MaxValue;
            var minIndex = -1;
            for (var i = 0; i < distSource.Length; i++)
            {
                if (consumSet[i] == false && distSource[i] <= min)
                {
                    min = distSource[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        for (var index = 0; index < nodeCount - 1; index++)
        {
            var minDistIndex = minDistanceNode();
            consumSet[minDistIndex] = true;

            // Iterate through each distance in row and find min dis and set it.
            for(var col = 0; col < nodeCount; col++)
            {
                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller

                // than current value of dist[v]
                if (consumSet[col]) continue;
                if (graph[minDistIndex, col]==0) continue;
                if (distSource[minDistIndex] == int.MaxValue) continue;
                if (distSource[minDistIndex] + graph[minDistIndex, col] < distSource[col]) 
                    distSource[col] = distSource[minDistIndex] + graph[minDistIndex, col];
            }
        }
        return distSource;
    }

    // using BFS with adj metrix
    public static int[] Dijkstra(int V, List<List<AdjListNode>> graph, int src)
    {
        // Graph Sample
        //graph[0].Add(new AdjListNode(1, 4));
        //graph[0].Add(new AdjListNode(7, 8));
        //graph[1].Add(new AdjListNode(2, 8));
        //graph[1].Add(new AdjListNode(7, 11));
        //graph[1].Add(new AdjListNode(0, 7));
        //graph[2].Add(new AdjListNode(1, 8));
        //graph[2].Add(new AdjListNode(3, 7));
        //graph[2].Add(new AdjListNode(8, 2));
        //graph[2].Add(new AdjListNode(5, 4));
        //graph[3].Add(new AdjListNode(2, 7));
        //graph[3].Add(new AdjListNode(4, 9));
        //graph[3].Add(new AdjListNode(5, 14));
        //graph[4].Add(new AdjListNode(3, 9));
        //graph[4].Add(new AdjListNode(5, 10));
        //graph[5].Add(new AdjListNode(4, 10));
        //graph[5].Add(new AdjListNode(6, 2));
        //graph[6].Add(new AdjListNode(5, 2));
        //graph[6].Add(new AdjListNode(7, 1));
        //graph[6].Add(new AdjListNode(8, 6));
        //graph[7].Add(new AdjListNode(0, 8));
        //graph[7].Add(new AdjListNode(1, 11));
        //graph[7].Add(new AdjListNode(6, 1));
        //graph[7].Add(new AdjListNode(8, 7));
        //graph[8].Add(new AdjListNode(2, 2));
        //graph[8].Add(new AdjListNode(6, 6));
        //graph[8].Add(new AdjListNode(7, 1));

        int[] distance = new int[V];
        for (int i = 0; i < V; i++)
            distance[i] = Int32.MaxValue;
        distance[src] = 0;

        SortedSet<AdjListNode> pq  = new SortedSet<AdjListNode>();
        pq.Add(new AdjListNode(src, 0));

        while (pq.Count > 0)
        {
            AdjListNode current = pq.First();
            pq.Remove(current);

            foreach (var n in graph[current.getVertex()])
            {
                if (distance[current.getVertex()] + n.getWeight() < distance[n.getVertex()])
                {
                    distance[n.getVertex()] = n.getWeight() + distance[current.getVertex()];
                    pq.Add(new AdjListNode(n.getVertex(), distance[n.getVertex()]));
                }
            }
        }
        // If you want to calculate distance from source to
        // a particular target, you can return
        // distance[target]
        return distance;
    }
}


public class AdjListNode : IComparable<AdjListNode>
{
    private int vertex, weight;
    public AdjListNode(int v, int w)
    {
        vertex = v;
        weight = w;
    }
    public int getVertex() { return vertex; }
    public int getWeight() { return weight; }
    public int CompareTo(AdjListNode other)
    {
        return weight - other.weight;
    }
}