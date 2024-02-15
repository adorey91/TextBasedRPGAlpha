using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class RangedEnemy : Enemy
    {
        public RangedEnemy()
        {
            character = 'R';

            Random random = new Random();
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(35, 65);
            healthSystem.health = randomHealth;
        }

        public void RangerMovement()
        {
            if (!healthSystem.dead)
            {
                if (PlayerDistance() < 10 && PlayerDistance() > 3)
                {
                    dx = Math.Sign(Hero.pos.x - pos.x);
                    dy = Math.Sign(Hero.pos.y - pos.y);

                    newDX = pos.x + dx;
                    newDY = pos.y + dy;

                    if (buildMap.CheckBoundaries(newDX, newDY))
                    {
                        if (newDX == Hero.pos.x && newDY == Hero.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newDX;
                            pos.y = newDY;
                        }
                    }
                }
                else
                {
                    Move(2);

                    while (!buildMap.CheckBoundaries(newDX, newDY))
                    {
                        Move(2);
                    }

                    if (newDX == Hero.pos.x && newDY != Hero.pos.y)
                        AttackPlayer();
                    else
                    {
                        pos.x = newDX;
                        pos.y = newDY;
                    }
                }
                //if (pos.x == Traps[].pos.x && pos.y == Trap.pos.y && !trap.collected)
                //{
                //    healthSystem.TrapDamage(7);
                //    Traps.collected = true;
                //}
            }
        }
    }
}

