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
                            Item[] Potion, Item[] Money,Item[] Trap, BuildMap buildMap)
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
            PlaceCharactersRandomly(Rangers, random);
            PlaceCharactersRandomly(Mages, random);
            PlaceCharactersRandomly(Slimes, random);
            PlaceItemsRandomly(Potions, random);
            PlaceItemsRandomly(Money, random);
            PlaceItemsRandomly(Traps, random);

        }

        private void PlaceCharactersRandomly(Enemy[] characters, Random random)
        {
            foreach (Enemy character in characters)
            {
                int x, y;
                do
                {
                    x = random.Next(0, buildMap.MapContent.GetLength(1));
                    y = random.Next(0, buildMap.MapContent.GetLength(0));
                } while (!CheckValidPlacement(x, y));

                character.pos = new Point2D { x = x, y = y };
            }
        }

        private void PlaceItemsRandomly(Item[] items, Random random)
        {
            foreach (Item item in items)
            {
                int x, y;
                do
                {
                    x = random.Next(0, buildMap.MapContent.GetLength(1));
                    y = random.Next(0, buildMap.MapContent.GetLength(0));
                } while (!CheckValidPlacement(x, y));

                item.pos = new Point2D { x = x, y = y };
            }
        }

        public bool CheckValidPlacement(int x, int y)
        {
            return buildMap.CheckBoundaries(x, y) && IsEmptySpace(x, y);
        }

        private bool IsEmptySpace(int x, int y)
        {
            if (Hero.pos.x == x && Hero.pos.y == y)
                return false;

            foreach (RangedEnemy enemy in Rangers)
            {
                if (enemy.pos.x == x && enemy.pos.y == y)
                    return false;
            }

            foreach (MageEnemy enemy in Mages)
            {
                if (enemy.pos.x == x && enemy.pos.y == y)
                    return false;
            }

            foreach (MeleeEnemy enemy in Slimes)
            {
                if (enemy.pos.x == x && enemy.pos.y == y)
                    return false;
            }
            foreach (Item potion in Potions)
            {
                if(potion.pos.x == x && potion.pos.y == y)
                    return false;
            }
            foreach (Item money in Money)
            {
                if(money.pos.x == x && money.pos.y == y)
                    return false;
            }
            foreach(Item trap in Traps)
            {
                if(trap.pos.x == x && trap.pos.y == y)
                    return false;
            }

            return true;
        }
    }
}
