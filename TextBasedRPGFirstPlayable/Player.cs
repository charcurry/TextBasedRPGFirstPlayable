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
        public bool gameOver = false;
        public bool playerVictory = false;
        #endregion

        #region Player Death
        public bool playerDead = false;
        #endregion

        readonly Map map;
        public Enemy enemy;

        public void PlayerDraw()
        {
            Console.SetCursorPosition(this.position.x, this.position.y);
            Console.WriteLine("@");
        }

        public void PlayerUpdate()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                int newY = position.y - 1;
                int newEnemyY = enemy.position.y - 1;
                Point2D newPosition = new Point2D(position.x, newY);
                Point2D newEnemyPosition = new Point2D(enemy.position.x, newEnemyY);
                Move(map, position, newPosition);
                if (gaveDamage)
                {
                    enemy.Move(map, enemy.position, newEnemyPosition);
                }
            }
            else if (input.Key == ConsoleKey.A)
            {
                int newX = position.x - 1;
                int newEnemyX = enemy.position.x - 1;
                Point2D newPosition = new Point2D(newX, position.y);
                Point2D newEnemyPosition = new Point2D(newEnemyX, enemy.position.y);
                Move(map, position, newPosition);
                if (gaveDamage)
                {
                    enemy.Move(map, enemy.position, newEnemyPosition);
                }
            }
            else if (input.Key == ConsoleKey.D)
            {
                int newX = position.x + 1;
                int newEnemyX = enemy.position.x + 1;
                Point2D newPosition = new Point2D(newX, position.y);
                Point2D newEnemyPosition = new Point2D(newEnemyX, enemy.position.y);
                Move(map, position, newPosition);
                if (gaveDamage)
                {
                    enemy.Move(map, enemy.position, newEnemyPosition);
                }
            }
            else if (input.Key == ConsoleKey.S)
            {
                int newY = position.y + 1;
                int newEnemyY = enemy.position.y + 1;
                Point2D newPosition = new Point2D(position.x, newY);
                Point2D newEnemyPosition = new Point2D(enemy.position.x, newEnemyY);
                Move(map, position, newPosition);
                if (gaveDamage)
                {
                    enemy.Move(map, enemy.position, newEnemyPosition);
                }
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }
        }

        public Player(Enemy enemy, Map map, int health) : base(health)
        {
            this.enemy = enemy;
            this.map = map;
            this.position.x = 3;
            this.position.y = 3;
            //Console.WriteLine("Player Class Constructed");
        }
    }
}
