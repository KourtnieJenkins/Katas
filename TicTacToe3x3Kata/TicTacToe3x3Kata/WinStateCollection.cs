using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe3x3Kata
{
    public class WinStateCollection
    {
        private List<WinState> possibleWins = new List<WinState>();
        private List<WinState> columnWinStates = new List<WinState>();
        private List<WinState> rowWinStates = new List<WinState>();
        private WinState diagonalForwardWinState;
        private WinState diagonalBackwardWinState;


        public WinStateCollection()
        {
            //default constructor -- may change this
        }

        public void populateWinStates(int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                columnWinStates.Add(new WinState());

            }

            for (int i = 0; i < m; i++)
            {
                rowWinStates.Add(new WinState());
            }

            if (n == m)
            {
                diagonalForwardWinState = new WinState();
                diagonalBackwardWinState = new WinState();
            }

        }

        public List<WinState> getColumnWinStates()
        {
            return columnWinStates;
        }

        public List<WinState> getRowWinStates()
        {
            return rowWinStates;
        }

        public WinState getDiagonalForwardWinState()
        {
            return diagonalForwardWinState;
        }

        public WinState getDiagonalBackwardWinState()
        {
            return diagonalBackwardWinState;
        }

        public WinState getColumnWinStateAtIndexOf(int index)
        {
            return columnWinStates.ElementAt(index);
        }

        public WinState getRowWinStateAtIndexOf(int index)
        {
            return rowWinStates.ElementAt(index);
        }

        public void updateWinStates(String player, int row, int column)
        {
            updateColumnWinStates(player, column);
            updateRowWinStates(player, row);
            updateDiagonalWinStates(player, row, column);
           

        }

        public void updateColumnWinStates(String player, int rowIndex)
        {
            WinState winState = new WinState();
            winState = getRowWinStateAtIndexOf(rowIndex);

            //
            if (winState.getOwner() == null)
            {
                winState.setOwner(player);
            }
            else if(winState.getOwner().Equals(player))
            {
               

            }
            else
            {
                //update positions, remove wins
            }

           
        }

        public void updateRowWinStates(String player, int columnIndex)
        {
            WinState winState = new WinState();
            winState = getColumnWinStateAtIndexOf(columnIndex);
            winState.setOwner(player);

        }

        public void updateDiagonalWinStates(String player, int row, int column)
        {

        }

    }
}
