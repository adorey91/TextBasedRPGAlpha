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
        public Enemy Badman1;
        public Enemy Badman2;
        public Item money1;
        public Item money2;
        public Item trap;

        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
        }

        public void Init(BuildMap buildMap, Enemy Badman1, Enemy Badman2, Item money1, Item money2, Item potion1, Item potion2, Item trap)
        {
            this.buildMap = buildMap;
            this.Badman1 = Badman1;
            this.Badman2 = Badman2;
            this.money1 = money1;
            this.money2 = money2;
            this.potion1 = potion1;
            this.potion2 = potion2;
            this.trap = trap;
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
                    if (buildMap.CheckPoisonFloor(newX, newY))
                        healthSystem.FloorDamage(5);
                    else if (newX == trap.pos.x && newY == trap.pos.y && !trap.collected)
                    {
                        healthSystem.TrapDamage(7);
                        trap.collected = true;
                    }
                }
            }
            else
                return;
        }


        public bool CheckEnemy(int newX, int newY) 
        {
            return Badman1.pos.x == newX && Badman1.pos.y == newY && Badman1.healthSystem.health != 0 ||
                Badman2.pos.x == newX && Badman2.pos.y == newY && Badman2.healthSystem.health != 0;
        }

        void AttackEnemy(int newX, int newY)
            {
                if (Badman1.pos.x == newX && Badman1.pos.y == newY && Badman1.healthSystem.health != 0)
                Badman1.TakeDamage(10);
            else if (Badman2.pos.x == newX && Badman2.pos.y == newY && Badman2.healthSystem.health != 0)
                Badman2.TakeDamage(10);
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
            }
        }

        private void MovePlayer(int newX, int newY)
        {
            pos.x = newX;
            pos.y = newY;

            money1.TryCollect(newX, newY);
            money2.TryCollect(newX, newY);
            CollectPotion(newX, newY);
        }

        public bool PlayerDied()
        {
            return healthSystem.dead;
        }

        public bool PlayerWon()
        {
            return Badman1.healthSystem.dead && Badman2.healthSystem.dead && money1.collected && money2.collected;
        }
    }
}