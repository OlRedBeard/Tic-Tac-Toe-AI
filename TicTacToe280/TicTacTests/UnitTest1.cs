using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using TicTacToeBasePlayer;
using GerritEasyPlayer;
using GerritModeratePlayer;
using GerritDifficultPlayer;
using System.Collections.Generic;

namespace TicTacTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddOnePlayer()
        {
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
        }

        [TestMethod]
        public void TestAddTwoPlayersSame()
        {
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            TicTacToeEasy p2 = new TicTacToeEasy(-1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            t.AddPlayer(p2);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
            Assert.AreEqual(p2, results[1]);
        }

        [TestMethod]
        public void TestAddTwoPlayersDifferent()
        {
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            TicTacToeDifficult p2 = new TicTacToeDifficult(-1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            t.AddPlayer(p2);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
            Assert.AreEqual(p2, results[1]);
        }

        [TestMethod]
        public void TestAddThreePlayersSame()
        {
            TicTacToeEasy p1 = new TicTacToeEasy(1);
            TicTacToeEasy p2 = new TicTacToeEasy(1);
            TicTacToeEasy p3 = new TicTacToeEasy(1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            t.AddPlayer(p2);
            t.AddPlayer(p3);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
            Assert.AreEqual(p2, results[1]);
            Assert.AreEqual(p3, results[2]);
        }

        [TestMethod]
        public void TestAddThreePlayersTwoTypes()
        {
            TicTacToeDifficult p1 = new TicTacToeDifficult(1);
            TicTacToeEasy p2 = new TicTacToeEasy(1);
            TicTacToeEasy p3 = new TicTacToeEasy(1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            t.AddPlayer(p2);
            t.AddPlayer(p3);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
            Assert.AreEqual(p2, results[1]);
            Assert.AreEqual(p3, results[2]);
        }

        [TestMethod]
        public void TestAddThreePlayersDifferent()
        {
            TicTacToeDifficult p1 = new TicTacToeDifficult(1);
            TicTacToeModerate p2 = new TicTacToeModerate(1);
            TicTacToeEasy p3 = new TicTacToeEasy(1);
            Tournament t = new Tournament();
            t.AddPlayer(p1);
            t.AddPlayer(p2);
            t.AddPlayer(p3);
            List<ITicTacToePlayer> results = t.CheckPlayers();

            Assert.AreEqual(p1, results[0]);
            Assert.AreEqual(p2, results[1]);
            Assert.AreEqual(p3, results[2]);
        }
    }
}
