using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{
    internal class GameEntity : GameObject
    {
        public char character;
        public HealthSystem healthSystem;
        public BuildMap buildMap;
        public Item potion1;
        public Item potion2;
        public bool attacked;
        public int potionHeal = 7;


        public void TakeDamage(int damage)
        {
            healthSystem.TakeDamage(damage);
            attacked = true;
        }

        public void Heal(int hp)
        {
            healthSystem.Heal(hp);
        }

        //public void CollectPotion(int posX,int posY)
        //{
        //    potion1.TryCollect(posX, posY);
        //    potion2.TryCollect(posX, posY);
        //    if (potion1.pickedUp)
        //        Heal(potionHeal);
        //    else if (potion2.pickedUp)
        //        Heal(potionHeal);
        //}
    }
}