using algos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class TheMaze
{
    public bool HasPath_Dfs(int[][] maze, int[] start, int[] destination)
    {
         
        bool isValidLocation(int r, int c)
        { 
            return r>=0 && r < maze.Length && c >= 0 && c < maze[0].Length;
        }

        var path = new LinkedList<string>();

        bool dfs(int r, int c)
        {
            
            if ( !isValidLocation(r, c)) return false;

            if (maze[r][c] == 1)
                return false;

            if (maze[r][c] == 2)
                return false;

            Console.Write($"[{r},{c}] -> ");

            if (r == destination[0] && c == destination[1])
                return true;


            // Go Up
            maze[r][c] = 2;
            path.AddLast("left");
            if (dfs(r, c -1)) return true;
            path.RemoveLast();

            // go Left
            path.AddLast("up");
            if (dfs(r-1, c)) return true;
            path.RemoveLast();

            // Go Right
            path.AddLast("down");
            if (dfs(r + 1, c)) return true;
            path.RemoveLast();
            
            // Go Down
            path.AddLast("right");
            if (dfs(r, c + 1)) return true;
            path.RemoveLast();
            

            return false;
        }

        
        var result = dfs(start[0], start[1]);
        Console.WriteLine();
        LinkedListHelpers.PrintLinkedList("Path: ", path.First);
        return result;  
    }


    public bool HasPath_Bfs(int[][] maze, int[] start, int[] destination)
    {

        bool isValidLocation(int r, int c)
        {
            return r >= 0 && r < maze.Length && c >= 0 && c < maze[0].Length;
        }
        
        var possibleDirections = new[] {
            new[]{ +1,0, 'D' }, 
            new[]{ -1,0, 'U' }, 
            new[]{ 0,+1, 'R' }, 
            new[]{ 0,-1, 'L' } };

        var path = new LinkedList<string>();
        path.AddLast("O");

        var queue = new Queue<(int, int)>();

        queue.Enqueue((start[0], start[1]));
        var result = false;
        while (queue.Count > 0)
        {
            foreach (var i in Enumerable.Range(0, queue.Count))
            {
                var current = queue.Dequeue();
                var r = current.Item1;
                var c = current.Item2;


                if (r == destination[0] && c == destination[1])
                {
                    result = true;
                    break;
                }

                foreach (var direction in possibleDirections)
                {
                    var nr = r + direction[0];
                    var nc = c + direction[1];

                    if (!isValidLocation(nr, nc)) continue;

                    if (maze[nr][nc] == 1) continue;

                    if (maze[nr][nc] == 2) continue;

                    path.AddLast(((char)direction[2]).ToString());
                    maze[r][c] = 2;
                    queue.Enqueue((nr, nc));
                }
            }
            
        }
         
        Console.WriteLine();
        LinkedListHelpers.PrintLinkedList("Path: ", path.First);
        return result;
    }
}
