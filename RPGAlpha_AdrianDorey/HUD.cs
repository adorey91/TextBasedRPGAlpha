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
        public Enemy Badman1;
        public Enemy Badman2;
        public Item money1;
        public Item money2;

        public void Init(Player Hero, Enemy Badman1, Enemy Badman2, Item money1, Item money2)
        {
            this.Hero = Hero;
            this.Badman1 = Badman1;
            this.Badman2 = Badman2;
            this.money1 = money1;
            this.money2 = money2;
        }
        
        public void ShowHUD()   // handles hud output
        {
            Console.WriteLine("++++++++++++++++++++++++++++");
            Console.WriteLine("Hero Health: " + Hero.healthSystem.health);
            Console.WriteLine("Badman1 Health: " + Badman1.healthSystem.health);
            Console.WriteLine("Badman2 Health: " + Badman2.healthSystem.health);
            Console.Write("Item Picked Up: ");

            if (money1.collected == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money1.moneyChar);
                Console.ResetColor();
            }

            Console.Write(' ');

            if (money2.collected == true)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(money2.moneyChar);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++");
            Console.WriteLine();
        }
    }
}
