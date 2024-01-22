using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class Enemy : Entity
    {

        #region Enemy Death
        public static bool enemyDead = false;
        #endregion

        static void EnemyTakeDamage(int damage)
        {
            if (damage > 0)
            {
                enemyHealth -= damage;
                if (enemyHealth <= 0)
                {
                    enemyDead = true;
                    gameOver = true;
                    playerVictory = true;
                }
            }
        }
        public Enemy(int health) : base(health)
        {
            Console.WriteLine("Enemy Class Constructed");
        }
    }
}
