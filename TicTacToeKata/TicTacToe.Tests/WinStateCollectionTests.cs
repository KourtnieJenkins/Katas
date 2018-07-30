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
    class WinStateCollectionTests
    {

        private WinStateCollection winStateCollection;
        private string player1 = "X";
        private string player2 = "O";
        private int numberOfRows = 3;
        private int numberOfColumns = 3;
        private int row;
        private int column;

    [SetUp]
        public void Init()
        {
            winStateCollection = new WinStateCollection();
            winStateCollection.populateWinStates(numberOfRows, numberOfColumns);
        }
        
        [Test]
        public void PopulateWinStates_InvokedWith3Rows3Columns_RowWinStatesContains3WinStates()
        {
            Assert.That(winStateCollection.RowWinStates.Count == 3);
        }

        [Test]
        public void PopulateWinStates_InvokedWith3Rows3Columns_ColumnWinStatesContains3WinStates()
        {
            Assert.That(winStateCollection.ColumnWinStates.Count == 3);
        }

        [Test]
        public void PopulateWinStates_InvokedWith3Rows3Columns_DiagonalForwardWinStateIsCreated()
        {
            Assert.IsInstanceOf<WinState>(winStateCollection.DiagonalForwardWinState);
        }

        [Test]
        public void PopulateWinStates_InvokedWith3Rows3Columns_DiagonalBackwardWinStateIsCreated()
        {
            Assert.IsInstanceOf<WinState>(winStateCollection.DiagonalBackwardWinState);
        }

        [Test]
        public void PopulateWinStates_InvokedWith3Rows3Columns_PossibleWinsConatains8WinStates()
        {
            Assert.That(winStateCollection.PossibleWins.Count == 8);
        }

        [Test]
        public void UpdateWinStates_InvokedWithPlayer1Row0Column1_ValueOfRowWinStateAtIndex0SetToPlayer1()
        {
            row = 0;
            column = 1;
            winStateCollection.updateWinStates(player1, row, column);
            
            Assert.That(player1.Equals(winStateCollection.RowWinStates.ElementAt(row).Positions.ElementAt(column)));
        }

        [Test]
        public void UpdateWinStates_InvokedWithplayer1Row0Column1_ValueOfColumnWinStatesAtIndex1SetToPlayer1()
        {
            row = 0;
            column = 1;
            winStateCollection.updateWinStates(player1, row, column);

            Assert.That(player1.Equals(winStateCollection.ColumnWinStates.ElementAt(column).Positions.ElementAt(row)));
        }

        [Test]
        public void UpdateWinStates_InvokedWithPlayer1Row0Column0_ValueOfDiagonalForwardWinStateAtIndex0SetToPlayer1()
        {
            row = 0;
            column = 0;
            winStateCollection.updateWinStates(player1, row, column);

            Assert.That(winStateCollection.DiagonalForwardWinState.Positions.ElementAt(0).Equals(player1));

        }

        [Test]
        public void UpdateWinStates_InvokedWithPlayer1Row2Column0_ValueOfDiagonalBackwardWinStateAtIndex0SetToPlayer1()
        {
            row = 2;
            column = 0;
            winStateCollection.updateWinStates(player1, row, column);

            Assert.That(winStateCollection.DiagonalBackwardWinState.Positions.ElementAt(0).Equals(player1));

        }

        [Test]
        public void UpdateWinStates_InvokedWithIndexOutOfBounds_ThrowOutOfBoundsException()
        {
            row = 0;
            column = 5;
            
            var exception = Assert.Catch(() => winStateCollection.updateWinStates(player1, row, column));
            Assert.IsInstanceOf<IndexOutOfRangeException>(exception);
        }

        [Test]
        public void UpdatePossibleWins_InvokedAfterTwoPlayersChoosePositionsInSameWinState_AmountOfPossibleWinsDecreasesByOneOrMore()
        {
            int actualBefore = winStateCollection.PossibleWins.Count;
            
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player2, 0, 1);

            int actualAfter = winStateCollection.PossibleWins.Count;

            Assert.That(actualAfter < actualBefore);
        }


        [Test]
        public void CheckForWin_InvokedAfterPlayer1SelectsAllPositionsInAWinState_AmountOfPossibleWinsIs0()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player1, 0, 1);
            winStateCollection.updateWinStates(player1, 0, 2);

            Assert.That(winStateCollection.Winner.Owner.Equals(player1));//winStateCollection.PossibleWins.Count == 0);
        }

        [Test]
        public void CheckForWin_InvokedAfterRowWin_WinnerNotNull()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player1, 0, 1);
            winStateCollection.updateWinStates(player1, 0, 2);

            Assert.IsNotNull(winStateCollection.Winner);
        }

        [Test]
        public void CheckForWin_InvokedAfterColumnWin_WinnerNotNull()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player1, 1, 0);
            winStateCollection.updateWinStates(player1, 2, 0);

            Assert.IsNotNull(winStateCollection.Winner);
        }

        [Test]
        public void CheckForWin_InvokedAfterDiagonalForwardWin_WinnerNotNull()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player1, 1, 1);
            winStateCollection.updateWinStates(player1, 2, 2);

            Assert.IsNotNull(winStateCollection.Winner);
        }

        [Test]
        public void CheckForWin_InvokedAfterDiagonalBackwardWin_WinnerNotNull()
        {
            winStateCollection.updateWinStates(player1, 0, 2);
            winStateCollection.updateWinStates(player1, 1, 1);
            winStateCollection.updateWinStates(player1, 2, 0);

            Assert.IsNotNull(winStateCollection.Winner);
        }

        [Test]
        public void CheckForWin_InvokedAfterTie_WinnerIsNull()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player2, 0, 1);
            winStateCollection.updateWinStates(player1, 0, 2);
            winStateCollection.updateWinStates(player2, 1, 0);
            winStateCollection.updateWinStates(player2, 1, 1);
            winStateCollection.updateWinStates(player1, 1, 2);
            winStateCollection.updateWinStates(player1, 2, 0);
            winStateCollection.updateWinStates(player1, 2, 1);
            winStateCollection.updateWinStates(player2, 2, 2);

            Assert.IsNull(winStateCollection.Winner);
        }

        [Test]
        public void CheckForWin_InvokedAfterTie_AmountOfPossibleWinsIs0()
        {
            winStateCollection.updateWinStates(player1, 0, 0);
            winStateCollection.updateWinStates(player2, 0, 1);
            winStateCollection.updateWinStates(player1, 0, 2);
            winStateCollection.updateWinStates(player2, 1, 0);
            winStateCollection.updateWinStates(player2, 1, 1);
            winStateCollection.updateWinStates(player1, 1, 2);
            winStateCollection.updateWinStates(player1, 2, 0);
            winStateCollection.updateWinStates(player1, 2, 1);
            winStateCollection.updateWinStates(player2, 2, 2);

            Assert.That(winStateCollection.PossibleWins.Count == 0);
        }



    }
}
