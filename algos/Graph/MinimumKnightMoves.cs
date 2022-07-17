using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph;

public class MinimumKnightMoves
{
    //https://leetcode.com/problems/minimum-knight-moves/
    public int FindMinMove(int[] start, int[] end)
    {
        var possibleMoved = new[]
        { 
            new []{ -2,1},
            new []{ -2,-1},
            new []{ +2,1},            
            new []{ +2,-1},
            new []{ -1,2},
            new []{ +1,2},
            new []{ 1,-2},
            new []{ -1,-2},
        };

        var queue = new Queue<(int, int)>();

        var visited = new HashSet<(int, int)>();
        queue.Enqueue((start[0], start[1]));
        var level = 0;
        while (queue.Count > 0)
        {
            
            foreach(var i in Enumerable.Range(0, queue.Count))
            {
                var current = queue.Dequeue();
                if (current.Item1 == end[0] && current.Item2 == end[1])
                {
                    return level;
                }

                visited.Add((current.Item1, current.Item2));
                foreach (var possibleLocation in possibleMoved)
                {
                    var nextR = current.Item1 + possibleLocation[0];
                    var nextC = current.Item2 + possibleLocation[1];
                    if (!visited.Contains((nextR, nextC)))
                        queue.Enqueue((nextR, nextC));
                }
            }
            level++;
        }
        return -1;
    }

    public int FindMinMove(int x, int y)
    {
        var possibleMoved = new[]
        {
            new []{ -2,1},
            new []{ -2,-1},
            new []{ +2,1},
            new []{ +2,-1},
            new []{ -1,2},
            new []{ +1,2},
            new []{ 1,-2},
            new []{ -1,-2},
        };

        var queue = new Queue<(int, int)>();

        var visited = new HashSet<(int, int)>();
        queue.Enqueue((0, 0));
        var level = 0;
        while (queue.Count > 0)
        {
            level++;

            foreach (var i in Enumerable.Range(0, queue.Count))
            {
                var current = queue.Dequeue();
                

                visited.Add((current.Item1, current.Item2));
                foreach (var possibleLocation in possibleMoved)
                {
                    var nextR = current.Item1 + possibleLocation[0];
                    var nextC = current.Item2 + possibleLocation[1];



                    if (!visited.Contains((nextR, nextC)))
                    {
                        if (nextR == x && nextC== y)
                        {
                            return level;
                        }

                        queue.Enqueue((nextR, nextC));
                    }
                }
            }
            
        }
        return -1;
    }
}