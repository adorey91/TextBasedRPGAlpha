using System;
using System.Linq;

namespace RPGAlpha_AdrianDorey
{
    internal class GameManager
    {
        public Player Hero;
        public RangedEnemy[] Rangers = new RangedEnemy[3];
        public MageEnemy[] Mages = new MageEnemy[3];
        public MeleeEnemy[] Slime = new MeleeEnemy[3];
        public Potions[] potion = new Potions[4];
        public Money[] money = new Money[4];
        public Traps[] traps = new Traps[3];
        public MapLegendColours legendColours;
        public MapPositions mapPositions;
        public BuildMap buildMap;
        public HUD hUD;
        public GameLog log;
        public bool gameOver = false;
        Random random = new();

        public GameManager()
        {
            Hero = new Player();
            for (int i = 0; i < 3; i++)
            {
                Rangers[i] = new RangedEnemy(random);
                Mages[i] = new MageEnemy(random);
                Slime[i] = new MeleeEnemy(random);
            }
            for (int i = 0; i < potion.Length; i++)
                potion[i] = new Potions();
            for (int i = 0; i < money.Length; i++)
                money[i] = new Money();
            for (int i = 0; i < traps.Length; i++)
                traps[i] = new Traps();

            legendColours = new MapLegendColours(Hero, Rangers[0], Mages[0], Slime[0], money[0], traps[0], potion[0]);
            buildMap = new BuildMap();
            mapPositions = new MapPositions(Hero, Rangers, Mages, Slime, potion, money, traps, buildMap);
            hUD = new HUD();
            log = new GameLog();
        }

        public void Gameplay()
        {
            //Initializing
            hUD.Init(Hero, Rangers, Mages, Slime, money, buildMap);
            buildMap.Init(legendColours, Hero, Rangers, Mages, Slime, potion, money, traps);
            buildMap.MapInit();
            mapPositions.InitializeCharacterPositions();
            Hero.Init(buildMap, Rangers, Mages, Slime, money, potion, traps);
            log.Init(Hero, Rangers, Mages, Slime, money, potion, traps);
            for (int i = 0; i < 3; i++)
            {
                Rangers[i].EnemyInit(Hero, buildMap, traps, log);
                Mages[i].EnemyInit(Hero, buildMap, traps, log);
                Slime[i].EnemyInit(Hero, buildMap, traps, log);
            }
            TutorialText();

            while (!gameOver)
            {
                buildMap.CheckMapChange();
                WriteGameToScreen();

                //movement
                Hero.PlayerMovement();

                switch (buildMap.mapLevel)
                {
                    case 0:
                        Rangers[0].RangerMovement();
                        Rangers[1].RangerMovement();
                        break;
                    case 1:
                        Rangers[2].RangerMovement();
                        Mages[0].MageMovement();
                        Mages[1].MageMovement();
                        break;
                    case 2:
                        Mages[2].MageMovement();
                        Slime[0].MeleeMovement();
                        Slime[1].MeleeMovement();
                        Slime[2].MeleeMovement();
                        break;
                }
                CheckGameOver();
            }
            
            WriteGameToScreen();

            if (!Hero.healthSystem.dead)
                Console.WriteLine(Hero.name + " has won! Press enter to exit");
            else
                Console.WriteLine(Hero.name + " has died, press enter to exit");

            ConsoleKeyInfo input = Console.ReadKey();
            while(input.Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Press Enter");
                input = Console.ReadKey();
            }
                System.Environment.Exit(0);

        }

        public void CheckGameOver()
        {
            if (AreAllEnemiesDead(Rangers) && AreAllEnemiesDead(Mages) && AreAllEnemiesDead(Slime) && IsMoneyColleceted(money))
                gameOver = true;
            if (Hero.healthSystem.dead)
                gameOver = true;
        }

        private bool AreAllEnemiesDead<T>(T[] enemies) where T : Enemy
        {
            return enemies.All(enemy => enemy.healthSystem.mapDead);
        }

        private bool IsMoneyColleceted<T>(T[] money) where T : Item
        {
            return money.All(money => money.collected);
        }

        private void WriteGameToScreen()
        {
            Console.SetWindowSize(80, 50);
            Console.CursorVisible = false;
            
            Console.Clear(); // Clear the console before updating the text
            Console.SetCursorPosition(0, 0);
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(200));


            Console.Write("Text Based RPG Alpha \n");
            hUD.ShowHUD();
            buildMap.DrawMap();
            legendColours.DisplayLegend();
            log.PrintGameLog();
        }

        private void TutorialText()
        {
            Console.SetWindowSize(80, 50);
            Console.CursorVisible = false;

            Console.Write("Text Based RPG Alpha \n");
            Console.WriteLine();
            Console.WriteLine("Move:");
            DisplaySymbolsInColumns("Up   ", "W");
            DisplaySymbolsInColumns("Up-Left", "Q");
            Console.WriteLine();
            DisplaySymbolsInColumns("Down ", "S");
            DisplaySymbolsInColumns("Up-Right", "E");
            Console.WriteLine();
            DisplaySymbolsInColumns("Left ", "A");
            DisplaySymbolsInColumns("Down-Left", "Z");
            Console.WriteLine();
            DisplaySymbolsInColumns("Right", "D");
            DisplaySymbolsInColumns("Down-Right", "C");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }

        private void DisplaySymbolsInColumns(string direction, string description)
        {
            Console.Write($"{direction} = {description}");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(" ");
            }
        }
    }
}