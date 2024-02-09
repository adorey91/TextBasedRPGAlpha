using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class Enemy : GameEntity
    {
        private Random randomMovement = new Random();
        public Player Hero;
        public Item trap;


        private int dx;
        private int dy;
        private int newX;
        private int newY;

        public Enemy(Random random)
        {
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 65);
            healthSystem.health = randomHealth;
        }

        public void Init(BuildMap buildMap, Player Hero, Item trap)
        {
            this.buildMap = buildMap;
            this.Hero = Hero;
            this.trap = trap;
        }

        public void AttackPlayer()
        {
            Hero.TakeDamage(10);
        }

        public void EnemyMovement()
        {
            if (healthSystem.health != 0)
            {
                int playerDistance = Math.Abs(pos.x - Hero.pos.x) + Math.Abs(pos.y - Hero.pos.y);

                if (playerDistance <= 4) //checks if the player is within 6 places
                {
                    dx = Math.Sign(Hero.pos.x - pos.x);
                    dy = Math.Sign(Hero.pos.y - pos.y);

                    newX = pos.x + dx;
                    newY = pos.y + dy;

                    if (buildMap.CheckBoundaries(newX, newY))
                    {
                        if (newX == Hero.pos.x && newY == Hero.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newX;
                            pos.y = newY;
                        }
                    }
                }
                else // randomly moves
                {
                    int direction = randomMovement.Next(0, 4);
                    int dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                    int dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                    int newX = pos.x + dx;
                    int newY = pos.y + dy;

                    while (!buildMap.CheckBoundaries(newX, newY))
                    {
                        direction = randomMovement.Next(0, 4);
                        dx = (direction == 2) ? 1 : (direction == 3) ? -1 : 0;
                        dy = (direction == 0) ? 1 : (direction == 1) ? -1 : 0;

                        newX = pos.x + dx;
                        newY = pos.y + dy;
                    }
                    
                    if (newX == Hero.pos.x && newY == Hero.pos.y)
                            AttackPlayer();
                    else
                    {
                        pos.x = newX;
                        pos.y = newY;
                    }
                }
                if (buildMap.CheckPoisonFloor(pos.x, pos.y))
                    healthSystem.FloorDamage(5);
                else if (pos.x == trap.pos.x && pos.y == trap.pos.y && !trap.collected)
                {
                    healthSystem.TrapDamage(7);
                    trap.collected = true;
                }
            }
        }
    }
}