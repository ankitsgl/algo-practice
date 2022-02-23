using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    // We have many tasks need to be executed, we need to write a scheduler to schedule the tasks to run. 
    // But some tasks have dependencies. For example, given a task list below:(1, 2, 3, 4) and all the dependencies among the tasks: (1→ 2), (2→3), (3→ 4)
    // Given a scheduling order and all dependencies, verify if the scheduling order is valid: output will be a boolean. 

    // Task 
    // Depended Task

    //(1→ 2), (2→3), (3→ 4)
    //1,2
    //2,3
    //3,4
    //1,3


    // head = 1
    // dep1 = 1-> 2 
    // dep2 = 2-> 3 
    //  (1→ 2), (3→ 4) , (1,3)

    public class TaskScheduler
    {
        public static bool IsValidOrder(int[] order, int[][] dependencies)
        {
            if (order == null || order.Length == 0) return false;

            if (dependencies == null || dependencies.Length == 0) return true;
            
            for (var i = 0; i < dependencies.Length; i++)
            {
                var task = dependencies[i][0];
                var dependency = dependencies[i][1];
                if (task == dependency) return false;
                var taskIndex = IndexOfTask(order, task); // Check if task in available in order and get index of it.
                if (taskIndex == -1 || !IsValidDependencyOrder(order, taskIndex, dependency)) return false;
            }
            
            return true;
        }

        public static bool IsValidOrderUsingDictionary(int[] order, int[][] dependencies)
        {
            if (order == null || order.Length == 0) return false;

            if (dependencies == null || dependencies.Length == 0) return true;

            // Create hashmap of tasks and index
            var hashMap = new Dictionary<int, int>();
            for (int i = 0; i < order.Length; i++)
            {
                if (hashMap.ContainsKey(order[i])) return false;// Duplicate task
                hashMap.Add(order[i], i);
            }
            for (var i = 0; i < dependencies.Length; i++)
            {
                var task = dependencies[i][0];
                var dependency = dependencies[i][1];

                if (!hashMap.ContainsKey(task) || !hashMap.ContainsKey(dependency)) return false; // Taks or dependency is not availble in order list.

                // Index of dependent task must be lower then task index
                if (hashMap[task] < hashMap[dependency]) return false;                 
            }

            return true;
        }


        private static int IndexOfTask(int[] order, int task)
        {
            // This can be optimized
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] == task) return i;
            }
            return -1;
        }
        private static bool IsValidDependencyOrder(int[] order, int taskIndex, int dependency)
        {
            for (int i = 0; i < taskIndex; i++)
            {
                if (order[i] == dependency) return true;
            }
            return false;
        }
    }

    
}
