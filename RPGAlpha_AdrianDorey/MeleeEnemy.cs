using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MeleeEnemy : Enemy
    {
        int MeleeDamage = 3;

        public MeleeEnemy(Random random)
        {
            character = 'S';
            name = "Slime";

            healthSystem = new HealthSystem();
            int randomHealth = random.Next(20, 55);
            healthSystem.health = randomHealth;
        }



        public void MeleeMovement()
        {
            if (!healthSystem.dead)
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

        private void AttackPlayer()
        {
            Hero.healthSystem.TakeDamage(MeleeDamage);
        }

    }
}
