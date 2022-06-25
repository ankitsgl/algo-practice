using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;

public class NQueen
{
    public List<string> PlaceNQueen(int numberOfQeeen, int boardSize)
    {
        var result = new List<string>();
        var colSet = new HashSet<int>();
        var posDiag = new HashSet<int>();
        var negDiag = new HashSet<int>();


        var board = new int[boardSize][];
        for (int i = 0; i < boardSize; i++)
            board[i] = new int[boardSize];

        void backtrack(int r)
        {
            if (r == numberOfQeeen)
            {
                var placement = "";
                foreach (var row in board)
                {
                    placement += string.Join(' ', row) + Environment.NewLine;
                }                    
                result.Add(placement);
                return;
            }

            foreach(var c in Enumerable.Range(0, boardSize))
            {
                if (colSet.Contains(c)
                    || posDiag.Contains(r + c)
                    || negDiag.Contains(r - c))
                    continue;

                colSet.Add(c);
                posDiag.Add(r + c);
                negDiag.Add(r - c);
                board[r][c] = 1;
                backtrack(r + 1);

                colSet.Remove(c);
                posDiag.Remove(r + c);
                negDiag.Remove(r - c);
                board[r][c] = 0;
            }
        }
        backtrack(0);

        return result;
    }
}
