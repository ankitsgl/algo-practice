using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using algos.Helpers;

namespace algos.Graph.Tests
{
    [TestClass()]
    public class ShortestPathTests
    {
        [TestMethod()]
        public void DijkstraTest()
        {
            // Graph : https://www.geeksforgeeks.org/wp-content/uploads/Fig-11.jpg
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 }, // Distance from 0 node
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 }, // Distance from 1 node
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            var sol = new ShortestPath();
            var result = sol.Dijkstra(graph, 0);
            ArrayHelper.PrintArrayMatrix(result, "Vertex  : Distance from Source");
        }

        [TestMethod()]
        public void DijkstraMyTest()
        {
            // Graph : https://www.geeksforgeeks.org/wp-content/uploads/Fig-11.jpg
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 }, // Distance from 0 node
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 }, // Distance from 1 node
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            var sol = new ShortestPath();
            var result = sol.DijkstraMy(graph, 0);
            ArrayHelper.PrintArrayMatrix(result, "Vertex  : Distance from Source");
        }
    }
}