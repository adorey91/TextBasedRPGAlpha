using System;

namespace RPGAlpha_AdrianDorey
{
    internal class Player : GameEntity
    {
        int dirX;
        int dirY;
        int damageAmount = 10;
        RangedEnemy[] Rangers;
        MageEnemy[] Mages;
        MeleeEnemy[] Slime;
        Money[] money;
        Potions[] potion;
        Traps[] trap;
        public char character;
        public string name = "Hero (Player)";
        public bool attackedEnemy = false;

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
                        CheckEnemy(newX, newY, buildMap.mapLevel);

                        if (!attackedEnemy)
                            MovePlayer(newX, newY);

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
                    return; // using for testing, player doesn't move
            }
        }

        private void MovePlayer(int newX, int newY)
        {
            pos.x = newX;
            pos.y = newY;


            switch (buildMap.mapLevel)
            {
                case 0:
                    money[0].TryCollect(newX, newY);
                    CheckForTraps(trap, 0, 1, newX, newY);
                    CheckForPotion(potion, 0, 1, newX, newY);
                    break;
                case 1:
                    money[1].TryCollect(newX, newY);
                    money[2].TryCollect(newX, newY);
                    CheckForTraps(trap, 1, 2, newX, newY);
                    CheckForPotion(potion, 1, 2, newX, newY);
                    break;
                case 2:
                    money[3].TryCollect(newX, newY);
                    CheckForTraps(trap, 1, 2, newX, newY);
                    CheckForPotion(potion, 2, 4, newX, newY);
                    break;
            }
        }

        public void CheckEnemy(int newX, int newY, int levelName)
        {
            switch (levelName)
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

        private void CheckForEnemies(Enemy[] enemies, int startIndex, int endIndex, int newX, int newY)
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

        private void CheckForPotion(Potions[] potion, int startIndex, int endIndex, int newX, int newY)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                potion[i].TryCollect(newX, newY);
                if (potion[i].pickedUp)
                {
                    healthSystem.Heal(potion[i].potionHeal);
                }
            }
        }
    }
}