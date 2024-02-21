using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class RangedEnemy : Enemy
    {
        int RangerDamage = 5;

        public RangedEnemy(Random random)
        {
            character = 'R';
            name = "Ranger";

            healthSystem = new HealthSystem();
            int randomHealth = random.Next(35, 65);
            healthSystem.health = randomHealth;
        }

        public void RangerMovement()
        {
            if (!healthSystem.mapDead)
            {
                if (PlayerDistance() < 10 && PlayerDistance() >= 3)
                {
                    dx = Math.Sign(Hero.pos.x - pos.x); // calculations direction to player
                    dy = Math.Sign(Hero.pos.y - pos.y);

                    newDX = pos.x + dx;
                    newDY = pos.y + dy;

                    if (PlayerDistance() >= 3 && PlayerDistance() <=5)
                        AttackPlayer();
                    else
                    {
                        if (mapPositions.CheckValidPlacement(newDX, newDY, buildMap.mapLevel))
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
                        }
                    }
                }
            }
        }

        private void AttackPlayer()
        {

            Hero.healthSystem.TakeDamage(RangerDamage);
        }
    }
}