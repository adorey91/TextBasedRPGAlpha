using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGAlpha_AdrianDorey
{

    internal class Enemy : GameEntity
    {
        public Player Hero;
        public char character;
        public string name;
        public Traps[] trap;
        public MapPositions mapPositions;

        Random randomMovement = new();
        public int dx;
        public int dy;
        public int newDY;
        public int newDX;
        

        public void EnemyInit(Player Hero, BuildMap buildMap, Traps[] trap, MapPositions mapPositions)
        {
            this.Hero = Hero;
            this.buildMap = buildMap;
            this.trap = trap;
            this.mapPositions = mapPositions;
        }

        public int PlayerDistance() // calculates distance to player
        {
            return Math.Abs(pos.x - Hero.pos.x) + Math.Abs(pos.y - Hero.pos.y);
        }

        public void Move(int spaces)
        {
            int direction = randomMovement.Next(0, 4);
            dx = (direction == 2) ? spaces : (direction == 3) ? -spaces : 0;
            dy = (direction == 0) ? spaces : (direction == 1) ? -spaces : 0;

            newDX = pos.x + dx;
            newDY = pos.y + dy;
        }



    }
}
