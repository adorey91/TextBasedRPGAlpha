using System;
using System.Diagnostics;

namespace RPGAlpha_AdrianDorey
{
    internal class Item : GameObject
    {
        public bool collected;  // used for the HUD
        public bool pickedUp;   // used for the game log
        public char moneyChar = '$';
        public char potionChar = 'δ';
        public char trapChar = 'T';

        public int potionHeal = 8;

        public Item() 
        {
            collected = false;
            pickedUp = false;
        }

        public void TryCollect(int posX, int posY)
        {
            if (pos.y == posY && pos.x == posX && !collected)
            {
                collected = true;
                pickedUp = true;
            }
        }
    }
}