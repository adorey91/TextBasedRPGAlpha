using System;

namespace RPGAlpha_AdrianDorey
{
    internal class MeleeEnemy : Enemy
    {
        int MeleeDamage = 1;
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
            if (!healthSystem.mapDead)
            {
                if (PlayerDistance() < 4)
                {
                    dx = Math.Sign(Hero.pos.x - pos.x);
                    dy = Math.Sign(Hero.pos.y - pos.y);

                    newDX = pos.x + dx;
                    newDY = pos.y + dy;

                    if (CheckValidPlacement(newDX, newDY, buildMap.mapLevel))
                    {
                        if (newDX == Hero.pos.x && newDY == Hero.pos.y)
                            AttackPlayer();
                        else
                        {
                            pos.x = newDX;
                            pos.y = newDY;

                            switch (buildMap.mapLevel)
                            {
                                case 0:
                                    CheckForTraps(trap, 0, 1, newDX, newDY);
                                    break;
                                case 1:
                                    CheckForTraps(trap, 1, 2, newDX, newDY);
                                    break;
                                case 2:
                                    CheckForTraps(trap, 1, 2, newDX, newDY);
                                    break;
                            }
                            CheckFloor(newDX, newDY);
                        }
                    }
                }
                else
                {
                    Move(1);

                    while (!CheckValidPlacement(newDX, newDY, buildMap.mapLevel))
                        Move(1);

                    pos.x = newDX;
                    pos.y = newDY;

                    switch (buildMap.mapLevel)
                    {
                        case 0:
                            CheckForTraps(trap, 0, 1, newDX, newDY);
                            break;
                        case 1:
                            CheckForTraps(trap, 1, 2, newDX, newDY);
                            break;
                        case 2:
                            CheckForTraps(trap, 1, 2, newDX, newDY);
                            break;
                    }
                    CheckFloor(newDX, newDY);
                }
            }

        }

        private void AttackPlayer()
        {
            Hero.healthSystem.TakeDamage(MeleeDamage);
            log.enemyAttack = $"by Slime sludge - {MeleeDamage} damage";
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