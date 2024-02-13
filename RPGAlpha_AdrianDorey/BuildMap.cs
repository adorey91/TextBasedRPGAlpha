using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class BuildMap
    {
        public MapExtras mapExtras;
        public int mapLevel = 0;
        private char[,] mapContent;
        private string[] mapTextFiles = new string[] { "Map1.txt", "Map2.txt", "Map3.txt" };

        public char[,] MapContent
        {
            get { return mapContent; }
        }

        public void MapInit() // initializes map from file to map content
        {
            string[] lines = File.ReadAllLines("Map1.txt");
            // Add debug information
            Console.WriteLine($"File lines: {lines.Length}");
            mapContent = new char[lines.Length, lines[0].Length];



            for (int i = 0; i < lines.Length; i++)
            {
                // Add debug information
                Console.WriteLine($"Line {i}: {lines[i]}");

                for (int j = 0; j < lines[i].Length; j++)
                {
                    // Add debug information
                    Console.WriteLine($"Character at position ({i}, {j}): {lines[i][j]}");

                    mapContent[i, j] = lines[i][j];
                }
            }
        }

        public void DrawMap()
        {
            for (int i = 0; i < mapContent.GetLength(0); i++)
            {
                for (int j = 0; j < mapContent.GetLength(1); j++)
                {
                    char characterToDraw = GetCharacterToDraw(i, j);
                    mapExtras.MapColor(characterToDraw);
                    Console.Write(characterToDraw);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private char GetCharacterToDraw(int i, int j)
        {
            //if (i == Hero.pos.y && j == Hero.pos.x)
            //    return Hero.character;

            //if (i == Badman1.pos.y && j == Badman1.pos.x && !Badman1.healthSystem.dead)
            //    return Badman1.character;

            //if (i == Badman2.pos.y && j == Badman2.pos.x && !Badman2.healthSystem.dead)
            //    return Badman2.character;

            //if (i == money1.pos.y && j == money1.pos.x && !money1.collected)
            //    return money1.moneyChar;

            //if (i == money2.pos.y && j == money2.pos.x && !money2.collected)
            //    return money2.moneyChar;

            //if (i == potion1.pos.y && j == potion1.pos.x && !potion1.collected)
            //    return potion1.potionChar;

            //if (i == potion2.pos.y && j == potion2.pos.x && !potion2.collected)
            //    return potion1.potionChar;

            //if (i == trap.pos.y && j == trap.pos.x && !trap.collected)
            //    return trap.trapChar;
            //else
            //    return mapContent[i, j];
            return mapContent[i, j];
        }

        public bool CheckBoundaries(int x, int y) //handles player avoiding boundaries & water & mountains
        {
            return x >= 0 && x < mapContent.GetLength(1) && y >= 0 && y < mapContent.GetLength(0) && 
                mapContent[y, x] != '#' && mapContent[y, x] != '~' && mapContent[y,x] != '^';
        }

        public bool CheckPoisonFloor(int x, int y) // checks for poison spills
        {
            return mapContent[y, x] == 'P';
        }
        
        
    }
}