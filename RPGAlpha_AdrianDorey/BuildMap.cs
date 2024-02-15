using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class BuildMap
    {
        public MapLegendColours legendColours;

        public int mapLevel = 0;
        public int previousLevel = 0;
        private char[,] mapContent;
        private string[] mapTextFiles = new string[] { "Map1.txt", "Map2.txt", "Map3.txt" };

        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slime;
        public Item[] Potions;
        public Item[] Money;
        public Item[] Traps;


        public BuildMap(MapLegendColours legendColours, Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes)
        {
            this.legendColours = legendColours;
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slime = Slimes;
        }


        public char[,] MapContent
        {
            get { return mapContent; }
        }

        // initializes map from file to map content
        public void MapInit()
        {
            string[] lines = File.ReadAllLines(mapTextFiles[mapLevel]);
            mapContent = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    mapContent[i, j] = lines[i][j];
                }
            }
        }

        public void DrawMap()
        {
            CheckMapChange();

            for (int i = 0; i < mapContent.GetLength(0); i++)
            {
                for (int j = 0; j < mapContent.GetLength(1); j++)
                {
                    char characterToDraw = GetCharacterToDraw(i, j);
                    legendColours.MapColor(characterToDraw);
                    Console.Write(characterToDraw);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private char GetCharacterToDraw(int i, int j)
        {
            if (i == Hero.pos.y && j == Hero.pos.x)
                return Hero.character;
            if (i == Rangers[0].pos.y && j == Rangers[0].pos.x && !Rangers[0].healthSystem.dead && mapLevel == 0)
                return Rangers[0].character;
            if (i == Rangers[1].pos.y && j == Rangers[1].pos.x && !Rangers[1].healthSystem.dead && mapLevel == 0)
                return Rangers[1].character;
            if (i == Rangers[2].pos.y && j == Rangers[2].pos.x && !Rangers[2].healthSystem.dead && mapLevel == 1)
                return Rangers[2].character;
            if (i == Mages[0].pos.y && j == Mages[0].pos.x && !Mages[0].healthSystem.dead && mapLevel == 1)
                return Mages[0].character;
            if (i == Mages[1].pos.y && j == Mages[1].pos.x && !Mages[1].healthSystem.dead && mapLevel == 1)
                return Mages[1].character;
            if (i == Mages[2].pos.y && j == Mages[2].pos.x && !Mages[2].healthSystem.dead && mapLevel == 2)
                return Mages[2].character;
            //if (i == Slime[0].pos.y && j == Slime[0].pos.x && !Slime[0].healthSystem.dead && mapLevel == 2)
            //    return Slime[0].character;
            //if (i == Slime[1].pos.y && j == Slime[1].pos.x && !Slime[1].healthSystem.dead && mapLevel == 2)
            //    return Slime[1].character;
            //if (i == Slime[2].pos.y && j == Slime[2].pos.x && !Slime[2].healthSystem.dead && mapLevel == 2)
            //    return Slime[2].character;
            //if (i == money1.pos.y && j == money1.pos.x && !money1.collected)
            //    return money1.moneyChar;

            //if (i == money2.pos.y && j == money2.pos.x && !money2.collected)
            //    return money2.moneyChar;

            //if (i == potion1.pos.y && j == potion1.pos.x && !potion1.collected)
            //    return potion1.potionChar;

            //if (i == potion2.pos.y && j == potion2.pos.x && !potion2.collected)
            //    return potion1.potionChar;

            //if (i == Traps.pos.y && j == Traps.pos.x && !Traps.collected)
            //    return Traps.trapChar;
            else
                return mapContent[i, j];
        }

        public bool CheckBoundaries(int x, int y) //handles player avoiding boundaries & water & mountains
        {
            return x >= 0 && x < mapContent.GetLength(1) && y >= 0 && y < mapContent.GetLength(0) && mapContent[y, x] != '#' && mapContent[y, x] != '~' && mapContent[y, x] != '^';
        }

        public bool CheckPoisonFloor(int x, int y) // checks for poison spills
        {
            return mapContent[y, x] == 'P';
        }


        private void CheckMapChange()
        {
            if (mapLevel == previousLevel) return;
            else
            {
                previousLevel = mapLevel;
                MapInit();
            }
        }
    }
}