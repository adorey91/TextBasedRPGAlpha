using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MapLegendColours
    {
        public Player Hero;
        public RangedEnemy Rangers;
        public MageEnemy Mage;
        public MeleeEnemy Slime;
        public Money money;
        public Traps trap;
        public Potions potion;

        public MapLegendColours(Player Hero, RangedEnemy Rangers, MageEnemy Mages, MeleeEnemy Slime, Money money, Traps trap, Potions potion)
        {
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mage = Mages;
            this.Slime = Slime;
            this.money = money;
            this.trap = trap;
            this.potion = potion;
        }
        public void DisplayLegend() // displays legend on the bottom of the map.
        {
            Console.Write("+--------------------------+" + "\n");
            Console.Write("Map Legend:" + "\n");
            DisplaySymbol(Hero.character, Hero.name);
            DisplaySymbol(Rangers.character, Rangers.name);
            DisplaySymbol(Mage.character, Mage.name);
            DisplaySymbol(Slime.character, Slime.name);
            DisplaySymbol(money.character, money.name);
            DisplaySymbol(potion.character, potion.name);
            DisplaySymbol(trap.character, trap.name);
            DisplaySymbol('*', "Next Area" );
            DisplaySymbol('~', "Deep Water");
            DisplaySymbol('^', "Mountains");
            DisplaySymbol('#', "Walls");
            Console.WriteLine("+--------------------------+");
        }

        private void DisplaySymbol(char symbol, string description)
        {
            MapColor(symbol);
            Console.Write(symbol);
            Console.ResetColor();
            Console.Write($" = {description}" + "\n");
        }

        public void MapColor(char c)    // handles map color
        {
            switch (c)
            {
                case '#': // Boundaries
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case '^': // Mountain
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case '~': // Water
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case '$': // money (item)
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'T': // trap (item)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'S': // Slime
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'R': // Ranged enemy
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 'M': // Mage
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 'H': // Hero(player)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'δ': // Potion (item)
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '*': // next area
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

            }
        }
    }
}
