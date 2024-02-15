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
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slimes;
        public Item[] Money;
        public Item[] Potion;

        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
            character = 'H';
        }

        public void Init(BuildMap buildMap, RangedEnemy[] Rangers, MageEnemy[] Mages, Item[] Money, Item[] Potion)
        {
            this.buildMap = buildMap;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Money = Money;
            this.Potion = Potion;
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

                    if (buildMap.CheckBoundaries(newX, newY))
                    {
                        if (CheckEnemy(newX, newY))
                            AttackEnemy(newX, newY);
                        else
                            MovePlayer(newX, newY);
                    }
                }
            }
        }


        public bool CheckEnemy(int newX, int newY)
        {
            foreach (RangedEnemy enemy in Rangers)
            {
                if(enemy.pos.x == newX &&  enemy.pos.y == newY && !enemy.healthSystem.dead)
                return true;
            }
            return false;
        }

        void AttackEnemy(int newX, int newY)
        {
            foreach (RangedEnemy enemy in Rangers)
            {
                if (enemy.pos.x == newX && enemy.pos.y == newY && !enemy.healthSystem.dead)
                    enemy.TakeDamage(10);
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

            //money1.TryCollect(newX, newY);
            //money2.TryCollect(newX, newY);
            //CollectPotion(newX, newY);
        }

        public bool PlayerDied()
        {
            return healthSystem.dead;
        }
    }
}