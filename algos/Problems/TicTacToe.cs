using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems.TicTacToe;

public class TicTacToe
{
    // Can be solved in Class diagram 
    //https://www.youtube.com/watch?v=gktZsX9Z8Kw&t=4s

    int[][] board;
    int boardSize;

    public TicTacToe(int size)
    {
        this.boardSize = size;
        this.board = new int[size][];
        foreach(var i in Enumerable.Range(0,size))
            board[i] = new int[size];


        // Used for Optimized version
        rowSum = new int[boardSize];
        colSum = new int[boardSize];
    }

    public int Move(int player, int row, int col)
    {
        if (player < 1 && player > 2)
            throw new ArgumentException("Invalid Player");
        if (row < 0 || row >= boardSize | col < 0 || col >= boardSize)
            throw new ArgumentException("Invalid location.");
        if (board[row][col] != 0)
            throw new ArgumentException("Move not allowed.");
         player = player == 1 ? -1 : +1;
        board[row][col] = player;
        bool winRow = true, winCol = true, winDiag = true, winRevDiag = true;
        for (var i = 0; i < boardSize; i++)
        {
            if ( board[row][i] != player)
                winRow = false;
            if (board[i][col] != player)
                winCol = false;
            if (board[i][i] != player)
                winDiag = false;
            if ( board[i][boardSize -1-i] != player)
                winRevDiag = false;
        }
        if (winRow || winCol || winDiag || winRevDiag)
        {
            return player;
        }
        return 0;

    }
    int[] rowSum;
    int[] colSum;
    int diagSum;
    int revDiagSum;
    public int MoveOp(int player, int row, int col)
    {
        // Pre compute score of each row col and diag and rev Diag
        // Use Abs Value to to check score
        if (player < 1 && player > 2)
            throw new ArgumentException("Invalid Player");
        if (row < 0 || row >= boardSize | col < 0 || col >= boardSize)
            throw new ArgumentException("Invalid location.");
        if (board[row][col] != 0)
            throw new ArgumentException("Move not allowed.");
        player = player == 1 ? -1 : +1;
        board[row][col] = player;

        rowSum[row] += player;
        colSum[col] += player;
        if ( row == col)
            diagSum += player;
        if ( row == boardSize-1-col)
            revDiagSum += player;

         
        if (Math.Abs(rowSum[row]) == boardSize || 
            Math.Abs(colSum[col]) == boardSize ||
            Math.Abs(diagSum) == boardSize ||
            Math.Abs(revDiagSum) == boardSize)
        {
            return player;
        }
        return 0;

    }
}
