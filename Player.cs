using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRockPaperScissors
{
    public class Player
    {
        public string Name { get; private set; }
        public playerChoice Turn { get; private set; }
        public int Wins { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void NextTurn(playerChoice varient)
        {
            Turn = varient;
        }

        public void PlayerWon()
        {
            Wins++;
        }
    }
}
