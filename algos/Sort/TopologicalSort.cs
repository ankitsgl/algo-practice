using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Sort
{
    public class TopologicalSort
    {
        private static bool IsCyclic(int[][] dependencies, int[][] vector, Stack<int> stack)
        {

            return false;
        }

        public static bool IsValidDependencies(int[][] dependencies)
        {
            var stack = new Stack<int>();
            var vector = new int[dependencies.Length][];

            return IsCyclic(dependencies, vector, stack);
        }

        
    }

    internal enum Status
    {
        NotVisited, 
        Visited, 
        InProcess
    }
}
