using System;

namespace RPGAlpha_AdrianDorey
{ 
    internal class Enemy : GameEntity
    {
        public Player Hero;
        public char character;
        public string name;
        public Traps[] trap;
        public MapPositions mapPositions;
        
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
    }
}
