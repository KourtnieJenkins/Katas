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
    class WinStateTests
    {
        WinState winState;
        string player1 = "player1";
        string player2 = "player2";
        int winStateSize = 3;

        [SetUp]
        public void Init()
        {
            winState = new WinState(winStateSize);
        }


        [Test]
        public void Owner_InvokedWithAPlayerForFirstTime_OwnerIsSetToThatPlayer()
        {
            winState.Owner = player1;

            Assert.That(winState.Owner == player1);
        }

        [Test]
        public void Owner_InvokedTwiceByDifferentPlayers_OwnerIsSetToFirstPlayer()
        {
            winState.Owner = player1;
            winState.Owner = player2;

            Assert.That(winState.Owner == player1);
        }

        [Test]
        public void Owner_InvokedTwiceBySamePlayer_WinStatusIsSetToUnknown()
        {
            winState.Owner = player1;
            winState.Owner = player1;

            Assert.That(winState.WinStatus == WinType.Unknown);
        }

        [Test]
        public void Owner_InvokedTwiceByDifferentPlayers_WinStatusIsSetToLose()
        {
            winState.Owner = player1;
            winState.Owner = player2;

            Assert.That(winState.WinStatus == WinType.Lose);
        }
        
        [Test]
        public void TryUpdatingPositions_InvokedByOwnerAndValidIndex_WinStatusIsUnknown()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);

            Assert.That(winState.WinStatus == WinType.Unknown);

        }

        [Test]
        public void TryUpdatingPositions_InvokedByNonOwnerAndValidIndex_WinStateIsSetToLose()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player2, 0);

            Assert.That(winState.WinStatus == WinType.Lose);
        }
        
        [Test]
        public void TryUpdatingPositions_InvokedWithPlayerAndIndex0_PositionAtIndex0IsSetToThatPlayer()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);

            Assert.That(winState.Positions[0].Equals(player1));
        }

        [Test]
        public void TryUpdatingPositions_InvokedTwiceByDifferentPlayersAndSameIndex_PositionAtIndexIsSetToFirstPlayer()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);
            winState.tryUpdatingPositions(player2, 0);

            Assert.That(winState.Positions[0].Equals(player1));
        }

        [Test]
        public void TryUpdatingPositions_InvokedWithPlayerAndIndex0_ReturnTrue()
        {
            winState.Owner = player1;

            Assert.IsTrue(winState.tryUpdatingPositions(player1, 0));
        }

        [Test]
        public void TryUpdatingPositions_InvokedByTwoDifferentPlayersAndSameIndex_ReturnFalse()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);

            Assert.IsFalse(winState.tryUpdatingPositions(player2, 0));
        }

        [Test]
        public void TryUpdatingPositions_InvokedWithIndexOutOfBounds_ThrowOutOfBoundsException()
        {
            winState.Owner = player1;

            var exception = Assert.Catch(() => winState.tryUpdatingPositions(player1, winStateSize + 1));
            Assert.IsInstanceOf<IndexOutOfRangeException>(exception);                 
        }

        [Test]
        public void CheckForWinInWinState_InvokedAfterSamePlayerFillsAllPositions_WinStatusIsSetToWin()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1,0);
            winState.tryUpdatingPositions(player1, 1);
            winState.tryUpdatingPositions(player1, 2);

            winState.checkForWinInWinState();

            Assert.That(winState.WinStatus == WinType.Win);

        }

        [Test]
        public void CheckForWinInWinState_InvokedWhenNotAllPositionsAreFilled_WinStatusIsUnknown()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);
            winState.tryUpdatingPositions(player1, 1);

            winState.checkForWinInWinState();

            Assert.That(winState.WinStatus == WinType.Unknown);
        }

        [Test]
        public void CheckForWinInWinState_InvokedWhenAllPositionsAreFilledByDifferentPlayers_WinStatusIsLose()
        {
            winState.Owner = player1;
            winState.tryUpdatingPositions(player1, 0);
            winState.tryUpdatingPositions(player1, 1);
            winState.tryUpdatingPositions(player2, 2);

            winState.checkForWinInWinState();

            Assert.That(winState.WinStatus == WinType.Lose);
        }
        
    }
}
