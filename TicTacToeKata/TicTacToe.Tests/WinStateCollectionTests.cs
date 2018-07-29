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
        private int numberOfRows = 3;
        private int numberOfColumns = 3;

    [SetUp]
        public void Init()
        {
            winStateCollection = new WinStateCollection();
            winStateCollection.populateWinStates(numberOfRows, numberOfColumns);
        }

        /*
        [TestCase(playerO, 2)]
        [TestCase(playerX, 0)]        
        public void UpdatePosition_InvokedWithPlayerAndPositionIndex_PositionAtIndexIsPopulatedWithPlayerValue(string player, int positionIndex)
        */

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

        //updateWinStates -- invoked with player1,0,0 -- owner of rowWinState at index 0 set to player
        //updateWinStates -- invoked with player1,0,0 -- owner of columnWinState at index 0 set to player
        //updated...  UpdateWinStates_InvokedWithPlayer1Row0Column0_

    }
}
