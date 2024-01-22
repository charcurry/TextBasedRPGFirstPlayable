using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class Player : Entity
    {

        #region GameOver States
        public static bool gameOver = false;
        public static bool playerVictory = false;
        #endregion

        #region Player Health
        public static int playerHealth = 4;
        #endregion

        #region Player Death
        public static bool playerDead = false;
        #endregion

        public Player(int health) : base(health)
        {
            Console.WriteLine("Player Class Constructed");
        }
    }
}
