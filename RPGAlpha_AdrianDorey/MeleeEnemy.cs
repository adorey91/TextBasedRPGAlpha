using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MeleeEnemy : Enemy
    {
        public MeleeEnemy()
        {
            character = 'S';

            Random random = new Random();
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(20, 55);
            healthSystem.health = randomHealth;
        }

        //public void MeleeMovement()
        //{
        //    if(!healthSystem.dead)
        //    {
        //        Move(1);

        //        while (!buildMap.CheckBoundaries(newDX, newDY))
        //            Move(1);

        //        if (newDX == Hero.pos.x && newDY != Hero.pos.y)
        //            AttackPlayer();
        //        else
        //        {
        //            pos.x = newDX;
        //            pos.y = newDY;
        //        }
        //    }
        //}

        private void AttackPlayer()
        {
            Hero.TakeDamage(4);
        }

    }
}
