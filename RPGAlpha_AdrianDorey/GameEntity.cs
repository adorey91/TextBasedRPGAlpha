using System;

namespace RPGAlpha_AdrianDorey
{
    internal class GameEntity : GameObject
    {
        public HealthSystem healthSystem;
        public BuildMap buildMap;

        public void CheckForTraps(Traps[] trap, int startIndex, int endIndex, int newX, int newY)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                trap[i].TryCollect(newX, newY);
                if (trap[i].pickedUp)
                {
                    healthSystem.TrapDamage(trap[i].trapAmount);
                    trap[i].pickedUp = false;
                }
            }
        }

        public void CheckFloor(int newX, int newY)
        {
            if (buildMap.CheckPoisonFloor(newX, newY))
                healthSystem.FloorDamage();
        }
    }
}