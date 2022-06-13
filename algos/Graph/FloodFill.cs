using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Graph
{

    public class FloodFillProblem
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
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {   
            if (image.Length == 0) return image;

            var rows = image.Length;
            var cols = image[0].Length;

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
            void bfs(int row, int col, int startColor)
            {
                var queue = new Queue<Location>();
                queue.Enqueue(new Location(row, col));
                while (queue.Count > 0)
                {
                    var loc = queue.Dequeue();
                    image[loc.Row][loc.Col] = newColor;
                    foreach (var direction in possibleDirections)
                    {
                        var r = loc.Row + direction[0];
                        var c = loc.Col + direction[1];
                        if (isLocationInRange(r, c)
                            && image[r][c] == startColor
                            && visited[r, c] != 1)
                        {
                            queue.Enqueue(new Location(r, c));
                            
                            visited[r, c] = 1;
                        }
                    }
                }
            }

            
            bfs(sr, sc, image[sr][sc]);

            return image;
        }


        public int[][] FloodFill_UsingDfs(int[][] image, int sr, int sc, int newColor)
        {   
            var rowCount = image.Length;
            var colCount = image[0].Length;
            
            int[,] visited = new int[rowCount, colCount];

            void dfs(int row, int col, int startColor)
            {
                if (row < 0 || row >= rowCount || col < 0 || col >= colCount || visited[row, col] == 1
                    || image[row][col] != startColor)
                    return;

                // Set New Color
                visited[row, col] = 1;
                image[row][col] = newColor;
                
                dfs(row + 1, col, startColor);
                dfs(row - 1, col, startColor);
                dfs(row, col + 1, startColor);
                dfs(row, col - 1, startColor);

            } 
              
            dfs(sr, sc, image[sr][sc]);
              
            return image;
        }
    }
}
