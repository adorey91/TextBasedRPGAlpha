using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class BuildMap
    {
        public MapLegendColours legendColours;

        public int mapLevel = 0;
        public int previousLevel = 0;
        private string[] mapTextFiles = new string[] { "Map0.txt", "Map1.txt", "Map2.txt" };
        private char[][,] allMapContents = new char[3][,];

        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slime;
        public Potion[] potions;
        public Money[] money;
        public Traps[] trap;



        public BuildMap(MapLegendColours legendColours, Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes,
            Potion[] potions, Money[] money, Traps[] trap)
        {
            this.legendColours = legendColours;
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slime = Slimes;
            this.potions = potions;
            this.money = money;
            this.trap = trap; 
        }


        public char[][,] AllMapContents
        {
            get { return allMapContents; }
        }

        public char[,] GetMapContent(int mapLevel)
        {
            if (mapLevel >= 0 && mapLevel < allMapContents.Length)
                return allMapContents[mapLevel];
            else
                throw new IndexOutOfRangeException("Index is out of range.");
        }

        // initializes map from file to map content
        public void MapInit()
        {
            for (int i = 0; i < mapTextFiles.Length; i++)
            {
                string[] lines = File.ReadAllLines(mapTextFiles[i]);
                allMapContents[i] = new char[lines.Length, lines[0].Length];

                for (int j = 0; j < lines.Length; j++)
                {
                    for (int k = 0; k < lines[j].Length; k++)
                    {
                        allMapContents[i][j, k] = lines[j][k];
                    }
                }
            }
        }

        public void DrawMap()
        {
            CheckMapChange();

            for (int i = 0; i < GetMapContent(mapLevel).GetLength(0); i++)
            {
                for (int j = 0; j < GetMapContent(mapLevel).GetLength(1); j++)
                {
                    char characterToDraw = GetCharacterToDraw(i, j);
                    legendColours.MapColor(characterToDraw);
                    Console.Write(characterToDraw);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        private char GetCharacterToDraw(int i, int j)
        {
            if (i == Hero.pos.y && j == Hero.pos.x)
                return Hero.character;

            switch (mapLevel)
            {
                case 0:
                    if (Rangers[0].pos.x == j && Rangers[0].pos.y == i && !Rangers[0].healthSystem.dead)
                        return Rangers[0].character;
                    if (Rangers[1].pos.x == j && Rangers[1].pos.y == i && !Rangers[1].healthSystem.dead)
                        return Rangers[1].character;
                    if (potions[0].pos.x == j && potions[0].pos.y == i && !potions[0].collected)
                        return potions[0].character;
                    if (money[0].pos.x == j && money[0].pos.y == i && !money[0].collected)
                        return money[0].character;
                    if (trap[0].pos.x == j && trap[0].pos.y == i && !trap[0].collected)
                        return trap[0].character;
                    break;
                case 1:
                    if (Rangers[2].pos.x == j && Rangers[2].pos.y == i && !Rangers[2].healthSystem.dead)
                        return Rangers[2].character;
                    if (Mages[0].pos.x == j && Mages[0].pos.y == i && !Mages[0].healthSystem.dead)
                        return Mages[0].character;
                    if (Mages[1].pos.x == j && Mages[1].pos.y == i && !Mages[1].healthSystem.dead)
                        return Mages[1].character;
                    if (potions[1].pos.x == j && potions[1].pos.y == i && !potions[1].collected)
                        return potions[1].character;
                    if (money[1].pos.x == j && money[1].pos.y == i && !money[1].collected)
                        return money[1].character;
                    if (money[2].pos.x == j && money[2].pos.y == i && !money[2].collected)
                        return money[2].character;
                    if (trap[1].pos.x == j && trap[1].pos.y == i && !trap[1].collected)
                        return trap[1].character;
                    break;
                case 2:
                    if (Mages[2].pos.x == j && Mages[2].pos.y == i && !Mages[2].healthSystem.dead)
                        return Mages[2].character;
                    if (Slime[0].pos.x == j && Slime[0].pos.y == i && !Slime[0].healthSystem.dead)
                        return Slime[0].character;
                    if (Slime[1].pos.x == j && Slime[1].pos.y == i && Slime[1].healthSystem.dead)
                        return Slime[1].character;
                    if (Slime[2].pos.x == j && Slime[2].pos.y == i && !Slime[2].healthSystem.dead)
                        return Slime[2].character;
                    if (potions[2].pos.x == j && potions[2].pos.y == i && !potions[2].collected)
                        return potions[2].character;
                    if (potions[3].pos.x == j && potions[3].pos.y == i && !potions[3].collected)
                        return potions[3].character;
                    if (money[3].pos.x == j && money[3].pos.y == i && !money[3].collected)
                        return money[3].character;
                    if (trap[2].pos.x == j && trap[2].pos.y == i && !trap[2].collected)
                        return trap[2].character;
                    break;
            }
            return allMapContents[mapLevel][i, j];
        }
        

        public bool CheckBoundaries(int x, int y, int levelNumber) //handles avoiding boundaries & water & mountains
        {
            return x >= 0 && x < GetMapContent(levelNumber).GetLength(1) && y >= 0 && y < GetMapContent(levelNumber).GetLength(0) && 
                GetMapContent(levelNumber)[y, x] != '#' && GetMapContent(levelNumber)[y, x] != '~' && GetMapContent(levelNumber)[y, x] != '^';
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