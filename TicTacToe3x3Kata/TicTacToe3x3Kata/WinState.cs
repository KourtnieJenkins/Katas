using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe3x3Kata
{
    public class WinState
    {
        private string owner;
        private bool isWinning;
        private string[] positions;

        public WinState(int numberOfPositions)
        {
            positions = new string[numberOfPositions];
        }

        public string[] Positions
        {
            get
            {
                return positions;
            }
        }

        public string Owner
        {
            get
            {
                if (owner == null)
                {
                    owner = "";
                }
                return owner;
            }

            set
            {
                if (owner == null)
                {
                    owner = value;
                }
                else if (!value.Equals(owner))
                {
                    isWinning = false;
                }
            }
        }

        public bool IsWinning
        {
            get
            {
                return isWinning;
            }
        }


        public String getOwner()
        {
            return owner;
        }

        public void setOwner(String player)
        {
            owner = player;
        }

        /*
        public void updatePosition(string player, int index)
        {
            if (positions[index] == null)
            {
                positions[index] = player;
            }
        }*/

        public bool positionIsUpdated(string player, int index)
        {
            if (positions[index] == null)
            {
                positions[index] = player;
                return true;
            }

            return false;
            
        }


    }

}
