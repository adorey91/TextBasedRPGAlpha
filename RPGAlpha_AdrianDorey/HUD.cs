using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class HUD
    {
        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slimes;
        public Item[] Money;
        public BuildMap buildMap;

        public void Init(Player Hero, RangedEnemy[] Rangers,MageEnemy[] Mages, MeleeEnemy[] Slimes, Item[] Money, BuildMap buildMap)
        {
            this.Hero = Hero;

            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slimes = Slimes;
            this.Money = Money;
            this.buildMap = buildMap;
        }
        
        public void ShowHUD()   // handles hud output
        {
            Console.WriteLine("+--------------------------+");
            Console.WriteLine("Hero Health: " + Hero.healthSystem.health);
            if(buildMap.mapLevel == 0)
            {
                Console.WriteLine("Ranger0 Health: " + Rangers[0].healthSystem.health);
                Console.WriteLine("Ranger1 Health: " + Rangers[1].healthSystem.health);
            }
            if(buildMap.mapLevel == 1)
            {
                Console.WriteLine("Ranger2 Health: " + Rangers[2].healthSystem.health);
                Console.WriteLine("Mage0 Health: " + Mages[0].healthSystem.health);
                Console.WriteLine("Mage1 Health: " + Mages[1].healthSystem.health);
            }
            if(buildMap.mapLevel == 2)
            {
                Console.WriteLine("Mage2 Health: " + Mages[2].healthSystem.health);
                Console.WriteLine("Slime0 Health: " + Slimes[0].healthSystem.health);
                Console.WriteLine("Slime1 Health: " + Slimes[1].healthSystem.health);
                Console.WriteLine("Slime2 Health: " + Slimes[2].healthSystem.health);
            }
            Console.Write("Item Picked Up: ");

            foreach(Money money in Money)
            {
                if(money.collected)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(money.character);
                    Console.ResetColor();
                    Console.Write(' ');
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("+--------------------------+");
            Console.WriteLine();
        }
    }
}
