using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MapExtras
    {
        BuildMap buildMap;

        public void DisplayLegend() // displays legend on the bottom of the map.
        {
            Console.WriteLine("Map Legend:");

            DisplaySymbol('H', "Hero (Player)");
            DisplaySymbol('E', "Enemies");
            DisplaySymbol('$', "Money");
            DisplaySymbol('δ', "Potion");
            DisplaySymbol('T', "Trap");
            DisplaySymbol('~', "Deep Water");
            DisplaySymbol('P', "Poison Spill");
            DisplaySymbol('#', "Walls");
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
                case '#':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 'P':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case '$':
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'E':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'T':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                case 'H':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'δ':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
    }
}
