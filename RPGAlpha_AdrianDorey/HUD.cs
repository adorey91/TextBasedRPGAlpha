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
        public MeleeEnemy[] Slime;
        public Money[] money;
        public BuildMap buildMap;

        public void Init(Player Hero, RangedEnemy[] Rangers,MageEnemy[] Mages, MeleeEnemy[] Slime, Money[] money, BuildMap buildMap)
        {
            this.Hero = Hero;

            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slime = Slime;
            this.money = money;
            this.buildMap = buildMap;
        }
        
        public void ShowHUD()   // handles hud output
        {
            Console.Write("+--------------------------+ \n");
            Console.Write("Hero Health: " + Hero.healthSystem.health + "\n");
            if(buildMap.mapLevel == 0)
            {
                Console.Write("Ranger0 Health: " + Rangers[0].healthSystem.health + "\n");
                Console.Write("Ranger1 Health: " + Rangers[1].healthSystem.health + "\n");
            }
            if(buildMap.mapLevel == 1)
            {
                Console.Write("Ranger2 Health: " + Rangers[2].healthSystem.health + "\n");
                Console.Write("Mage0 Health: " + Mages[0].healthSystem.health + "\n");
                Console.Write("Mage1 Health: " + Mages[1].healthSystem.health + "\n");
            }
            if(buildMap.mapLevel == 2)
            {
                Console.Write("Mage2 Health: " + Mages[2].healthSystem.health + "\n");
                Console.Write("Slime0 Health: " + Slime[0].healthSystem.health + "\n");
                Console.Write("Slime1 Health: " + Slime[1].healthSystem.health + "\n");
                Console.Write("Slime2 Health: " + Slime[2].healthSystem.health + "\n");
            }
            Console.Write("Item Picked Up: ");

            foreach(Money money in money)
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
        }
    }
}
