using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe3x3Kata
{
    public class WinStateCollection
    {
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
                columnWinStates.Add(new WinState(n));

            }

            for (int i = 0; i < m; i++)
            {
                rowWinStates.Add(new WinState(m));
            }

            if (n == m)
            {
                diagonalForwardWinState = new WinState(n);
                diagonalBackwardWinState = new WinState(n);
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

        public void updateColumnWinStates(String player, int columnIndex)
        {
            WinState winState = new WinState(columnWinStates.Count);
            winState = getColumnWinStateAtIndexOf(columnIndex);

            //
            if (winState.getOwner() == null)
            {
                winState.Owner = player;
            }
            else if(winState.Owner.Equals(player))
            {
               

            }
            else
            {
                //update positions, remove wins
            }

           
        }

        public void updateRowWinStates(String player, int rowIndex)
        {
            WinState winState = new WinState(rowWinStates.Count);
            winState = getRowWinStateAtIndexOf(rowIndex);

            //
            if (winState.getOwner() == null)
            {
                winState.Owner = player;
            }
            else if (winState.Owner.Equals(player))
            {


            }
            else
            {
                //update positions, remove wins
            }

        }

        public void updateDiagonalWinStates(String player, int row, int column)
        {

        }

    }
}
