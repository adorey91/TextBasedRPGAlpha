﻿using System;

namespace RPGAlpha_AdrianDorey
{
    internal class MeleeEnemy : Enemy
    {
        int MeleeDamage = 3;
        Random randomMovement = new();

        public MeleeEnemy(Random random)
        {
            character = 'S';
            name = "Slime";

            healthSystem = new HealthSystem();
            int randomHealth = random.Next(20, 50);
            healthSystem.health = randomHealth;
        }


        public void MeleeMovement() // moves randomly unless close enough to the player.
        {
            if (!healthSystem.dead)
            {
                if (PlayerDistance() <= 3)
                {
                    dx = Math.Sign(Hero.pos.x - pos.x);
                    dy = Math.Sign(Hero.pos.y - pos.y);

                    newDX = pos.x + dx;
                    newDY = pos.y + dy;

                    if (!mapPositions.CheckValidPlacement(newDX, newDY, buildMap.mapLevel))
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
                    Move(1);

                    while (!mapPositions.CheckValidPlacement(newDX, newDY, buildMap.mapLevel))
                        Move(1);

                    if (newDX == Hero.pos.x && newDY == Hero.pos.y)
                        AttackPlayer();
                    else
                    {
                        pos.x = newDX;
                        pos.y = newDY;
                    }
                }
            }
        }

        private void AttackPlayer()
        {
            Hero.healthSystem.TakeDamage(MeleeDamage);
        }

        private void Move(int spaces)
        {
            int direction = randomMovement.Next(0, 4);
            dx = (direction == 2) ? spaces : (direction == 3) ? -spaces : 0;
            dy = (direction == 0) ? spaces : (direction == 1) ? -spaces : 0;

            newDX = pos.x + dx;
            newDY = pos.y + dy;
        }
    }
}