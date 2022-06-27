using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking
{
    public class ValidateSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            var cols = new Dictionary<int, HashSet<int>>();
            var rows = new Dictionary<int, HashSet<int>>();
            var squares = new Dictionary<(int,int), HashSet<int>>();

            foreach (var r in Enumerable.Range(0, 9))
            {
                foreach (var c in Enumerable.Range(0, 9))
                {
                    if (board[r][c] == '.') continue;

                    if (rows.ContainsKey(r) && rows[r].Contains(board[r][c]))
                        return false;                    

                    if (cols.ContainsKey(c) && cols[c].Contains(board[r][c]))
                        return false;

                    
                    if (squares.ContainsKey((r,c)) &&
                        squares[(r, c)].Contains(board[r][c]))
                        return false;

                    if (!rows.ContainsKey(r))
                        rows.Add(r, new HashSet<int>());

                    if (!cols.ContainsKey(c))
                        cols.Add(c, new HashSet<int>());

                    if (!squares.ContainsKey((r, c)))
                        squares.Add((r, c), new HashSet<int>());

                    rows[r].Add(board[r][c]);
                    cols[c].Add(board[r][c]);
                    squares[(r, c)].Add(board[r][c]);                    
                }
            }

            return true;
        }

    }
}
