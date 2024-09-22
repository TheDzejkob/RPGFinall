using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGFinall.Classes
{
    public class GameMaster
    {
        public bool PlayersTurn { get; set; }
        public bool Alive { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public Player CurentPlayer { get; set; }

        public GameMaster(bool playersTurn, bool alive, int xp, int level, Player curentPlayer)
        {
            PlayersTurn = playersTurn;
            Alive = alive;
            Xp = xp;
            Level = level;
            CurentPlayer = curentPlayer;
        }
    }

}
