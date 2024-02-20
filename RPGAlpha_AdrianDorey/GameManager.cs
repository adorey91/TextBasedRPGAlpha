using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPGAlpha_AdrianDorey
{
    internal class GameManager
    {
        public Player Hero;
        public RangedEnemy[] Rangers = new RangedEnemy[3];
        public MageEnemy[] Mages = new MageEnemy[3];
        public MeleeEnemy[] Slimes = new MeleeEnemy[3];
        public Potion[] potion = new Potion[4];
        public Money[] money = new Money[4];
        public Traps[] traps = new Traps[3];
        public MapLegendColours legendColours;
        public MapPositions mapPositions;
        public BuildMap buildMap;
        public HUD hUD;
        public GameLog log;
        public bool gameOver = false;

        public GameManager()
        {
            Hero = new Player();
            for (int i = 0; i < 3; i++)
            {
                Rangers[i] = new RangedEnemy();
                Mages[i] = new MageEnemy();
                Slimes[i] = new MeleeEnemy();
            }
            for (int i = 0; i< potion.Length; i++)
                potion[i] = new Potion();
            for (int i = 0;i< money.Length; i++)
                money[i] = new Money();
            for (int i = 0; i < traps.Length; i++)
                traps[i] = new Traps();

            legendColours = new MapLegendColours(Hero, Rangers[0], Mages[0], Slimes[0], money[0], traps[0], potion[0]);
            buildMap = new BuildMap(legendColours, Hero, Rangers, Mages, Slimes, potion, money, traps);
            mapPositions = new MapPositions(Hero, Rangers, Mages, Slimes, potion, money, traps, buildMap);

            hUD = new HUD();
            log = new GameLog();
        }

        public void Gameplay()
        {
            
            //Initializing
            hUD.Init(Hero, Rangers,Mages,Slimes, money, buildMap);
            buildMap.MapInit();
            
            mapPositions.InitializeCharacterPositions();
            Hero.Init(buildMap, Rangers, Mages, money, potion);


            Rangers[0].EnemyInit(Hero);
            Rangers[1].EnemyInit(Hero);
            Rangers[2].EnemyInit(Hero);
            Mages[0].EnemyInit(Hero);
            Mages[1].EnemyInit(Hero);
            Mages[2].EnemyInit(Hero);
            

            while (!gameOver)
            {
                WriteTitle();
                hUD.ShowHUD();
                buildMap.DrawMap();
                legendColours.DisplayLegend();

                //movement
                Hero.PlayerMovement();
                //if (buildMap.mapLevel == 0)
                //{
                //    Rangers[0].RangerMovement();
                //    Rangers[1].RangerMovement();
                //}
                //if (buildMap.mapLevel == 1)
                //{
                //    Rangers[2].RangerMovement();
                //    Mages[0].MageMovement();
                //    Mages[1].MageMovement();
                //}
                //if(buildMap.mapLevel == 2)
                //{
                //    Mages[2].MageMovement();
                //}

                //log.PrintGameLog();

                //if (Hero.PlayerDied())
                //    Console.WriteLine("Player has died, press any key to exit");
                //else
                //    Console.WriteLine("Player has won! Press any key to exit");
                //if (input.Key == ConsoleKey.D1)
                //    buildMap.mapLevel = 1;
                //if(input.Key == ConsoleKey.D2)
                //    buildMap.mapLevel = 2;
                //if( input.Key == ConsoleKey.D3)
                //    buildMap.mapLevel = 0;
            }
        }

        public void CheckGameOver()
        {
            if(AreAllEnemiesDead(Rangers) && AreAllEnemiesDead(Mages) && AreAllEnemiesDead(Slimes) && IsMoneyColleceted(money))
                gameOver = true;
        }

        private bool AreAllEnemiesDead<T>(T[] enemies) where T : Enemy
        {
            return enemies.All(enemy => enemy.healthSystem.dead);
        }

        private bool IsMoneyColleceted<T>(T[] money) where T : Item
        {
            return money.All(money => money.collected);
        }

        private void WriteTitle()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("Text Based RPG Alpha");
        }
    }
}