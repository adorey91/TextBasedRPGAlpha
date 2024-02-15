using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MapLegendColours
    {
        public void DisplayLegend() // displays legend on the bottom of the map.
        {
            Console.WriteLine("+--------------------------+");
            Console.WriteLine("Map Legend:");
            DisplaySymbol('H', "Hero (Player)");
            DisplaySymbol('R', "Ranger");
            DisplaySymbol('M', "Mage");
            DisplaySymbol('S', "Slime");
            DisplaySymbol('$', "Money");
            DisplaySymbol('δ', "Potion");
            DisplaySymbol('T', "Trap");
            DisplaySymbol('*', "Next Area");
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
            Console.WriteLine($" = {description}");
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
                case '$': // Money (item)
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'T': // Traps (item)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'S': // Slimes
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
                case '*':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

            }
        }
    }
}
