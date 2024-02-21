using System;

namespace RPGAlpha_AdrianDorey
{
    internal class Program
    {
        static GameManager gameManager = new();

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.CursorVisible = false;
            gameManager.Gameplay();
        }
    }
}
