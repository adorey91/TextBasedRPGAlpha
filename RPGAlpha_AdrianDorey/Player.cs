using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class Player : GameEntity
    {
        int dirX;
        int dirY;
        int damageAmount = 10;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slimes;
        public Money[] money;
        public Potion[] potion;
        public char character;
        bool attackedEnemy = false;
        public string name = "Hero (Player)";

        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
            character = 'H';
        }

        public void Init(BuildMap buildMap, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes, Money[] money, Potion[] potion)
        {
            this.buildMap = buildMap;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slimes = Slimes;
            this.money = money;
            this.potion = potion;
        }

        public void PlayerMovement()
        {
            if (!healthSystem.dead)
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


        public void CheckEnemy(int newX, int newY, int levelName)
        {
            switch (levelName)
            {
                case 0:
                    if (Rangers[0].pos.x == newX && Rangers[0].pos.y == newY && !Rangers[0].healthSystem.dead)
                    {
                        Rangers[0].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Rangers[1].pos.x == newX && Rangers[1].pos.y == newY && !Rangers[1].healthSystem.dead)
                    {
                        Rangers[1].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    break;
                case 1:
                    if (Rangers[2].pos.x == newX && Rangers[2].pos.y == newY && !Rangers[2].healthSystem.dead)
                    {
                        Rangers[2].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Mages[0].pos.x == newX && Mages[0].pos.y == newY && !Mages[0].healthSystem.dead)
                    {
                        Mages[0].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Mages[1].pos.x == newX && Mages[1].pos.y == newY && !Mages[1].healthSystem.dead)
                    {
                        Mages[1].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    break;
                case 2:
                    if (Mages[2].pos.x == newX && Mages[2].pos.y == newY && !Mages[2].healthSystem.dead)
                    {
                        Mages[2].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Slimes[0].pos.x == newX && Slimes[0].pos.y == newY && !Slimes[0].healthSystem.dead)
                    {
                        Slimes[0].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Slimes[1].pos.x == newX && Slimes[1].pos.y == newY && Slimes[1].healthSystem.dead)
                    {
                        Slimes[1].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    if (Slimes[2].pos.x == newX && Slimes[2].pos.y == newY && !Slimes[2].healthSystem.dead)
                    {
                        Slimes[2].TakeDamage(damageAmount);
                        attackedEnemy = true;
                    }
                    break;
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
                case ConsoleKey.UpArrow:
                    dirY = -1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    dirY = 1;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    dirX = -1;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    dirX = 1;
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
                    if (money[0].pos.x == newX && money[0].pos.y == newY)
                        money[0].TryCollect(newX, newY);
                    break;
                case 1:
                    if (money[1].pos.x == newX && money[1].pos.y == newY)
                        money[1].TryCollect(newX, newY);
                    if (money[2].pos.x == newX && money[2].pos.y == newY)
                        money[2].TryCollect(newX, newY);
                    break;
                case 2:
                    if (money[3].pos.x == newX && money[3].pos.y == newY)
                        money[3].TryCollect(newX, newY);
                    break;
            }
        }

        public bool PlayerDied()
        {
            return healthSystem.dead;
        }
    }
}