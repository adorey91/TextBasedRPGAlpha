using System;

namespace RPGAlpha_AdrianDorey
{
    internal class Enemy : GameEntity
    {
        public Player Hero;
        public char character;
        public string name;
        public GameLog log;
        public Traps[] trap;
        Random randomMovement = new();

        public int dx;
        public int dy;
        public int newDX;
        public int newDY;

        public void EnemyInit(Player Hero, BuildMap buildMap, Traps[] trap, GameLog log)
        {
            this.Hero = Hero;
            this.buildMap = buildMap;
            this.trap = trap;
            this.log = log;
        }

        public int PlayerDistance() // calculates distance to player
        {
            return Math.Abs(pos.x - Hero.pos.x) + Math.Abs(pos.y - Hero.pos.y);
        }

        public bool CheckValidPlacement(int x, int y, int levelNumber)
        {
            return buildMap.CheckBoundaries(x, y, levelNumber) && buildMap.CheckMapForEmptySpace(x, y, levelNumber) &&
                buildMap.GetMapContent(levelNumber)[y, x] != '*';
        }
    }
}

