using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class HealthSystem
    {
        public int health;

        public HealthSystem(int initHealth)
        {
            health = initHealth;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Heal(int health)
        {
            health += health;
        }
    }
}
