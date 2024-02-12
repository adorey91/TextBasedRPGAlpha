using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class GameManager
    {
        public Player Hero;
        public RangedEnemy Ranger;
        public BuildMap buildMap;
        public HUD hUD;
        public GameLog log;

        public GameManager()
        {

        }

        public void Gameplay()
        {
            //Initializing
            buildMap.MapInit();
            InitPositions();


            while (!isGameOver())
            {
                WriteTitle();
                hUD.ShowHUD();
            }

            WriteTitle();
            hUD.ShowHUD();
            log.PrintGameLog();

            if (Hero.PlayerDied())
                Console.WriteLine("Player has died, press any key to exit");
            else
                Console.WriteLine("Player has won! Press any key to exit");

            Console.ReadKey();

        }


        public bool isGameOver()
        {
            return Hero.PlayerWon() || Hero.PlayerDied();
        }

        private void WriteTitle()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.WriteLine("Text Based RPG Alpha");
            Console.WriteLine();
        }

        private void InitPositions()
        {
            Hero.pos = new Point2D { x = 4, y = 4 };
            Ranger.pos = new Point2D { x = 4, y = 18 };
        }
    }
}