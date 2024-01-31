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

        //public Point2D enemyCursor = new Point2D(10, 16);

        #endregion

        #region Enemy Death
        public bool enemyDead = false;
        #endregion

        #region Enemy was Attacked Check
        public bool enemyWasAttacked;
        #endregion

        readonly Map enemyMap;

        public Enemy(Map map, int health) : base(health)
        {
            enemyMap = map;
            this.position.y = 10;
            this.position.x = 16;
            //Console.WriteLine("Enemy Class Constructed");
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
            //if (enemyPlayer.playerDead)
            //{
            //    enemyPlayer.gameOver = true;
            //}
            //else if (enemyCursor.x - 1 == enemyPlayer.playerCursor.x)
            //{
            //    direction = 0;
            //}
            //else if (enemyCursor.x + 1 == enemyPlayer.playerCursor.x)
            //{
            //    direction = 3;
            //}
            //else if (enemyCursor.y - 1 == enemyPlayer.playerCursor.y)
            //{
            //    direction = 2;
            //}
            //else if (enemyCursor.y + 1 == enemyPlayer.playerCursor.y)
            //{
            //    direction = 1;
            //}
            //if (!enemyDead)
            //{
            //    switch (direction)
            //    {
            //        case 0:
            //            enemyCursor.x--;
            //            if (enemyCursor.x < 1) enemyCursor.x = 1;
            //            else if (enemyMap.CheckForWall(enemyMap.enemyNextTileLeft, enemyMap.wallTile)) enemyCursor.x++;
            //            else if (enemyCursor.x == enemyPlayer.playerCursor.x && enemyCursor.y == enemyPlayer.playerCursor.y)
            //            {
            //                healthSystem.TakeDamage(1);
            //                enemyCursor.x++;
            //                enemyPlayer.playerCursor.x--;
            //                if (enemyMap.CheckForWall(enemyMap.nextTileLeft, enemyMap.wallTile) || enemyPlayer.playerCursor.x < 1)
            //                {
            //                    enemyPlayer.playerCursor.x++;
            //                }
            //            }
            //            break;
            //        case 1:
            //            enemyCursor.y++;
            //            if (enemyCursor.y > enemyMap.mapYLength) enemyCursor.y = enemyMap.mapYLength;
            //            else if (enemyMap.CheckForWall(enemyMap.enemyNextTileDown, enemyMap.wallTile)) enemyCursor.y--;
            //            else if (enemyCursor.x == enemyPlayer.playerCursor.x && enemyCursor.y == enemyPlayer.playerCursor.y)
            //            {
            //                healthSystem.TakeDamage(1);
            //                enemyCursor.y--;
            //                enemyPlayer.playerCursor.y++;
            //                if (enemyMap.CheckForWall(enemyMap.nextTileDown, enemyMap.wallTile) || enemyPlayer.playerCursor.y > enemyMap.mapYLength)
            //                {
            //                    enemyPlayer.playerCursor.y--;
            //                }
            //            }
            //            break;
            //        case 2:
            //            enemyCursor.y--;
            //            if (enemyCursor.y < 1) enemyCursor.y = 1;
            //            else if (enemyMap.CheckForWall(enemyMap.enemyNextTileUp, enemyMap.wallTile)) enemyCursor.y++;
            //            else if (enemyCursor.x == enemyPlayer.playerCursor.x && enemyCursor.y == enemyPlayer.playerCursor.y)
            //            {
            //                healthSystem.TakeDamage(1);
            //                enemyCursor.y++;
            //                enemyPlayer.playerCursor.y--;
            //                if (enemyMap.CheckForWall(enemyMap.nextTileUp, enemyMap.wallTile) || enemyPlayer.playerCursor.y < 1)
            //                {
            //                    enemyPlayer.playerCursor.y++;
            //                }
            //            }
            //            break;
            //        case 3:
            //            enemyCursor.x++;
            //            if (enemyCursor.x > enemyMap.mapXLength) enemyCursor.x = enemyMap.mapXLength;
            //            else if (enemyMap.CheckForWall(enemyMap.enemyNextTileRight, enemyMap.wallTile)) enemyCursor.x--;
            //            else if (enemyCursor.x == enemyPlayer.playerCursor.x && enemyCursor.y == enemyPlayer.playerCursor.y)
            //            {
            //                healthSystem.TakeDamage(1);
            //                enemyCursor.x--;
            //                enemyPlayer.playerCursor.x++;
            //                if (enemyMap.CheckForWall(enemyMap.nextTileRight, enemyMap.wallTile) || enemyPlayer.playerCursor.x > enemyMap.mapXLength)
            //                {
            //                    enemyPlayer.playerCursor.x--;
            //                }
            //            }
            //            break;
            //    }
            //}
        }
    }
}
