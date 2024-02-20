using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class MageEnemy : Enemy
    {
        int moveCount = 0;
        MapPositions mapPositions;

        public void MageInit(MapPositions mapPositions)
        {
            this.mapPositions = mapPositions;
        }

        public MageEnemy()
        {
            character = 'M';
            name = "Mage";
           
            Random random = new Random();
            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 75);
            healthSystem.health = randomHealth;
        }

        //public void MageMovement()
        //{
        //    if (!healthSystem.dead)
        //    {
        //        if(moveCount == 6)
        //            RandomPlacement();
        //        else
        //        {
        //            Move(1);

        //            while (!buildMap.CheckBoundaries(newDX, newDY))
        //                Move(1);

        //            if (newDX == Hero.pos.x || newDY != Hero.pos.y)
        //                AttackPlayer();
        //            else
        //            {
        //                pos.x = newDX;
        //                pos.y = newDY;
        //                moveCount++;
        //            }
        //        }
        //    }
        //}

        private void AttackPlayer()
        {
            Hero.TakeDamage(6);
        }

        private void RandomPlacement()
        {
            int x, y;
            do
            {
                Random random = new Random();
                x = random.Next(0, buildMap.GetMapContent(buildMap.mapLevel).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(buildMap.mapLevel).GetLength(0));
            } while (!mapPositions.CheckValidPlacement(x, y, buildMap.mapLevel));

            pos = new Point2D { x = x, y = y };
        }
    }
}
