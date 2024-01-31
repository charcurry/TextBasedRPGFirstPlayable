using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    abstract class Entity : GameObject
    {
        public HealthSystem healthSystem;

        public void Move(Map map, Point2D startPos, Point2D endPos)
        {
            if (endPos.y < 0 || endPos.x < 0 || endPos.y >= map.mapYLength || endPos.x >= map.mapXLength)
            {
                return;
            }
        }

        public void Attack(Entity target)
        {
            target.healthSystem.TakeDamage(1);
        }

        public Entity(int health)
        {
            Console.WriteLine("Entity Class Constructed");

            healthSystem = new HealthSystem(health);
        }
    }
}
