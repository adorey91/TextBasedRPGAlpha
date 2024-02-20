using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MapPositions
    {
        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slimes;
        public Item[] Potions;
        public Item[] Money;
        public Item[] Traps;
        public BuildMap buildMap;

        public MapPositions(Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes,
                            Item[] Potion, Item[] Money, Item[] Trap, BuildMap buildMap)
        {
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slimes = Slimes;
            this.Potions = Potion;
            this.Money = Money;
            this.Traps = Trap;
            this.buildMap = buildMap;
        }


        public void InitializeCharacterPositions()
        {
            Hero.pos = new Point2D { x = 4, y = 4 };
            RandomizePlacements();
        }

        private void RandomizePlacements()
        {
            Random random = new Random();
            PlaceCharactersRandomly(Rangers[0], random, 0);
            PlaceCharactersRandomly(Rangers[1], random, 0);
            PlaceCharactersRandomly(Rangers[2], random, 1);
            PlaceCharactersRandomly(Mages[0], random, 1);
            PlaceCharactersRandomly(Mages[1], random, 1);
            PlaceCharactersRandomly(Mages[2], random, 2);
            PlaceCharactersRandomly(Slimes[0], random, 2);
            PlaceCharactersRandomly(Slimes[1], random, 2);
            PlaceCharactersRandomly(Slimes[2], random, 2);
            PlaceItemsRandomly(Potions[0], random, 0);
            PlaceItemsRandomly(Potions[1], random, 1);
            PlaceItemsRandomly(Potions[2], random, 2);
            PlaceItemsRandomly(Potions[3], random, 2);
            PlaceItemsRandomly(Money[0], random, 0);
            PlaceItemsRandomly(Money[1], random, 1);
            PlaceItemsRandomly(Money[2], random, 1);
            PlaceItemsRandomly(Money[3], random, 2);
            PlaceItemsRandomly(Traps[0], random, 0);
            PlaceItemsRandomly(Traps[1], random, 1);
            PlaceItemsRandomly(Traps[2], random, 2);
        }

        private void PlaceCharactersRandomly(Enemy character, Random random, int levelNumber)
        {
            int x, y;
            do
            {
                x = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(0));
            } while (!CheckValidPlacement(x, y, levelNumber));

            character.pos = new Point2D { x = x, y = y };
        }

        private void PlaceItemsRandomly(Item item, Random random, int levelNumber)
        {
            int x, y;
            do
            {
                x = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(0));
            } while (!CheckValidPlacement(x, y, levelNumber));

            item.pos = new Point2D { x = x, y = y };
        }

        public bool CheckValidPlacement(int x, int y, int levelNumber)
        {
            return buildMap.CheckBoundaries(x, y, levelNumber) && IsEmptySpace(x, y, levelNumber);
        }

        private bool IsEmptySpace(int x, int y, int mapLevel) 
        {
            char[,] mapContent = buildMap.GetMapContent(mapLevel);

            if (Hero.pos.x == x && Hero.pos.y == y)
                return false;

            switch (mapLevel)
            {
                case 0:
                    if (Rangers[0].pos.x == x && Rangers[0].pos.y == y)
                        return false;
                    if (Rangers[1].pos.x == x && Rangers[1].pos.y == y)
                        return false;
                    if (Potions[0].pos.x == x && Potions[0].pos.y == y)
                        return false;
                    if (Money[0].pos.x == x && Money[0].pos.y == y)
                        return false;
                    if (Traps[0].pos.x == x && Traps[0].pos.y == y)
                        return false;
                    break;
                case 1:
                    if (Rangers[2].pos.x == x && Rangers[2].pos.y == y)
                        return false;
                    if (Mages[0].pos.x == x && Mages[0].pos.y == y)
                        return false;
                    if (Mages[1].pos.x == x && Mages[1].pos.y == y)
                        return false;
                    if (Potions[1].pos.x == x && Potions[1].pos.y == y)
                        return false;
                    if (Money[1].pos.x == x && Money[1].pos.y == y)
                        return false;
                    if (Money[2].pos.x == x && Money[2].pos.y == y)
                        return false;
                    if (Traps[1].pos.x == x && Traps[1].pos.y == y)
                        return false;
                    break;
                case 2:
                    if (Mages[2].pos.x == x && Mages[2].pos.y == y)
                        return false;
                    if (Slimes[0].pos.x == x && Slimes[0].pos.y == y)
                        return false;
                    if (Slimes[1].pos.x == x && Slimes[1].pos.y == y)
                        return false;
                    if (Slimes[2].pos.x == x && Slimes[2].pos.y == y)
                        return false;
                    if (Potions[2].pos.x == x && Potions[2].pos.y == y)
                        return false;
                    if (Potions[3].pos.x == x && Potions[3].pos.y == y)
                        return false;
                    if (Money[3].pos.x == x && Money[3].pos.y == y)
                        return false;
                    if (Traps[2].pos.x == x && Traps[2].pos.y == y)
                        return false;
                    break;
            }
            return true;
        }
    }
}
