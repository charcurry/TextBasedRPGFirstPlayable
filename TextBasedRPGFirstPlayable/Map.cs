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
        static char wallTile = '^';
        #endregion

        #region Border Offset
        static int borderOffset = 1;
        #endregion

        #region Map
        static string path = @"map.txt";
        static string[] mapRows = File.ReadAllLines(path);
        #endregion

        #region Map Axis Lengths
        static int mapXLength = mapRows[0].Length;
        static int mapYLength = mapRows.Length;
        #endregion

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
                    if (cursory - borderOffset > 0)
                    {
                        nextTileUp = mapRows[cursory - 1 - borderOffset][cursorx - borderOffset];
                    }
                    if (mapRows.Length - 1 > cursory - borderOffset)
                    {
                        nextTileDown = mapRows[cursory + 1 - borderOffset][cursorx - borderOffset];
                    }
                    if (cursorx - borderOffset > 0)
                    {
                        nextTileLeft = mapRows[cursory - borderOffset][cursorx - 1 - borderOffset];
                    }
                    if (cursorx - borderOffset < mapRow.Length - 1)
                    {
                        nextTileRight = mapRows[cursory - borderOffset][cursorx + 1 - borderOffset];
                    }
                    if (enemyCursory - borderOffset > 0)
                    {
                        enemyNextTileUp = mapRows[enemyCursory - 1 - borderOffset][enemyCursorx - borderOffset];
                    }
                    if (mapRows.Length - 1 > enemyCursory - borderOffset)
                    {
                        enemyNextTileDown = mapRows[enemyCursory + 1 - borderOffset][enemyCursorx - borderOffset];
                    }
                    if (enemyCursorx - borderOffset > 0)
                    {
                        enemyNextTileLeft = mapRows[enemyCursory - borderOffset][enemyCursorx - 1 - borderOffset];
                    }
                    if (enemyCursorx - borderOffset < mapRow.Length - 1)
                    {
                        enemyNextTileRight = mapRows[enemyCursory - borderOffset][enemyCursorx + 1 - borderOffset];
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
