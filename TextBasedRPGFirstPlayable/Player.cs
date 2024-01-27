using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    public class Player : Entity
    {

        #region GameOver States
        public bool gameOver = false;
        public bool playerVictory = false;
        #endregion

        #region Player Death
        public bool playerDead = false;
        #endregion

        #region Player Cursor Positions
        public Point2D playerCursor = new Point2D(10, 10);
        #endregion

        public void PlayerDraw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("@");
        }

        public void PlayerUpdate()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                playerCursor.y--;
                if (playerCursor.y < 1) playerCursor.y = 1;
                else if (Map.CheckForWall(nextTileUp, wallTile)) playerCursor.y++;
                else if (enemyCursorx == playerCursor.x && enemyCursory == playerCursor.y)
                {
                    EnemyTakeDamage(1);
                    playerCursor.y++;
                    enemyCursory--;
                    if (Map.CheckForWall(enemyNextTileUp, wallTile) || enemyCursory < 1) enemyCursory++;
                    enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.A)
            {
                playerCursor.x--;
                if (playerCursor.x < 1) playerCursor.x = 1;
                else if (Map.CheckForWall(nextTileLeft, wallTile)) playerCursor.x++;
                else if (enemyCursorx == playerCursor.x && enemyCursory == playerCursor.y)
                {
                    EnemyTakeDamage(1);
                    playerCursor.x++;
                    enemyCursorx--;
                    if (Map.CheckForWall(enemyNextTileLeft, wallTile) || enemyCursorx < 1) enemyCursorx++;
                    enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.D)
            {
                playerCursor.x++;
                if (playerCursor.x > mapXLength) playerCursor.x = mapXLength;
                else if (Map.CheckForWall(nextTileRight, wallTile)) playerCursor.x--;
                else if (enemyCursorx == playerCursor.x && enemyCursory == playerCursor.y)
                {
                    EnemyTakeDamage(1);
                    playerCursor.x--;
                    enemyCursorx++;
                    if (Map.CheckForWall(enemyNextTileRight, wallTile) || enemyCursorx > mapXLength) enemyCursorx--;
                    enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.S)
            {
                playerCursory++;
                if (playerCursory > mapYLength) playerCursory = mapYLength;
                else if (Map.CheckForWall(nextTileDown, wallTile)) playerCursor.y--;
                else if (enemyCursorx == playerCursor.x && enemyCursory == playerCursor.y)
                {
                    EnemyTakeDamage(1);
                    playerCursor.y--;
                    enemyCursory++;
                    if (Map.CheckForWall(enemyNextTileDown, wallTile) || enemyCursory > mapYLength) enemyCursory--;
                    enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            if (playerDead)
            {
                gameOver = true;
            }
        }

        public Player(int health) : base(health)
        {
            Console.WriteLine("Player Class Constructed");
        }
    }
}
