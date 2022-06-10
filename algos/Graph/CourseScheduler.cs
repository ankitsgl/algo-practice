using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph
{
    public class CourseScheduler
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Create Graph
            var nodes = new int[numCourses];
            var edges = new Dictionary<int, HashSet<int>>();

            var visitingStatus = new Dictionary<int, int>();

            // 0 = Not Visited
            // 1 = Visited
            // 2 = Visiting
            for (var i = 0; i < numCourses; i++)
            {
                nodes[i] = i;
                visitingStatus.Add(i, 0);
                edges.Add(i, new HashSet<int>());
            }


            foreach (var prerequisit in prerequisites)
            {
                edges[prerequisit[0]].Add(prerequisit[1]);
            }

            foreach (var node in nodes)
            {
                if (!CanFinish(node, edges, visitingStatus))
                    return false;
            }
            return true;
        }

        private bool CanFinish(int numCourses, Dictionary<int, HashSet<int>> edges,
            Dictionary<int, int> visitingStatus)
        {
            visitingStatus[numCourses] = 2;
            foreach (var edge in edges[numCourses])
            {
                if (visitingStatus[edge] == 2)
                    return false;

                if (visitingStatus[edge] != 1)
                {
                    if (!CanFinish(edge, edges, visitingStatus))
                        return false;
                }
            }

            visitingStatus[numCourses] = 1;
            return true;
        }
    }
}
