using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RPGAlpha_AdrianDorey
{
    internal class GameLog
    {
        public Player Hero;
        public RangedEnemy[] Rangers;
        public MageEnemy[] Mages;
        public MeleeEnemy[] Slime;
        public Money[] money;
        public Potions[] potion;
        public Traps[] trap;
        public string enemyAttack;

        public void Init(Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slime, Money[] money, Potions[] potion, Traps[] trap)
        {
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slime = Slime;
            this.potion = potion;
            this.money = money;
            this.trap = trap;
        }

        public void PrintGameLog()
        {
            Console.Write("Game Log: \n");
            LogAttackText();
            LogTrapText();
            LogPickUpText();
            LogHealingText();
            LogEnemyDeathText();
            Console.WriteLine();
        }

        private void LogAttackText()
        {
            if (Hero.healthSystem.hurt)
            {
                Console.Write(Hero.name + " was attacked" + enemyAttack +"\n");
                Hero.healthSystem.hurt = false;
                enemyAttack = null;
            }
            CheckAndLogEnemyHurtStatus(Rangers);
            CheckAndLogEnemyHurtStatus(Mages);
            CheckAndLogEnemyHurtStatus(Slime);
        }

        private void CheckAndLogEnemyHurtStatus(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.hurt)
                {
                    Console.Write("Attacked " + enemies[i].name + i + "\n");
                    enemies[i].healthSystem.hurt = false;
                }
            }
        }


        private void LogTrapText()
        {
            if (Hero.healthSystem.hurtByTrap)
            {
                Console.Write(Hero.name + " hurt by a trap \n");
                Hero.healthSystem.hurtByTrap = false;
            }
            CheckAndLogEnemyTrapStatus(Rangers);
            CheckAndLogEnemyTrapStatus(Mages);
            CheckAndLogEnemyTrapStatus(Slime);
        }

        private void CheckAndLogEnemyTrapStatus(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.hurtByTrap)
                {
                    Console.Write(enemies[i].name + i + " hurt by a trap \n");
                    enemies[i].healthSystem.hurtByTrap = false;
                }
            }
        }

        private void LogPickUpText()
        {
            foreach (Money money in money)
            {
                if (money.pickedUp)
                {
                    Console.Write("Player picked up money \n");
                }
                money.pickedUp = false;
            }
        }

        private void LogHealingText()
        {
            foreach (Potions potion in potion)
            {
                if (potion.pickedUp)
                {
                    if (Hero.healthSystem.healed)
                    {
                        Console.Write("Player picked up potion \n");
                        Hero.healthSystem.healed = false;
                    }
                    if(Hero.healthSystem.cannotHeal)
                    {
                        Console.Write("Player cannot heal anymore \n");
                        Hero.healthSystem.cannotHeal = false;
                    }
                }
                potion.pickedUp = false;
            }
        }

        private void LogEnemyDeathText()
        {
            CheckAndLogEnemyDeath(Rangers);
            CheckAndLogEnemyDeath(Mages);
            CheckAndLogEnemyDeath(Slime);
        }

        private void CheckAndLogEnemyDeath(Enemy[] enemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].healthSystem.dead)
                {
                    Console.Write(enemies[i].name + i + " has died \n");
                    enemies[i].healthSystem.dead = false;
                }
            }
        }
    }
}
