using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class Program
    {
        static Player Hero;
        static Enemy Badman1;
        static Enemy Badman2;
        static Item money1;
        static Item money2;
        static Item potion1;
        static Item potion2;
        static Item trap;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            BuildMap buildMap = new BuildMap();
            HUD hUD = new HUD();
            GameLog log = new GameLog();
            Random random = new Random(); // makes sure that the enemies have different health amounts
            Hero = new Player();
            Badman1 = new Enemy(random);
            Badman2 = new Enemy(random);
            money1 = new Item();
            money2 = new Item();
            potion1 = new Item();
            potion2 = new Item();
            trap = new Item();

            Hero.character = 'H';
            Badman1.character = 'E';
            Badman2.character = 'E';


            //Initializing
            buildMap.MapInit();
            hUD.Init(Hero,Badman1,Badman2,money1,money2);
            log.Init(Hero, Badman1,Badman2,money1,money2, potion1, potion2, trap);
            Hero.Init(buildMap, Badman1, Badman2,money1,money2, potion1, potion2, trap);
            Badman1.Init(buildMap, Hero, trap);
            Badman2.Init(buildMap, Hero, trap);


            //positions of GameObjects
            Hero.pos = new Point2D { x = 4, y = 4 };
            Badman1.pos = new Point2D { x = 4, y = 18 };
            Badman2.pos = new Point2D { x = 32, y = 8 };
            money1.pos = new Point2D { x = 6, y = 8 };
            money2.pos = new Point2D { x = 30, y = 18 };
            potion1.pos = new Point2D { x = 25, y = 4 };
            potion2.pos = new Point2D { x = 15, y = 10 };
            trap.pos = new Point2D { x = 25, y = 13 };


            while (!isGameOver())
            {
                WriteTitle();
                hUD.ShowHUD();
                buildMap.DrawMap(Hero, Badman1, Badman2, money1, money2, potion1, potion2, trap);
                buildMap.DisplayLegend();
                log.PrintGameLog();
                Hero.PlayerMovement();
                Badman1.EnemyMovement();
                Badman2.EnemyMovement();
            }

            WriteTitle();
            hUD.ShowHUD();
            buildMap.DrawMap(Hero, Badman1, Badman2, money1, money2, potion1, potion2, trap);
            buildMap.DisplayLegend();
            log.PrintGameLog();

            if (Hero.PlayerDied())
                Console.WriteLine("Player has died, press any key to exit");
            else
                Console.WriteLine("Player has won! Press any key to exit");

            Console.ReadKey();
        }

        static bool isGameOver()
        {
            return Hero.PlayerWon() || Hero.PlayerDied();
        }

        static void WriteTitle()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("Text Based RPG 2024");
            Console.WriteLine();
        }
    }
}
