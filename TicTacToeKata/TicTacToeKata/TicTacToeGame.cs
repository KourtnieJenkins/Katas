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
        private int count = 0;
        
        public TicTacToeGame(int gameDimensions)
        {
            this.gameDimensions = gameDimensions;
        }

        public WinStateCollection WinStates => winStates;

        public void startGame()
        {
            winStates = new WinStateCollection();
            winStates.populateWinStates(gameDimensions, gameDimensions);
        }

        
        public string updatePlayerMove(string player, int row, int column)
        {
            
            if (row >= gameDimensions && column >= gameDimensions)
            {
                return "Invalid move, entry out of bounds. Please try again.";
            }
            else if (winStates.updateWinStates(player, row, column))
            {
                return "";
            }

            return "Invalid move, entry already filled. Please try again.";
            
        }
    }
}
