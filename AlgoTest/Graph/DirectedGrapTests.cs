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
    public class DirectedGrapTests
    {
        [TestMethod()]
        public void DirectedGraphTest()
        {
            var directedGraph = new DirectedGrap();

            directedGraph.AddVertex(0)
                .AddVertex(1)
                .AddVertex(2)
                .AddVertex(3)
                .AddVertex(4)
                .AddVertex(5)
                .AddVertex(6)

                .AddEdge(3, 1)
                .AddEdge(1, 3)
                .AddEdge(3, 4)
                .AddEdge(4, 2)
                .AddEdge(4, 5)
                .AddEdge(1, 2);

            directedGraph.PrintGraph();
        }


        [TestMethod()]
        public void IsCircular_Cycle_Test()
        {
            var directedGraph = new DirectedGrap();

            directedGraph.AddVertex(0)
                .AddVertex(1)
                .AddVertex(2)
                .AddVertex(3)
                .AddVertex(4)
                .AddVertex(5)
                .AddVertex(6)

                .AddEdge(3, 1)
                .AddEdge(1, 3) // Cycle
                .AddEdge(3, 4)
                .AddEdge(4, 2)
                .AddEdge(4, 5)
                .AddEdge(1, 2);

            var result = directedGraph.IsCircular();

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsCircular_NotCycle_Test()
        {
            var directedGraph = new DirectedGrap();

            directedGraph.AddVertex(0)
                .AddVertex(1)
                .AddVertex(2)
                .AddVertex(3)
                .AddVertex(4)
                .AddVertex(5)
                .AddVertex(6)

                .AddEdge(3, 1)                
                .AddEdge(3, 4)
                .AddEdge(4, 2)
                .AddEdge(4, 5)
                .AddEdge(1, 2);

            var result = directedGraph.IsCircular();

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TopologicalSort_Test()
        {
            var directedGraph = new DirectedGrap();

            directedGraph.AddVertex(0)
                .AddVertex(1)
                .AddVertex(2)
                .AddVertex(3)
                .AddVertex(4)
                .AddVertex(5)
                .AddVertex(6)

                .AddEdge(3, 1)
                .AddEdge(3, 4)
                .AddEdge(4, 2)
                .AddEdge(4, 5)
                .AddEdge(1, 2);

            var result = directedGraph.TopologicalSort();

            Assert.IsNotNull(result);
            ArrayHelper.PrintArray(result);
        }
    }
}