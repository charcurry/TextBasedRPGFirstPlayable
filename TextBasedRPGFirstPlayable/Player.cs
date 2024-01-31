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
                Point2D newPosition = new Point2D(position.x, newY);
                Move(map, position, newPosition);
            }
            else if (input.Key == ConsoleKey.A)
            {
                int newX = position.x - 1;
                Point2D newPosition = new Point2D(newX, position.y);
                Move(map, position, newPosition);
            }
            else if (input.Key == ConsoleKey.D)
            {
                int newX = position.x + 1;
                Point2D newPosition = new Point2D(newX, position.y);
                Move(map, position, newPosition);
            }
            else if (input.Key == ConsoleKey.S)
            {
                int newY = position.y + 1;
                Point2D newPosition = new Point2D(position.x, newY);
                Move(map, position, newPosition);
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            if (this.healthSystem.isDead)
            {
                playerDead = true;
                gameOver = true;
            }
        }

        public Player(Map map, int health) : base(health)
        {
            this.map = map;
            this.position.x = 1;
            this.position.y = 1;
            //Console.WriteLine("Player Class Constructed");
        }
    }
}
