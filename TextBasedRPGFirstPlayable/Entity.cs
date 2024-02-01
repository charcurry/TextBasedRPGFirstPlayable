using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    abstract class Entity : GameObject
    {
        public HealthSystem healthSystem;
        public int damageNumber = 1;

        public void Move(Map map, Point2D startPos, Point2D endPos)
        {
            if (endPos.y < 0 || endPos.x < 0 || endPos.y >= map.mapYLength || endPos.x >= map.mapXLength)
            {
                return;
            }
            else if (map.GetTile(endPos) == map.wallTile)
            {
                return;
            }
            else if (map.GetEntity(endPos) != null)
            {
                Attack(map.GetEntity(endPos));
            }
            else
            {
                map.AddEntity(map.GetEntity(startPos), endPos);
                map.RemoveEntity(startPos);
            }
        }

        public void Attack(Entity target)
        {
            //Random random = new Random();
            //int damage = random.Next(0, 2);
            target.healthSystem.TakeDamage(damageNumber);
        }

        public Entity(int health)
        {
            //Console.WriteLine("Entity Class Constructed");
            healthSystem = new HealthSystem(health);
        }
    }
}