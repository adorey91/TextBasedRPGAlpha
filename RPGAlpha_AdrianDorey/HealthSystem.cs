using System;

namespace RPGAlpha_AdrianDorey
{
    internal class HealthSystem
    {
        public int health;
        public bool hurt;
        public bool hurtByTrap;
        public bool dead;
        public bool mapDead;
        public bool cannotHeal;
        public bool healed;
        public bool floorDamage;

        public void TakeDamage(int damage)
        {
            health -= damage;
            hurt = true;

            if (health <= 0)
            {
                health = 0;
                mapDead = true;
                dead = true;
            }
        }

        public void FloorDamage()
        {
            health -= 5;
            floorDamage = true;

            if (health <= 0)
            {
                health = 0;
                mapDead = true;
                dead = true;
            }
        }

        public void Heal(int hp)
        {
            health += hp;
            healed = true;
            //if (health >= 100)
            //{
            //    health = 100;
            //    cannotHeal = true;
            //}

        }

        public void TrapDamage(int damage)
        {
            health -= damage;
            hurtByTrap = true;

            if (health <= 0)
            {
                health = 0;
                mapDead = true;
                dead = true;
            }
        }
    }
}
