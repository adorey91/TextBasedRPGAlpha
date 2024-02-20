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
        public MeleeEnemy[] Slimes;
        public Money[] Money;
        public Potion[] potion;
        public Traps[] trap;


        public void Init(Player Hero, RangedEnemy[] Rangers, MageEnemy[] Mages, MeleeEnemy[] Slimes, Money[] money, Potion[] potion, Traps[] trap)
        {
            this.Hero = Hero;
            this.Rangers = Rangers;
            this.Mages = Mages;
            this.Slimes = Slimes;
            this.potion = potion;
            this.Money = money;
            this.trap = trap;
        }

        public void PrintGameLog()
        {
            Console.WriteLine();
            Console.WriteLine("Game Log:");
           // LogAttackText();
            LogFloorTrapText();
            LogPickUpText();
            LogHealingText();
            LogEnemyDeathText();
            Console.WriteLine();
        }

        //private void LogAttackText()
        //{
        //    if (Badman1.healthSystem.attackedByEnemy)
        //    {
        //        Console.WriteLine("Player attacked Badman1");
        //        Badman1.healthSystem.attackedByEnemy = false;
        //    }
        //    if (Badman2.healthSystem.attackedByEnemy)
        //    {
        //        Console.WriteLine("Player attacked Badman2");
        //        Badman2.healthSystem.attackedByEnemy = false;
        //    }
        //    if (Hero.healthSystem.attackedByEnemy)
        //    {
        //        Console.WriteLine("Enemy attacked player");
        //        Hero.healthSystem.attackedByEnemy = false;
        //    }
        //}

        private void LogFloorTrapText()
        {
            if (Hero.healthSystem.trapDamage)
            {
                Console.WriteLine("Player damaged by a trap");
                //trap.collected = true;
                Hero.healthSystem.trapDamage = false;
            }
            //if (Enemy.healthSystem.floorDamage) // need to fix this
            //{
            //    Console.WriteLine("Enemy damaged by poison spill");
            //    Enemy.healthSystem.floorDamage = false;
            //    Enemy.healthSystem.floorDamage = false;
            //}
        }

        private void LogPickUpText()
        {
            foreach(Money money in Money)
            {
                if (money.pickedUp)
                {
                    Console.WriteLine("Player picked up money");
                    money.pickedUp = false;
                }

            }
        }

        private void LogHealingText()
        {
            foreach(Potion potion in potion)
            {
                if(potion.pickedUp)
                {
                    if (Hero.healthSystem.health < 100)
                        Console.Write("Player picked up potion");
                    else if (Hero.healthSystem.health >= 100)
                        Console.Write("Player cannot heal anymore");
                }
                Console.WriteLine();
                potion.pickedUp = false;
            }
        }

        private void LogEnemyDeathText()
        {
            //if (Badman1.healthSystem.dead && badman1)
            //{
            //    Console.WriteLine("Badman1 died");
            //    badman1 = false;
            //}
            //else if (Badman2.healthSystem.dead && badman2)
            //{
            //    Console.WriteLine("Badman2 died");
            //    badman2 = false;
            //}
        }
    }
}
