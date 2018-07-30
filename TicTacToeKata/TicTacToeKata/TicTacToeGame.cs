using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private int gameDimensions;
        private WinStateCollection winStates;
        private string player1 = "X";
        private string player2 = "O";

        public WinStateCollection WinStates { get => winStates; }

        public TicTacToeGame(int gameDimensions)
        {
            this.gameDimensions = gameDimensions;
        }

        public void startGame()
        {
            winStates = new WinStateCollection();
            winStates.populateWinStates(gameDimensions, gameDimensions);
        }
    }
}
