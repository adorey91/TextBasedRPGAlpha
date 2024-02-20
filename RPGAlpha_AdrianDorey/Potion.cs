using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class Potion : Item
    {
         public int potionHeal = 8;
        public HealthSystem healthSystem;

        public Potion()
        {
            character = 'δ';
            name = "Potion";
        }

        public void PotionCollect(int heal = 7)
        {
            healthSystem.Heal(heal);

        }
    }
}
