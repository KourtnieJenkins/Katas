using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToeKata;

namespace TicTacToe.Tests
{
    [TestFixture]
    class TicTacToeGameTests
    {
        //TicTacToeGame(int gameDimensions)
        //startGame -- starts game by creating a winstatecollection & populating possiblewinstates
        //updateplayerMove -- handles: insertions, duplicate insertions, and outofbounds exception for invalid input
        //printgame -- meh, if time is available 
        //GetWinner -- returns a string detailing outcome?
        //parsePlayerInput -- parse incoming string input

        private TicTacToeGame ticTacToe;
        private int gameDimensions = 3;


        [SetUp]
        public void Init()
        {
            ticTacToe = new TicTacToeGame(gameDimensions);
        }

        [Test]
        public void StartGame_InvokedForFirstTime_AmountOfPossibleWinsIsGreaterThan0()
        {
            ticTacToe.startGame();

            Assert.That(ticTacToe.WinStates.PossibleWins.Count > 0);
        }

        [Test]
        public void UpdatePlayerMove_InvokedWithValidMoveIsMade_ReturnsAnEmptyString()
        {
            ticTacToe.startGame();
            string actual = ticTacToe.updatePlayerMove("X", 0, 0);
            Assert.IsEmpty(actual);
        }
    }
}
