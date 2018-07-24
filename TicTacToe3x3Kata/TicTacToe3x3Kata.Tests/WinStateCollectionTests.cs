using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe3x3Kata.Tests
{
    [TestFixture]
    public class WinStateCollectionTests
    {
        private WinStateCollection winStateCollection;
        const int n = 3;
        const int m = 3;
        const String playerX = "X";
        const String playerO = "O";

        [SetUp]
        public void Init()
        {
            winStateCollection = new WinStateCollection();
            winStateCollection.populateWinStates(3, 3);

        }

        [Test]
        public void populateWinStateCollection_InvokedWith3Rows3Columns_3RowWinStatesAreCreated()
        {
            //winStateCollection.populateWinStates(3,3);

            Assert.That(winStateCollection.getRowWinStates().Count == 3);

        }

        [Test]
        public void populateWinStateCollection_InvokedWith3Rows3Columns_3ColumnWinStatesAreCreated()
        {
            //winStateCollection.populateWinStates(3, 3);

            Assert.That(winStateCollection.getColumnWinStates().Count == 3);

        }

        [Test]
        public void populateWinStateCollection_InvokedWith3Rows3Columns_1DiagonalForwardWinStateIsCreated()
        {
            //winStateCollection.populateWinStates(3, 3);

            Assert.That(winStateCollection.getDiagonalForwardWinState() != null);

        }

        [Test]
        public void populateWinStateCollection_InvokedWith3Rows3Columns_1DiagonalBackwardWinStateIsCreated()
        {
            //winStateCollection.populateWinStates(3, 3);

            Assert.That(winStateCollection.getDiagonalBackwardWinState() != null);

        }

        [Test]
        public void populateWinStateCollection_InvokedWith3Rows4Columns_DiagonalWinStatesNotCreated()
        {
            WinStateCollection winStateCollection = new WinStateCollection();
            winStateCollection.populateWinStates(3, 4);

            Assert.That(winStateCollection.getDiagonalForwardWinState() == null && winStateCollection.getDiagonalBackwardWinState() == null);            
        }

        
        [Test]
        public void updateWinStates_InvokedWithPlayerXRow1Column1ForFistTime_OwnerOfRowWinStateAndColumnWinState1IsSetToPlayerX()
        {
            winStateCollection.updateWinStates(playerX, 1, 1);
            
            Assert.That(winStateCollection.getRowWinStateAtIndexOf(1).getOwner().Equals("X"));
        }
        


    }
}
