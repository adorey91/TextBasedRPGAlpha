using System;
using System.Diagnostics;

namespace RPGAlpha_AdrianDorey
{
    internal class Item : GameObject
    {
        public bool collected = false;  // used for the HUD - is set once and stays set.
        public bool pickedUp = false;   // used for the game log - is set true then goes false after that turn.
        public char character;
        public string name;


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