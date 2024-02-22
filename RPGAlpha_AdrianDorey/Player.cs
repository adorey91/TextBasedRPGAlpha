using System;

namespace RPGAlpha_AdrianDorey
{
    internal class Player : GameEntity
    {
        int dirX;
        int dirY;
        public int damageAmount = 10;
        RangedEnemy[] Rangers;
        MageEnemy[] Mages;
        MeleeEnemy[] Slime;
        Money[] money;
        Potions[] potion;
        Traps[] trap;
        public char character;
        public string name = "Hero (Player)";
        public bool attackedEnemy = false;
        public bool itemPickedUp = false;

        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
            character = 'H';
        }

        public void Init(BuildMap buildMap, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slime, Money[] money, Potions[] potion, Traps[] trap)
        {
            this.buildMap = buildMap;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slime = Slime;
            this.money = money;
            this.potion = potion;
            this.trap = trap;
        }

        public void PlayerMovement()
        {
            if (!healthSystem.mapDead)
            {
                PlayerInput();

                if (dirX != 0 || dirY != 0)
                {
                    int newX = pos.x + dirX;
                    int newY = pos.y + dirY;

                    if (buildMap.CheckBoundaries(newX, newY, buildMap.mapLevel))
                    {
                        CheckEnemy(newX, newY);
                        ItemPickups(newX, newY);

                        if (!attackedEnemy && !itemPickedUp)
                        {
                            pos.x = newX;
                            pos.y = newY;

                            CheckTraps(newX, newY);
                        }
                        itemPickedUp = false;
                        attackedEnemy = false;
                    }
                }
            }
        }

        private void PlayerInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            dirX = 0;
            dirY = 0;

            switch (input.Key)
            {
                case ConsoleKey.W:
                    dirY = -1;
                    break;
                case ConsoleKey.S:
                    dirY = 1;
                    break;
                case ConsoleKey.A:
                    dirX = -1;
                    break;
                case ConsoleKey.D:
                    dirX = 1;
                    break;
                case ConsoleKey.Q:
                    {
                        dirY = -1;
                        dirX = -1;
                    }
                    break;
                case ConsoleKey.E:
                    {
                        dirY = -1;
                        dirX = 1;
                    }
                    break;
                case ConsoleKey.Z:
                    {
                        dirY = 1;
                        dirX = -1;
                    }
                    break;
                case ConsoleKey.C:
                    {
                        dirY = 1;
                        dirX = 1;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    return; // using for testing, player doesn't move
                case ConsoleKey.Escape:
                    System.Environment.Exit(0);
                    return; 
            }
        }

        private void ItemPickups(int newX, int newY)
        {
            switch (buildMap.mapLevel)
            {
                case 0:
                    CheckForMoney(0, 1, newX, newY);
                    CheckForPotion(0, 1, newX, newY);
                    break;
                case 1:
                    CheckForMoney(1, 3, newX, newY);
                    CheckForPotion(1, 2, newX, newY);
                    break;
                case 2:
                    CheckForMoney(3, 4, newX, newY);
                    CheckForPotion(2, 4, newX, newY);
                    break;
            }
        }

        private void CheckTraps(int newX, int newY)
        {
            switch (buildMap.mapLevel)
            {
                case 0:
                    CheckForTraps(trap, 0, 1, newX, newY);
                    break;
                case 1:
                    CheckForTraps(trap, 1, 2, newX, newY);
                    break;
                case 2:
                    CheckForTraps(trap, 1, 2, newX, newY);
                    break;
            }
        }

        private void CheckEnemy(int newX, int newY)
        {
            switch (buildMap.mapLevel)
            {
                case 0:
                    CheckForEnemies(Rangers, 0, 2, newX, newY);
                    break;
                case 1:
                    CheckForEnemies(Rangers, 2, 3, newX, newY);
                    CheckForEnemies(Mages, 0, 2, newX, newY);
                    break;
                case 2:
                    CheckForEnemies(Mages, 2, 3, newX, newY);
                    CheckForEnemies(Slime, 0, 3, newX, newY);
                    break;
            }
        }

        private void CheckForEnemies(Enemy[] enemies, int startIndex, int endIndex, int newX, int newY) // start index is the beginning of the array of that enemy and the end is the last one to count
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if (enemies[i].pos.x == newX && enemies[i].pos.y == newY && !enemies[i].healthSystem.mapDead)
                {
                    enemies[i].healthSystem.TakeDamage(damageAmount);
                    attackedEnemy = true;
                }
            }
        }

        private void CheckForPotion(int startIndex, int endIndex, int newX, int newY)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                potion[i].TryCollect(newX, newY);
                if (potion[i].pickedUp)
                {
                    healthSystem.Heal(potion[i].potionHeal);
                    itemPickedUp = true;
                }
            }
        }

        private void CheckForMoney(int startIndex, int endIndex, int newX, int newY)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                money[i].TryCollect(newX, newY);
                if (money[i].pickedUp)
                    itemPickedUp = true;
            }
        }
    }
}