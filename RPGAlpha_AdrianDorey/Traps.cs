using System;

namespace RPGAlpha_AdrianDorey
{
    internal class Traps : Item
    {
        public int trapAmount = 4;

        public Traps()
        {
            character = 'T';
            name = "Trap";
        }
    }
}
