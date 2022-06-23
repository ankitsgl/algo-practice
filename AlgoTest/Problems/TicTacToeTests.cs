using Microsoft.VisualStudio.TestTools.UnitTesting;
using algos.Problems.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems.TicTacToe.Tests
{
    [TestClass()]
    public class TicTacToeTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            var game = new TicTacToe(3);

            var result = game.Move(1, 1, 1);

            result = game.Move(2, 0, 2);

            result = game.Move(1, 2, 2);
            result = game.Move(2, 1, 0);

            result = game.Move(1, 0, 0);
            Assert.AreEqual(-1, result);
        }

        [TestMethod()]
        public void MoveOpTest()
        {
            var game = new TicTacToe(3);

            var result = game.MoveOp(1, 1, 1);

            result = game.MoveOp(2, 0, 2);

            result = game.MoveOp(1, 2, 2);
            result = game.MoveOp(2, 1, 0);

            result = game.MoveOp(1, 0, 0);
            Assert.AreEqual(-1, result);
        }
    }
}