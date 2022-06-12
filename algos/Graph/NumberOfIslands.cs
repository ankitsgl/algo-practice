using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph
{

    public class NumberOfIslands
    {
        class Location
        {
            public int Row;
            public int Col;
            public Location(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }
        public int NumIslands(char[][] grid)
        {
            var result = 0;
            if (grid.Length == 0) return result;

            var rows = grid.Length;
            var cols = grid[0].Length;

            int[,] visited = new int[rows, cols];
            var possibleDirections = new[] {
                new[] { 1,0 },
                new[] { -1,0 },
                new[] { 0,1 },
                new[] { 0,-1 },
            };

            bool isLocationInRange(int r, int c)
            {
                return r >= 0 && r < rows && c >= 0 && c < cols;
            }
            void bfs(int row, int col)
            {
                var queue = new Queue<Location>();
                queue.Enqueue(new Location(row, col));
                while (queue.Count > 0)
                {
                    var loc = queue.Dequeue();
                    foreach (var direction in possibleDirections)
                    {
                        var r = loc.Row + direction[0];
                        var c = loc.Col + direction[1];
                        if (isLocationInRange(r, c)
                            && grid[r][c] == '1'
                            && visited[r, c] != 1)
                        {
                            queue.Enqueue(new Location(r, c));
                            visited[r, c] = 1;
                        }
                    }
                }
            }

            foreach (var row in Enumerable.Range(0, rows))
            {
                foreach (var col in Enumerable.Range(0, cols))
                {
                    if (grid[row][col] == '1' && visited[row, col] == 0)
                    {
                        bfs(row, col);
                        result++;
                    }
                }
            }


            return result;
        }


        public int NumIslands_UsingDfs(char[][] grid)
        {
            int islands = 0;
            
            var rowCount = grid.Length;
            var colCount = grid[0].Length;

            void dfs(int row, int col)
            {
                if ( row < 0 || row >= rowCount || col < 0 || col >= colCount || grid[row][col] != '1')
                    return;

                // Flip Island to new state
                grid[row][col] = '2';
                dfs(row + 1, col);
                dfs(row - 1, col);
                dfs(row, col + 1);
                dfs(row, col - 1);

            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        islands++;
                        dfs(i, j);
                    }
                }
            }
            return islands;

        }
    }
}
