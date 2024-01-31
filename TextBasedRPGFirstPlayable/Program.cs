using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class Program
    {
        static Map map = new Map();
        static Enemy enemy = new Enemy(map, 50);
        static Player player = new Player(map, 100);

        static void Main(string[] args)
        {
            map.AddEntity(player, player.position);
            map.AddEntity(enemy, enemy.position);
            map.GetEntities();
            Console.CursorVisible = false;
            map.RenderMap();
            map.ShowHUD(player, enemy);
            while (!player.gameOver)
            {
                if (!player.healthSystem.isDead)
                {
                    player.PlayerDraw();
                }
                if (!enemy.healthSystem.isDead)
                {
                    enemy.EnemyDraw(enemy.position.x, enemy.position.y);
                }
                if (!player.healthSystem.isDead)
                {
                    player.PlayerUpdate();
                }
                if (!enemy.healthSystem.isDead)
                {
                    if (!enemy.enemyWasAttacked)
                    {
                        enemy.EnemyUpdate();
                    }
                    enemy.enemyWasAttacked = false;
                }
                map.RenderMap();
                map.ShowHUD(player, enemy);
                if (player.playerVictory)
                {
                    RenderTextScreen("Victory");
                }
                if (player.playerDead)
                {
                    RenderTextScreen("Game Over");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            void RenderTextScreen(string displayText)
            {
                Console.Clear();
                Console.WriteLine(displayText);
            }
        }
    }
}
