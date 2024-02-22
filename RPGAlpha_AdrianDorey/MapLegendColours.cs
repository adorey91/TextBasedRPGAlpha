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
            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("Map Legend:");
            DisplaySymbolsInColumns(Hero.character, Hero.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(Rangers.character, Rangers.name);
            DisplaySymbolsInColumns(Mage.character, Mage.name);
            DisplaySymbolsInColumns(Slime.character, Slime.name);
            Console.WriteLine();
            DisplaySymbolsInColumns(money.character, money.name);
            DisplaySymbolsInColumns(potion.character, potion.name);
            DisplaySymbolsInColumns(trap.character, trap.name);
            Console.WriteLine();
            DisplaySymbolsInColumns('*', "Next Area");
            DisplaySymbolsInColumns('~', "Deep Water");
            Console.WriteLine();
            DisplaySymbolsInColumns('^', "Mountains");
            DisplaySymbolsInColumns('#', "Walls");
            Console.WriteLine();
            Console.WriteLine("+-----------------------------------------------------------+");
        }

        private void DisplaySymbolsInColumns(char symbol, string description)
        {
            MapColor(symbol);
            Console.Write(symbol);
            Console.ResetColor();
            Console.Write($" = {description}");

            int spacesCount = 20 - description.Length; // Adjust this number based on your desired column width

            // Add spaces to align the columns
            for (int i = 0; i < spacesCount; i++)
            {
                Console.Write(" ");
            }
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
