using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe3x3Kata
{
    public class WinState
    {
        private String owner;

        public String getOwner()
        {
            return owner;
        }

        public void setOwner(String player)
        {
            owner = player;
        }

    }
}
