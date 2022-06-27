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
                if (!rows.ContainsKey(r))
                    rows.Add(r, new HashSet<int>());

                foreach (var c in Enumerable.Range(0, 9))
                {
                    if (!cols.ContainsKey(c))
                        cols.Add(c, new HashSet<int>());

                    var box = (r / 3, c / 3);

                    if (!squares.ContainsKey(box))
                        squares.Add(box, new HashSet<int>());

                    if (board[r][c] == '.') continue;

                    if (rows[r].Contains(board[r][c]))
                        return false;                    

                    if (cols[c].Contains(board[r][c]))
                        return false;
                    
                    if (squares[box].Contains(board[r][c]))
                        return false;

                    rows[r].Add(board[r][c]);
                    cols[c].Add(board[r][c]);
                    squares[box].Add(board[r][c]);                    
                }
            }

            return true;
        }

    }
}
