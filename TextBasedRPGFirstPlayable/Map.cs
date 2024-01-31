using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

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
        static readonly string[] mapRows = File.ReadAllLines(path);
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

        private List<Entity> entities = new List<Entity>();

        public Map(List<Entity> initialEntities)
        {
            entities.AddRange(initialEntities);
        }

        public void AddEntity(Entity entity, Point2D position)
        {
            entities.Add(entity);
            entity.position = position;
        }

        public void RemoveEntity(Point2D position)
        {
            foreach (var entity in GetEntities())
            {
                if (entity.position.y == position.y && entity.position.x == position.x)
                {
                    entities.Remove(entity);
                }
            }
        }

        public Entity GetEntity(Point2D position)
        {
            foreach (var entity in GetEntities())
            {
                if (entity.position.y == position.y && entity.position.x == position.x)
                {
                    return entity;
                }
            }
            return null;
        }

        public List<Entity> GetEntities()
        {
            return entities;
        }

        public Map()
        {
            //mapPlayer = player;
            //mapEnemy = enemy;
            //Console.WriteLine("Player Class Constructed");
        }

        public void RenderMap()
        {
            Console.SetCursorPosition(0, 0);


            //Console.Write('+');
            for (int i = 0; i < mapXLength; i++)
            {
                //Console.Write('-');
            }
            //Console.Write('+');
            //Console.WriteLine();
            for (int y = 0; y < mapRows.Length; y++)
            {
                //Console.Write('|');
                string mapRow = mapRows[y];
                for (int x = 0; x < mapRow.Length; x++)
                {
                    char tile = mapRow[x];
                    Console.Write(tile);

                }
                //Console.Write('|');
                Console.WriteLine();
            }
            //Console.Write('+');
            for (int i = 0; i < mapXLength; i++)
            {
                //Console.Write('-');
            }
            //Console.Write('+');
            Console.WriteLine();
        }

        public char GetTile(Point2D coords)
        {
            return mapRows[coords.y][coords.x];
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

        public void ShowHUD(Player player, Enemy enemy)
        {
            RenderLegend();
            RenderHealth(player, enemy);
        }
    }
}
