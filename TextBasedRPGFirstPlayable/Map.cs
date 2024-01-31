using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextBasedRPGFirstPlayable
{
    internal class Map
    {
        #region Wall Tile Char
        public char wallTile = '^';
        #endregion

        #region Border Offset
        public int borderOffset = 1;
        #endregion

        #region Map
        static string path = @"map.txt";
        static string[] mapRows = File.ReadAllLines(path);
        #endregion

        #region Map Axis Lengths
        public int mapXLength = mapRows[0].Length;
        public int mapYLength = mapRows.Length;
        #endregion

        #region Player Surrounding Tiles Check
        public char nextTileUp;
        public char nextTileDown;
        public char nextTileLeft;
        public char nextTileRight;
        #endregion

        #region Enemy Surrounding Tiles Check
        public char enemyNextTileUp;
        public char enemyNextTileDown;
        public char enemyNextTileLeft;
        public char enemyNextTileRight;
        #endregion

        readonly Player mapPlayer;
        readonly Enemy mapEnemy;

        public Map(Enemy enemy, Player player)
        {
            mapPlayer = player;
            mapEnemy = enemy;
            Console.WriteLine("Player Class Constructed");
        }

        public void RenderMap()
        {
            Console.SetCursorPosition(0, 0);


            Console.Write('+');
            for (int i = 0; i < mapXLength; i++)
            {
                Console.Write('-');
            }
            Console.Write('+');
            Console.WriteLine();
            for (int y = 0; y < mapRows.Length; y++)
            {
                Console.Write('|');
                string mapRow = mapRows[y];
                for (int x = 0; x < mapRow.Length; x++)
                {
                    char tile = mapRow[x];
                    Console.Write(tile);
                    if (mapPlayer.playerCursor.y - borderOffset > 0)
                    {
                        nextTileUp = mapRows[mapPlayer.playerCursor.y - 1 - borderOffset][mapPlayer.playerCursor.x - borderOffset];
                    }
                    if (mapRows.Length - 1 > mapPlayer.playerCursor.y - borderOffset)
                    {
                        nextTileDown = mapRows[mapPlayer.playerCursor.y + 1 - borderOffset][mapPlayer.playerCursor.x - borderOffset];
                    }
                    if (mapPlayer.playerCursor.x - borderOffset > 0)
                    {
                        nextTileLeft = mapRows[mapPlayer.playerCursor.y - borderOffset][mapPlayer.playerCursor.x - 1 - borderOffset];
                    }
                    if (mapPlayer.playerCursor.x - borderOffset < mapRow.Length - 1)
                    {
                        nextTileRight = mapRows[mapPlayer.playerCursor.y - borderOffset][mapPlayer.playerCursor.x + 1 - borderOffset];
                    }
                    if (mapEnemy.enemyCursor.y - borderOffset > 0)
                    {
                        enemyNextTileUp = mapRows[mapEnemy.enemyCursor.y - 1 - borderOffset][mapEnemy.enemyCursor.x - borderOffset];
                    }
                    if (mapRows.Length - 1 > mapEnemy.enemyCursor.y - borderOffset)
                    {
                        enemyNextTileDown = mapRows[mapEnemy.enemyCursor.y + 1 - borderOffset][mapEnemy.enemyCursor.x - borderOffset];
                    }
                    if (mapEnemy.enemyCursor.x - borderOffset > 0)
                    {
                        enemyNextTileLeft = mapRows[mapEnemy.enemyCursor.y - borderOffset][mapEnemy.enemyCursor.x - 1 - borderOffset];
                    }
                    if (mapEnemy.enemyCursor.x - borderOffset < mapRow.Length - 1)
                    {
                        enemyNextTileRight = mapRows[mapEnemy.enemyCursor.y - borderOffset][mapEnemy.enemyCursor.x + 1 - borderOffset];
                    }
                }
                Console.Write('|');
                Console.WriteLine();
            }
            Console.Write('+');
            for (int i = 0; i < mapXLength; i++)
            {
                Console.Write('-');
            }
            Console.Write('+');
            Console.WriteLine();
        }

        static void RenderLegend()
        {
            Console.WriteLine("~ - River");
            Console.WriteLine("  - Grass");
            Console.WriteLine("A - Village");
            Console.WriteLine("^ - Mountain (Cannot Climb)");
            Console.WriteLine("* - Trees");
            Console.WriteLine();
        }

        static void RenderHealth(Player player, Enemy enemy)
        {
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemy Health: " + enemy.healthSystem.health);
            Console.WriteLine();
        }

        public bool CheckForWall(char tile, char wallTile)
        {
            if (tile == wallTile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowHUD(Player player, Enemy enemy)
        {
            RenderLegend();
            RenderHealth(player, enemy);
        }
    }
}
