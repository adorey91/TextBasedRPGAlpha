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
        private string[] mapTextFiles = new string[] { "Map0.txt", "Map1.txt", "Map2.txt" };

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

            foreach (var ranger in Rangers)
            {
                if (mapLevel == 0 && i == ranger.pos.y && j == ranger.pos.x && !ranger.healthSystem.dead)
                    return ranger.character;
                else if (mapLevel == 1 && i == ranger.pos.y && j == ranger.pos.x && !ranger.healthSystem.dead)
                    return ranger.character;
            }

            foreach (var mage in Mages)
            {
                if (mapLevel == 1 && i == mage.pos.y && j == mage.pos.x && !mage.healthSystem.dead)
                    return mage.character;
                else if (mapLevel == 2 && i == mage.pos.y && j == mage.pos.x && !mage.healthSystem.dead)
                    return mage.character;
            }

            foreach (var slime in Slime)
            {
                if (mapLevel == 2 && i == slime.pos.y && j == slime.pos.x && !slime.healthSystem.dead)
                    return slime.character;
            }

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
            switch (mapLevel)
            {
                case 0:
                    if (Hero.pos.x == 40 && Hero.pos.y == 7)
                    {
                        mapLevel = 1;
                        Hero.pos.x = 1;
                        Hero.pos.y = 7;
                    }
                    break;
                case 1:
                    if (Hero.pos.x == 0 && Hero.pos.y == 7)
                    {
                        mapLevel = 0;
                        Hero.pos.x = 39;
                        Hero.pos.y = 7;
                    }
                    else if (Hero.pos.x == 37 && Hero.pos.y == 3)
                    {
                        mapLevel = 2;
                        Hero.pos.x = 37;
                        Hero.pos.y = 20;
                    }
                    break;
                case 2:
                    if (Hero.pos.x == 37 && Hero.pos.y == 21)
                    {
                        mapLevel = 1;
                        Hero.pos.x = 37;
                        Hero.pos.y = 4;
                    }
                    break;
            }

            if (mapLevel == previousLevel) return;
            else
            {
                previousLevel = mapLevel;
                MapInit();
            }
        }
    }
}