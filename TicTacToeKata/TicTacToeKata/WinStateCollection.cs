using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeKata
{
    public class WinStateCollection
    {

        private List<WinState> rowWinStates = new List<WinState>();
        private List<WinState> columnWinStates = new List<WinState>();
        private WinState diagonalForwardWinState;
        private WinState diagonalBackwardWinState;
        private List<WinState> possibleWins = new List<WinState>();
        private int diagonalDimensions;
        private WinState winner;
        
        public List<WinState> RowWinStates => rowWinStates;
        public List<WinState> ColumnWinStates => columnWinStates;
        public List<WinState> PossibleWins => possibleWins;
        public WinState DiagonalForwardWinState => diagonalForwardWinState;
        public WinState DiagonalBackwardWinState => diagonalBackwardWinState;
        public WinState Winner => winner;

        public void populateWinStates(int numberOfRows, int numberOfColumns)
        {                              
            for (int i = 0; i < numberOfRows; i++)
            {
                rowWinStates.Add(new WinState(numberOfColumns));
                possibleWins.Add(rowWinStates.ElementAt(i));
            }

            for (int i = 0; i < numberOfColumns; i++)
            {
                columnWinStates.Add(new WinState(numberOfRows));
                possibleWins.Add(columnWinStates.ElementAt(i));
            }

            if (numberOfRows == numberOfColumns)
            {
                diagonalDimensions = numberOfRows;

                diagonalForwardWinState = new WinState(numberOfRows);
                possibleWins.Add(diagonalForwardWinState);

                diagonalBackwardWinState = new WinState(numberOfRows);
                possibleWins.Add(diagonalBackwardWinState);
            }
            
        }

        public bool updateWinStates(string player, int rowIndex, int columnIndex)
        {            
            if(!rowWinStates.ElementAt(rowIndex).tryUpdatingPositions(player, columnIndex) ||
                !columnWinStates.ElementAt(columnIndex).tryUpdatingPositions(player, rowIndex))
            {
                return false;
            }

            if (rowIndex == columnIndex)
            {
                if (!diagonalForwardWinState.tryUpdatingPositions(player, rowIndex))
                {
                    return false;
                }
            }

            if ((rowIndex + columnIndex) == (diagonalDimensions - 1))
            {
                if (!diagonalBackwardWinState.tryUpdatingPositions(player, columnIndex))
                {
                    return false;
                }
            }
            updatePossibleWins();
            checkForWin();
            return true;           
        }

        public void updatePossibleWins()
        {
            for (int i = 0; i < possibleWins.Count; i++)
            {
                if (possibleWins.ElementAt(i).WinStatus == WinType.Lose)
                {
                    possibleWins.RemoveAt(i--);                    
                }
            }
        }
        public void checkForWin()
        {
            foreach (var winState in possibleWins)
            {
                if (winState.WinStatus == WinType.Win)
                {
                    winner = winState;
                    possibleWins.Clear();
                    return;
                }
            }
        }       
    }
}
