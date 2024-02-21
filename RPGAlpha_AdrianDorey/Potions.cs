using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class Potions : Item
    {
        public int potionHeal = 20;

        public Potions()
        {
            character = 'δ';
            name = "Potion";
        }
    }
}
