using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace RPGAlpha_AdrianDorey
{
    internal class Program
    {
        static GameManager gameManager = new();

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);
            Console.CursorVisible = false;
            gameManager.Gameplay();
        }
    }
}
