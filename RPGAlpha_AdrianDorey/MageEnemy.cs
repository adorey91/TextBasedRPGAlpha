using System;

namespace RPGAlpha_AdrianDorey
{
    internal class MageEnemy : Enemy
    {
        int moveCount = 0;
        int MageDamage = 2;

        public MageEnemy(Random random)
        {
            character = 'M';
            name = "Mage";

            healthSystem = new HealthSystem();
            int randomHealth = random.Next(40, 65);
            healthSystem.health = randomHealth;
        }

        public void MageMovement() // moves to random places in the map every 6 turns
        {
            if (!healthSystem.mapDead)
            {
                if (moveCount == 6)
                {
                    RandomPlacement();
                    moveCount = 0;
                }
                else
                {
                    if (pos.x == Hero.pos.x || pos.y == Hero.pos.y)
                        AttackPlayer();
                    else
                        moveCount++;
                }
            }
        }

        private void AttackPlayer() // attacks player within distance
        {
            if (PlayerDistance() <= 10)
            {
                Hero.healthSystem.TakeDamage(MageDamage);
                log.enemyAttack = $" by mage magic - {MageDamage} damage";
            }
        }

        private void RandomPlacement()
        {
            int x, y;
            do
            {
                Random random = new();
                x = random.Next(0, buildMap.GetMapContent(buildMap.mapLevel).GetLength(1));
                y = random.Next(0, buildMap.GetMapContent(buildMap.mapLevel).GetLength(0));
            } while (!CheckValidPlacement(x, y, buildMap.mapLevel));

            pos = new Point2D { x = x, y = y };
        }
    }
}
