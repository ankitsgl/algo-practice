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

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();

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
            void backtrack(int row, int col, string word, int index)
            {
                if (!IsValidLocation(row, col))
                    return;

                if (board[row][col] != word[index])
                    return;

                if (board[row][col] == '#')
                    return;

                if (index == word.Length - 1)
                {
                    result.Add(word);
                    return;
                }
                board[row][col] = '#';


                foreach (var nextLocation in possibleDirections)
                {
                    backtrack(row + nextLocation[0],
                        col + nextLocation[1], word, index + 1);
                }
                board[row][col] = word[index];
            }


            foreach (var word in words)
            {
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        backtrack(row, col, word, 0);
                    }

                }
            }

            return result;
        }
    }
}
