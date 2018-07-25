using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe3x3Kata.Tests
{
    [TestFixture]
    class WinStateTests
    {
        private WinState winState;
        const string playerX = "X";
        const string playerO = "O";
        const int numberOfPositions = 3;


        [SetUp]
        public void Init()
        {
            winState = new WinState(numberOfPositions);
        }

        [Test]
        public void SetOwner_InvokedByASinglePlayer_OwnerSetToPlayerX()
        {
            winState.Owner = playerX; //.setOwner(playerX);
            Assert.That(winState.Owner.Equals(playerX));
        }

        [Test]
        public void SetOwner_InvokedByTwoDifferentPlayers_FirstPlayerIsSetToOwner()//InvokedWithPlayerXThenWithPlayerO_WinStateOwnerSetToPlayerX()
        {
            winState.Owner = playerX;
            winState.Owner = playerO;
            Assert.That(winState.Owner.Equals(playerX));
        }

        [Test]
        public void SetOwner_InvokedWithTwoDifferentPlayers__IsWinningSetToFalse()
        {
            winState.Owner = playerX;
            winState.Owner = playerO;
            Assert.IsFalse(winState.IsWinning);
        }

        /*
        [TestCase(playerO, 2)]
        [TestCase(playerX, 0)]        
        public void UpdatePosition_InvokedWithPlayerAndPositionIndex_PositionAtIndexIsPopulatedWithPlayerValue(string player, int positionIndex)
        {
            winState.updatePosition(player, positionIndex);

            Assert.That(winState.Positions[positionIndex].Equals(player));
        }
        
        [Test]
        public void UpdatePosition_InvokedWithTwoPlayersSelectingTheSamePosition_PositionSetToFirstPlayerValue()
        {
            winState.updatePosition(playerX, 0);
            winState.updatePosition(playerO, 0);

            Assert.That(winState.Positions[0].Equals(playerX)); 
        }*/

        [TestCase(playerO, 2)]
        [TestCase(playerX, 0)]
        public void PositionIsUpdated_InvokedWithPlayerAndPositionIndex_ReturnTrue(string player, int positionIndex)
        {
            bool actual = winState.positionIsUpdated(player, positionIndex);

            Assert.IsTrue(actual);
        }

        [Test]
        public void PositionIsUpdated_InvokedWithTwoPlayersSelectingTheSamePosition_ReturnFalse()
        {
            bool actual = winState.positionIsUpdated(playerX, 0);
            actual = winState.positionIsUpdated(playerO, 0);

            Assert.IsFalse(actual);
        }

        [Test]
        public void UpdateIsWinning_InvokedAfterAllWinStatePositionsArePopulatedBySamePlayerValue_IsWinningSetToTrue()
        {
            winState.positionIsUpdated(playerX, 0);
            winState.positionIsUpdated(playerX, 1);
            winState.positionIsUpdated(playerX, 2);

            Assert.IsTrue(winState.IsWinning);
        }

    }
}
