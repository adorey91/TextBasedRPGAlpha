using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
