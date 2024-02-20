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
        public Money[] money;
        public Potion[] potion;
        public char character;
        public string name = "Hero (Player)";

        public Player()
        {
            healthSystem = new HealthSystem();
            healthSystem.health = 100;
            character = 'H';
        }

        public void Init(BuildMap buildMap, RangedEnemy[] Rangers, MageEnemy[] Mages, Money[] money, Potion[] potion)
        {
            this.buildMap = buildMap;
            this.Rangers = Rangers;
            this.Mages = Mages;
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