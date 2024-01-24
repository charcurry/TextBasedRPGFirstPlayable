using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class Enemy : Entity
    {
        #region Enemy Cursor Position
        public Point2D enemyCursor = new Point2D(10, 16);
        #endregion

        #region Enemy Death
        public bool enemyDead = false;
        #endregion

        #region Enemy was Attacked Check
        public bool enemyWasAttacked;
        #endregion

        public Enemy(int health) : base(health)
        {
            Console.WriteLine("Enemy Class Constructed");
        }

        public void EnemyDraw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("G");
        }

        public void EnemyUpdate()
        {
            Random random = new Random();
            int direction = random.Next(0, 4);
            if (player.playerDead)
            {
                player.gameOver = true;
            }
            else if (enemyCursor.x - 1 == cursorx)
            {
                direction = 0;
            }
            else if (enemyCursor.x + 1 == cursorx)
            {
                direction = 3;
            }
            else if (enemyCursor.y - 1 == cursory)
            {
                direction = 2;
            }
            else if (enemyCursor.y + 1 == cursory)
            {
                direction = 1;
            }
            if (!enemyDead)
            {
                switch (direction)
                {
                    case 0:
                        enemyCursor.x--;
                        if (enemyCursor.x < 1) enemyCursor.x = 1;
                        else if (Map.CheckForWall(enemyNextTileLeft, wallTile)) enemyCursor.x++;
                        else if (enemyCursor.x == cursorx && enemyCursor.y == cursory)
                        {
                            PlayerTakeDamage(1);
                            enemyCursor.x++;
                            cursorx--;
                            if (Map.CheckForWall(nextTileLeft, wallTile) || cursorx < 1)
                            {
                                cursorx++;
                            }
                        }
                        break;
                    case 1:
                        enemyCursor.y++;
                        if (enemyCursor.y > mapYLength) enemyCursor.y = mapYLength;
                        else if (Map.CheckForWall(enemyNextTileDown, wallTile)) enemyCursor.y--;
                        else if (enemyCursor.x == cursorx && enemyCursory == cursory)
                        {
                            PlayerTakeDamage(1);
                            enemyCursor.y--;
                            cursory++;
                            if (Map.CheckForWall(nextTileDown, wallTile) || cursory > mapYLength)
                            {
                                cursory--;
                            }
                        }
                        break;
                    case 2:
                        enemyCursor.y--;
                        if (enemyCursory < 1) enemyCursor.y = 1;
                        else if (Map.CheckForWall(enemyNextTileUp, wallTile)) enemyCursor.y++;
                        else if (enemyCursor.x == cursorx && enemyCursor.y == cursory)
                        {
                            PlayerTakeDamage(1);
                            enemyCursor.y++;
                            cursory--;
                            if (Map.CheckForWall(nextTileUp, wallTile) || cursory < 1)
                            {
                                cursory++;
                            }
                        }
                        break;
                    case 3:
                        enemyCursor.x++;
                        if (enemyCursor.x > mapXLength) enemyCursor.x = mapXLength;
                        else if (Map.CheckForWall(enemyNextTileRight, wallTile)) enemyCursor.x--;
                        else if (enemyCursor.x == cursorx && enemyCursory == cursory)
                        {
                            PlayerTakeDamage(1);
                            enemyCursor.x--;
                            cursorx++;
                            if (Map.CheckForWall(nextTileRight, wallTile) || cursorx > mapXLength)
                            {
                                cursorx--;
                            }
                        }
                        break;
                }
            }
        }
    }
}
