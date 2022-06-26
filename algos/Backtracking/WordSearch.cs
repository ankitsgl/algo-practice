using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            var result = false;

            var possibleDirections = new int[][]
            {
                new[] {1,0},
                new[] {0,1},
                new[] { -1, 0},
                new[] { 0, -1}
            };


            bool IsValidLocation(int row, int col)
            {
                return row >= 0 && row < board.Length
                    && col >= 0 && col < board[0].Length;
            }
            bool backtrack(int row, int col, int index)
            {
                if ( !IsValidLocation(row, col))
                    return false;

                if (board[row][col] != word[index])
                    return false;

                if (board[row][col] == '#')
                    return false;

                if (index == word.Length-1)
                    return true;
                board[row][col] = '#';


                foreach (var nextLocation in possibleDirections)
                {
                    if (backtrack(row + nextLocation[0], 
                        col + nextLocation[1], index+1))
                        return true;
                }
                board[row][col] = word[index];
                return false;
            }

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (backtrack(row, col, 0)) return true;
                }

            }

            return result;
        }
    }
}
