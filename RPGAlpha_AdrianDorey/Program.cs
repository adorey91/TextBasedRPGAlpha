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
        static GameManager gameManager;

        static void Main(string[] args)
        {
            gameManager = new GameManager();

            gameManager.Gameplay();
        }
    }
}
