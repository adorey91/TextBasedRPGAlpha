using System;

namespace RPGAlpha_AdrianDorey
{
    internal class MapPositions
    {
        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slimes;
        public Potions[] potion;
        public Money[] money;
        public Traps[] trap;
        public BuildMap buildMap;

        public MapPositions(Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes,
                            Potions[] potion, Money[] money, Traps[] trap, BuildMap buildMap)
        {
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slimes = Slimes;
            this.potion = potion;
            this.money = money;
            this.trap = trap;
            this.buildMap = buildMap;
        }


        public void InitializeCharacterPositions()
        {
            Hero.pos = new Point2D { x = 4, y = 4 };
            RandomizePlacements();
        }

        private void RandomizePlacements()
        {
            Random random = new();
            PlaceCharactersRandomly(Rangers[0], random, 0);
            PlaceCharactersRandomly(Rangers[1], random, 0);
            PlaceCharactersRandomly(Rangers[2], random, 1);
            PlaceCharactersRandomly(Mages[0], random, 1);
            PlaceCharactersRandomly(Mages[1], random, 1);
            PlaceCharactersRandomly(Mages[2], random, 2);
            PlaceCharactersRandomly(Slimes[0], random, 2);
            PlaceCharactersRandomly(Slimes[1], random, 2);
            PlaceCharactersRandomly(Slimes[2], random, 2);
            PlaceItemsRandomly(potion[0], random, 0);
            PlaceItemsRandomly(potion[1], random, 1);
            PlaceItemsRandomly(potion[2], random, 2);
            PlaceItemsRandomly(potion[3], random, 2);
            PlaceItemsRandomly(money[0], random, 0);
            PlaceItemsRandomly(money[1], random, 1);
            PlaceItemsRandomly(money[2], random, 1);
            PlaceItemsRandomly(money[3], random, 2);
            PlaceItemsRandomly(trap[0], random, 0);
            PlaceItemsRandomly(trap[1], random, 1);
            PlaceItemsRandomly(trap[2], random, 2);
        }

        private void PlaceCharactersRandomly(Enemy character, Random random, int levelNumber)
        {
            int x, y;
            do
            {
                x = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(0));
            } while (!CheckInitialPlacement(x, y, levelNumber));

            character.pos = new Point2D { x = x, y = y };
        }

        private void PlaceItemsRandomly(Item item, Random random, int levelNumber)
        {
            int x, y;
            do
            {
                x = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(levelNumber).GetLength(0));
            } while (!CheckInitialPlacement(x, y, levelNumber));

            item.pos = new Point2D { x = x, y = y };
        }

        private bool CheckInitialPlacement(int x, int y, int levelNumber)
        {
            return buildMap.CheckBoundaries(x, y, levelNumber) && IsEmptySpace(x, y, levelNumber) &&
                buildMap.GetMapContent(levelNumber)[y, x] != '*';
        }

        private bool IsEmptySpace(int x, int y, int mapLevel)
        {
            if (Hero.pos.x == x && Hero.pos.y == y)
                return false;

            switch (mapLevel)
            {
                case 0:
                    if (Rangers[0].pos.x == x && Rangers[0].pos.y == y)
                        return false;
                    if (Rangers[1].pos.x == x && Rangers[1].pos.y == y)
                        return false;
                    if (potion[0].pos.x == x && potion[0].pos.y == y)
                        return false;
                    if (money[0].pos.x == x && money[0].pos.y == y)
                        return false;
                    if (trap[0].pos.x == x && trap[0].pos.y == y)
                        return false;
                    break;
                case 1:
                    if (Rangers[2].pos.x == x && Rangers[2].pos.y == y)
                        return false;
                    if (Mages[0].pos.x == x && Mages[0].pos.y == y)
                        return false;
                    if (Mages[1].pos.x == x && Mages[1].pos.y == y)
                        return false;
                    if (potion[1].pos.x == x && potion[1].pos.y == y)
                        return false;
                    if (money[1].pos.x == x && money[1].pos.y == y)
                        return false;
                    if (money[2].pos.x == x && money[2].pos.y == y)
                        return false;
                    if (trap[1].pos.x == x && trap[1].pos.y == y)
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
                    if (potion[2].pos.x == x && potion[2].pos.y == y)
                        return false;
                    if (potion[3].pos.x == x && potion[3].pos.y == y)
                        return false;
                    if (money[3].pos.x == x && money[3].pos.y == y)
                        return false;
                    if (trap[2].pos.x == x && trap[2].pos.y == y)
                        return false;
                    break;
            }
            return true;
        }
    }
}