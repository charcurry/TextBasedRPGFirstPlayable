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

        #region Player Cursor Positions
        public Point2D playerCursor = new Point2D(10, 10);
        #endregion

        public void PlayerDraw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("@");
        }

        Map playerMap;
        Enemy playerEnemy;

        public void PlayerUpdate()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                playerCursor.y--;
                if (playerCursor.y < 1) playerCursor.y = 1;
                else if (playerMap.CheckForWall(playerMap.nextTileUp, playerMap.wallTile)) playerCursor.y++;
                else if (playerEnemy.enemyCursor.x == playerCursor.x && playerEnemy.enemyCursor.y == playerCursor.y)
                {
                    healthSystem.TakeDamage(1);
                    playerCursor.y++;
                    playerEnemy.enemyCursor.y--;
                    if (playerMap.CheckForWall(playerMap.enemyNextTileUp, playerMap.wallTile) || playerEnemy.enemyCursor.y < 1) playerEnemy.enemyCursor.y++;
                    playerEnemy.enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.A)
            {
                playerCursor.x--;
                if (playerCursor.x < 1) playerCursor.x = 1;
                else if (playerMap.CheckForWall(playerMap.nextTileLeft, playerMap.wallTile)) playerCursor.x++;
                else if (playerEnemy.enemyCursor.x == playerCursor.x && playerEnemy.enemyCursor.y == playerCursor.y)
                {
                    healthSystem.TakeDamage(1);
                    playerCursor.x++;
                    playerEnemy.enemyCursor.x--;
                    if (playerMap.CheckForWall(playerMap.enemyNextTileLeft, playerMap.wallTile) || playerEnemy.enemyCursor.x < 1) playerEnemy.enemyCursor.x++;
                    playerEnemy.enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.D)
            {
                playerCursor.x++;
                if (playerCursor.x > playerMap.mapXLength) playerCursor.x = playerMap.mapXLength;
                else if (playerMap.CheckForWall(playerMap.nextTileRight, playerMap.wallTile)) playerCursor.x--;
                else if (playerEnemy.enemyCursor.x == playerCursor.x && playerEnemy.enemyCursor.y == playerCursor.y)
                {
                    healthSystem.TakeDamage(1);
                    playerCursor.x--;
                    playerEnemy.enemyCursor.x++;
                    if (playerMap.CheckForWall(playerMap.enemyNextTileRight, playerMap.wallTile) || playerEnemy.enemyCursor.x > playerMap.mapXLength) playerEnemy.enemyCursor.x--;
                    playerEnemy.enemyWasAttacked = true;
                }
            }
            else if (input.Key == ConsoleKey.S)
            {
                playerCursor.y++;
                if (playerCursor.y > playerMap.mapYLength) playerCursor.y = playerMap.mapYLength;
                else if (playerMap.CheckForWall(playerMap.nextTileDown, playerMap.wallTile)) playerCursor.y--;
                else if (playerEnemy.enemyCursor.x == playerCursor.x && playerEnemy.enemyCursor.y == playerCursor.y)
                {
                    healthSystem.TakeDamage(1);
                    playerCursor.y--;
                    playerEnemy.enemyCursor.y++;
                    if (playerMap.CheckForWall(playerMap.enemyNextTileDown, playerMap.wallTile) || playerEnemy.enemyCursor.y > playerMap.mapYLength) playerEnemy.enemyCursor.y--;
                    playerEnemy.enemyWasAttacked = true;
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

        public Player(Enemy enemy, Map map, int health) : base(health)
        {
            playerEnemy = enemy;
            playerMap = map;
            Console.WriteLine("Player Class Constructed");
        }
    }
}
