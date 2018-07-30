using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeKata
{
    public class WinState
    {
        private string owner;
        private WinType winStatus = WinType.Unknown;
        private string[] positions;

        public WinState(int numberOfPositions)
        {
            positions = new string[numberOfPositions];
            //winStatus = WinType.Unknown;
        }

        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                if(owner == null)
                {
                    owner = value;
                }else if (!value.Equals(owner))
                {
                    winStatus = WinType.Lose;
                }
            }
        }

        public WinType WinStatus
        {
            get
            {
                return winStatus;
            }
            set
            {
                winStatus = value;
            }
        }

        public string[] Positions => positions;  //made this field gettable for testing, what are other solutions for this??

        public bool tryUpdatingPositions(string player, int index)
        {
            Owner = player;
            if (positions[index] == null)
            {
                positions[index] = player;
                if (!player.Equals(owner))
                {
                    winStatus = WinType.Lose;

                }

            }
            else
            {
                return false;
            }
            checkForWinInWinState();
            return true;
        }

        public void checkForWinInWinState()
        {
            if (winStatus != WinType.Lose)
            {
                foreach (var position in positions)
                {

                    if (position == null)
                    {
                        winStatus = WinType.Unknown;
                        return;
                    }else if (position.Equals(owner))
                    {
                        winStatus = WinType.Win;                          
                    }
                    
                }
            }
            
        }

    }
}
