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

        public WinStateCollection()
        {

        }

        public List<WinState> RowWinStates { get => rowWinStates; }
        public List<WinState> ColumnWinStates { get => columnWinStates; }
        public List<WinState> PossibleWins { get => possibleWins;  }
        public WinState DiagonalForwardWinState { get => diagonalForwardWinState; }
        public WinState DiagonalBackwardWinState { get => diagonalBackwardWinState; }

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
                diagonalForwardWinState = new WinState(numberOfRows);
                possibleWins.Add(diagonalForwardWinState);

                diagonalBackwardWinState = new WinState(numberOfRows);
                possibleWins.Add(diagonalBackwardWinState);

            }
            
        }



    }
}
