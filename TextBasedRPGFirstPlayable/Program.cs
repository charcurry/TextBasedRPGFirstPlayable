using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGFirstPlayable
{
    internal class Program
    {
        static Map map = new Map(enemy, player);
        static Enemy enemy = new Enemy(player, map, 50);
        static Player player = new Player(enemy, map, 100);
        static void Main(string[] args)
        {

            
            Console.CursorVisible = false;
            map.RenderMap();
            map.ShowHUD(player, enemy);
            while (!player.gameOver)
            {
                if (!player.playerDead)
                {
                    player.PlayerDraw(player.playerCursor.x, player.playerCursor.y);
                }
                if (!enemy.enemyDead)
                {
                    enemy.EnemyDraw(enemy.enemyCursor.x, enemy.enemyCursor.y);
                }
                if (!player.playerDead)
                {
                    player.PlayerUpdate();
                }
                if (!enemy.enemyDead)
                {
                    if (!enemy.enemyWasAttacked)
                    {
                        enemy.EnemyUpdate();
                    }
                    enemy.enemyWasAttacked = false;
                }
                map.RenderMap();
                map.ShowHUD(player, enemy);
            }
            if (player.playerVictory)
            {
                RenderTextScreen("Victory");
            }
            if (player.playerDead)
            {
                RenderTextScreen("Game Over");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void RenderTextScreen(string displayText)
        {
            Console.Clear();
            Console.WriteLine(displayText);
        }
    }
}
