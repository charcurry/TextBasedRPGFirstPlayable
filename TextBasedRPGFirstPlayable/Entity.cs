using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    public abstract class Entity : GameObject
    {
        public HealthSystem healthSystem;

        public Entity(int health)
        {
            Console.WriteLine("Entity Class Constructed");

            healthSystem = new HealthSystem(health);
        }
    }
}
